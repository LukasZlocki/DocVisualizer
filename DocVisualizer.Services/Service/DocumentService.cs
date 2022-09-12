using DocVisualizer.Models.Models;

namespace DocVisualizer.Services.Service
{
    public class DocumentService : IDocumentService
    {
        public Documents GetAllDocumentsByProduct(string product)
        {
            Documents documents = new Documents();

            // ToDo : code retriving service from database (XML file)
            // ...

            return documents;
        }
    }
}
