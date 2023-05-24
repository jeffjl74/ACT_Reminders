using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ACT_Reminders
{
    [XmlRoot]
    public class PlayerList
    {
        public List<Player> Players { get; set;} = new List<Player>();

        public BindingList<ReminderType> Reminders { get; set;} = new BindingList<ReminderType>();

        public int NextReminderId { get { return Reminders.Count == 0 ? 1 : Reminders.Max(x => x.ID) + 1; } }

        public Player this[string key]
        {
            get
            {
                return Players.Find(x => x.Name == key);
            }
        }
    }
}
