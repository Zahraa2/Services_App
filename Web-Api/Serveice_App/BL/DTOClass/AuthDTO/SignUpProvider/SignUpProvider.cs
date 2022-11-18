using BL.DTO.AuthDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SignUpProvider : SignUpBasicProperties
    {
        public Guid ServiceId { get; set; }
        public string sammary { get; set; }

    }
}
