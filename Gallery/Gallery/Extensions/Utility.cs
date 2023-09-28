using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gallery.Extensions
{
    internal static class Utility
    {
        internal static async void Shake(View element)
        {
            uint timeout = 50;

            await element.TranslateTo(-15, 0, timeout);

            await element.TranslateTo(15, 0, timeout);

            await element.TranslateTo(-10, 0, timeout);

            await element.TranslateTo(10, 0, timeout);

            await element.TranslateTo(-5, 0, timeout);

            await element.TranslateTo(5, 0, timeout);

            element.TranslationX = 0;

        }
    }
}
