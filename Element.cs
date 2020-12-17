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

        Random rng = new Random();

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

        //public Image setType(int type)
        //{
        //    BitmapImage bi = new BitmapImage(Resources._0);
        //    pic.Source = bi;
        //    return pic;
        //}

        //public Element()
        //{
        //    pic = new BitmapImage();
        //    typeofb = -1;
        //}

        //public Element(BitmapImage pic, int typeofb)
        //{
        //    this.pic = pic;
        //    this.typeofb = typeofb;
        //}

        //public int getType()
        //{
        //    return typeofb;
        //}

        //public StackPanel getPanel(BitmapImage picture)
        //{
        //    StackPanel stackPanel = new StackPanel();

        //    Image image = new Image();
        //    image.Source = picture;
        //    stackPanel.Children.Add(image);
        //    stackPanel.Margin = new Thickness(1);

        //    return stackPanel;
        //}
    }
}
