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



/* Delete this 
// SAVE - database / only for db testing purpose 
public void SaveDummyCLassToFile()
{
    List<Documents> dummyDocs = new List<Documents>();
    dummyDocs = dummyClass();

    SaveDatabase(dummyDocs);
}
*/


/* Delete this ! 
// Dummy objects for db test purpose
private List<Documents> dummyClass()
{
    List<Documents> dummyDocLists = new List<Documents>();

    Documents docs1 = new Documents();
    Documents docs2 = new Documents();

    docs1.ProductID = "150L0065";
    docs2.ProductID = "150L0071";

    Document d1 = new Document { DocumentName = "Instrukcja1" };
    Document d2 = new Document { DocumentName = "Instrukcja2" };
    Document d3 = new Document { DocumentName = "Instrukcja3" };
    Document d4 = new Document { DocumentName = "Instrukcja4" };

    docs1.DocumentsList.Add(d1);
    docs1.DocumentsList.Add(d2);

    docs2.DocumentsList.Add(d3);
    docs2.DocumentsList.Add(d4);

    dummyDocLists.Add(docs1);
    dummyDocLists.Add(docs2);

    return dummyDocLists;
}
*/