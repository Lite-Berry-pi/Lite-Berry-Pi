using Lite_Berry_Pi.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces
{
    public interface IDesign
    {
        Task<Design> CreateDesign(DesignDto incomingData);
        Task<DesignDto> GetDesign(int id);
        Task <List<DesignDto>> GetAllDesigns();
        Task<Design> UpdateDesign(int id, DesignDto incomingData);
        Task DeleteDesign(int id);
    }
}
