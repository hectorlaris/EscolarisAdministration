using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ESC.AdministrationCore.Entities.DbSet
{

    [Index("DocumentNumber", Name = "DocumentNumber")]
    [Index("LastName", Name = "LastName")]
    public class Citizen
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(12)]
        public string? DocumentNumber { get; set; }
        public string? MyDocumentType { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El campo {0} no debe exceder de {1} caracteres.")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El campo {0} no debe exceder de {1} caracteres.")]
        public string? LastName { get; set; }

        [Column(TypeName = "image")]
        public byte[]? Picture { get; set; }

        [ForeignKey("DocumentType")]
        [DataMember(Name = "IdDocumentType")]
        public Guid? IdDocumentType { get; set; }

        public string? Address { get; set; }

        public string? Telephone { get; set; }

        public string? Email { get; set; }

        [ForeignKey("CitizenMaritalStatus")]
        [DataMember(Name = "IdMaritalStatus")]
        public Guid? IdMaritalStatus { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Profession { get; set; }

        public DateTime? ModifyDate { get; set; }

        //relationships
        public required DocumentType DocumentType { get; set; }
     //   public required CitizenMaritalStatus CitizenMaritalStatus { get; set; }

    }
}