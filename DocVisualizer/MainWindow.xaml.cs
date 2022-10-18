using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DocVisualizer.Models.Models;
using DocVisualizer.Services.Service;

namespace DocVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigationService Navigation;

        public MainWindow()
        {
            InitializeComponent();
        }

       
        #region Buttons
        private void btnLanguage_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Return)
            {
                MainLoop();
            }
        }

        private void SettingsWindowRun(object sender, RoutedEventArgs e)
        {

        }


        // Gets document from user, load documents from database, show documents on screeen, set up document counter on frontend
        private void MainLoop()
        {
            // ToDo: Show set of documents , and make it available to switch between docs up/down and show it on document counter

            Documents documents = new Documents();        
            string partNumber = txtBoxID.Text;
            documents = LoadDocumentsFomDatabase(partNumber);
            Navigation = new NavigationService(documents);
            ShowDocumentsOnScreen(documents, Navigation);
        }

        private Documents LoadDocumentsFomDatabase(string partNumber)
        {
            Documents docs = new Documents();
            DocumentService documentService = new DocumentService();
            docs = documentService.GetAllDocumentsByProductId(partNumber);
            return docs;
        }

        private void ShowDocumentsOnScreen(Documents documents, NavigationService navigation)
        {
            // ToDo : Code to show proper document from navigation class
            string fullPAth = @"C:\0 VirtualServer\Documents\BrakDokumentu.jpg";
            ImageSource imageSource = new BitmapImage(new System.Uri(fullPAth));
            ImageShow.Source = imageSource;

            UpdateDocumentCounterOnScreen(navigation);
        }

        private void UpdateDocumentCounterOnScreen(NavigationService navigation)
        {
            lblCounter.Content = "" + navigation.GetCounter();
        }
        
    }
}
