using MatchApi.PlayerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MatchApi.Controllers
{
    public class PlayerController : ApiController
    {
        [HttpGet]
        [Route("Players")]
        public IEnumerable<Player> GetPlayers()
        {
            using(var client = new PlayerServiceClient())
            {
                return client.GetPlayers();
            }
        }

        [HttpGet]
        [Route("Player/{id}")]
        public IHttpActionResult GetPlayer(int id)
        {
            using (var client = new PlayerServiceClient())
            {
                if (client.GetPlayer(id) != null)
                {
                    return Ok(client.GetPlayer(id));
                }
                return NotFound();
            }
        }
        
        [HttpPost]
        [Route("InsertPlayer")]
        public IHttpActionResult InsertPlayer(Player player)
        {
            using (var client = new PlayerServiceClient())
            {
                if (client.Insert(player))
                {
                    return Ok("Inserted Successfully");
                }
                return BadRequest("Cannot be Inserted");
            }
        }


        [HttpPut]
        [Route("UpdatePlayer")]
        public IHttpActionResult UpdatePlayer(Player player)
        {

            using (var client = new PlayerServiceClient())
            {
                if (client.Update(player))
                {
                    return Ok("Updated Successfully");
                }
                return BadRequest("Cannot be Updated");
            }
        }


        [HttpDelete]
        [Route("DeletePlayer/{id}")]
        public IHttpActionResult DeletePlayer(int id)
        {
            using (var client = new PlayerServiceClient())
            {
                if (client.Delete(id))
                {
                    return Ok("Deleted Successfully");
                }
                return BadRequest("Cannot be Deleted");
            }
        }
    }
}
