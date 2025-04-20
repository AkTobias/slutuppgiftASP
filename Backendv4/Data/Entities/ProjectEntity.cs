using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProjectName { get; set; } = null!;

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Budget { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public StatusEntity Status { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public OwnerEntity  Owner { get; set; } = null!;
    }
}
