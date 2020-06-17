using System;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace GTRP.NET.Core.Client.Helpers
{
    public class ChatHelper : BaseScript
    {
        private static void AddMessage(string author, string message, bool multiLine, int[] color)
        {
            if (color == null) color = new int[3] { 255, 0, 0 };
            if (color.Length > 3)
            {
                //log invalid color
                AddMessage("ChatHelper:AddMessage - ERROR", "Provided color had more than 3 values", false, new int[] { 255, 0, 0 });
                return;
            }
            TriggerEvent("chat:addMessage", new
            {
                color = color,
                multiline = multiLine,
                args = new[] {author, message}
            });
        }

        public static void InfoMessage(string author, string message)
        {
            AddMessage(author, message, false, new[] { 255, 255, 255 });
        }

        public static void SuccessMessage(string author, string message)
        {
            AddMessage(author, message, false, new[] { 0, 255, 0 });
        }

        public static void ErrorMessage(string author, string message)
        {
            AddMessage(author, message, false, new[] { 255, 0, 0 });
        }

        public static void WarningMessage(string author, string message)
        {
            AddMessage(author, message, false, new[] { 255, 255, 0 });
        }
    }
}
