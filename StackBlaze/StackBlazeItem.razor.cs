using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace StackBlaze
{
    public partial class StackBlazeItem : ComponentBase
    {
        #region Parameters and injection
        [Inject]
        public StackBlazeService GridStackService { get; set; }

        [CascadingParameter]
        StackBlazeGrid Grid { get; set; }

        [Parameter]
        public ElementReference Element { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        #endregion
        public StackBlazeItem()
        {
            Options = new ItemOptions();
        }

        public StackBlazeItem(string options = null)
        {

            Options = SetFromSerialized(options);

        }

        #region Gridstack Item Options
        [Parameter]
        public bool autoPosition
        {
            get
            {
                return Options.autoPosition;
            }
            set
            {
                Options.autoPosition = value;
            }
        }

        [Parameter]
        public int initialH
        {
            get
            {
                return Options.initialH;
            }
            set
            {
                Options.initialH = value;
            }
        }

        [Parameter]
        public int initialW
        {
            get
            {
                return Options.initialW;
            }
            set
            {
                Options.initialW = value;
            }
        }

        [Parameter]
        public int initialX
        {
            get
            {
                return Options.initialX;
            }
            set
            {
                Options.initialX = value;
            }
        }

        [Parameter]
        public int initialY
        {
            get
            {
                return Options.initialY;
            }
            set
            {
                Options.initialY = value;
            }
        }

        [Parameter]
        public int X
        {
            get
            {
                return Options.X;
            }
            set
            {
                Options.X = value;
            }
        }

        [Parameter]
        public int Y
        {
            get
            {
                return Options.Y;
            }
            set
            {
                Options.Y = value;
            }
        }

        [Parameter]
        public int Width
        {
            get
            {
                return Options.Width;
            }
            set
            {
                Options.Width = value;
            }
        }

        [Parameter]
        public int minWidth
        {
            get
            {
                return Options.minWidth;
            }
            set
            {
                Options.minWidth = value;
            }
        }

        [Parameter]
        public int maxWidth
        {
            get
            {
                return Options.maxWidth;
            }
            set
            {
                Options.maxWidth = value;
            }
        }

        [Parameter]
        public int Height
        {
            get
            {
                return Options.Height;
            }
            set
            {
                Options.Height = value;
            }
        }

        [Parameter]
        public int minHeight
        {
            get
            {
                return Options.minHeight;
            }
            set
            {
                Options.minHeight = value;
            }
        }

        [Parameter]
        public int maxHeight
        {
            get
            {
                return Options.maxHeight;
            }
            set
            {
                Options.maxHeight = value;
            }
        }

        [Parameter]
        public bool locked
        {
            get
            {
                return Options.locked;
            }
            set
            {
                Options.locked = value;
            }
        }

        [Parameter]
        public bool noResize
        {
            get
            {
                return Options.noResize;
            }
            set
            {
                Options.noResize = value;
            }
        }

        [Parameter]
        public bool noMove
        {
            get
            {
                return Options.noMove;
            }
            set
            {
                Options.noMove = value;
            }
        }

        [Parameter]
        public string Params { get; set; } = "";

        private ItemOptions Options;

        [Parameter]
        public string BackgroundColor { get; set; } = "none";



        public string SerializedOptions()
        {
            return System.Text.Json.JsonSerializer.Serialize(Options);
        }

        private ItemOptions SetFromSerialized(string ser)
        {
            return System.Text.Json.JsonSerializer.Deserialize<ItemOptions>(ser);

        }

        public async Task Refresh()
        {
            await InvokeAsync(StateHasChanged);
        }
        #endregion

        private int _id;

        public int ID { get => _id; }

        public string ElementID { get; set; }

        // Basic Lifecycle Functions
        //      There are Async versions of these        
        protected override void OnInitialized()
        {
            _id = GridStackService.GetItemId();
            ElementID = "gsitem-" + _id.ToString();
            this.X = initialX;
            this.Y = initialY;
            this.Width = initialW;
            this.Height = initialH;

            if (this.Params != "")
                Options = SetFromSerialized(Params);

            Grid.RegisterItem(this);
            base.OnInitialized();

        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                if (GridStackService.IsItemAddedOnRuntime(Grid.ElementID))
                    await Grid.MakeItem(this);
            }

        }

        public void UpdateValues(ItemChangedArgs e)
        {
            this.Height = e.Height;
            this.Width = e.Width;
            this.X = e.X;
            this.Y = e.Y;
        }

    }
}
