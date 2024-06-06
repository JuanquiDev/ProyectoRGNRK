﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RGNRK.Data
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}