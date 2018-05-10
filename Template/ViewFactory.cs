// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using Windows.ApplicationModel.Core;

namespace $safeprojectname$
{
    internal class ViewFactory<T> : IFrameworkViewSource where T : IFrameworkView, new()
    {
        public IFrameworkView CreateView() => new T();
    }
}
