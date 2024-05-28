using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

ESC.AdminitrationCore.Entities.DbSet
{
    public class Municipality
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [ForeignKey("Department")]
        [DataMember(Name = "IdDepartment")]
        public Guid? IdDepartment { get; set; }

        [DataMember(Name = "Code")]
        public string Code { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "CodeDepaMuni")]
        public string CodeDepaMuni { get; set; }

        [DataMember(Name = "DivipoRUNT")]
        public string DivipoRUNT { get; set; }


        //relationships
        public virtual Department Department { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}