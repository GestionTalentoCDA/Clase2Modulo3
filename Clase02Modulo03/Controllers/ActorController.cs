using Clase02Modulo03.Domain.DTOs;
using Clase02Modulo03.Domain.Entities;
using Clase02Modulo03.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Clase02Modulo03.Controllers
{
    [Route( "v1" )]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly SimpleIMDBContext _context;
        public ActorController( SimpleIMDBContext context )
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _context.Actor.ToList() );
        }

        [HttpGet( "{id}", Name = "GetActorById" )]
        public IActionResult GetActorById( [FromRoute] int id )
        {
            return Ok( _context.Actor.Where( a => a.Id == id ).FirstOrDefault() );
        }

        [HttpPost]
        public IActionResult CreateActor( [FromBody] Actor actor )
        {
            _context.Add( actor );
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost( "condto" )]
        public IActionResult CreateActorV2( [FromBody] ActorDTO actor )
        {
            //Mapeo de datos de ActorDT a Actor
            Actor a = new Actor()
            {
                Apellido = actor.Apellido,
                Nombre = actor.Nombre,
                Edad = actor.Edad,
                Genero = actor.Genero,
                Nacionalidad = actor.Nacionalidad,
                NombreArtistico = actor.NombreArtistico
            };

            _context.Add( a );
            _context.SaveChanges();
            //return Ok(); // status code = 200
            return CreatedAtRoute( "GetActorById", new { id = a.Id }, a ); //Status Code 201 Created
        }

        [HttpPut( "{id}" )]
        public IActionResult UpdateActor( [FromRoute] int id, [FromBody] ActorDTO actor )
        {
            //Mapeo de datos de ActorDT a Actor
            var a = _context.Actor.FirstOrDefault( a => a.Id == id );
            a.Nombre = actor.Nombre;
            a.Apellido = actor.Apellido;
            a.Edad = actor.Edad;
            a.NombreArtistico = actor.NombreArtistico;
            a.Genero = actor.Genero;
            a.Nacionalidad = actor.Nacionalidad;

            _context.SaveChanges();
            return Ok( a );
        }

        [HttpPost( "get_actor" )]
        public IActionResult GetActorByIdWithPost( [FromBody] int id )
        {
            return Ok( _context.Actor.FirstOrDefault( a => a.Id == id ) );
        }

    }
}
