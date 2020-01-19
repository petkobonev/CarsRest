using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarCore.Core
{
    public class Car
    {
        public string Plate { get; }
        public int Kilometers { get; }
        public Brand Brand { get; }
        public Model Model { get; }

        public Car(string plate, int kilometers, Brand brand, Model model)
        {
            Plate = plate;
            Kilometers = kilometers;
            Brand = brand;
            Model = model;
        }
    }


    public class Brand
    {
        public string Name { get; }
        public string Country { get; }

        public Brand(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }

    public class Model
    {
        public string Name { get; }
        public int Year { get; }

        public Model(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
