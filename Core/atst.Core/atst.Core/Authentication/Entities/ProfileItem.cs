using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atst.Core.Authentication.Entities
{
    public class ProfileItem
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public ProfileItem(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }
}
