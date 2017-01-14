namespace ProjectRichard.Model.Bot
{
    internal class BotConstants
    {
        static internal char PrefixChar
        {
            get
            {
                return '!';
            }
        }

        static internal string TimeCommand
        {
            get
            {
                return "time";
            }
        }
        static internal string GetNationInfoCommand
        {
            get
            {
                return "nation";
            }
        }

        static internal string UpdateCommand
        {
            get
            {
                return "update";
            }
        }

        static internal string Separator
        {
            get
            {
                return new string('=', 50);
            }
        }

        static internal string PropertyFormat
        {
            get
            {
                return "{0}:\n\t{1}\n";
            }
        }
        
    }
}
