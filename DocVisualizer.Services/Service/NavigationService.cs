using DocVisualizer.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocVisualizer.Services.Service
{
    public class NavigationService : INavigationService
    {
        private Documents _documents = new Documents();
        private int _docPagePossition;
        private int _docPages;

        public NavigationService(Documents documents)
        {
            _documents = documents;
            _docPages = documents.DocumentsList.Count;
            _docPagePossition = 0;
        }

        public void MoveBackward()
        {
            this._docPagePossition--;
        }

        public void MoveForward()
        {
            this._docPagePossition++;
        }

        public string GetCodeNumber()
        {
            return _documents.ProductID;
        }

        public string GetCounter()
        {
            string _counter = "" + _docPagePossition + " / " + _docPages;
            return _counter;
        }

        public string GetPresentDocName()
        {
            Document _doc = _documents.DocumentsList[_docPagePossition];
            string _docName = _doc.DocumentName;
            return _docName;
        }
    }
}
