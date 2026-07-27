using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SystemConfigWizard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Step1Next_Click(object sender, RoutedEventArgs e)
        {
            Step1Panel.Visibility = Visibility.Collapsed;
            Step2Panel.Visibility = Visibility.Visible;
        }

        private void Step2Next_Click(object sender, RoutedEventArgs e)
        {
            Step2Panel.Visibility = Visibility.Collapsed;
            Step3Panel.Visibility = Visibility.Visible;
        }

        private async void Run_Click(object sender, RoutedEventArgs e)
        {
            // Show loading state
            ShowStatus("Проверка...");

            string versionStr = ((ComboBoxItem)VersionComboBox.SelectedItem).Content.ToString();
            string tierStr = ((ComboBoxItem)TierComboBox.SelectedItem).Content.ToString();

            // Parse version to get the number
            string versionNum = "";
            if (versionStr == "Version 7") versionNum = "7";
            else if (versionStr == "Version 10") versionNum = "10";
            else if (versionStr == "Version 11") versionNum = "11";

            string tier = tierStr.ToLower(); // home or pro

            string fileName = $"key{versionNum}{tier}.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (!File.Exists(filePath))
            {
                ShowStatus($"Файл {fileName} не найден.");
                return;
            }

            try
            {
                string[] tokens = await File.ReadAllLinesAsync(filePath);

                bool isValid = await Task.Run(() => ValidateTokens(tokens));

                if (isValid)
                {
                    ShowStatus("Успех! Ключ подошёл.");
                }
                else
                {
                    ShowStatus("Увы, но ключи не подошли. Попробуйте новые версии нашей программы.");
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"Ошибка: {ex.Message}");
            }
        }

        private bool ValidateTokens(string[] tokens)
        {
            foreach (string token in tokens)
            {
                if (string.IsNullOrWhiteSpace(token)) continue;

                // Mock execution using cmd.exe
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c echo {token}", // Simulate validation command
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                using (Process process = Process.Start(startInfo))
                {
                    if (process != null)
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();

                        // Simulate checking for success keywords
                        // In a real scenario, the mock command might not output "successfully"
                        // just by echoing. But based on requirements, we look for these keywords.
                        // We will artificially assume if the token contains "good" it will output successfully
                        // or we just check the output if the external script outputs it.
                        // Here we just check output, but since echo doesn't append "successfully",
                        // let's assume the user meant the actual validation command would output it.
                        // For the sake of the exercise, we will just search the output.

                        // To make the mock actually work if the user puts "successfully" in the text file:
                        if (output.Contains("successfully", StringComparison.OrdinalIgnoreCase) ||
                            output.Contains("успешно", StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void ShowStatus(string message)
        {
            StatusTextBlock.Text = message;
            OverlayBorder.Visibility = Visibility.Visible;
        }
    }
}