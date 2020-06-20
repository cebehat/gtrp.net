using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTRP.NET.Shared.Models
{
    public class GTRPUser
    {
        private int id;
        private string steam_id;
        private int banned;
        private string ban_reason;
        private string discord_id;
        private string last_used_ip;
        private int whitelisted;

        //System based properties for players
        public int PlayerId { get; private set; }
        public string SteamId { get; private set; }
        public string DiscordId { get; private set; }
        public string LastUsedIp { get; private set; }
        public bool Whitelisted { get; private set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
        public PermissionLevelEnum PermissionLevel { get; private set; }
        
        public GTRPUser(string steamId, string discordId, string ip)
        {
            SteamId = steamId;
            DiscordId = discordId;
            LastUsedIp = ip;
            IsBanned = false;
            Whitelisted = false;
            PermissionLevel = PermissionLevelEnum.PLAYER;
        }

        public GTRPUser(dynamic dbResult)
        {
            try
            {
                PlayerId = dbResult.id;
                SteamId = dbResult.steam_id;
                DiscordId = dbResult.discord_id;
                LastUsedIp = dbResult.last_used_ip;
                IsBanned = dbResult.banned == 1;
                BanReason = IsBanned ? dbResult.ban_reason : string.Empty;                
                Whitelisted = dbResult.whitelisted == 1;
                PermissionLevel = (PermissionLevelEnum)dbResult.permission_level;
            }catch(Exception ex)
            {
                Console.Out.WriteLine("User was not found in db");
                Console.Out.WriteLine(ex.Message);
            }            
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player id: {PlayerId}");
            sb.AppendLine($"Steam id: {SteamId}");
            sb.AppendLine($"Discord id: {DiscordId}");
            sb.AppendLine($"Last used IP: {LastUsedIp}");
            sb.AppendLine($"Has Whitelist: {Whitelisted}");
            sb.AppendLine($"Is Banned: {IsBanned}");
            if (IsBanned) {
                sb.AppendLine($"Ban reason: {BanReason}");
            }
            return sb.ToString();            
        }

        public enum PermissionLevelEnum
        {
            PLAYER = 0,
            MODERATOR = 1,
            SUPERUSER = 2,
            ADMIN = 3,
            OWNER = 4
        }

    }
}
