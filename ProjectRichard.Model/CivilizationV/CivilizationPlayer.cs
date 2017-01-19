using ProjectRichard.Data;

namespace ProjectRichard.Model.CivilizationV
{
    public class CivilizationPlayer : Player
    {
        public Nation BannedNation { get; set; }

        public CivilizationPlayer(string name) : base(name) { }

        public override string ToString()
        {
            return Name;
        }
    }
}
