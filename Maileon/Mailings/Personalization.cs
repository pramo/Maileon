using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

using Maileon.Utils;

namespace Maileon.Mailings
{
    /// <summary>
    /// A class for wrapping a Maileon personalization
    /// </summary>
    [XmlRoot("personalization")]
    public class Personalization
    {
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("property_name")]
        public string PropertyName { get; set; }
        [XmlElement("fallback_value")]
        public string Fallbackvalue { get; set; }
        [XmlElement("occurs_in_conditional_content")]
        public bool OccursInConditionalContent { get; set; }
        [XmlElement("conditional_content_ruleid")]
        public NullableValue<long> ConditionalContentRuleId { get; set; }
        [XmlElement("conditional_content_rulesetid")]
        public NullableValue<long> ConditionalContentRulesetId { get; set; }
        [XmlElement("event_type")]
        public NullableValue<string> EventType { get; set; }
        [XmlElement("option_name")]
        public NullableValue<string> OptionName { get; set; }

        public Personalization() { }
    }
}
