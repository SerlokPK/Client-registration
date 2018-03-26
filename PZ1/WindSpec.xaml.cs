using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PZ1
{
    /// <summary>
    /// Interaction logic for WindSpec.xaml
    /// </summary>
    public partial class WindSpec : Window
    {
        public WindSpec()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonAddArticle_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                MainWindow.AnimeList.Add(new Anime(textBoxTitle.Text, textBoxChar.Text, textBoxImage.Text, Double.Parse(textBoxImdb.Text), textBoxRestr.Text,textBoxAbout.Text));
                
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an error. Try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool validate()
        {
            
            bool status = true;

            if (textBoxTitle.Text.Trim().Equals(""))
            {
                labelTitleError.Content = "U can't leave this blank.";
                textBoxTitle.BorderBrush = Brushes.Red;
                status = false;
            }
            else
            {
                textBoxTitle.BorderBrush = Brushes.Gray;
                labelTitleError.Content = "";
            }

            if (textBoxChar.Text.Trim().Equals(""))
            {
                labelCharError.Content = "U can't leave this blank.";
                textBoxChar.BorderBrush = Brushes.Red;
                status = false;
            }
            else
            {
                textBoxChar.BorderBrush = Brushes.Gray;
                labelCharError.Content = "";
            }

            
            if (textBoxImdb.Text.Trim().Equals(""))
            {
                labelImdbError.Content = "U can't leave this blank.";
                textBoxImdb.BorderBrush = Brushes.Red;
                status = false;
            } 
            else 
            {
                textBoxImdb.BorderBrush = Brushes.Gray;
                labelImdbError.Content = "";

                try
                {
                    if (Double.Parse(textBoxImdb.Text) < 0 || Double.Parse(textBoxImdb.Text) > 10)
                    {
                        labelImdbError.Content = "U didn't enter a valid number.";
                        textBoxImdb.BorderBrush = Brushes.Red;

                        status = false;
                    }
                }
                catch(Exception ex)
                {
                    labelImdbError.Content = "U didn't enter a valid number.";
                    textBoxImdb.BorderBrush = Brushes.Red;
                    Console.WriteLine(ex.Message);
                    status = false;
                }
            }

            if (textBoxRestr.Text.Trim().Equals(""))
            {
                labelResrtError.Content = "U can't leave this blank.";
                textBoxRestr.BorderBrush = Brushes.Red;
                status = false;
            }
            else
            {
                textBoxRestr.BorderBrush = Brushes.Gray;
                labelResrtError.Content = "";
            }

            if (textBoxAbout.Text.Trim().Equals(""))
            {
                labelAboutError.Content = "U can't leave this blank.";
                textBoxAbout.BorderBrush = Brushes.Red;
                status = false;
            }
            else
            {
                textBoxAbout.BorderBrush = Brushes.Gray;
                labelAboutError.Content = "";
            }

            if (imageAnime.Source is null)
            {
                labelImageError.Content = "U must add picture.";
                
                status = false;
            }
            else
            {

                labelImageError.Content = "";
            }

            return status;
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                
                string filename = dlg.FileName;
                textBoxImage.Text = filename;
                var uri = new Uri(filename);
                imageAnime.Source = new BitmapImage(uri);
            }
        }
    }
}
