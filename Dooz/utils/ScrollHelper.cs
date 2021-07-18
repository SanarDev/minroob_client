using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dooz.utils
{
    class ScrollHelper
    {

        public static ScrollViewer FindScrollViewer(DependencyObject d)
        {
            if (d is ScrollViewer)
                return d as ScrollViewer;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
            {
                var sw = FindScrollViewer(VisualTreeHelper.GetChild(d, i));
                if (sw != null) return sw;
            }
            return null;
        }

        public static void AutoScrollToEnd(DependencyObject d, int MessagesSize)
        {
            var Scroll = FindScrollViewer(d);
            if (Scroll.VerticalOffset + Scroll.ViewportHeight >= MessagesSize)
            {
                Scroll.ScrollToVerticalOffset(MessagesSize);
            }
        }

        public static void ScrollToEnd(DependencyObject d, int MessagesSize)
        {
            var Scroll = FindScrollViewer(d);
            Scroll.ScrollToVerticalOffset(MessagesSize);
        }
        public static void ScrollToPosition(DependencyObject d, int Position)
        {
            var Scroll = FindScrollViewer(d);
            Scroll.ScrollToVerticalOffset(Position);
        }
    }
}
