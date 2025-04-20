using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Client
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = null!;
    }
}
