using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESC.AdministrationCore.Application.DTOs
{
    public class DocumentTypeDTO
    {
        public required string Code { get; set; }
        public required string Description { get; set; }
        public short? IdDocumentType { get; set; }
    }
}
