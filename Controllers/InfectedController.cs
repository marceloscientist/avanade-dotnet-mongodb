using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedOnesCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedOnesCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SetInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.Birthdate, dto.Gender, dto.Latitude, dto.Longitude);

            _infectedOnesCollection.InsertOne(infected);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult GetInfected()
        {
            var infected = _infectedOnesCollection.Find(Builders<Infected>.Filter.Empty).ToList();

            return Ok(infected);
        }

    }
}


