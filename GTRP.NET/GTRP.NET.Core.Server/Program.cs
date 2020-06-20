using CitizenFX.Core;
using GTRP.NET.Shared.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            
        }

        private void OnServerResourceStart(string resourceName)
        {
            if (resourceName != "GTRP.NET_Core") return;
            EventHandlers["playerConnecting"] += new Action<Player, string, CallbackDelegate, dynamic>(OnPlayerConnecting);
        }


        private async void OnPlayerConnecting([FromSource]Player source, string playerName, CallbackDelegate kickCallback, dynamic deferrals)
        {
            var steamid = source.Identifiers["steam"];
            var discordId = source.Identifiers["discord"];
            var ip = source.Identifiers["ip"];
            deferrals.defer();
            await Delay(500);

            if(steamid == null)
            {
                deferrals.done("You need to have steam open to access this server");
                return;
            }


            var result = (List<object>)await Exports["ghmattimysql"].executeSync($"SELECT * FROM gtrp.users users WHERE users.steam_id = '{steamid}'");


            GTRPUser gTRPUser;
            if (!result.Any())
            {
                var result2 = (dynamic)await Exports["ghmattimysql"].executeSync($"INSERT INTO gtrp.users( steam_id, discord_id, last_used_ip) VALUES('{steamid}', '{discordId}', '{ip}')");
                gTRPUser = new GTRPUser(result2);
            }
            else
            {
                gTRPUser = new GTRPUser(result.First());
            }

            

            Console.Out.WriteLine(gTRPUser.ToString());

            if (!gTRPUser.Whitelisted)
            {
                deferrals.done("Not whitelisted");
            }

            if (gTRPUser.IsBanned)
            {
                deferrals.done($"Banned, Reason: {gTRPUser.BanReason}");
            }

            deferrals.done();
            return;
        }
    }
}
