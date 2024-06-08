using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ESC.AdministrationCore.Application.DTOs
{
    public class DocumentTypeCreateDTO
    {

        public required string Code { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "El campo {0} no debe exceder de {1} caracteres.")]
        public required string Description { get; set; }
        public short? IdDocumentType { get; set; }

    }
}
