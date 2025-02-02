﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StoreId {  get; set; }
        public string Description {  get; set; }
    }
}
