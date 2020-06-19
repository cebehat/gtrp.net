using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTRP.NET.Shared.Models
{
    public class GTRPPlayer
    {
        //System based properties for players
        public int PlayerId { get; private set; }
        public string SteamId { get; private set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
        public bool IsCharacterKilled { get; set; }
        
        public GTRPPlayer(int playerID, string steamId)
        {
            this.PlayerId = playerID;
            this.SteamId = steamId;
        }


        //RP/Ingame based properties for players

        /// <summary>
        /// GovernmentID is a string representation of the RP id for a character
        /// this could for example be the social security number on american based servers.
        /// </summary>
        public string GovernmentID { get; set; }
        public bool HasPhone => Mobilephone != null;
        public GTRPPhone Mobilephone { get; set; }
        
        public int MyProperty { get; set; }

    }
}
