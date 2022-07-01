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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Captcha
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path;
        string code;
        int ran;
        BitmapImage bi3;
        Random random;
        public MainWindow()
        {
            InitializeComponent();
            ChangeCaptcha();
        }
        public void ChangeCaptcha() { 
            bi3 = new BitmapImage();
            random = new Random();
            ran = random.Next(1, 5);
            for (int i = 0; i <= 5; i++) {
                if (ran == i) {
                    path = @"..\..\" + i.ToString() + "kap.png";
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(path, UriKind.Relative);
                    bi3.EndInit();
                    imagecaptcha.Stretch = Stretch.Fill;
                    imagecaptcha.Source = bi3;
                    if (ran == 1)
                    {
                        code = "1#r#k#o#2#";
                    }
                    else if (ran == 2) {
                        code = "2#g#r#5#6#";
                    }
                    else if (ran == 3)
                    {
                        code = "6#w#r#f#r#";
                    }
                    else if (ran == 4)
                    {
                        code = "8#r#t#e#h#";
                    }
                    else if (ran == 5)
                    {
                        code = "i#o#h#t#5#";
                    }
                }
            }
        }
        public void UserConfirm(string codeuser) {
           
                string newcodeuser = "";
                for (int i = 0; i <= codeuser.Length-1; i++)
                {
                    newcodeuser += codeuser[i] + "#";
                }
                if (newcodeuser == code)
                {
                    MessageBox.Show("Поздравляю! Вы не робот.", "Captcha", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Вы робот", "Captcha", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            
        }
        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeCaptcha();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (UserText.Text.Length >= 5) {
                e.Handled = true;
                UserConfirm(UserText.Text);
            }
        }
    }
}
