using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsUTCControl
{
    /// <summary>
    /// UTC controller interface
    /// </summary>
    public interface IUTCController
    {
        bool IsEnabled { get; set; }

        void Enable();

        void Disable();
    }
}
