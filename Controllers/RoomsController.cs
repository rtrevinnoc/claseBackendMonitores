using Microsoft.AspNetCore.Mvc;
using Monitores.Entidades;

namespace Monitores.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private ApplicationDbContext db;

        public RoomsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Room>> Get() => db.Rooms.ToList();


        [HttpPost]
        public ActionResult<Room> Post(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();

            return room;
        }

        [HttpDelete]
        public ActionResult<Room> Delete(Guid id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();

            return room;
        }

        [HttpPut]
        public ActionResult<Room> Put(Room updatedRoom)
        {
            var oldRoom = db.Rooms.Find(updatedRoom.RoomId);

            db.Rooms.Entry(oldRoom).CurrentValues.SetValues(updatedRoom);
            db.SaveChanges();

            return updatedRoom;
        }
    }
}
