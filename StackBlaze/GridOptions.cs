using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StackBlaze
{

    public partial class GridOptions
    {
        [JsonProperty("itemClass")]
        public string ItemClass { get; set; } = "grid-stack-item";

        [JsonProperty("column")]
        public int Column { get; set; } = 12;

        [JsonProperty("minRow")]
        public int MinRow { get; set; } = 0;

        [JsonProperty("maxRow")]
        public int MaxRow { get; set; } = 0;

        [JsonProperty("placeholderClass")]
        public string PlaceholderClass { get; set; } = "grid-stack-placeholder";

        [JsonProperty("placeholderText")]
        public string PlaceholderText { get; set; } = "";

        [JsonProperty("handle")]
        public string Handle { get; set; } = ".grid-stack-item-content";

        [JsonProperty("handleClass")]
        public object HandleClass { get; set; } = "null";

        [JsonProperty("cellHeight")]
        public int CellHeight { get; set; } = 60;

        [JsonProperty("verticalMargin")]
        public int VerticalMargin { get; set; } = 10;

        [JsonProperty("auto")]
        public bool Auto { get; set; } = true;

        [JsonProperty("minWidth")]
        public int MinWidth { get; set; } = 768;

        [JsonProperty("float")]
        public bool Float { get; set; } = true;

        [JsonProperty("staticGrid")]
        public bool StaticGrid { get; set; } = false;

        [JsonProperty("animate")]
        public bool Animate { get; set; } = true;

        [JsonProperty("alwaysShowResizeHandle")]
        public bool AlwaysShowResizeHandle { get; set; } = false;

        [JsonProperty("resizable")]
        public Resizable Resizable { get; set; } = new Resizable();

        [JsonProperty("draggable")]
        public Draggable Draggable { get; set; } = new Draggable();

        [JsonProperty("disableDrag")]
        public bool DisableDrag { get; set; } = false;

        [JsonProperty("disableResize")]
        public bool DisableResize { get; set; } = false;

        [JsonProperty("rtl")]
        public bool Rtl { get; set; } = false;

        [JsonProperty("removable")]
        public string Removable { get; set; } = ".trash";

        [JsonProperty("removeTimeout")]
        public int RemoveTimeout { get; set; } = 100;

        [JsonProperty("disableOneColumnMode")]
        public bool DisableOneColumnMode { get; set; } = false;

    }

    public partial class Draggable
    {
        [JsonProperty("handle")]
        public string Handle { get; set; } = ".grid-stack-item-content";

        [JsonProperty("scroll")]
        public bool Scroll { get; set; } = false;

        [JsonProperty("appendTo")]
        public string AppendTo { get; set; } = "body";

    }

    public partial class Resizable
    {
        [JsonProperty("autoHide")]
        public bool AutoHide { get; set; } = true;

        [JsonProperty("handles")]
        public string Handles { get; set; } = "se";
    }

}


