using CitizenFX.Core;
using GTRP.NET.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;

namespace GTRP.NET.Core.Server
{
    public class Program : BaseScript
    {
        public Program()
        {
            EventHandlers["onServerResourceStart"] += new Action<string>(OnServerResourceStart);
            EventHandlers["playerConnecting"] += new Action<Player, string, CallbackDelegate, dynamic>(OnPlayerConnecting);
        }

        private void OnServerResourceStart(string resourceName)
        {
            
        }

        private async void OnPlayerConnecting([FromSource]Player source, string playerName, CallbackDelegate kickCallback, dynamic deferrals)
        {
            var steamid = source.Identifiers["steam"];
            deferrals.defer();
            await Delay(500);

            if(steamid == null)
            {
                deferrals.done("You need to have steam open to access this server");
                return;
            }

            //do whitelist check here

            //save the steamID to DB
            GTRPPlayer gTRPPlayer = new GTRPPlayer(0, steamid);
        }
    }
}
