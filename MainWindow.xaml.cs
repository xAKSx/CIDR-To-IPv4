using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace CIDR_TO_IPv4_PRO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void octact5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int parsedValue))
            {
                // If the input is not a valid number, reject it
                e.Handled = true;
            }
            else
            {
                // Ensure the value is between 0 and 32
                TextBox textBox = sender as TextBox;
                string newText = textBox.Text.Substring(0, textBox.SelectionStart) + e.Text + textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength);

                if (int.TryParse(newText, out int newValue) && (newValue < 0 || newValue > 32))
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Clear the text if it is the first time the text box is focused
                if (textBox.Tag == null)
                {
                    textBox.Text = "";
                    textBox.Tag = "Cleared";
                }

                // Set the caret index to the end of the text
                textBox.CaretIndex = textBox.Text.Length;
            }
        }



        private void NumericInputValidation(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            
            if (!int.TryParse(e.Text, out int parsedValue))
            {
                // If the input is not a valid number, reject it
                e.Handled = true;
            }
            else
            {
                // Ensure the value is between 0 and 255
                string newText = textBox.Text.Substring(0, textBox.SelectionStart) + e.Text + textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength);

                if (int.TryParse(newText, out int newValue) && (newValue < 0 || newValue > 255))
                {
                    e.Handled = true;
                }
            }

            if (textBox != null)
            {
                // Check if the entered character is a digit or a decimal point
                if (char.IsDigit(e.Text, 0) || e.Text == ".")
                {
                    // Check if the current text box has 3 digits or a decimal point
                    if (textBox.Text.Length == 3 || textBox.Text.Contains("."))
                    {
                        // Shift focus to the next text box
                        textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    }
                }
                else
                {
                    // Cancel the input
                    e.Handled = true;
                }
            }
        }

        private void octact1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(octact1.Text, out int decimalValue))
            {
                if (decimalValue >= 0 && decimalValue <= 255)
                {
                    string binaryValue = Convert.ToString(decimalValue, 2).PadLeft(8, '0');

                    // Update each bit TextBox with its corresponding bit from the binary representation
                    Bit7TextBox.Text = binaryValue.Substring(0, 1);
                    Bit6TextBox.Text = binaryValue.Substring(1, 1);
                    Bit5TextBox.Text = binaryValue.Substring(2, 1);
                    Bit4TextBox.Text = binaryValue.Substring(3, 1);
                    Bit3TextBox.Text = binaryValue.Substring(4, 1);
                    Bit2TextBox.Text = binaryValue.Substring(5, 1);
                    Bit1TextBox.Text = binaryValue.Substring(6, 1);
                    Bit0TextBox.Text = binaryValue.Substring(7, 1);
                }
                else
                {
                    // Handle invalid input (outside the range 0-255)
                    // For example, clear all bit TextBoxes
                    Bit7TextBox.Text = "";
                    Bit6TextBox.Text = "";
                    Bit5TextBox.Text = "";
                    Bit4TextBox.Text = "";
                    Bit3TextBox.Text = "";
                    Bit2TextBox.Text = "";
                    Bit1TextBox.Text = "";
                    Bit0TextBox.Text = "";
                }
            }
            else
            {
                // Handle non-numeric input
                // For example, clear all bit TextBoxes
                Bit7TextBox.Text = "";
                Bit6TextBox.Text = "";
                Bit5TextBox.Text = "";
                Bit4TextBox.Text = "";
                Bit3TextBox.Text = "";
                Bit2TextBox.Text = "";
                Bit1TextBox.Text = "";
                Bit0TextBox.Text = "";
            }
            CalculateIPRanges(sender, e);
        }

        private void octact2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(octact2.Text, out int decimalValue))
            {
                if (decimalValue >= 0 && decimalValue <= 255)
                {
                    string binaryValue = Convert.ToString(decimalValue, 2).PadLeft(8, '0');

                    // Update each bit TextBox with its corresponding bit from the binary representation
                    Bit7TextBox2.Text = binaryValue.Substring(0, 1);
                    Bit6TextBox2.Text = binaryValue.Substring(1, 1);
                    Bit5TextBox2.Text = binaryValue.Substring(2, 1);
                    Bit4TextBox2.Text = binaryValue.Substring(3, 1);
                    Bit3TextBox2.Text = binaryValue.Substring(4, 1);
                    Bit2TextBox2.Text = binaryValue.Substring(5, 1);
                    Bit1TextBox2.Text = binaryValue.Substring(6, 1);
                    Bit0TextBox2.Text = binaryValue.Substring(7, 1);
                }
                else
                {
                    // Handle invalid input (outside the range 0-255)
                    // For example, clear all bit TextBoxes
                    Bit7TextBox2.Text = "";
                    Bit6TextBox2.Text = "";
                    Bit5TextBox2.Text = "";
                    Bit4TextBox2.Text = "";
                    Bit3TextBox2.Text = "";
                    Bit2TextBox2.Text = "";
                    Bit1TextBox2.Text = "";
                    Bit0TextBox2.Text = "";
                }
            }
            else
            {
                // Handle non-numeric input
                // For example, clear all bit TextBoxes
                Bit7TextBox2.Text = "";
                Bit6TextBox2.Text = "";
                Bit5TextBox2.Text = "";
                Bit4TextBox2.Text = "";
                Bit3TextBox2.Text = "";
                Bit2TextBox2.Text = "";
                Bit1TextBox2.Text = "";
                Bit0TextBox2.Text = "";
            }
            CalculateIPRanges(sender, e);
        }

        private void octact3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(octact3.Text, out int decimalValue))
            {
                if (decimalValue >= 0 && decimalValue <= 255)
                {
                    string binaryValue = Convert.ToString(decimalValue, 2).PadLeft(8, '0');

                    // Update each bit TextBox with its corresponding bit from the binary representation
                    Bit7TextBox3.Text = binaryValue.Substring(0, 1);
                    Bit6TextBox3.Text = binaryValue.Substring(1, 1);
                    Bit5TextBox3.Text = binaryValue.Substring(2, 1);
                    Bit4TextBox3.Text = binaryValue.Substring(3, 1);
                    Bit3TextBox3.Text = binaryValue.Substring(4, 1);
                    Bit2TextBox3.Text = binaryValue.Substring(5, 1);
                    Bit1TextBox3.Text = binaryValue.Substring(6, 1);
                    Bit0TextBox3.Text = binaryValue.Substring(7, 1);
                }
                else
                {
                    // Handle invalid input (outside the range 0-255)
                    // For example, clear all bit TextBoxes
                    Bit7TextBox3.Text = "";
                    Bit6TextBox3.Text = "";
                    Bit5TextBox3.Text = "";
                    Bit4TextBox3.Text = "";
                    Bit3TextBox3.Text = "";
                    Bit2TextBox3.Text = "";
                    Bit1TextBox3.Text = "";
                    Bit0TextBox3.Text = "";
                }
            }
            else
            {
                // Handle non-numeric input
                // For example, clear all bit TextBoxes
                Bit7TextBox3.Text = "";
                Bit6TextBox3.Text = "";
                Bit5TextBox3.Text = "";
                Bit4TextBox3.Text = "";
                Bit3TextBox3.Text = "";
                Bit2TextBox3.Text = "";
                Bit1TextBox3.Text = "";
                Bit0TextBox3.Text = "";
            }
            CalculateIPRanges(sender, e);
        }

        private void octact4_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (int.TryParse(octact4.Text, out int decimalValue))
            {
                if (decimalValue >= 0 && decimalValue <= 255)
                {
                    string binaryValue = Convert.ToString(decimalValue, 2).PadLeft(8, '0');

                    // Update each bit TextBox with its corresponding bit from the binary representation
                    Bit7TextBox4.Text = binaryValue.Substring(0, 1);
                    Bit6TextBox4.Text = binaryValue.Substring(1, 1);
                    Bit5TextBox4.Text = binaryValue.Substring(2, 1);
                    Bit4TextBox4.Text = binaryValue.Substring(3, 1);
                    Bit3TextBox4.Text = binaryValue.Substring(4, 1);
                    Bit2TextBox4.Text = binaryValue.Substring(5, 1);
                    Bit1TextBox4.Text = binaryValue.Substring(6, 1);
                    Bit0TextBox4.Text = binaryValue.Substring(7, 1);
                }
                else
                {
                    // Handle invalid input (outside the range 0-255)
                    // For example, clear all bit TextBoxes
                    Bit7TextBox4.Text = "";
                    Bit6TextBox4.Text = "";
                    Bit5TextBox4.Text = "";
                    Bit4TextBox4.Text = "";
                    Bit3TextBox4.Text = "";
                    Bit2TextBox4.Text = "";
                    Bit1TextBox4.Text = "";
                    Bit0TextBox4.Text = "";
                }
            }
            else
            {
                // Handle non-numeric input
                // For example, clear all bit TextBoxes
                Bit7TextBox4.Text = "";
                Bit6TextBox4.Text = "";
                Bit5TextBox4.Text = "";
                Bit4TextBox4.Text = "";
                Bit3TextBox4.Text = "";
                Bit2TextBox4.Text = "";
                Bit1TextBox4.Text = "";
                Bit0TextBox4.Text = "";
            }
            CalculateIPRanges(sender, e);
        }


        private void octact5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(octact5.Text, out int maxValue))
            {
                if (maxValue >= 0 && maxValue <= 32)
                {
                    if (maxValue == 0)
                    {
                        
                        count.Text = (Math.Pow(2,32)).ToString("N0");
                        netMask.Text = "0.0.0.0";
                    }
                    else
                    {
                        int hostBits = 32 - maxValue; // Calculate the number of host bits
                        uint numberOfHosts = (uint)Math.Pow(2, hostBits); // Calculate the number of 
                        count.Text = numberOfHosts.ToString("N0");
                        string netmask = CalculateNetmask(maxValue);
                        netMask.Text = netmask; // Set the calculated netmask in the designated text box
                    }
                    SolidColorBrush[] customColors =
                    {
                         new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF35325")), // Red for StackPanel1
                         new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF81BC06")), // Green for StackPanel2
                         new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF05A6F0")), // Blue for StackPanel3
                         new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFBA08"))  // Yellow for StackPanel4
                    };

                    // Reset all text box colors to default
                    ResetTextBoxesColor();

                    // Update the color of specific text boxes in each stack panel
                    UpdateStackPanels(maxValue, customColors);
                }
            }
            CalculateIPRanges(sender, e);
          
        }

        private string CalculateNetmask(int subnetValue)
        {
            // Calculate the netmask in CIDR notation based on the subnet value
            uint netmask = (uint)(0xFFFFFFFF << (32 - subnetValue));
            return new IPAddress(BitConverter.GetBytes(netmask).Reverse().ToArray()).ToString();
        }

        private void ResetTextBoxesColor()
        {
            // Function to reset the color of all text boxes in each stack panel
            foreach (StackPanel stackPanel in new[] { StackPanel1, StackPanel2, StackPanel3, StackPanel4 })
            {
                foreach (TextBox textBox in stackPanel.Children.OfType<TextBox>())
                {
                    textBox.Background = Brushes.Transparent; // Set the default background color
                }
            }
        }

        private void UpdateStackPanels(int totalTextBoxesToColor, SolidColorBrush[] customColors)
        {
            int boxesColored = 0;
            int currentColorIndex = 0;

            foreach (StackPanel stackPanel in new[] { StackPanel1, StackPanel2, StackPanel3, StackPanel4 })
            {
                SolidColorBrush colorForPanel = customColors[currentColorIndex];

                foreach (TextBox textBox in stackPanel.Children.OfType<TextBox>())
                {
                    if (boxesColored < totalTextBoxesToColor)
                    {
                        // Change the color of the text box
                        textBox.Background = colorForPanel; // Assign the custom color for the stack panel
                        boxesColored++;
                    }
                    else
                    {
                        // Break if the required number of text boxes are already colored
                        break;
                    }
                }

                currentColorIndex++;

                if (boxesColored >= totalTextBoxesToColor)
                {
                    // Break if the required number of text boxes are already colored
                    break;
                }
            }
        }
        
        private void CalculateIPRanges(object sender, TextChangedEventArgs e)
        {
            if (octact1 != null && int.TryParse(octact1.Text, out int octet1) &&
                octact2 != null && int.TryParse(octact2.Text, out int octet2) &&
                octact3 != null && int.TryParse(octact3.Text, out int octet3) &&
                octact4 != null && int.TryParse(octact4.Text, out int octet4) &&
                octact5 != null && int.TryParse(octact5.Text, out int subnetValue))
            {
                
                // Calculate the network address
                uint ipAddress = (uint)((octet1 << 24) | (octet2 << 16) | (octet3 << 8) | octet4);
                uint subnetMask = (uint)(0xFFFFFFFF << (32 - subnetValue));
                uint networkAddress = ipAddress & subnetMask;

                // Calculate the number of hosts
                int hostBits = 32 - subnetValue;
                uint numberOfHosts = (uint)Math.Pow(2, hostBits);
                //numberOfHosts -= 2; // Exclude the network and broadcast addresses

                // Calculate the broadcast address
                uint broadcastAddress = networkAddress + numberOfHosts - 1;

                // Calculate the first and last usable IP addresses
                uint firstUsableIP = networkAddress + 1;
                uint lastUsableIP = broadcastAddress - 1;

                // Display the results in respective TextBoxes
                baseIP.Text = new IPAddress(BitConverter.GetBytes(networkAddress).Reverse().ToArray()).ToString();
                broadcastIP.Text = new IPAddress(BitConverter.GetBytes(broadcastAddress).Reverse().ToArray()).ToString();
                firstIP.Text = new IPAddress(BitConverter.GetBytes(firstUsableIP).Reverse().ToArray()).ToString();
                lastIP.Text = new IPAddress(BitConverter.GetBytes(lastUsableIP).Reverse().ToArray()).ToString();
            }
        }


    }

}
