using Windows.ApplicationModel.Core;

namespace TemplateDefaultNamespace
{
    internal class App
    {
        private static void Main(string[] args)
        {
            CoreApplication.Run(new ViewFactory<View1>());
        }
    }
}
