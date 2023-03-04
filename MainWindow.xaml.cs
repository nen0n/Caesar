using System.Windows;
using Microsoft.Win32;

namespace Caesar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string selectedInputFile;
        public string selectedOutputPath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AllInvisible()
        {
            InfoBlock.Visibility = Visibility.Hidden;

            EncryptText_Encrypt.Visibility = Visibility.Hidden;
            EncryptText_EncryptedText.Visibility = Visibility.Hidden;
            EncryptText_KeyBlock.Visibility = Visibility.Hidden;
            EncryptText_KeyText.Visibility = Visibility.Hidden;
            EncryptText_Text.Visibility = Visibility.Hidden;
            EncryptText_TextBlock.Visibility = Visibility.Hidden;

            DecryptText_Decrypt.Visibility = Visibility.Hidden;
            DecryptText_DecryptedText.Visibility = Visibility.Hidden;
            DecryptText_KeyBlock.Visibility = Visibility.Hidden;
            DecryptText_KeyText.Visibility = Visibility.Hidden;
            DecryptText_Text.Visibility = Visibility.Hidden;
            DecryptText_TextBlock.Visibility = Visibility.Hidden;

            DecryptFile_ChooseInputButton.Visibility = Visibility.Hidden;
            DecryptFile_ChooseOutputButton.Visibility = Visibility.Hidden;
            DecryptFile_DecryptButton.Visibility = Visibility.Hidden;
            DecryptFile_Key.Visibility = Visibility.Hidden;
            DecryptFile_KeyText.Visibility = Visibility.Hidden;

            EncryptFile_ChooseInputButton.Visibility = Visibility.Hidden;
            EncryptFile_ChooseOutputButton.Visibility = Visibility.Hidden;
            EncryptFile_EncryptButton.Visibility = Visibility.Hidden;
            EncryptFile_Key.Visibility = Visibility.Hidden;
            EncryptFile_KeyText.Visibility = Visibility.Hidden;
        }

        private void AllClear()
        {
            EncryptText_KeyText.Text = "";
            EncryptText_Text.Text = "";
            EncryptText_EncryptedText.Text = "";

            DecryptText_KeyText.Text = "";
            DecryptText_Text.Text = "";
            DecryptText_DecryptedText.Text = "";

            selectedInputFile = "";
            selectedOutputPath = "";

            DecryptFile_KeyText.Text = "";
            EncryptFile_KeyText.Text = "";

            EncryptFile_KeyText.IsEnabled = true;
            DecryptFile_KeyText.IsEnabled = true;
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            AllClear();
            AllInvisible();
            InfoBlock.Visibility = Visibility.Visible;
        }

        private void EncryptTextButton_Click(object sender, RoutedEventArgs e)
        {
            AllClear();
            AllInvisible();

            EncryptText_Encrypt.Visibility = Visibility.Visible;
            EncryptText_EncryptedText.Visibility = Visibility.Visible;
            EncryptText_KeyBlock.Visibility = Visibility.Visible;
            EncryptText_KeyText.Visibility = Visibility.Visible;
            EncryptText_Text.Visibility = Visibility.Visible;
            EncryptText_TextBlock.Visibility = Visibility.Visible;
        }

        private void EncryptText_Text_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EncryptText_Text.Text != "" && int.TryParse(EncryptText_KeyText.Text, out int key))
            {
                EncryptText_EncryptedText.Text = Crypting.DecryptText(EncryptText_Text.Text, int.Parse(EncryptText_KeyText.Text));
            }
            else
            {
                EncryptText_EncryptedText.Text = "";
            }
        }

        private void EncryptText_KeyText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EncryptText_Text.Text != "" && int.TryParse(EncryptText_KeyText.Text, out int key))
            {
                EncryptText_EncryptedText.Text = Crypting.DecryptText(EncryptText_Text.Text, int.Parse(EncryptText_KeyText.Text));
            }
            else
            {
                EncryptText_EncryptedText.Text = "";
            }
        }

        private void DecryptTextButton_Click(object sender, RoutedEventArgs e)
        {
            AllClear();
            AllInvisible();

            DecryptText_Decrypt.Visibility = Visibility.Visible;
            DecryptText_DecryptedText.Visibility = Visibility.Visible;
            DecryptText_KeyBlock.Visibility = Visibility.Visible;
            DecryptText_KeyText.Visibility = Visibility.Visible;
            DecryptText_Text.Visibility = Visibility.Visible;
            DecryptText_TextBlock.Visibility = Visibility.Visible;
        }

        private void DecryptText_Text_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (DecryptText_Text.Text != "" && int.TryParse(DecryptText_KeyText.Text, out int key))
            {
                DecryptText_DecryptedText.Text = Crypting.DecryptText(DecryptText_Text.Text, int.Parse(DecryptText_KeyText.Text));
            }
            else
            {
                DecryptText_DecryptedText.Text = "";
            }
        }

        private void DecryptText_KeyText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (DecryptText_Text.Text != "" && int.TryParse(DecryptText_KeyText.Text, out int key))
            {
                DecryptText_DecryptedText.Text = Crypting.DecryptText(DecryptText_Text.Text, int.Parse(DecryptText_KeyText.Text));
            }
            else
            {
                DecryptText_DecryptedText.Text = "";
            }
        }

        private void EncryptFileButton_Click(object sender, RoutedEventArgs e)
        {
            AllClear();
            AllInvisible();
            EncryptFile_ChooseInputButton.Visibility = Visibility.Visible;
        }

        private void EncryptFile_ChooseInputButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == true)
            {
                selectedInputFile = openFileDialog.FileName;
            }

            EncryptFile_Key.Visibility = Visibility.Visible;
            EncryptFile_KeyText.Visibility = Visibility.Visible;
        }

        private void EncryptFile_KeyText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(int.TryParse(EncryptFile_KeyText.Text, out int result))
            {
                EncryptFile_ChooseOutputButton.Visibility = Visibility.Visible;
            }
            else 
            {
                EncryptFile_ChooseOutputButton.Visibility = Visibility.Hidden;
            }
        }

        private void EncryptFile_ChooseOutputButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = false;
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Select a folder";
            openFileDialog.Filter = "Folders|\n";
            openFileDialog.DereferenceLinks = true;
            openFileDialog.FileName = "Select";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedOutputPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            }

            EncryptFile_KeyText.IsEnabled = false;
            EncryptFile_EncryptButton.Visibility = Visibility.Visible;
        }

        private void EncryptFile_EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            AllInvisible();
            Crypting.EncryptNonText(selectedInputFile, selectedOutputPath, int.Parse(EncryptFile_KeyText.Text));
            AllClear();
        }

        private void DecryptFileButton_Click(object sender, RoutedEventArgs e)
        {
            DecryptFile_ChooseInputButton.Visibility = Visibility.Visible;
        }

        private void DecryptFile_ChooseInputButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == true)
            {
                selectedInputFile = openFileDialog.FileName;
            }

            DecryptFile_Key.Visibility = Visibility.Visible;
            DecryptFile_KeyText.Visibility = Visibility.Visible;
        }

        private void DecryptFile_KeyText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(int.TryParse(DecryptFile_KeyText.Text, out int result))
            {
                DecryptFile_ChooseOutputButton.Visibility = Visibility.Visible;
            }
            else
            {
                DecryptFile_ChooseOutputButton.Visibility = Visibility.Hidden;
            }
        }

        private void DecryptFile_ChooseOutputButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Select a folder";
            openFileDialog.Filter = "Folders|\n";
            openFileDialog.DereferenceLinks = true;
            openFileDialog.FileName = "Select";


            if (openFileDialog.ShowDialog() == true)
            {
                selectedOutputPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            }

            DecryptFile_KeyText.IsEnabled = false;
            DecryptFile_DecryptButton.Visibility = Visibility.Visible;
        }

        private void DecryptFile_DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            AllInvisible();
            Crypting.DecryptNonText(selectedInputFile, selectedOutputPath, int.Parse(DecryptFile_KeyText.Text));
            AllClear();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
