using ProjectRichard.Data;

namespace ProjectRichard.Model.CivilizationV
{
    public class CivilizationPlayer : Player
    {
        public Nation BannedNation { get; set; }

        public CivilizationPlayer(string name, Nation bannedNation) : base(name)
        {
            BannedNation = bannedNation;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
