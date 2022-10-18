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
        private Documents Documents;

        public MainWindow()
        {
            InitializeComponent();
        }


        #region Buttons

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MoveBackward();
            ShowDocumentsOnScreen(Documents, Navigation);

        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MoveForward();
            ShowDocumentsOnScreen(Documents, Navigation);
        }

        private void btnLanguage_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Return)
            {
                MainDocumentsAction(ref Documents, ref Navigation);
            }
        }

        private void SettingsWindowRun(object sender, RoutedEventArgs e)
        {

        }


        // Gets document from user, load documents from database, show documents on screeen, set up document counter on frontend
        private void MainDocumentsAction(ref Documents documents, ref NavigationService navigation)
        {
            documents = new Documents();        
            string partNumber = txtBoxID.Text;
            documents = LoadDocumentsFomDatabase(partNumber);
            
            // Set up navigation 
            navigation = new NavigationService(documents);
            ShowDocumentsOnScreen(documents, navigation);
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
            // ToDo : Code to show proper document from navigation class - test it on code and couple files dedicated for the code
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
