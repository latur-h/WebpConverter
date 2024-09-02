using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebpConverter.dlls
{
    internal static class RTConsole
    {
        static RichTextBox? console;

        public static void Init(ref RichTextBox rt) => console = rt;
        public static void Write(string text, Color? color = null)
        {
            if (console is null) return;

            console.Invoke(() => 
            {
                console.SelectionColor = (Color)(color is null ? Color.LightGray : color);

                console?.AppendText($"{DateTime.Now.ToShortTimeString()} | {text}\r");

                console?.ScrollToCaret();
            });
        }
    }
}
