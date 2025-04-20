using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Status
{
    public class UpdateStatusForm
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string StatusName { get; set; } = null!;
    }
}
