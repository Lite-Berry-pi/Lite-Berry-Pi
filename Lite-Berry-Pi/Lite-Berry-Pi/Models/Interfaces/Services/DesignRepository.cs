using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lite_Berry_Pi.Data;
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

        public async Task<Design> CreateDesign(Design Design)
        {
            _context.Entry(Design).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return Design;
        }

        public async Task DeleteDesign(int id)
        {

            Design design = await GetDesign(id);
            _context.Entry(design).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Design>> GetAllDesigns()
        {
            return await _context.Design
                .Include(d => d.UserDesign)
                .ThenInclude(u => u.User)
                .ThenInclude(us => us.Name)
                .ToListAsync();
        }

        public async Task<Design> GetDesign(int id)
        {
            return await _context.Design
                .Include(d => d.UserDesign)
                .ThenInclude(u => u.User)
                .ThenInclude(us => us.Name)
                .FirstOrDefaultAsync(e => e.Id == id);
            
        }

        public async Task<Design> UpdateDesign(int id, Design design)
        {
            _context.Entry(design).State =  Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return design;
        }
    }
}
