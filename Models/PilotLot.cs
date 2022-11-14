namespace SBD.Models
{
    public class PilotLot
    {
        public int id_pilota { get; set; }
        public Pilot Pilot { get; set; }
        public int id_lotu { get; set; }
        public Lot Lot { get; set; }
    }
}
