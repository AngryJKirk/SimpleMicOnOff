using System;
using System.Diagnostics;
using System.Windows.Forms;
using SimpleMicOnOff.Properties;

namespace SimpleMicOnOff
{
    class ContextMenus
    {
        public bool isMicDisabled;
        private NotifyIcon notifyIcon;
        private string SOUND_VOLUME_VIEW_PATH = Resources.SOUND_VOLUME_VIEW_PATH;
        private string SOUND_VOLUME_VIEW_MUTE_COMMAND = Resources.SOUND_VOLUME_VIEW_MUTE_COMMAND;
        private string SOUND_VOLUME_VIEW_UNMUTE_COMMAND = Resources.SOUND_VOLUME_VIEW_UNMUTE_COMMAND;

        public ContextMenus(NotifyIcon notifyIcon)
        {
            this.notifyIcon = notifyIcon;
            Process proc = new Process();
            proc.StartInfo.FileName = SOUND_VOLUME_VIEW_PATH;
            proc.StartInfo.Arguments = SOUND_VOLUME_VIEW_MUTE_COMMAND;
            proc.Start();
            proc.WaitForExit();
            isMicDisabled = true;
        }
        public ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;

            item = new ToolStripMenuItem();
            item.Text = "Mic Toggle";
            item.Click += new EventHandler(Mic_Toogle_Click);
            item.Image = Resources.mic;
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            item.Image = Resources.Exit;
            menu.Items.Add(item);

            return menu;
        }

        public void Mic_Toogle_Click(object sender, EventArgs e)
        {
            string command;
            System.IO.Stream sound;
            if (isMicDisabled)
            {
                command = SOUND_VOLUME_VIEW_UNMUTE_COMMAND;
                isMicDisabled = false;
                notifyIcon.Icon = Resources.GREEN;
                sound = Resources.on;
            }
            else
            {
                command = SOUND_VOLUME_VIEW_MUTE_COMMAND;
                isMicDisabled = true;
                notifyIcon.Icon = Resources.RED;
                sound = Resources.off;
            }

            Process proc = new Process();
            proc.StartInfo.FileName = SOUND_VOLUME_VIEW_PATH;
            proc.StartInfo.Arguments = command;
            proc.Start();
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(sound);
            snd.Play();
        }

        void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}