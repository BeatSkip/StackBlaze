using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace StackBlaze
{
    public class StackBlazeInterop
    {
        private readonly IJSRuntime JSRuntime;
        private readonly StackBlazeGrid Grid;

        private readonly DotNetObjectReference<StackBlazeService> serviceRef;

        public StackBlazeInterop(StackBlazeGrid sender, IJSRuntime jSRuntime, StackBlazeService c)
        {
            this.JSRuntime = jSRuntime ?? throw new ArgumentNullException(nameof(jSRuntime));
            this.Grid = sender;
            this.serviceRef = DotNetObjectReference.Create(c);
            
        }

        public async Task Init(GridOptions opts)
        {
            await JSRuntime.InvokeVoidAsync("StackBlaze.registerService", serviceRef);
            await JSRuntime.InvokeVoidAsync("StackBlaze.init",opts);

        }

        public async Task Callbacks()
        {
            await JSRuntime.InvokeVoidAsync("StackBlaze.callbacks", Grid.ElementID);
        }

        public async Task RegisterItem(string el)
        {
            await JSRuntime.InvokeVoidAsync("StackBlaze.registerItem", Grid.ElementID, el);
        }

        public async Task Enable()
        {
            await JSRuntime.InvokeVoidAsync("StackBlaze.enablegrid", Grid.ElementID);
        }

        public async Task Disable()
        {
            await JSRuntime.InvokeVoidAsync("StackBlaze.disablegrid", Grid.ElementID);
        }

        public ValueTask<int> CellHeight()
        {
            return JSRuntime.InvokeAsync<int>("StackBlaze.cellheight", Grid.ElementID);
        }

        public ValueTask<int> CellWidth()
        {
            return JSRuntime.InvokeAsync<int>("StackBlaze.cellwidth", Grid.ElementID);
        }



    }
}
