using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class isPasswordCorrect
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
    }
}
