using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace GTRP.NET.Shared.Helpers
{
    public class ChatHelper
    {
        public void AddMessage()
        {
            TriggerEvent(); 
        } 
    }
}
