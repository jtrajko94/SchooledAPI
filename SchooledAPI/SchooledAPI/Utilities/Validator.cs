using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

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
        public static bool Item(ValidatorType type, string value)
        {

            switch (type)
            {
                case ValidatorType.ZipUS:
                    return ZipUS(value);
                case ValidatorType.ZipCanada:
                    return ZipCanada(value);
                case ValidatorType.Password:
                    return Password(value);
                case ValidatorType.PhoneUS:
                    return PhoneUS(value);
                case ValidatorType.Date:
                    return Date(value);
                case ValidatorType.FutureDate:
                    return FutureDate(value);
                case ValidatorType.FirstAndLastName:
                    return FirstAndLastName(value);
                case ValidatorType.Email:
                    return Email(value);
                case ValidatorType.Double:
                    return IsDouble(value);
                case ValidatorType.IP:
                    return IsIP(value);
                case ValidatorType.Integer:
                    return IsInteger(value);
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

        private static bool Password(string subject)
        {
            return IsMatch("^(?=.{8,})(?=.*[0-9].*)(?=.*[a-z].*).*$", subject);
        }

        private static bool PhoneUS(string subject)
        {
            return IsMatch("^(\\([2-9]\\d{2}\\)|[2-9]\\d{2})[- .]?\\d{3}[- .]?\\d{4}$", subject);
        }

        private static bool Email(string subject)
        {
            return IsMatch("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", subject);
        }

        private static bool IsDouble(string subject)
        {
            double val;
            return Double.TryParse(subject, out val);
        }

        private static bool IsInteger(string subject)
        {
            int val;
            return Int32.TryParse(subject, out val);
        }

        private static bool IsIP(string subject)
        {
            return IsMatch(@"^[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}?", subject);
        }

        private static bool Date(string subject)
        {
            try
            {
                DateTime d = DateTime.Parse(subject);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool FutureDate(string subject)
        {
            try
            {
                DateTime d = DateTime.Parse(subject);
                if (d > DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
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