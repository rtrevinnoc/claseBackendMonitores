using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult<List<Room>> Get() => db.Rooms.Include(r => r.monitors).ToList();


        [HttpPost]
        public ActionResult<Room> Post(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();

            return room;
        }

        public class claimMonitorResource
        {
            public Guid roomId { get; set; }
            public Guid monitorId { get; set; }
        }

        [Route("claimMonitor")]
        [HttpPost]
        public ActionResult<Room> ClaimMonitor([FromBody] claimMonitorResource claimMonitorResource)
        {
            Room room = db.Rooms.Find(claimMonitorResource.roomId);
            EMonitor monitor = db.Monitors.Find(claimMonitorResource.monitorId);

            room.monitors.Add(monitor);
            monitor.Room = room;

            db.Monitors.Entry(monitor).Reference(e => e.Room).IsModified = true;
            db.Rooms.Entry(room).Collection(e => e.monitors).IsModified = true;

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
