using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCore.Core
{
    public interface ICarRepository
    {
        Car RegisterCar(RegisterCarRequest request);

        List<Car> GetAllCars();

        Car FindCar(string plate);

        Car UpdateCar(string plate, UpdateCarRequest request);

        void RemoveCar(string plate);
    }


    public struct RegisterCarRequest
    {
        public string Plate { get; }
        public int Kilometers { get; }
        public Brand Brand { get; }
        public Model Model { get; }

        public RegisterCarRequest(string plate, int kilometers, Brand brand, Model model)
        {
            Plate = plate;
            Kilometers = kilometers;
            Brand = brand;
            Model = model;
        }
    }

    public struct UpdateCarRequest
    {
        public string Plate { get; }
        public int Kilometers { get; }
        public Brand Brand { get; }
        public Model Model { get; }

        public UpdateCarRequest(string plate, int kilometers, Brand brand, Model model)
        {
            Plate = plate;
            Kilometers = kilometers;
            Brand = brand;
            Model = model;
        }
    }
}
