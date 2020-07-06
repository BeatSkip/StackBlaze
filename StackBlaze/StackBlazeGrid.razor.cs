using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;


namespace StackBlaze
{
    public partial class StackBlazeGrid : ComponentBase
    {
        [Inject]
        private StackBlazeService StackBlazeService { get; set; }

        #region grid
        private StackBlazeInterop GridJS;

        public ElementReference Element { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private RenderFragment DynamicRender { get; set; }

        private int _gridId { get; set; }
        public int Id { get => _gridId; }

        private Dictionary<int, StackBlazeItem> Items = new Dictionary<int, StackBlazeItem>();
        #endregion

        #region Events
        [Parameter] public GridOptions Options { get; set; } = new GridOptions();

        private bool initialized = false;
        #endregion

        private string _elementid;
        public string ElementID { get => _elementid; }

        #region lifecycle
        // Basic Lifecycle Functions
        //      There are Async versions of these        
        protected override async Task OnInitializedAsync()
        {
            _gridId = StackBlazeService.GetGridId();
            _elementid = "gsgrid-" + _gridId;
            StackBlazeService.RegisterGrid(this);

            GridJS = new StackBlazeInterop(this, JSRuntime, StackBlazeService);
            Console.WriteLine("[c#] initialized gridstack grid!");

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await GridJS.Init(Options);
                await GridJS.Callbacks();
                initialized = true;
            }
        }
        #endregion

        #region Item management

        internal void RegisterItem(StackBlazeItem item)
        {
            Console.WriteLine("[c#] registering item with id: {0}", item.ID);
            Items.Add(item.ID, item);
            
        }

        internal async Task MakeItem(StackBlazeItem item)
        {
            await GridJS.RegisterItem(item.ElementID);
            await Refresh();
        }

        internal async void UpdateItem(ItemChangedArgs e)
        {
            Items[e.Id].UpdateValues(e);
            Console.WriteLine("[cs] updated item!");
            await Refresh();
        }

        public async Task Refresh()
        {
            await InvokeAsync(StateHasChanged);
        }

        internal bool isRunning()
        {
            return initialized;
        }

        #endregion

        #region GridStack API
        public async Task<int> CellHeight()
        {
            var h = await GridJS.CellHeight();
            return h;
        }

        public async Task<int> CellWidth()
        {
            var h = await GridJS.CellWidth();
            return h;
        }

        public async Task Disable()
        {
            await GridJS.Disable();
        }

        public async Task Enable()
        {
            await GridJS.Enable();
        }

        #endregion
    }
}
