using Shadowsocks.Controller;
using Shadowsocks.Model;
using Shadowsocks.Util;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shadowsocks.View
{
    public partial class ShortCutForm : Form
    {
        public ShortCutForm(Controller.ShadowsocksController controller)
        {
            InitializeComponent();
            this.controller = controller;
            this.Load += ShortCutForm_Load;
        }

        private void ShortCutForm_Load(object sender, EventArgs e)
        {
            if (controller.GetCurrentConfiguration().switchPacModifysKey != 0)
            {
                key1 = (Keys)controller.GetCurrentConfiguration().switchPacModifysKey;
                key2 = (Keys)controller.GetCurrentConfiguration().switchPacKey;
                txtSwitch.Text = key1.ToString() + "+" + key2.ToString();
            }
        }

        private Keys key1 = Keys.None;
        private Keys key2 = Keys.None;
        private readonly ShadowsocksController controller;

        private void txtSwitch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift || e.Modifiers == Keys.Control)
            {
                if (GetKeyChar(e, out string keyStr, out Keys key1, out Keys key2))
                {
                    txtSwitch.Text = keyStr;
                }
                this.key1 = key1;
                this.key2 = key2;
            }

            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                txtSwitch.Text = "";
                this.key1 = Keys.None;
                this.key2 = Keys.None;
            }
        }

        private bool GetKeyChar(KeyEventArgs e, out string keyStr, out Keys key1, out Keys key2)
        {
            keyStr = "";
            keyStr += e.Control ? "Ctrl" : e.Shift ? "Shift" : e.Alt ? "Alt" : "";
            keyStr += "+";
            var key2Str = ((int)e.KeyCode >= 65 && (int)e.KeyCode <= 90) ? e.KeyCode.ToString() : "";
            if (string.IsNullOrEmpty(key2Str))
            {
                key1 = Keys.None;
                key2 = Keys.None;
                return false;
            }
            else
            {
                keyStr += key2Str;
                key1 = e.Modifiers;
                key2 = e.KeyCode;
                return true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var _curConfig = controller.GetCurrentConfiguration();
            _curConfig.switchPacModifysKey = (int)key1;
            _curConfig.switchPacKey = (int)key2;
            Configuration.Save(_curConfig);
            this.Close();
        }
    }
}