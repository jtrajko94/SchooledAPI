using System.Text.RegularExpressions;

namespace SchooledAPI.Utilities
{
    public static class TextMethods
    {
        public static string ToLastName(this string fullName)
        {
            string result;

            if (fullName.Contains(" "))
            {
                result = fullName.Substring(fullName.IndexOf(" "));
            }
            else
            {
                result = "NA";
            }

            return result.Trim();
        }

        public static string ToFirstName(this string fullName)
        {
            string result;

            if (fullName.Contains(" "))
            {
                result = fullName.Substring(0, fullName.IndexOf(" "));
            }
            else
            {
                result = fullName;
            }

            if (string.IsNullOrEmpty(result)) result = "NA";
            return result.Trim();
        }

        public static string ToPhone(this string text, bool numbersOnly = false)
        {
            var match = Regex.Match(text, @"^(1|\+1|)[- .]?(\((?<areacode>[2-9]\d{2})\)|(?<areacode>[2-9]\d{2}))[- .]?" +
                @"(?<exchange>\d{3})[- .]?(?<number>\d{4})$", RegexOptions.IgnoreCase);

            if (!match.Success)
                return text;

            var areacode = match.Groups["areacode"].Value;
            var exchange = match.Groups["exchange"].Value;
            var number = match.Groups["number"].Value;

            if (numbersOnly)
                return areacode + exchange + number;

            return string.Format("({0}) {1}-{2}", areacode, exchange, number);
        }

        public static string NoNull(this string value)
        {
            return (value == null) ? "" : value.Trim();
        }

        public static string ToFriendly(this string text, int limit = 0, string seperator = "-", bool makeLower = true)
        {
            if (text != null)
            {
                text = Regex.Replace(text, "_", "-");
                text = Regex.Replace(text.Trim(), "[^a-zA-Z0-9\\s-]", "");
                text = Regex.Replace(text, "[\\s]", seperator);
                while (text.Contains("--"))
                {
                    text = text.Replace("--", "-");
                }
                if (limit > 0 && text.Length > limit)
                {
                    text = text.Substring(0, limit).ToLower();
                    text = text.Substring(0, text.LastIndexOf("-"));
                    return text;
                }
                else
                {
                    if (makeLower)
                    {
                        return text.ToLower();
                    }
                    else
                    {
                        return text;
                    }
                }
            }
            else
            {
                return "";
            }
        }
    }
}