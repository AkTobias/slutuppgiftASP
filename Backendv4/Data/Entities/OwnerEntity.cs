using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OwnerEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string FullName { get; set; } = null!;

        public int ClientId { get; set; }
        public ClientEntity Client { get; set; } = null!;

        public ICollection<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
