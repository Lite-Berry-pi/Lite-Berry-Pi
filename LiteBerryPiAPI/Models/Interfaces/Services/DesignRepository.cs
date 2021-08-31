using Lite_Berry_Pi.Data;
using Lite_Berry_Pi.Models.Api;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces.Services
{
  public class DesignRepository : IDesign
  {
    private LiteBerryDbContext _context;
    private HubConnection _serverHub;
    private string _url;
    public DesignRepository(LiteBerryDbContext context)
    {
      _url = "https://liteberrypisignalrserver.azurewebsites.net/raspi";
      _context = context;
      _serverHub = new HubConnectionBuilder()
              .WithUrl(_url)
              .WithAutomaticReconnect()
              .Build();
    }

    public async Task<Design> CreateDesign(DesignDto incomingData)
    {
      Design design = new Design
      {
        Id = incomingData.Id,
        Title = incomingData.Title,
        DesignCoords = incomingData.DesignCoords,
        TimeStamp = DateTime.Now
      };

      _context.Entry(design).State = Microsoft.EntityFrameworkCore.EntityState.Added;
      await _context.SaveChangesAsync();
      return design;
    }

    public async Task DeleteDesign(int id)
    {
      DesignDto designdto = await GetDesign(id);
      Design design = await _context.Design.FirstOrDefaultAsync(d => d.Id == designdto.Id);
      _context.Entry(design).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<List<DesignDto>> GetAllDesigns()
    {
      var designs = await _context.Design
           .Select(design => new DesignDto
           {
             Id = design.Id,
             Title = design.Title,
             DesignCoords = design.DesignCoords
           })
           .ToListAsync();
      return designs;
    }

    public async Task<DesignDto> GetDesign(int id)
    {
      return await _context.Design
          .Where(design => design.Id == id)
          .Select(design => new DesignDto
          {
            Id = id,
            Title = design.Title,
            DesignCoords = design.DesignCoords
          })
          //TODO: Do we want to get the name of the user who created the design here?
          .FirstOrDefaultAsync();

    }

    public async Task<Design> UpdateDesign(int id, DesignDto incomingData)
    {
      Design design = await _context.Design.FirstOrDefaultAsync(x => x.Id == id);
      design.Title = incomingData.Title;
      design.DesignCoords = incomingData.DesignCoords;
      _context.Entry(design).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return design;
    }

    public async Task GetDesignToSend(int id)
    {
      var design = await GetDesign(id);

      if (design == null) design = await GetDesign(2);
      string designCoords = design.DesignCoords;
      var t = _serverHub.StartAsync();
      t.Wait();
      // send a message to the hub
      await _serverHub.InvokeAsync("SendLiteBerry", designCoords);
      await _serverHub.StopAsync();      
    }
    public async Task TestConnection()
    {
      

      var t = _serverHub.StartAsync();
      t.Wait();
      Debug.WriteLine($"TestConnection Status: {t.Status}");
      // send a message to the hub
      await _serverHub.InvokeAsync("TestConnection", "TestFromClient");

      await _serverHub.StopAsync();
      //close the connection
      t.Dispose();
    }
    public async Task DisplayStandardDesign (string key)
    {      
      var t =_serverHub.StartAsync();
      t.Wait();
      Debug.WriteLine("DisplayStandardDesign Connection: " + t.Status);
      await _serverHub.InvokeAsync("DisplayStandardDesign", key);
      await _serverHub.StopAsync();
    }
  }
}
