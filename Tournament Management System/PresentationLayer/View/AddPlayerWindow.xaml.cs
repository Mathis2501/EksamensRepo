using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayerWindow : Window
    {
        public AddPlayerWindow()
        {
            InitializeComponent();
            btn_AddPlayer.IsEnabled = false;
        }

        private void btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            
            //PLAYER NewPlayer = new PLAYER(txt_FirstName.Text, txt_LastName.Text, int.Parse(txt_PhoneNr.Text), txt_Email.Text);
        }

        private void Txt_FirstName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DoEveryTextboxContainText();
        }

        private void Txt_LastName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DoEveryTextboxContainText();
        }

        private void Txt_PhoneNr_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            //ensures that only numbers are entered
            if (txt_PhoneNr.Text != "")
            {
                if (!int.TryParse(txt_PhoneNr.Text, out i))
                {
                    //Removes the last letter
                    txt_PhoneNr.Text = txt_PhoneNr.Text.Remove(txt_PhoneNr.Text.Length - 1);
                }
                MessageBox.Show("Indtast kun tal");
            }
            DoEveryTextboxContainText();
        }

        private void Txt_Email_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DoEveryTextboxContainText();
        }

        private void DoEveryTextboxContainText()
        {
            if (!string.IsNullOrWhiteSpace(txt_FirstName.Text) && !string.IsNullOrWhiteSpace(txt_LastName.Text) && !string.IsNullOrWhiteSpace(txt_PhoneNr.Text) && !string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                btn_AddPlayer.IsEnabled = true;
            }
            else
            {
                btn_AddPlayer.IsEnabled = false;
            }
        }
    }
}
