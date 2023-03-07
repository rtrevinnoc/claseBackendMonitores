using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monitores.Entidades;

namespace Monitores.Controllers
{
    [ApiController]
    [Route("api/monitores")]
    public class MonitoresController : ControllerBase
    {
        private ApplicationDbContext db;

        public MonitoresController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]
        public ActionResult<List<EMonitor>> Get() => db.Monitors.Include(r => r.Room).ToList();


        [HttpPost]
        public ActionResult<EMonitor> Post(EMonitor monitor)
        {
            db.Monitors.Add(monitor);
            db.SaveChanges();

            return monitor;
        }

        [HttpDelete]
        public ActionResult<EMonitor> Delete(Guid id)
        {
            EMonitor monitor = db.Monitors.Find(id);
            db.Monitors.Remove(monitor);
            db.SaveChanges();

            return monitor;
        }

        [HttpPut]
        public ActionResult<EMonitor> Put(EMonitor updatedMonitor)
        {
            var oldMonitor = db.Monitors.Find(updatedMonitor.EMonitorId);

            db.Monitors.Entry(oldMonitor).CurrentValues.SetValues(updatedMonitor);
            db.SaveChanges();

            return updatedMonitor;
        }

        public class addToRoomResource
        {
            public Guid roomId { get; set; }
            public Guid monitorId { get; set; }
        }

        [Route("addToRoom")]
        [HttpPost]
        public ActionResult<EMonitor> AddToRoom([FromBody] addToRoomResource addToRoomResource)
        {
            EMonitor monitor = db.Monitors.Find(addToRoomResource.monitorId);
            Room room = db.Rooms.Find(addToRoomResource.roomId);

            room.monitors.Add(monitor);
            monitor.Room = room;

            db.Monitors.Entry(monitor).Reference(e => e.Room).IsModified = true;
            db.Rooms.Entry(room).Collection(e => e.monitors).IsModified = true;

            db.SaveChanges();

            return monitor;
        }
    }
}
