using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ESC.AdministrationCore.Entities.DbSet
{
    public class DocumentType
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [DataMember(Name = "Code")]
        public required string Code { get; set; }

        [DataMember(Name = "Description")]
        public required string Description { get; set; }

        [DataMember(Name = "IdDocumentType")]
        public short? IdDocumentType { get; set; }

        //relationships
  
        [InverseProperty("DocumentType")]
        public ICollection<Citizen> Citizens { get; set; } = new List<Citizen>();
    }
}
