using System.Text.RegularExpressions;
using System.Windows;

namespace RegularExpression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static string namePattern = @"^((\w{1,}-*\w{1,}\.*)\s{1}){1,2}\w{1,}-*\w{1,}$";
        private static string phonePattern = @"^\((\d{3})\)[\s](\d{3})\-(\d{4})$";
        private static string emailPattern = @"^\w{1,}\.*\w{1,}\@\w{1,}\.*\w{1,}\.[a-z]{2,3}$";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static bool ValidName(string nameString)
        {
            return Regex.IsMatch(nameString, namePattern);
        }

        public static bool ValidPhone(string phoneString)
        {
            return Regex.IsMatch(phoneString, phonePattern);
        }

        public static bool ValidEmail(string emailString)
        {
            return Regex.IsMatch(emailString, emailPattern);
        }

        public void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidName(NameString.Text))
            {
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");
            }
            if (!ValidPhone(PhoneString.Text))
            {
                MessageBox.Show("The phone is invalid (correct pattern: (###) ###-####)");
            }
            if (!ValidEmail(EmailString.Text))
            {
                MessageBox.Show("The email is invalid (email should be: ex. mentor07@example.com)");
            }
            else if (ValidName(NameString.Text) && ValidPhone(PhoneString.Text) && ValidEmail(EmailString.Text))
            {
                MessageBox.Show("Congratulation, all fields match");
            }
        }

        public void BtnReformat_Click(object sender, RoutedEventArgs e)
        {
            if (ValidPhone(PhoneInput.Text))
            {
                PhoneOutput.Text = "No reformatting needed";
            }
            else if (Regex.IsMatch(PhoneInput.Text, phonePattern))
            {
                PhoneOutput.Text = ReformatPhone(PhoneInput.Text);
            }
            else 
            {
                PhoneOutput.Text = "Reformatting is not possible";
            }
        }

        public string ReformatPhone(string phoneString)
        {

            return Regex.Replace(phoneString, @"^\d{3}", @"");
        }
    }
}