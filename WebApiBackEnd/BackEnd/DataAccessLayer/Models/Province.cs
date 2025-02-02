﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Province")]
    public class Province
    {
        [Key]
        public string Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Type {  get; set; }
    }
}
