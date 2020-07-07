using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackBlaze
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemOptions
    {

        #region event handling
        public event Action<ItemOptions> OnChanged;
        private void changed() => OnChanged?.Invoke(this);

        #endregion

        private bool suppressevents = false;

        #region private variables

        private bool _autoPosition = true;
        private int _X = 0;
        private int _Y = 0;
        private int _Width = 1;
        private int _minWidth = 1;
        private int _maxWidth = 12;
        private int _Height = 1;
        private int _minHeight = 1;
        private int _maxHeight = 12;
        private bool _locked = false;
        private bool _noResize = false;
        private bool _noMove = false;
        #endregion

        [JsonProperty]
        public bool autoPosition
        {
            get { return _autoPosition; }
            set
            {
                if (value != _autoPosition)
                {
                    _autoPosition = value;

                    if (!suppressevents)
                    {
                        changed();
                        
   
                    }
                        
                }
            }
        }

        [JsonProperty]
        public int X
        {
            get { return _X; }
            set
            {
                if (value != _X)
                {
                    _X = value;

                    if (!suppressevents)
                    {
                        changed();
                        if (grid != null)
                            grid.GridJS.update(this.ElementID, this._X, this._Y, this._Width, this._Height);
                    }
                }
            }
        }

        [JsonProperty]
        public int Y
        {
            get { return _Y; }
            set
            {
                if (value != _Y)
                {
                    _Y = value;

                    if (!suppressevents)
                    {
                        changed();
                        if (grid != null)
                            grid.GridJS.update(this.ElementID, this._X, this._Y, this._Width, this._Height);
                    }
                }
            }
        }

        [JsonProperty]
        public int Width
        {
            get { return _Width; }
            set
            {
                if (value != _Width)
                {
                    _Width = value;

                    if (!suppressevents)
                    {
                        changed();
                        if (grid != null)
                            grid.GridJS.update(this.ElementID, this._X, this._Y, this._Width, this._Height);
                    }
                }
            }
        }

        [JsonProperty]
        public int minWidth
        {
            get { return _minWidth; }
            set
            {
                if (value != _minWidth)
                {
                    _minWidth = value;

                    if (!suppressevents)
                    {
                        changed();
                        if (grid != null)
                            grid.GridJS.minWidth(this.ElementID, _minWidth);
                    }
                }
            }
        }

        [JsonProperty]
        public int maxWidth
        {
            get { return _maxWidth; }
            set
            {
                if (value != _maxWidth)
                {
                    _maxWidth = value;

                    if (!suppressevents)
                    {
                        if(grid != null)
                            grid.GridJS.maxWidth(this.ElementID, _maxWidth);

                        changed();
                    }
                }
            }
        }

        [JsonProperty]
        public int Height
        {
            get { return _Height; }
            set
            {
                if (value != _Height)
                {
                    _Height = value;

                    if (!suppressevents)
                    {
                        changed();
                        grid.GridJS.update(this.ElementID, this._X, this._Y, this._Width, this._Height);
                    }
                }
            }
        }

        [JsonProperty]
        public int minHeight
        {
            get { return _minHeight; }
            set
            {
                if (value != _minHeight)
                {
                    _minHeight = value;

                    if (!suppressevents)
                    {
                        changed();
                        if (grid != null)
                            grid.GridJS.minHeight(this.ElementID, _minHeight);
                    }
                }
            }
        }

        [JsonProperty]
        public int maxHeight
        {
            get { return _maxHeight; }
            set
            {
                if (value != _maxHeight)
                {
                    _maxHeight = value;

                    if (!suppressevents)
                    {
                        
                        if (grid != null)
                            grid.GridJS.maxHeight(this.ElementID, _maxHeight);

                        changed();
                    }
                }
            }
        }

        [JsonProperty]
        public bool Locked
        {
            get { return _locked; }
            set
            {
                if (value != _locked)
                {
                    _locked = value;

                    if (!suppressevents)
                    {
                        changed();
                        if (grid != null)
                            grid.GridJS.locked(this.ElementID, _locked);
                    }
                }
            }
        }

        [JsonProperty]
        public bool noResize
        {
            get { return _noResize; }
            set
            {
                if (value != _noResize)
                {
                    _noResize = value;

                    if (!suppressevents)
                    {
                        changed();
                    }
                }
            }
        }

        [JsonProperty]
        public bool noMove
        {
            get { return _noMove; }
            set
            {
                if (value != _noMove)
                {
                    _noMove = value;

                    if (!suppressevents)
                    {
                        changed();
                    }
                }
            }
        }

        private int _id;

        [JsonProperty]
        public int ID
        {
            get { return _id; }

            internal set
            {
                _id = value;
                ElementID = string.Format("gsitem-{0}", ID);
            }
        }

        public string ElementID { get; private set; }

        public string GetSerialized()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public void SetFromSerialized(string json)
        {
            suppressevents = true;
            JsonConvert.PopulateObject(json, this);
            suppressevents = false;
            changed();
        }

        internal void UpdateFromArgs(ItemChangedArgs e)
        {
            suppressevents = true;
            autoPosition = e.AutoPosition;
            X = e.X;
            Y = e.Y;
            Width = e.Width;
            minWidth = e.MinWidth;
            maxWidth = e.MaxWidth;
            Height = e.Height;
            minHeight = e.MinHeight;
            maxHeight = e.MaxHeight;
            Locked = e.Locked;
            noResize = e.NoResize;
            noMove = e.NoMove;
            suppressevents = false;
            changed();
        }

        internal StackBlazeGrid grid { get; set; }


    }
}
