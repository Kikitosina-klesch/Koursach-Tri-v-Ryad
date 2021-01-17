using Koursach_Tri_v_Ryad.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Koursach_Tri_v_Ryad
{
    public class Element
    {
        public BitmapImage pic { get; set; }
        public int typeofpic { get; set; }

        public Button b = new Button();

        int bSize = 50;

        public Element (int typeofpic, int tag)
        {  
            this.typeofpic = typeofpic;
            
            
            b = new Button();
            b.Tag = tag;
            b.Width = bSize;
            b.Height = bSize;
            b.Content = "";
            b.Margin = new Thickness(2);               
        }
    }
}
