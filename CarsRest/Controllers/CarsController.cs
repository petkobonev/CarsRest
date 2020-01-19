using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarCore.Core;

namespace CarsRest.Controllers
{
    public class CarsController : ApiController
    {
        private ICarRepository carRepository = InMemoryCarRepositoryProvider.GetRepo();

        [HttpGet]
        [Route("api/cars")]
        public HttpResponseMessage GetAllCars()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, carRepository.GetAllCars());
        }

        [HttpGet]
        [Route("api/cars/{plate}")]
        public HttpResponseMessage GetCarByPlate(string plate)
        {
            var car = carRepository.FindCar(plate);

            if (car != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, car);
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [Route("api/cars")]
        public HttpResponseMessage RegisterCar([FromBody]RegisterCarDto request)
        {
            var carRequest = new RegisterCarRequest(
                request.Plate, request.Kilometers,
                new Brand(request.Brand.Name, request.Brand.Country),
                new Model(request.Model.Name, request.Model.Year)
                );

            var savedCar = carRepository.RegisterCar(carRequest);
            return this.Request.CreateResponse(HttpStatusCode.Created, savedCar);
        }

        [HttpPut]
        [Route("api/cars/{plate}")]
        public HttpResponseMessage UpdateSong(string plate, [FromBody]UpdateCarDto request)
        {
            var carRequest = new UpdateCarRequest(
                request.Plate, request.Kilometers,
                new Brand(request.Brand.Name, request.Brand.Country),
                new Model(request.Model.Name, request.Model.Year)
            );
            var updatedSong = carRepository.UpdateCar(plate, carRequest);
            return this.Request.CreateResponse(HttpStatusCode.OK, updatedSong);
        }

        [HttpDelete]
        [Route("api/cars/{plate}")]
        public HttpResponseMessage DeleteSongById(string plate)
        {
            carRepository.RemoveCar(plate);
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }

    public struct UpdateCarDto
    {
        public string Plate { get; }
        public int Kilometers { get; }
        public BrandDto Brand { get; }
        public ModelDto Model { get; }

        public UpdateCarDto(string plate, int kilometers, BrandDto brand, ModelDto model)
        {
            Plate = plate;
            Kilometers = kilometers;
            Brand = brand;
            Model = model;
        }
    }

    public struct RegisterCarDto
    {
        public string Plate { get; }
        public int Kilometers { get; }
        public BrandDto Brand { get; }
        public ModelDto Model { get; }

        public RegisterCarDto(string plate, int kilometers, BrandDto brand, ModelDto model)
        {
            Plate = plate;
            Kilometers = kilometers;
            Brand = brand;
            Model = model;
        }
    }

    public class BrandDto
    {
        public string Name { get; }
        public string Country { get; }

        public BrandDto(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }

    public class ModelDto
    {
        public string Name { get; }
        public int Year { get; }

        public ModelDto(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}

