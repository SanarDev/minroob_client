using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dooz
{
    public abstract class BaseWindow : Window
    {
        protected bool StopAppAfterClose = true;
        public BaseWindow()
        {
            this.Closed += (s, e) => {
                if (StopAppAfterClose)
                {
                    Application.Current.Shutdown();
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    OnClosedCalled();
                }
            };
        }

        public virtual void OnClosedCalled()
        {

        }
    }
}
