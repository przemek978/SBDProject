namespace SBD.Models
{
    public class PilotLot
    {
        public int idPilota { get; set; }
        public Pilot Pilot { get; set; }
        public int idLotu { get; set; }
        public Lot Lot { get; set; }
    }
}
