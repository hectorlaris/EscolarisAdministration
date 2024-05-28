using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ESC.AdminitrationCore.Entities.DbSet
{
    public class Department
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [DataMember(Name = "Code")]
        public string Code { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [ForeignKey("Country")]
        [DataMember(Name = "IdCountry")]
        public Guid? IdCountry { get; set; }


        //relationships
        public virtual Country Country { get; set; }
        public virtual ICollection<Municipality> Municipality { get; set; }
    }
}