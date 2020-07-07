using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StackBlaze
{
    public class ItemChangedArgs
    {
        [JsonProperty("autoPosition")]
        public bool AutoPosition { get; set; }

        [JsonProperty("X")]
        public int X { get; set; }

        [JsonProperty("Y")]
        public int Y { get; set; }

        [JsonProperty("Width")]
        public int Width { get; set; }

        [JsonProperty("minWidth")]
        public int MinWidth { get; set; }

        [JsonProperty("maxWidth")]
        public int MaxWidth { get; set; }

        [JsonProperty("Height")]
        public int Height { get; set; }

        [JsonProperty("minHeight")]
        public int MinHeight { get; set; }

        [JsonProperty("maxHeight")]
        public int MaxHeight { get; set; }

        [JsonProperty("Locked")]
        public bool Locked { get; set; }

        [JsonProperty("noResize")]
        public bool NoResize { get; set; }

        [JsonProperty("noMove")]
        public bool NoMove { get; set; }

        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("gridid")]
        public string Gridid { get; set; }
    }
}
