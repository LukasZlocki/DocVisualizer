using System.Windows;
using DocVisualizer.Models.Models;
using DocVisualizer.Services.Service;

namespace DocVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Documents docs = new Documents();

        public MainWindow()
        {
            InitializeComponent();

           // DbTests_SaveDataFromDb();

           docs = DbTest_LoadDataFromDb();
        }

        // Loading list of documents from database
        Documents DbTest_LoadDataFromDb()
        {
            Documents _docs = new Documents();
            DocumentService service = new DocumentService();

            _docs = service.GetAllDocumentsByProductId("150L0065");

            return _docs;
        }

        /*
        void DbTests_SaveDataFromDb()
        {
            DocumentService docService = new DocumentService();
            docService.SaveDb();
        }
        */


    }
}
