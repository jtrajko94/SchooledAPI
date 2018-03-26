using System;
using System.Text.RegularExpressions;

namespace SchooledAPI.Utilities
{
    public enum ValidatorType
    {
        ZipUS,
        ZipCanada,
        Password,
        PhoneUS,
        Date,
        FutureDate,
        FirstAndLastName,
        Email,
        Integer,
        Double,
        IP,
        AnyValue,
        Blank
    }

    public static class Validator
    {
        public static bool IsValidGuid(string id)
        {
            Guid guid;
            if(Guid.TryParse(id, out guid))
            {
                if(guid != null && guid != Guid.Empty)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsBoundedInteger(int? value, int lowerbound, int upperbound)
        {
            if(value != null && value >= lowerbound && value <= upperbound)
            {
                return true;
            }
            return false;
        }

        public static bool IsValidPassword(string password)
        {
            if(!string.IsNullOrEmpty(password) && password.Length >= 5 && password.Length <= 25)
            {
                return true;
            }
            return false;
        }

        public static bool Item(ValidatorType type, string value)
        {

            switch (type)
            {
                case ValidatorType.ZipUS:
                    return ZipUS(value);
                case ValidatorType.ZipCanada:
                    return ZipCanada(value);
                case ValidatorType.PhoneUS:
                    return PhoneUS(value);
                case ValidatorType.FirstAndLastName:
                    return FirstAndLastName(value);
                case ValidatorType.Email:
                    return Email(value);
                case ValidatorType.AnyValue:
                    return !String.IsNullOrEmpty(value);
                case ValidatorType.Blank:
                    return String.IsNullOrEmpty(value);
                default:
                    return false;
            }
        }

        private static bool IsMatch(string regex, string subject)
        {
            if (string.IsNullOrEmpty(subject)) return false;
            var re = new Regex(regex, RegexOptions.IgnoreCase);
            return re.IsMatch(subject);
        }

        private static bool ZipUS(string subject)
        {
            return IsMatch("^\\d{5}$", subject);
        }

        private static bool ZipCanada(string subject)
        {
            return IsMatch(@"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}((\d[ABCEGHJKLMNPRSTVWXYZ]\d)|)$", subject.ToUpper());
        }

        private static bool PhoneUS(string subject)
        {
            return IsMatch("^(\\([2-9]\\d{2}\\)|[2-9]\\d{2})[- .]?\\d{3}[- .]?\\d{4}$", subject);
        }

        private static bool Email(string subject)
        {
            return IsMatch("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", subject);
        }
        
        private static bool FirstAndLastName(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                return false;
            }
            else
            {
                var s = subject.Trim();
                var sa = s.Split(' ');
                if (s.Contains(" ") & !s.Contains("&"))
                {
                    if (!string.IsNullOrEmpty(sa[0]) & !string.IsNullOrEmpty(sa[sa.Length - 1]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}