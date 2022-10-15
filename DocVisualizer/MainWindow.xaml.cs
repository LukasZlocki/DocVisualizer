﻿using System.Windows;
using DocVisualizer.Models.Models;
using DocVisualizer.Services.Service;

namespace DocVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            Documents documents = new Documents();        
            string partNumber = txtBoxID.Text;
            documents = LoadDocumentsFomDatabase(partNumber);
            ShowDocumentsOnScreen(documents);
        }

        private Documents LoadDocumentsFomDatabase(string partNumber)
        {
            Documents docs = new Documents();
            DocumentService documentService = new DocumentService();
            docs = documentService.GetAllDocumentsByProductId(partNumber);
            return docs;
        }

        private void ShowDocumentsOnScreen(Documents documents)
        {
            // ToDo: Code showing documents on screen
        }

        
    }
}
