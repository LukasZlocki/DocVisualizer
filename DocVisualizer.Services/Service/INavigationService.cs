using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocVisualizer.Services.Service
{
    internal interface INavigationService
    {
        public void MoveForward();
        public void MoveBackward();
        public string ShowCounter();
        public string ShowCodeNumber();

    }
}
