using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MediasforPost
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<string> Imgs { get; set; }
    }
}
