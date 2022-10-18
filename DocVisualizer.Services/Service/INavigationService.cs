namespace DocVisualizer.Services.Service
{
    internal interface INavigationService
    {
        public void MoveForward();
        public void MoveBackward();
        public string GetCounter();
        public string GetCodeNumber();
        public string GetPresentDocName();

    }
}
