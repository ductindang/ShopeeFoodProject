﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.DTOs
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public string Description { get; set; }
    }
}
