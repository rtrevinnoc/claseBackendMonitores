using System.ComponentModel.DataAnnotations;

namespace Monitores.Entidades
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; }

        public float width { get; set; }

        public float length { get; set; }

        public ICollection<EMonitor> monitors { get; set; }

        public Room()
        {
            this.monitors = new List<EMonitor>();
        }
    }
}
