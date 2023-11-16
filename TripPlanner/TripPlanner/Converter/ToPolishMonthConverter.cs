
namespace TripPlanner.Converter
{
    internal class ToPolishMonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            string mName = "";
            switch(dt.Month)
            {
                case 1:
                    mName = "sty";
                    break;
                case 2:
                    mName = "lut";
                    break;
                case 3:
                    mName = "mar";
                    break;
                case 4:
                    mName = "kwi";
                    break;
                case 5:
                    mName = "maj";
                    break;
                case 6:
                    mName = "cze";
                    break;
                case 7:
                    mName = "lip";
                    break;
                case 8:
                    mName = "sie";
                    break;
                case 9:
                    mName = "wrz";
                    break;
                case 10:
                    mName = "paź";
                    break;
                case 11:
                    mName = "lis";
                    break;
                case 12:
                    mName = "gru";
                    break;

                default:
                    mName = "sty";
                    break;
            }

            return $"{dt.Day} {mName} {dt.Year}";
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("Going back to what you had isn't supported.");
        }
    }
}
