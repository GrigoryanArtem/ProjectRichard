namespace ProjectRichard.Model.Bot
{
    internal class BotConstants
    {
        static internal char PrefixChar
        {
            get
            {
                return '-';
            }
        }

        static internal int RollCommandMinValue
        {
            get
            {
                return 1;
            }
        }

        static internal int RollCommandMaxValue
        {
            get
            {
                return 100;
            }
        }

        static internal string Separator
        {
            get
            {
                return new string('ᆖ', 45);
            }
        }

        static internal string PropertyFormat
        {
            get
            {
                return "{0}:\n\t{1}\n";
            }
        }

        static internal string Property
        {
            get
            {
                return "Свойство";
            }
        }

        static internal string Improvements
        {
            get
            {
                return "Здание/Улучшение";
            }
        }

        static internal string Units
        {
            get
            {
                return "Юниты";
            }
        }

        static internal string PowerEra
        {
            get
            {
                return "Эпоха силы";
            }
        }

        static internal string Place
        {
            get
            {
                return "Место";
            }
        }

        static internal string Evaluation
        {
            get
            {
                return "Оценка";
            }
        }

        static internal string URL
        {
            get
            {
                return "Больше информации";
            }
        }

        static internal string MapMainInfoFormat
        {
            get
            {
                return "Карта: {0} [{1}]";
            }
        }

        static internal string IsMarineFormat
        {
            get
            {
                return "Морская?: {0}";
            }
        }

        static internal string DescriptionFormat
        {
            get
            {
                return "Описание: {0}";
            }
        }

        static internal string Yes
        {
            get
            {
                return "Да";
            }
        }

        static internal string No
        {
            get
            {
                return "Нет";
            }
        }

        static internal int MessagesLimit
        {
            get
            {
                return 100;
            }
        }
        
    }
}