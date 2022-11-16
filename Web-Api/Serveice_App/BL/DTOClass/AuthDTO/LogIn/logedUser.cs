using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class logedUser
    {
        public UserTypes Type { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }

    }
}
