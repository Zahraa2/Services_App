﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class PostReadDTO
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public Guid? PostId { get; set; }
    public List<MediaReadDTO>? Medias { get; set; }
}
