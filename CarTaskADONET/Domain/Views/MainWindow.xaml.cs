using CarTaskADONET.Domain.ViewModels;
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

namespace CarTaskADONET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            if (mintxtb.Text == String.Empty)
            {
                mintxtb.Text = "0";
            }
            vm.Min = mintxtb;
            vm.Max = maxtxtb;
            if (minpricetxtb.Text == String.Empty)
            {
                minpricetxtb.Text = "0";
            }
            int max = vm.AllCars[0].Price;
            for (int i = 0; i < vm.AllCars.Count(); i++)
            {
                if (max < vm.AllCars[i].Price)
                {
                    max = vm.AllCars[i].Price;
                }
            }
            if (maxpricetxtb.Text == String.Empty)
            {
                maxpricetxtb.Text = max.ToString();
            }

            int max_mil = vm.AllCars[0].Mileage;
            for (int i = 0; i < vm.AllCars.Count(); i++)
            {
                if (max_mil < vm.AllCars[i].Mileage)
                {
                    max_mil = vm.AllCars[i].Mileage;
                }
            }
            if(maxtxtb.Text == String.Empty)
            {
                maxtxtb.Text = max_mil.ToString();
            }
            vm.MinPrice = minpricetxtb;
            vm.MaxPrice = maxpricetxtb;
            if(yeartxtb.Text == String.Empty)
            {
                yeartxtb.Text = "0";
            }
            vm.Year = yeartxtb;
            this.DataContext = vm;
        }
    }
}
