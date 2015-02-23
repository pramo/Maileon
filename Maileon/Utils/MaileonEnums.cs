using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Xml.Serialization;

using Maileon.Contacts;
using Maileon.Reports;
using Maileon.Mailings;

namespace Maileon.Utils
{
    /// <summary>
    /// Helper class for converting enums to query parameters
    /// </summary>
    internal class MaileonEnums
    {
        /// <summary>
        /// Returns the XmlEnum value for an enum value
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string GetValue(Enum enumVal)
        {
            Type type = enumVal.GetType();
            MemberInfo[] memInfo = type.GetMember(enumVal.ToString());

            foreach (object attribute in memInfo[0].GetCustomAttributes())
            {
                XmlEnumAttribute xmlEnum = attribute as XmlEnumAttribute;

                if(xmlEnum != null)
                {
                    return xmlEnum.Name;
                }
            }

            return null;

        }
        /*
        public static string GetValue(StandardFieldNames value)
        {
            return Enum.GetName(value.GetType(), value).ToUpper();
        }

        public static string GetValue(DeviceType value)
        {
            return Enum.GetName(typeof(DeviceType), value).ToLower();
        }

        public static string GetValue(MailingFormat value)
        {
            return Enum.GetName(typeof(MailingFormat), value).ToLower();
        }

        public static string GetValue(BounceType value)
        {
            return Enum.GetName(typeof(BounceType), value).ToLower();
        }

        public static string GetValue(BounceSource value)
        {
            switch (value)
            {
                case BounceSource.MtaListener:
                    return "mta-listener";
                default:
                    return "reply";
            }
        }

        public static string GetValue(UnsubscriptionSource value)
        {
            return Enum.GetName(typeof(UnsubscriptionSource), value).ToLower();
        }

        public static string GetValue(BlockReason value)
        {
            switch (value)
            {
                case BlockReason.Blacklist:
                    return "blacklist";
                default:
                    return "bounce_policy";
            }
        }

        public static string GetValue(BlockStatus value)
        {
            return Enum.GetName(typeof(BlockStatus), value).ToLower();
        }

        public static string GetValue(CustomFieldType value)
        {
            return Enum.GetName(typeof(CustomFieldType), value).ToLower();
        }

        public static string GetValue(SocialNetwork network)
        {
            switch (network)
            {
                case SocialNetwork.Delicious:
                    return "DL";
                case SocialNetwork.Digg:
                    return "DG";
                case SocialNetwork.Facebook:
                    return "FB";
                case SocialNetwork.GooglePlus:
                    return "GP";
                case SocialNetwork.LinkedIn:
                    return "LI";
                case SocialNetwork.Mixx:
                    return "MX";
                case SocialNetwork.Myspace:
                    return "MY";
                case SocialNetwork.Reddit:
                    return "RD";
                case SocialNetwork.Studivz:
                    return "SV";
                case SocialNetwork.Stumbleupon:
                    return "SU";
                case SocialNetwork.Twitter:
                    return "TW";
                case SocialNetwork.Xing:
                    return "XG";
                case SocialNetwork.Yigg:
                    return "YG";
                default:
                    return null;
            }
        }

        public static string GetValue(SpeedLevel speedLevel)
        {
            return Enum.GetName(typeof(SpeedLevel), speedLevel).ToLower();
        }

        public static string GetValue(TrackingStrategy t)
        {
            switch (t)
            {
                case TrackingStrategy.HighestPermission:
                    return "highest-permission";
                default:
                    return "none";
            }
        }

        public static string GetValue(MailingStates t)
        {
            return Enum.GetName(typeof(MailingStates), t).ToLower();
        }

        public static string GetValue(MailingFieldNames t)
        {
            switch (t)
            {
                case MailingFieldNames.Type:
                    return "type";
                case MailingFieldNames.State:
                    return "state";
                case MailingFieldNames.Name:
                    return "name";
                case MailingFieldNames.ScheduleTime:
                    return "scheduleTime";
                default:
                    return null;
            }
        }

        public static string GetValue(KeywordOperation o)
        {
            return Enum.GetName(Typeof(KeywordOperation), o).ToLower();
        }*/
    }
}
