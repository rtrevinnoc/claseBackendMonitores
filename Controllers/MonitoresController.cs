using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<EMonitor>> Get() => db.Monitors.ToList();


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
    }
}
