using System.Text;
using ProjectRichard.Data;

namespace ProjectRichard.Model.Bot
{
    static public class NationInfo
    {
        static public string Create(Nation nation)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(BotConstants.Separator);

            stringBuilder.AppendLine(nation.Name);
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat(BotConstants.PropertyFormat, BotConstants.Property, nation.Property);
            stringBuilder.AppendLine();

            if (nation.Improvements != null)
            {
                stringBuilder.AppendFormat(BotConstants.PropertyFormat, BotConstants.Improvements, nation.Improvements);
                stringBuilder.AppendLine();
            }

            stringBuilder.AppendFormat(BotConstants.PropertyFormat, BotConstants.Units, nation.Units);
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat(BotConstants.PropertyFormat, BotConstants.PowerEra, nation.PowerEra);
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat(BotConstants.PropertyFormat, BotConstants.Place, nation.Place);
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat(BotConstants.PropertyFormat, BotConstants.Evaluation, nation.Evaluation);
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat(BotConstants.PropertyFormat, BotConstants.URL, nation.URL);
            stringBuilder.AppendLine();

            stringBuilder.AppendLine(BotConstants.Separator);

            return stringBuilder.ToString();
        }
    }
}
