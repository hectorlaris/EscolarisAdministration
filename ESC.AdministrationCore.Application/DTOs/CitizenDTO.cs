using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EESC.AdministrationCore.Application.DTOs
{

    public class CitizenDTO
    {

        public string? DocumentNumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Guid? IdDocumentType { get; set; }

        public string? Address { get; set; }

        public string? Telephone { get; set; }

        public string? Email { get; set; }

        public Guid? IdMaritalStatus { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Profession { get; set; }

        public DateTime? ModifyDate { get; set; }

    }
}