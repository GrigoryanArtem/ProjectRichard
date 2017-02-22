using ProjectRichard.Data;
using System.Text;

namespace ProjectRichard.Model.Bot
{
    public static class MapInfo
    {
        public static string Create(Map map)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(BotConstants.MapMainInfoFormat, map.Name, map.Evaluation);
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat(BotConstants.IsMarineFormat, map.IsMarine ? BotConstants.Yes : BotConstants.No);
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat(BotConstants.DescriptionFormat, map.Description);
            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }
    }
}
