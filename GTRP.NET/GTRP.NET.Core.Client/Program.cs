using System;
using System.Collections.Generic;
using GTRP.NET.Core.Client.Helpers;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace GTRP.NET.Core.Client
{
    public class Program : BaseScript
    {

        public Program()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            
            if (GetCurrentResourceName() != resourceName) return;

            RegisterCommand("test", new Action<int, List<object>, string>((source, args, raw) =>
            {
                ChatHelper.InfoMessage("INFO", "This is an info test from client");
            }), false);

            RegisterCommand("error", new Action<int, List<object>, string>((source, args, raw) =>
            {
                ChatHelper.ErrorMessage("ERROR", "This is an error test from client");
            }), false);

            
            RegisterCommand("warning", new Action<int, List<object>, string>((source, args, raw) =>
            {
                ChatHelper.WarningMessage("WARNING", "This is a warning test from client");
            }), false);

            RegisterCommand("success", new Action<int, List<object>, string>((source, args, raw) =>
            {
                ChatHelper.WarningMessage("SUCCESS", "This is a success test from client");
            }), false);

        }

    }
}
