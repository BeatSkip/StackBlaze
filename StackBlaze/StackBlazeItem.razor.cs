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

        #region events
        /*
        [Parameter]
        public EventCallback<ItemOptions> ItemChangedCallback { get; set; }
        */
        #endregion


        #region Gridstack Item Options

        public int ID
        {
            get
            {
                return Options.ID;
            }
        }

        public string ElementID
        {
            get
            {
                return Options.ElementID;
            }
    
        }

        public string ContentID
        {
            get
            {
                return string.Format("{0}-content",Options.ElementID);
            }

        }

        [Parameter]
        public ItemOptions Options { get; set; }
        #endregion
        

        public async Task Refresh()
        {
            await InvokeAsync(StateHasChanged);
        }

        // Basic Lifecycle Functions
        //      There are Async versions of these        
        protected override void OnInitialized()
        {
            if (Options == null)
                Options = new ItemOptions();

            Options.OnChanged += Options_OnChanged;

            Options.ID = GridStackService.GetItemId();
            Grid.RegisterItem(this);
            base.OnInitialized();

        }

        private async void Options_OnChanged(ItemOptions obj)
        {
            await Refresh();
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

        internal void UpdateValues(ItemChangedArgs e)
        {
            this.Options.UpdateFromArgs(e);
        }

    }
}
