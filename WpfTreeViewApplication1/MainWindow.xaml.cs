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

        private List<State> stateList = new List<State>();


        public MainWindow()

        {

            InitializeComponent();


            List<City> citylist1 = new List<City>();

            citylist1.Add(new City("Baltimore", 636919));

            citylist1.Add(new City("Frederick", 59220));

            citylist1.Add(new City("Rockville", 60734));

            State state1 = new State();

            state1.Name = "Maryland";

            state1.NickName = "Old Line State";

            state1.Population = 5633597;

            state1.Cities = citylist1;


            stateList.Add(state1);


            List<City> citylist2 = new List<City>();

            citylist2.Add(new City("Los Angeles", 3833995));

            citylist2.Add(new City("Sacramento", 502743));

            citylist2.Add(new City("San Francisco", 808976));

            citylist2.Add(new City("San Diego", 1279329));

            State state2 = new State();

            state2.Name = "California";

            state2.NickName = "Golden State";

            state2.Population = 36756666;

            state2.Cities = citylist2;


            stateList.Add(state2);


            List<City> citylist3 = new List<City>();

            citylist3.Add(new City("Houston", 2242193));

            citylist3.Add(new City("Dallas", 1279910));

            citylist3.Add(new City("Austin", 757688));

            citylist3.Add(new City("San Antonio", 1351305));

            State state3 = new State();

            state3.Name = "Taxes";

            state3.NickName = "Lone Star State";

            state3.Population = 2432697;

            state3.Cities = citylist3;


            stateList.Add(state3);


            DataContext = stateList;

        }

    }


    public class City

    {

        public City(String name, int population)

        {

            Name = name;

            Population = population;

        }


        public int Population

        { get; set; }


        public String Name

        { get; set; }

    }


    public class State

    {

        public State()

        {

            this.Cities = new List<City>();

        }


        public String Name

        { get; set; }


        public String NickName

        { get; set; }


        public int Population

        { get; set; }


        public List<City> Cities

        { get; set; }

    }

}
