using System.Xml.Serialization;
using DocVisualizer.Models.Models;

namespace DocVisualizer.Services.Db_Service
{
    public class DbEngine
    {
        static string DB_FILE_NAME = "dbfile.xml";
        
        // READ
        public Documents ReadDocumentsFromDatabaseByProductId(string ProductId)
        {
            List<Documents> documentsList = new List<Documents>();
            Documents? documents = new Documents();

            // Loading database
            documentsList = LoadDatabase();
            // Extracting data refering proper ProductId           
            documents = documentsList.Where(id => id.ProductID == ProductId).FirstOrDefault();

            return documents;
        }
        
        private List<Documents> LoadDatabase()
        {
            List<Documents> docsList = new List<Documents>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Documents>));
            try{
                TextReader tr = new StreamReader(DB_FILE_NAME);
                docsList = (List<Documents>)xmlSerializer.Deserialize(tr);
            }
            catch(Exception ex){
                Console.WriteLine("No data base found. Creating empty file with database. Error: " + ex);
            }
            if (docsList == null){
                docsList = new List<Documents>();
            }

            return docsList;
        }


        private void SaveDatabase(List<Documents> documentsList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Documents>));
            TextWriter tw = new StreamWriter(DB_FILE_NAME);
            xmlSerializer.Serialize(tw, documentsList);
            tw.Close();
        }


    }
}