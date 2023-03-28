using System.Windows;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System;


namespace Caesar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string selectedInputFile;
        public string selectedOutputPath;
        private string pattern_only_numbers = @"\d+(,\d+)*";
        private string pattern_for_slogan = @"^\w+$";




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
            if (Regex.IsMatch(EncryptText_KeyText.Text, pattern_for_slogan))
            {
                EncryptText_EncryptedText.Text = Crypting.EncryptText(EncryptText_Text.Text, EncryptText_KeyText.Text);
            }
            else
            {
                if (Regex.IsMatch(EncryptText_KeyText.Text, pattern_only_numbers))
                {
                    string[] substrings = EncryptText_KeyText.Text.Split(',');
                    int[] numbers = new int[substrings.Length];
                    for (int i = 0; i < substrings.Length; i++)
                    {
                        try
                        {
                            numbers[i] = int.Parse(substrings[i].Trim());
                            EncryptText_EncryptedText.Text = Crypting.EncryptText(EncryptText_Text.Text, numbers);
                        }
                        catch (Exception)
                        {
                            EncryptText_EncryptedText.Text = "";
                        }
                    }
                }
                else
                {
                    EncryptText_EncryptedText.Text = "";
                }
            }
        }

        private void EncryptText_KeyText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Regex.IsMatch(EncryptText_KeyText.Text, pattern_for_slogan))
            {
                EncryptText_EncryptedText.Text = Crypting.EncryptText(EncryptText_Text.Text, EncryptText_KeyText.Text);
            }
            else
            {
               if(Regex.IsMatch(EncryptText_KeyText.Text, pattern_only_numbers))
               {
                    string[] substrings = EncryptText_KeyText.Text.Split(',');
                    int[] numbers = new int[substrings.Length];
                    for (int i = 0; i < substrings.Length; i++)
                    {
                        try
                        {
                            numbers[i] = int.Parse(substrings[i].Trim());
                            EncryptText_EncryptedText.Text = Crypting.EncryptText(EncryptText_Text.Text, numbers);
                        }
                        catch (Exception)
                        {
                            EncryptText_EncryptedText.Text = "";
                        }
                    }
               }
               else
               {
                    EncryptText_EncryptedText.Text = "";
               }
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
            if (Regex.IsMatch(DecryptText_KeyText.Text, pattern_for_slogan))
            {
                DecryptText_DecryptedText.Text = Crypting.DecryptText(DecryptText_Text.Text, DecryptText_KeyText.Text);
            }
            else
            {
                if (Regex.IsMatch(DecryptText_KeyText.Text, pattern_only_numbers))
                {
                    string[] substrings = DecryptText_KeyText.Text.Split(',');
                    int[] numbers = new int[substrings.Length];
                    for (int i = 0; i < substrings.Length; i++)
                    {
                        try
                        {
                            numbers[i] = int.Parse(substrings[i].Trim());
                            DecryptText_DecryptedText.Text = Crypting.DecryptText(DecryptText_Text.Text, numbers);
                        }
                        catch (Exception)
                        {
                            DecryptText_DecryptedText.Text = "";
                        }
                    }
                }
                else
                {
                    DecryptText_DecryptedText.Text = "";
                }
            }
        }

        private void DecryptText_KeyText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Regex.IsMatch(DecryptText_KeyText.Text, pattern_for_slogan))
            {
                DecryptText_DecryptedText.Text = Crypting.DecryptText(DecryptText_Text.Text, DecryptText_KeyText.Text);
            }
            else
            {
                if (Regex.IsMatch(DecryptText_KeyText.Text, pattern_only_numbers))
                {
                    string[] substrings = DecryptText_KeyText.Text.Split(',');
                    int[] numbers = new int[substrings.Length];
                    for (int i = 0; i < substrings.Length; i++)
                    {
                        try
                        {
                            numbers[i] = int.Parse(substrings[i].Trim());
                            DecryptText_DecryptedText.Text = Crypting.DecryptText(DecryptText_Text.Text, numbers);
                        }
                        catch (Exception)
                        {
                            DecryptText_DecryptedText.Text = "";
                        }
                    }
                }
                else
                {
                    DecryptText_DecryptedText.Text = "";
                }
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
            EncryptFile_ChooseOutputButton.Visibility = Visibility.Hidden;
            if (Regex.IsMatch(EncryptFile_KeyText.Text, pattern_for_slogan))
            {
                EncryptFile_ChooseOutputButton.Visibility = Visibility.Visible;
            }
            if (Regex.IsMatch(EncryptFile_KeyText.Text, pattern_only_numbers))
            {
                EncryptFile_ChooseOutputButton.Visibility = Visibility.Visible;
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
            if (Regex.IsMatch(EncryptFile_KeyText.Text, pattern_for_slogan))
            {
                EncryptFile_ChooseOutputButton.IsEnabled = true;
                Crypting.EncryptNonText(selectedInputFile, selectedOutputPath, EncryptFile_KeyText.Text);
            }
            if (Regex.IsMatch(EncryptFile_KeyText.Text, pattern_only_numbers))
            {
                EncryptFile_ChooseOutputButton.IsEnabled = true;
                string[] substrings = EncryptFile_KeyText.Text.Split(',');
                int[] numbers = new int[substrings.Length];
                for (int i = 0; i < substrings.Length; i++)
                {
                    numbers[i] = int.Parse(substrings[i].Trim());
                }
                Crypting.EncryptNonText(selectedInputFile, selectedOutputPath, numbers);
            }
            AllClear();
        }

        private void DecryptFileButton_Click(object sender, RoutedEventArgs e)
        {
            AllClear();
            AllInvisible();
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
            DecryptFile_ChooseOutputButton.Visibility = Visibility.Hidden;
            if (Regex.IsMatch(DecryptFile_KeyText.Text, pattern_for_slogan))
            {
                DecryptFile_ChooseOutputButton.Visibility = Visibility.Visible;
            }
            if (Regex.IsMatch(DecryptFile_KeyText.Text, pattern_only_numbers))
            {
                DecryptFile_ChooseOutputButton.Visibility = Visibility.Visible;
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
            if (Regex.IsMatch(DecryptFile_KeyText.Text, pattern_for_slogan))
            {
                Crypting.DecryptNonText(selectedInputFile, selectedOutputPath, DecryptFile_KeyText.Text);
            }
            if (Regex.IsMatch(DecryptFile_KeyText.Text, pattern_only_numbers))
            {
                string[] substrings = DecryptFile_KeyText.Text.Split(',');
                int[] numbers = new int[substrings.Length];
                for (int i = 0; i < substrings.Length; i++)
                {
                    numbers[i] = int.Parse(substrings[i].Trim());
                }
                Crypting.DecryptNonText(selectedInputFile, selectedOutputPath, numbers);
            }
            AllClear();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
