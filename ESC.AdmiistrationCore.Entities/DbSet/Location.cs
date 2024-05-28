using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ESC.AdminitrationCore.Entities.DbSet
{
    public class Location
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [ForeignKey("Municipality")]
        [DataMember(Name = "IdMunicipality")]
        public Guid IdMunicipality { get; set; }

        [DataMember(Name = "Code")]
        public string Code { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }


        //relationships
        public virtual Municipality Municipality { get; set; }
    }
}