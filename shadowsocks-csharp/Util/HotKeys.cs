using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Shadowsocks.Util
{
    public class HotKeys
    {
        //引入系统API
        [DllImport("user32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, Keys vk);
        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        int keyid = 10;     //区分不同的快捷键
        Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();   //每一个key对于一个处理函数
        public delegate void HotKeyCallBackHanlder();

        //组合控制键
        public enum HotkeyModifiers
        {
            Alt = 1,
            Control = 2,
            Shift = 4,
            Win = 8
        }

        public int GetModifiers(Keys modify)
        {
            switch (modify)
            {
                case Keys.Control: return 2;
                case Keys.Shift: return 4;
                case Keys.Alt: return 1;
                default: return 0;
            }
        }

        //注册快捷键
        public void Regist(IntPtr hWnd, int modifiers, Keys vk, HotKeyCallBackHanlder callBack)
        {
            int id = keyid++;
            if (!RegisterHotKey(hWnd, id, modifiers, vk))
                throw new Exception("注册失败！");
            keymap[id] = callBack;
        }

        // 注销快捷键
        public void UnRegist(IntPtr hWnd, HotKeyCallBackHanlder callBack)
        {
            foreach (KeyValuePair<int, HotKeyCallBackHanlder> var in keymap)
            {
                if (var.Value == callBack)
                {
                    UnregisterHotKey(hWnd, var.Key);
                    return;
                }
            }
        }

        // 快捷键消息处理
        public void ProcessHotKey(Message m)
        {
            if (m.Msg == 0x312)
            {
                int id = m.WParam.ToInt32();
                HotKeyCallBackHanlder callback;
                if (keymap.TryGetValue(id, out callback))
                    callback();
            }
        }
    }

}
