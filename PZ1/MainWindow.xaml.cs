using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PZ1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BindingList<Anime> animeList = new BindingList<Anime>();
        public static int ind = 0;
        public static string url = "";
        
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();            
        }

        public static BindingList<Anime> AnimeList { get => animeList; set => animeList = value; }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindSpec specification = new WindSpec();
            specification.ShowDialog();
            //url = AnimeList

        }

        private void buttonEXIT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void Button_read_Click(object sender, RoutedEventArgs e)
        {
            ind = dataGridItems.SelectedIndex;
            readingWind reader = new readingWind();
            
            reader.ShowDialog();
        }

        private void Button_del_Click(object sender, RoutedEventArgs e)
        {
            AnimeList.RemoveAt(dataGridItems.SelectedIndex);

        }

        private void Button_change_Click(object sender, RoutedEventArgs e)
        {
            ind = dataGridItems.SelectedIndex;
            url = AnimeList.ElementAt(ind).Image.ToString();
            Anime a = AnimeList.ElementAt(ind);
            editWind editor = new editWind(a);

            editor.ShowDialog();
        }

       
    }
}
