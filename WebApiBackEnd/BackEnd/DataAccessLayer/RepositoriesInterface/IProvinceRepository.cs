﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IProvinceRepository : IGenericRepository<Province>
    {
        Task<Province> GetProvinceById(string id);
    }
}
