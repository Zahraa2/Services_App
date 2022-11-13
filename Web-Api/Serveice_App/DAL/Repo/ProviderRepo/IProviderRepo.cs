﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public interface IProviderRepo:IGenericRepo<Provider>
{
    public List<Provider> GetProvidersByService(string Name);
}
