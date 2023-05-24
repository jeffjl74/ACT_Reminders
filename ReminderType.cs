using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACT_Reminders
{
    public class ReminderType
    {

        [XmlAttribute]
        public int ID { get; set; }

        [XmlIgnore]
        public bool Use { get; set; } = false;

        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public int QuietTime { get; set; }

        [XmlAttribute]
        public string Regexp { get; set; }

        [XmlIgnore]
        public Regex Trigger { get; set; }

        [XmlIgnore]
        public DateTime Started { get; set; } = DateTime.MinValue;

        public override string ToString()
        {
            return $"{ID}|{Title}|{Regexp}";
        }
    }
}
