using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces
{
    public interface IDesign
    {
        Task<Design> CreateDesign(Design Design);
        Task<Design> GetDesign(int id);
        Task <List<Design>> GetAllDesigns();
        Task<Design> UpdateDesign(int id, Design Design);
        Task DeleteDesign(int id);
    }
}
