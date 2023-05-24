using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACT_Reminders
{
    public class Player :IEquatable<Player>
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool Blink { get; set; } = true;

        [XmlAttribute]
        public int AlertLocX { get; set; }
        [XmlAttribute]
        public int AlertLocY { get; set; }
        [XmlAttribute]
        public int AlertWidth { get; set; }

        public List<AlertData> Alerts = new List<AlertData>();

        public Player() { }

        public void Copy(Player source)
        {
            this.Blink = source.Blink;
            this.AlertLocX = source.AlertLocX;
            this.AlertLocY = source.AlertLocY;
            this.AlertWidth = source.AlertWidth;

            AlertData[] dup = new AlertData[source.Alerts.Count];
            source.Alerts.CopyTo(dup);
            this.Alerts = dup.ToList();

        }

        public AlertData this[int id]
        {
            get
            {
                return Alerts.FirstOrDefault(x => x.ReminderId == id);
            }
        }

        bool IEquatable<Player>.Equals(Player other)
        {
            return this.Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
