using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ESC.AdministrationCore.Entities.DbSet
{
    public class CitizenMaritalStatus
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [DataMember(Name = "Name")]
        public required string Name { get; set; }


        //relationships
        //[InverseProperty("MaritalStatus")]
        //public ICollection<Citizen> MaritalSatusCitizens { get; set; } = new List<Citizen>();
    }
}