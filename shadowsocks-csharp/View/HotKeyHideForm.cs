using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shadowsocks.View
{
    public partial class HotKeyHideForm : Form
    {
        public HotKeyHideForm()
        {
            InitializeComponent();
        }

        public event EventHandler<WndProceMessageEventArgs> WndProcMessageHandler;
        protected override void WndProc(ref Message m)
        {
            //窗口消息处理函数
            WndProcMessageHandler?.Invoke(this, new WndProceMessageEventArgs(m));
            base.WndProc(ref m);
        }

        public class WndProceMessageEventArgs : EventArgs
        {
            public WndProceMessageEventArgs(Message message)
            {
                Message = message;
            }

            public Message Message { get; }
        }
    }
}
