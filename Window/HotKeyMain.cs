using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Windows_Toolbox;
using System.Windows.Input;

namespace Windows_Toolbox
{
	public class HotKeyMain
	{
        public static string[] c = new string[3];
        [STAThread]
        public static void main()
		{
            /**
            1, 2, 3 Copy
            Num1, Num2, Num3 Paste
            */            

            HotKeyManager.RegisterHotKey(Keys.D1, 0);
            HotKeyManager.RegisterHotKey(Keys.D2, 0);
            HotKeyManager.RegisterHotKey(Keys.D3, 0);            
            HotKeyManager.RegisterHotKey(Keys.NumPad1, 0);
            HotKeyManager.RegisterHotKey(Keys.NumPad2, 0);
            HotKeyManager.RegisterHotKey(Keys.NumPad3, 0);
            HotKeyManager.RegisterHotKey(Keys.NumPad5, 0);
            HotKeyManager.RegisterHotKey(Keys.Q, KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);            
		}

		static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                if (e.Key == Keys.D1)
                {                    
                    SendKeys.SendWait("^c");
                    c[0] = Clipboard.GetText();
                }
                if (e.Key == Keys.D2)
                {
                    SendKeys.SendWait("^c");
                    c[1] = Clipboard.GetText();                    
                }
                if (e.Key == Keys.D3)
                {
                    SendKeys.SendWait("^c");
                    c[2] = Clipboard.GetText();                    
                }
                if (e.Key == Keys.NumPad1)
                {                    
                    Clipboard.SetText(c[0]);
                    SendKeys.SendWait("^v");                    
                }
                if (e.Key == Keys.NumPad2)
                {                    
                    Clipboard.SetText(c[1]);
                    SendKeys.SendWait("^v");                    
                }
                if (e.Key == Keys.NumPad3)
                {                    
                    Clipboard.SetText(c[2]);
                    SendKeys.SendWait("^v");                    
                }
                if (e.Key == Keys.NumPad5)
                {
                    string s = "";
                    for(int i = 0; i < c.Length; i++)
                    {
                        s += c[i];
                    }
                    s += ", " + c.Length;
                    Clipboard.SetText(s);
                    SendKeys.SendWait("^v");
                }
            })  ;
        }
	}
}    