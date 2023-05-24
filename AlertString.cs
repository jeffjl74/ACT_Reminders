using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT_Reminders
{

    internal class AlertString
    {
        StringBuilder sb;

        public enum AlertType { AUDIO, VISUAL }
        public int Length { get { return sb.Length; } }
        public int Delay = 0;
        AlertType m_type;

        public AlertString(AlertType type)
        {
            m_type = type;
            sb = new StringBuilder();
        }

        public StringBuilder Append(string s, int del)
        {
            Delay = Math.Min(Delay, del);

            if (m_type == AlertType.AUDIO)
            {
                if(sb.Length > 0)
                    if (!sb.ToString().Trim().EndsWith(","))
                        sb.Append(", ");
                sb.Append(s.Replace("\n", ", "));
            }
            else if (m_type == AlertType.VISUAL)
            {
                if (sb.Length > 0 && !sb.ToString().EndsWith("\n") && !string.IsNullOrEmpty(s))
                    sb.Append("\n");
                sb.Append(s);
            }
            return sb;
        }

        public bool IsEmpty()
        {
            return sb.Length == 0;
        }

        public StringBuilder Clear()
        {
            sb.Clear();
            return sb;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
