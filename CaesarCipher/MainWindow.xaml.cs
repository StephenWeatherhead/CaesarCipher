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

namespace CaesarCipher
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

        private static char Encrypt(int shift, char character)
        {
            int number = GetNumber(character);
            if (number == -1)
                return character;
            number = (number + shift) % 26;
            if (number < 0)
                number += 26;
            else if (number > 25)
                number -= 26;
            return GetLetter(number);
        }

        private static char Decrypt(int shift, char character)
        {
            int number = GetNumber(character);
            if (number == -1)
                return character;
            number = (number - shift) % 26;
            if (number < 0)
                number += 26;
            else if (number > 25)
                number -= 26;
            return GetLetter(number);
        }

        private static char GetLetter(int number)
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[number];
        }

        private static int GetNumber(char character)
        {
            character = Char.ToUpper(character);
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(character);
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            EncryptedTextTextBox.Clear();
            int shift = int.Parse(ShiftTextBox.Text);
            foreach(char letter in PlainTextTextBox.Text)
            {
                EncryptedTextTextBox.AppendText(Encrypt(shift,letter).ToString());
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            EncryptedTextTextBox.Clear();
            int shift = int.Parse(ShiftTextBox.Text);
            foreach (char letter in PlainTextTextBox.Text)
            {
                EncryptedTextTextBox.AppendText(Decrypt(shift, letter).ToString());
            }
        }
    }
}
