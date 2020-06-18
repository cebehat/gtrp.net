using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTRP.NET.Shared.Models
{
    public class GTRPPlayer
    {
        public int PlayerId { get; set; }
        public string SteamId { get; private set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }

        public bool HasPhone => Mobilephone != null;
        public GTRPPhone Mobilephone { get; set; }

        public int MyProperty { get; set; }

    }
}
