using DocVisualizer.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocVisualizer.Services.Service
{
    public class DocumentService : IDocumentService
    {
        public List<Document> GetAllDocumentsByProduct(string product)
        {
            List<Document> documents = new List<Document>();

            // ToDo : code retriving service from database (XML file)
            // ...

            return documents;
        }
    }
}
