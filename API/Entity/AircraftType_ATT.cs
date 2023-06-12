namespace API.Entity
{
    public class AircraftType_ATT
    {
        public int aircraftTurnarroundTemplateId { get; set; }
        public AircraftTurnarroundPreset? aircraftTurnarroundTemplate { get; set; }

        public int AircraftTypeId { get; set; }
        public AircraftType? AircraftType { get; set; }
    }
}