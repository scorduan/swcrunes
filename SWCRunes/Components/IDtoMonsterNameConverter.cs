using System;
using System.Globalization;

namespace SWCRunes.Components
{
    public class IDToMonsterNameConverter : IValueConverter
    {
        public IDToMonsterNameConverter(SimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        private SimulationService _simulationService;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _simulationService.GetMonsterNameForId((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }

    }
}

