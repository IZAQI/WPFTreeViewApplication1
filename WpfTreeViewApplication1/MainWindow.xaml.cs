using System;

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

using System.Text;

using System.Windows;

using System.Windows.Controls;

using System.Windows.Data;

using System.Windows.Documents;

using System.Windows.Input;

using System.Windows.Media;

using System.Windows.Media.Imaging;

using System.Windows.Navigation;

using System.Windows.Shapes;


namespace WpfTreeViewApplication1

{

    /// <summary>

    /// Interaction logic for MainWindow.xaml

    /// </summary>

    public partial class MainWindow : Window
    {

        private List<ParentItem> stateList = new List<ParentItem>();

        public MainWindow()
        {

            InitializeComponent();

            List<ChildItem> citylist1 = new List<ChildItem>();
            citylist1.Add(new ChildItem("Baltimore"));
            citylist1.Add(new ChildItem("Frederick"));
            citylist1.Add(new ChildItem("Rockville"));

            ParentItem state1 = new ParentItem();
            state1.Name = "Maryland";
            state1.NickName = "Old Line State";
            state1.Population = 5633597;
            state1.Children = citylist1;

            stateList.Add(state1);


            List<ChildItem> citylist2 = new List<ChildItem>();
            citylist2.Add(new ChildItem("Los Angeles"));
            citylist2.Add(new ChildItem("Sacramento"));
            citylist2.Add(new ChildItem("San Francisco"));
            citylist2.Add(new ChildItem("San Diego"));

            ParentItem state2 = new ParentItem();
            state2.Name = "California";
            state2.NickName = "Golden State";
            state2.Population = 36756666;
            state2.Children = citylist2;

            stateList.Add(state2);


            List<ChildItem> citylist3 = new List<ChildItem>();
            citylist3.Add(new ChildItem("Houston"));
            citylist3.Add(new ChildItem("Dallas"));
            citylist3.Add(new ChildItem("Austin"));
            citylist3.Add(new ChildItem("San Antonio"));

            ParentItem state3 = new ParentItem();

            state3.Name = "Taxes";
            state3.NickName = "Lone Star State";
            state3.Population = 2432697;
            state3.Children = citylist3;

            stateList.Add(state3);

            // many object
            for(int i = 0; i < 500; i++)
            {
                List<ChildItem> childList = new List<ChildItem>();
                childList.Add(new ChildItem("1"));
                childList.Add(new ChildItem("2"));
                childList.Add(new ChildItem("3"));
                childList.Add(new ChildItem("4"));
                childList.Add(new ChildItem("5"));
                childList.Add(new ChildItem("6"));
                childList.Add(new ChildItem("7"));
                childList.Add(new ChildItem("8"));
                childList.Add(new ChildItem("9"));
                childList.Add(new ChildItem("10"));
                childList.Add(new ChildItem("11"));
                childList.Add(new ChildItem("12"));

                ParentItem parent = new ParentItem();

                parent.Name = "1";
                parent.NickName = "1";
                parent.Population = 0;
                parent.Children = childList;

                stateList.Add(parent);
            }


            DataContext = stateList;
        }



        // TODO TEMP Snapshot
        /// <summary>
        /// https://msdn.microsoft.com/ja-jp/library/system.windows.media.imaging.rendertargetbitmap(v=vs.110).aspx
        /// http://qiita.com/hugo-sb/items/894914f6bbe224a45d49
        /// </summary>
        private void SaveImage()
        {
            Image myImage = new Image();
            FormattedText text = new FormattedText("ABC",
                    new CultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface(this.FontFamily, FontStyles.Normal, FontWeights.Normal, new FontStretch()),
                    this.FontSize,
                    this.Foreground);

            //DrawingVisual drawingVisual = new DrawingVisual();
            //DrawingContext drawingContext = drawingVisual.RenderOpen();
            //drawingContext.DrawText(text, new Point(2, 2));
            //drawingContext.Close();
            var drawingVisual = this;

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)ActualWidth, (int)ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            myImage.Source = bmp;

            // Add Image to the UI
            //StackPanel myStackPanel = new StackPanel();
            //myStackPanel.Children.Add(myImage);
            //this.Content = myStackPanel;

            string path = "image.png";

            // filesave
            // 出力用の FileStream を作成する
            using (var os = new FileStream(path, FileMode.Create))
            {
                // 変換したBitmapをエンコードしてFileStreamに保存する。
                // BitmapEncoder が指定されなかった場合は、PNG形式とする。
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(os);
            }
        }



    }


    public class ChildItem
    {

        public ChildItem(String name)
        {
            Name = name;
            Population = new Random().Next();
        }


        public int Population
        { get; set; }


        public String Name
        { get; set; }

    }


    public class ParentItem
    {

        public ParentItem()
        {
            this.Children = new List<ChildItem>();
        }


        public String Name
        { get; set; }


        public String NickName
        { get; set; }


        public int Population
        { get; set; }


        public List<ChildItem> Children
        { get; set; }


    }

}
