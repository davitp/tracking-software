using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;

namespace WebApplication.Controllers.api
{
    [Authorize]
    public class CarsController : ApiController
    {
        private IEnumerable<Car> cars;

        public CarsController()
            : base() {
            var repo = new CarRepository();
            cars = repo.GetAll();
        }

        // GET api/cars
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cars;
        }

        



    }
}
