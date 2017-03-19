using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atst.Core.Game.Entities;

namespace atst.Core.Authentication.Entities
{
    public class GeneralItem
    {
        public string TimeStamp { get; set; }
        public ActionType ActionType { get; set; }
        public int Value { get; set; }

        public GeneralItem(int value, ActionType actionType)
        {
            ActionType = actionType;
            TimeStamp = DateTime.UtcNow.ToString("O");
            Value = value;
        }
    }
}
