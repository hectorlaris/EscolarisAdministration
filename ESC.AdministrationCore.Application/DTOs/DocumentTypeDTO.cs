using System;
using System.Collections.Generic;
using System.Text;

namespace ESC.AdministrationCore.Application.DTOs
{
    public class DocumentTypeDTO
    {
        public Guid Id { get; set; }

        public required string Code { get; set; }

        public required string Description { get; set; }

        public short? IdDocumentType { get; set; }

    }
}
