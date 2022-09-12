using DocVisualizer.Models.Models;

namespace DocVisualizer.Services.Service
{
    internal interface IDocumentService
    {
        public Documents GetAllDocumentsByProduct(string product);
    }
}
