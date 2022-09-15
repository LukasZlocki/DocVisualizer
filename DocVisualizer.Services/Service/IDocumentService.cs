using DocVisualizer.Models.Models;

namespace DocVisualizer.Services.Service
{
    internal interface IDocumentService
    {
        public Documents GetAllDocumentsByProductId(string productId);

        // for db test purpose
        // public void SaveDb();
    }
}
