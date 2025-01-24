﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("Doctor")]
    [PrimaryKey("Id")]
    public class Doctor
    {
        [Column("Id")]        
        
        public int Id { get; set; }
        [Column("FullName")]
        public string FullName { get; set; }

    }
}
