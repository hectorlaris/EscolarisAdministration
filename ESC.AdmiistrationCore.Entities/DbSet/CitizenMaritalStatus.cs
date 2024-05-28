using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ESC.AdminitrationCore.Entities.DbSet
{
    public class CitizenMaritalStatus
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [DataMember(Name = "Name")]
        public required string Name { get; set; }

        //relationships
        public required ICollection<Citizen> Citizens { get; set; }
    }
}