
using System;
using System.Windows.Forms;
using SimpleMicOnOff.Properties;

namespace SimpleMicOnOff
{

    class ProcessIcon : IDisposable
    {

        NotifyIcon ni;
        int hotkeyId = 0;

        public ProcessIcon()
        {
            ni = new NotifyIcon();
        }

        public void Display()
        {
            ni.Icon = Resources.RED;
            ni.Text = "Mic Toggle";
            ni.Visible = true;

            var contextMenus = new ContextMenus(ni);
            ni.ContextMenuStrip = contextMenus.Create();
            hotkeyId = HotKeyManager.RegisterHotKey(Keys.Oemtilde, KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(contextMenus.Mic_Toogle_Click);
        }

        public void Dispose()
        {
            ni.Dispose();
            if (hotkeyId != 0)
            {
                HotKeyManager.UnregisterHotKey(hotkeyId);
            }
        }


    }
}