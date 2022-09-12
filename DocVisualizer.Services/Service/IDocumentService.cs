using DocVisualizer.Models.Models;

namespace DocVisualizer.Services.Service
{
    internal interface IDocumentService
    {
        public List<Document> GetAllDocumentsByProduct(string product);
    }
}
