
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ESC.AdminitrationCore.Entities.DbSet
{
    public class Country
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [DataMember(Name = "Code")]
        public string Code { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }


        //relationships
        public virtual ICollection<Department> Department { get; set; }
    }
}