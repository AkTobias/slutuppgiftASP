using Business.Dtos.Status;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Status
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusModel>> GetAllStatus();
        Task<StatusModel?> AddAsync(AddStatusForm form);
        Task<StatusModel?> UpdateAsync(UpdateStatusForm form);

        
    }
}
