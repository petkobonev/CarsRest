using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCore.Core
{

    public class InMemoryCarRepositoryProvider
    {
        private static ICarRepository repo;

        public static ICarRepository GetRepo()
        {
            if (repo == null)
            {
                repo = new InMemoryCarRepository();
            }

            return repo;
        }
    }

    public class InMemoryCarRepository : ICarRepository
    {

        private List<Car> cars;

        public InMemoryCarRepository()
        {
            cars = new List<Car>();
        }

        public List<Car> GetAllCars()
        {
            return cars;
        }

        public Car FindCar(string plate)
        {
            return cars.Find(car => car.Plate == plate);
        }

        public Car RegisterCar(RegisterCarRequest request)
        {
            Car car = new Car(request.Plate, request.Kilometers, request.Brand, request.Model);

            cars.Add(car);

            return car;
        }

        public void RemoveCar(string plate)
        {
            cars.RemoveAll(car => car.Plate == plate);
        }

        public Car UpdateCar(string plate, UpdateCarRequest request)
        {
            cars.RemoveAll(carPredicate => carPredicate.Plate == plate);
            Car car = new Car(request.Plate, request.Kilometers, request.Brand, request.Model);
            cars.Add(car);

            return car;
        }
    }
}
