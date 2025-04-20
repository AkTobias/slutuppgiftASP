using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ClientEntity
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; } = null!;
        public ICollection<OwnerEntity> Owners { get; set; } = new List<OwnerEntity>();
        public ICollection<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
