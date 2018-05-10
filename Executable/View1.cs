using Microsoft.Graphics.Canvas;
using Windows.UI;

namespace TemplateDefaultNamespace
{
    internal class View1 : AbstractView
    {
        protected override Color _clearColor => Colors.Black;

        public override void MainLoop(CanvasDrawingSession drawingSession)
        {
            drawingSession.DrawText("Hello world!", 0.0f, 0.0f, Colors.White);
        }
    }
}
