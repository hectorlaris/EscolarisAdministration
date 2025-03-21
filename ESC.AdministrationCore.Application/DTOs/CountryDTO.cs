﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace ESC.AdministrationCore.Application.DTOs
{
    public class CountryDTO
    {
        public Guid Id { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }
    }
}