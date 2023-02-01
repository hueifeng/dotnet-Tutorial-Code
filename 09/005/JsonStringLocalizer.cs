using Microsoft.Extensions.Localization;
using System.Globalization;

namespace _005
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly Dictionary<string, LocalizationStringEntry> _localizaion;
        public JsonStringLocalizer(Dictionary<string, LocalizationStringEntry> directory)
        {
            _localizaion = new Dictionary<string, LocalizationStringEntry>(directory);
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _localizaion.Where(l => l.Value.LocalizedValue.Keys.Any(lv => lv
     == CultureInfo.CurrentCulture.Name))
                .Select(l => new
    LocalizedString(l.Key, l.Value.LocalizedValue[CultureInfo.CurrentCulture.Name], true));
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetString(string name)
        {
            var query = _localizaion.Where(l => l.Value.LocalizedValue.Keys.Any(lv => lv
    == CultureInfo.CurrentCulture.Name));
            var value = query.FirstOrDefault(l => l.Value.Key == name).Value;
            return value.LocalizedValue[CultureInfo.CurrentCulture.Name];
        }
    }

}
