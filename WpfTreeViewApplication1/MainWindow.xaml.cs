using System;

using System.Collections.Generic;

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

                ParentItem parent = new ParentItem();

                parent.Name = "1";
                parent.NickName = "1";
                parent.Population = 0;
                parent.Children = childList;

                stateList.Add(parent);
            }


            DataContext = stateList;
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
