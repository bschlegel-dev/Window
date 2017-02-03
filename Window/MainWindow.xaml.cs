using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Windows_Toolbox;

namespace BenWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void ShowToast(string text, int duration)
        {   
                     
            toast.Visibility = Visibility.Visible;
            //REMOVE THIS              
            toast.Show(text, System.TimeSpan.FromMilliseconds(duration));
                                    
        }

        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
            //Toast Stuff
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Top = SystemParameters.WorkArea.Top;
            this.Left = SystemParameters.WorkArea.Left;

            HotKeyManager.RegisterHotKey(Keys.D1, 0);
            HotKeyManager.RegisterHotKey(Keys.D2, 0);
            HotKeyManager.RegisterHotKey(Keys.D3, 0);
            //HotKeyManager.RegisterHotKey(Keys.C, KeyModifiers.Control);
            HotKeyManager.RegisterHotKey(Keys.NumPad1, 0);
            HotKeyManager.RegisterHotKey(Keys.NumPad2, 0);
            HotKeyManager.RegisterHotKey(Keys.NumPad3, 0);
            HotKeyManager.RegisterHotKey(Keys.NumPad5, 0);            
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);

        }

        public static string[] c = new string[3];

        void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                if (e.Key == Keys.D1)
                {                                        
                    SendKeys.SendWait("^c");
                    SendKeys.SendWait("^c");
                    SendKeys.Flush();
                    c[0] = System.Windows.Forms.Clipboard.GetText();
                    System.Windows.Clipboard.Clear();
                    ShowToast("'"+c[0]+"' was coppied to your Clipboard!", 3500);                    
                }
                if (e.Key == Keys.D2)
                {                    
                    SendKeys.SendWait("^c");
                    SendKeys.SendWait("^c");
                    SendKeys.Flush();
                    c[1] = System.Windows.Clipboard.GetText();                    
                    System.Windows.Clipboard.Clear();
                    ShowToast("'" + c[1] + "' was coppied to your Clipboard!", 3500);                    
                }
                if (e.Key == Keys.D3)
                {
                    SendKeys.Send("^c");                    
                    SendKeys.Flush();
                    c[2] = System.Windows.Clipboard.GetText();
                    System.Windows.Clipboard.Clear();
                    ShowToast("'" + c[2] + "' was coppied to your Clipboard!", 3500);
                }
                if (e.Key == Keys.NumPad1)
                {
                    if(c[0] != null)
                    {
                        System.Windows.Clipboard.SetText(c[0]);
                        SendKeys.SendWait("^v");
                    }                                        
                }
                if (e.Key == Keys.NumPad2)
                {
                    if(c[1] != null)
                    {
                        System.Windows.Forms.Clipboard.SetText(c[1]);
                        SendKeys.SendWait("^v");
                    }                                        
                }
                if (e.Key == Keys.NumPad3)
                {
                    if(c[2] != null)
                    {
                        System.Windows.Clipboard.SetText(c[2]);
                        SendKeys.SendWait("^v");
                    }                    
                }
                if (e.Key == Keys.NumPad5)
                {
                    string s = "";
                    for (int i = 0; i < c.Length; i++)
                    {
                        s += c[i];
                    }
                    s += ", " + c.Length;
                    System.Windows.Clipboard.SetText(s);
                    SendKeys.SendWait("^v");
                }  
                /**             
                if(e.Key == Keys.C && e.Modifiers == KeyModifiers.Control)
                {                    
                    ShowToast("Something' was coppied to your Clipboard!", 3500);
                }**/
            });
        }
    }
}