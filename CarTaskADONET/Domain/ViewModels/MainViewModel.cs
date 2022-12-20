using CarTaskADONET.DataAccess.Entities;
using CarTaskADONET.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
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

        private ObservableCollection<Car> allCars2;

        public ObservableCollection<Car> AllCars2
        {
            get { return allCars; }
            set { allCars = value; OnPropertyChanged(); }
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


        public MainViewModel()
        {
            var carsFromDataBase = App.DB.CarRepository.GetAll();
            ImageHelper helper = new ImageHelper();
            AllCars = new ObservableCollection<Car>(carsFromDataBase);
     



        }

    }

}
