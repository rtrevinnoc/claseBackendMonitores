using System.ComponentModel.DataAnnotations;

namespace Monitores.Entidades
{
    public class EMonitor
    {
        [Key]
        public Guid EMonitorId { get; set; }

        public float size { get; set; }

        public DisplayType displayType { get; set; }

        public int refreshRate { get; set; }

        public Brand brand { get; set; }

        public float price { get; set; }
    }

    public enum DisplayType
    {
        WQHD,
        UHD,
        FHD,
        SD
    }

    public enum Brand
    {
        Samsung,
        LG,
        Sony
    }
}
