using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL
{
    public class ServicesContext : DbContext
    {
        public ServicesContext(DbContextOptions<ServicesContext> options) : base(options)
        {

        }
    }
}
