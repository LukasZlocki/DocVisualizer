using DocVisualizer.Models.Models;
using DocVisualizer.Services.Db_Service;

namespace DocVisualizer.Services.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly DbEngine db = new DbEngine();

        public Documents GetAllDocumentsByProductId(string productId)
        {
            Documents documents = new Documents();

            documents = db.ReadDocumentsFromDatabaseByProductId(productId);
            // ToDo : code retriving service from database (XML file)
            // ...

            return documents;
        }

        /*
        // for db test purpose 
        public void SaveDb()
        {
            db.SaveDummyCLassToFile();
        }
        */

    }
}