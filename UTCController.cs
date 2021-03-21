using Microsoft.Win32;
using System;

namespace WindowsUTCControl
{
    /// <summary>
    /// UTC Controller for Windows
    /// </summary>
    public sealed class UTCController : IUTCController
    {
        public bool IsEnabled
        {
            get
            {
                using var key = Registry.LocalMachine.OpenSubKey(ControllerConfig.ADDRESS, false);
                if (key == null)
                {
                    throw new NotSupportedException("Failed to get registry key.");
                }

                var rawValue = key.GetValue(ControllerConfig.KEY_ENTRY);

                return (rawValue != null) && (int)rawValue != 0;
            }

            set
            {
                uint newVal = (uint)(value ? 1 : 0);

                using var key = Registry.LocalMachine.OpenSubKey(ControllerConfig.ADDRESS, true);
                if (key == null)
                {
                    throw new NotSupportedException("Failed to get registry key.");
                }

                key.SetValue(ControllerConfig.KEY_ENTRY, newVal, RegistryValueKind.DWord);
            }
        }

        private static class ControllerConfig
        {
            public const string KEY_ENTRY = "RealTimeIsUniversal";
            public static readonly RegistryValueKind TYPE = RegistryValueKind.DWord;

            public const string ADDRESS = @"SYSTEM\CurrentControlSet\Control\TimeZoneInformation";
            public static readonly string FULL_ADDRESS = @$"Computer\HKEY_LOCAL_MACHINE\{ADDRESS}";
        }

        public UTCController()
        {
        }

        public void Disable() => IsEnabled = false;

        public void Enable() => IsEnabled = true;
    }
}
