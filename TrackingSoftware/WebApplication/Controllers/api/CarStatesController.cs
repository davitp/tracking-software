using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using WebApplication.Models;

namespace WebApplication.Controllers.api
{
    public class CarStatesController : ApiController
    {

        private CarStateRepository repo;
        public CarStatesController() : base(){
            repo = new CarStateRepository();
        }
        // GET api/CarStates
        [HttpGet]
        public CarState Get(int id) {

            return repo.GetLastState(id);
        }
        [HttpPost]
        public IEnumerable<CarState> Post(CarStateHistoryModel model) {

            return repo.GetHistory(model.Id, model.Start, model.End);
        }
    }
}
