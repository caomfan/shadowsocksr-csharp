using Shadowsocks.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shadowsocks.Controller
{
    class HotKeyManager
    {
        public HotKeyManager(ShadowsocksController controller, IntPtr handle)
        {
            this.controller = controller;
            this.Handle = handle;
        }
        private HotKeys _hotKey = new HotKeys();
        private Keys switchPacModifysKey = Keys.None;
        private Keys switchPacKey = Keys.None;
        private ShadowsocksController controller;

        public event EventHandler<ProxyToggleEventArgs> ProxyToggleChanged;

        private IntPtr Handle { get; }

        public class ProxyToggleEventArgs : EventArgs
        {
            public ProxyToggleEventArgs(ProxyMode proxyMode)
            {
                ProxyMode = proxyMode;
            }

            public ProxyMode ProxyMode { get; }
        }

        public void UnRegister()
        {
            _hotKey.UnRegist(this.Handle, CallBack);
        }

        public void MessageHandler(Message message)
        {
            _hotKey.ProcessHotKey(message);
        }

        private void CallBack()
        {
            var proxyModel = (ProxyMode)controller.GetCurrentConfiguration().sysProxyMode;
            var waitSwitchModel = proxyModel == ProxyMode.Direct ? ProxyMode.Pac : ProxyMode.Direct;
            controller.ToggleMode(waitSwitchModel);
            ProxyToggleChanged?.Invoke(this, new ProxyToggleEventArgs(waitSwitchModel));
        }

        internal void Register(Keys switchPacModifysKey, Keys switchPacKey)
        {
            if (this.switchPacModifysKey != Keys.None && this.switchPacKey != Keys.None)
            {
                _hotKey.UnRegist(this.Handle, CallBack);
            }
            if (switchPacModifysKey != Keys.None && switchPacKey != Keys.None && ((int)this.switchPacKey + (int)this.switchPacModifysKey) != ((int)switchPacKey + (int)switchPacModifysKey))
            {
                this.switchPacModifysKey = switchPacModifysKey;
                this.switchPacKey = switchPacKey;
                _hotKey.Regist(this.Handle, _hotKey.GetModifiers(switchPacModifysKey), switchPacKey, CallBack);
            }
        }
    }
}
