using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lite_Berry_Pi.Data;
using Lite_Berry_Pi.Models.Api;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;

namespace Lite_Berry_Pi.Models.Interfaces.Services
{
    public class DesignRepository : IDesign
    {
        private LiteBerryDbContext _context;

        public DesignRepository(LiteBerryDbContext context)
        {
            _context = context;
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
            _context.Entry(design).State =  Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return design;
        }

        public async Task GetDesignToSend(int id)
        {
            var design = await GetDesign(id);

            if (design == null)
            {
                throw new ArgumentNullException("The design is empty");
            }

            string designCoords = design.DesignCoords;

            var url = "https://localhost:44371/raspberrypi";

            HubConnection connection = new HubConnectionBuilder()
              .WithUrl(url)
              .WithAutomaticReconnect()
              .Build();

            var t = connection.StartAsync();
            t.Wait();

            // send a message to the hub
            await connection.InvokeAsync("SendLiteBerry", designCoords);

        }
    }
}
