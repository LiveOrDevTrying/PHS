using Newtonsoft.Json;
using PHS.Core.Enums;
using System;

namespace PHS.Core.Models
{
    public struct PacketDTO
    {
        public string Data { get; set; }
        public int Action { get; set; }
        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public ActionType ActionType
        {
            get
            {
                return (ActionType)Action;
            }
        }
    }
}