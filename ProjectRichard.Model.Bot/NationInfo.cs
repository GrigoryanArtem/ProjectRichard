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

            stringBuilder.AppendFormat(BotConstants.PropertyFormat, "Свойство", nation.Property);
            stringBuilder.AppendFormat(BotConstants.PropertyFormat, "Здание/Улучшение", nation.Improvements);
            stringBuilder.AppendFormat(BotConstants.PropertyFormat, "Юниты", nation.Units);
            stringBuilder.AppendFormat(BotConstants.PropertyFormat, "Эпоха силы", nation.PowerEra);
            stringBuilder.AppendFormat(BotConstants.PropertyFormat, "Место", nation.Place);
            stringBuilder.AppendFormat(BotConstants.PropertyFormat, "Оценка", nation.Evaluation);
            stringBuilder.AppendFormat(BotConstants.PropertyFormat, "Больше информации", nation.URL);
            
            stringBuilder.AppendLine(BotConstants.Separator);

            return stringBuilder.ToString();
        }
    }
}
