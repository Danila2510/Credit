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

namespace Credit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DependencyPropertyDescriptor.FromProperty(Slider.ValueProperty, typeof(Slider))
                .AddValueChanged(slider, UpdateCreditLimit);

            DependencyPropertyDescriptor.FromProperty(TextBox.TextProperty, typeof(TextBox))
                .AddValueChanged(textBox, UpdateCreditLimit);
        }

        private void UpdateCreditLimit(object sender, EventArgs e)
        {
            double income;
            if (double.TryParse(textBox.Text, out income))
            {
                double maxCreditLimit = income * 2;
                slider.Maximum = maxCreditLimit;
                credit.Text = "Acceptable loan amount: " + slider.Value.ToString();
            }
        }
    }
}