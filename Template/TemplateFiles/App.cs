using Windows.ApplicationModel.Core;

namespace $safeprojectname$
{
    internal class App
    {
        private static void Main(string[] args)
        {
            CoreApplication.Run(new ViewFactory<View1>());
        }
    }
}
