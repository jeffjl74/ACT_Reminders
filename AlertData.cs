using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACT_Reminders
{
    public class AlertData
    {
        [XmlAttribute]
        public int ReminderId { get; set; }
        [XmlAttribute]
        public string Text { get; set; } = "";
        [XmlAttribute]
        public bool AudioAlert { get; set; }
        [XmlAttribute]
        public bool VisualAlert { get; set; }
        [XmlAttribute]
        public int AudioDelay { get; set; } = 5;
        [XmlAttribute]
        public int VisualDelay { get; set; } = 5;
    }
}
