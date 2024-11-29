using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;
        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }

        public List<DocumentTypeResponse> getAllDocumentType()
        {
            var ListDocumentTypes = (from doc in _context.DocumentTypes
                                    select new DocumentTypeResponse
                                    {
                                        DocumentTypeDescription = doc.DocumentTypeDescription,
                                        DocumentTypeId = doc.DocumentTypeId,
                                    }).ToList();
            return ListDocumentTypes;
            
        }
    }
}
