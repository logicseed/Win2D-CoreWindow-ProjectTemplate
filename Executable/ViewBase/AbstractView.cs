// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using Microsoft.Graphics.Canvas;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Core;

namespace TemplateDefaultNamespace
{
    internal abstract class AbstractView : IFrameworkView
    {
        protected CanvasDevice _canvasDevice;
        protected CanvasSwapChain _canvasSwapChain;
        protected CoreWindow _coreWindow;

        protected abstract Color _clearColor { get; }

        private void CoreApplication_Suspending(object sender, SuspendingEventArgs eventArgs)
        {
            _canvasDevice?.Trim();
        }

        private void CoreApplicationView_Activated(CoreApplicationView sender, IActivatedEventArgs eventArgs)
        {
            CoreWindow.GetForCurrentThread().Activate();
        }

        public virtual void Initialize(CoreApplicationView coreApplicationView)
        {
            coreApplicationView.Activated += CoreApplicationView_Activated;
            CoreApplication.Suspending += CoreApplication_Suspending;
        }

        public virtual void Load(string entryPoint)
        {
        }

        public virtual void Run()
        {
            while (true)
            {
                CoreWindow.GetForCurrentThread()
                          .Dispatcher
                          .ProcessEvents(CoreProcessEventsOption.ProcessAllIfPresent);

                using (var drawingSession = _canvasSwapChain.CreateDrawingSession(_clearColor))
                {
                    MainLoop(drawingSession);
                }
                _canvasSwapChain.Present();
            }
        }

        public virtual void SetWindow(CoreWindow coreWindow)
        {
            _coreWindow = coreWindow;

            float currentDpi = DisplayInformation.GetForCurrentView().LogicalDpi;

            _canvasDevice = new CanvasDevice();
            _canvasSwapChain = CanvasSwapChain.CreateForCoreWindow(_canvasDevice, coreWindow, currentDpi);
        }

        public virtual void Uninitialize()
        {
        }

        public abstract void MainLoop(CanvasDrawingSession drawingSession);
    }
}
