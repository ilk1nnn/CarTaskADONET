using CarTaskADONET.DataAccess.Entities;
using CarTaskADONET.Domain.Commands;
using CarTaskADONET.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CarTaskADONET.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Car> allCars;

        public ObservableCollection<Car> AllCars
        {
            get { return allCars; }
            set { allCars = value; OnPropertyChanged(); }
        }

        // AllIsNew

        private ObservableCollection<string> allIsNew;

        public ObservableCollection<string> AllIsNew
        {
            get { return allIsNew; }
            set { allIsNew = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> allTypes;

        public ObservableCollection<string> AllTypes
        {
            get { return allTypes; }
            set { allTypes = value; OnPropertyChanged(); }
        }


        private ObservableCollection<string> allBrands;

        public ObservableCollection<string> AllBrands
        {
            get { return allBrands; }
            set { allBrands = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> allColors;

        public ObservableCollection<string> AllColors
        {
            get { return allColors; }
            set { allColors = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> allFuels;

        public ObservableCollection<string> AllFuels
        {
            get { return allFuels; }
            set { allFuels = value; OnPropertyChanged(); }
        }


        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; OnPropertyChanged(); }
        }


        private ImageSource iS;

        public ImageSource IS
        {
            get { return iS; }
            set { iS = value; OnPropertyChanged(); }
        }


        private string brand;

        public string Brand
        {
            get { return brand; }
            set { brand = value; OnPropertyChanged(); }
        }


        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(); }
        }


        public RelayCommand SelectedBrandCommand { get; set; }

        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectedIsNewCommand { get; set; }

        public RelayCommand FilterCommand { get; set; }

        private TextBox min;

        public TextBox Min
        {
            get { return min; }
            set { min = value; OnPropertyChanged(); }
        }

        private TextBox max;

        public TextBox Max
        {
            get { return max; }
            set { max = value; OnPropertyChanged(); }
        }


        private TextBox minprice;

        public TextBox MinPrice
        {
            get { return minprice; }
            set { minprice = value; OnPropertyChanged(); }
        }

        private TextBox maxprice;

        public TextBox MaxPrice
        {
            get { return maxprice; }
            set { maxprice = value; OnPropertyChanged(); }
        }


        private TextBox year;

        public TextBox Year
        {
            get { return year; }
            set { year = value;OnPropertyChanged(); }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged(); }
        }

        private string fuel;

        public string Fuel
        {
            get { return fuel; }
            set { fuel = value; OnPropertyChanged(); }
        }



        public MainViewModel()
        {
            var carsFromDataBase = App.DB.CarRepository.GetAll();
            ImageHelper helper = new ImageHelper();
            AllCars = new ObservableCollection<Car>(carsFromDataBase);
            AllBrands = new ObservableCollection<string>();
            AllIsNew = new ObservableCollection<string>();
            AllTypes = new ObservableCollection<string>();
            AllFuels = new ObservableCollection<string>();
            AllColors = new ObservableCollection<string>();
            for (int i = 0; i < AllCars.Count(); i++)
            {
                var brand = AllCars[i].Brand;
                string result = brand.ToString();

                if(!AllBrands.Contains(result))
                {
                    AllBrands.Add(result);
                }

                var is_new = AllCars[i].IsNew;
                string result2 = is_new.ToString();

                if(!AllIsNew.Contains(result2))
                {
                    AllIsNew.Add(result2);
                }

                var types = AllCars[i].Type;
                string result3 = types.ToString();

                if(!AllTypes.Contains(result3))
                {
                    AllTypes.Add(result3);
                }

                var colors = AllCars[i].Color;
                string result4 = colors.ToString();
                if(!AllColors.Contains(result4))
                {
                    AllColors.Add(result4);
                }

                var fuels = AllCars[i].FuelType;
                string result5 = fuels.ToString();
                if(!AllFuels.Contains(result5))
                {
                    AllFuels.Add(result5);
                }

            }

      


            FilterCommand = new RelayCommand(f =>
            {
                AllCars = new ObservableCollection<Car>(carsFromDataBase);
                int minimum = int.Parse(Min.Text);
                int maximum = int.Parse(Max.Text);
                int m_price = int.Parse(MinPrice.Text);
                int mx_price = int.Parse(MaxPrice.Text);
                int year = int.Parse(Year.Text);
                if(Min.Text == String.Empty)
                {
                    minimum = 0;
                }
                if(Max.Text == String.Empty)
                {
                    maximum = 0;
                }
                if (MinPrice.Text == String.Empty)
                {
                    m_price = 0;
                }
                if (MaxPrice.Text == String.Empty)
                {
                    mx_price = 0;
                }
                var cardatabase = AllCars.Where(c => (c.Brand == Brand) && c.IsNew == IsNew && c.Type == Type && (minimum <= c.Mileage || c.Mileage <= maximum) && (m_price <= c.Price || mx_price <= c.Price) && c.Year == year  && c.Color == Color && c.FuelType == Fuel).ToList();
                AllCars = new ObservableCollection<Car>(cardatabase);
            });



        }

    }

}
