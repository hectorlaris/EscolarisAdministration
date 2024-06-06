
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ESC.AdministrationCore.Entities.DbSet
{
    public class Country
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        [DataMember(Name = "Code")]
        public string? Code { get; set; }


        [Required]
        [StringLength(20)]
        [DataMember(Name = "Name")]
        public string? Name { get; set; }



        //relationships
        //public virtual ICollection<Department> Departments { get; set; }
    }
}