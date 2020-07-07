using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace StackBlaze
{
    internal class StackBlazeInterop
    {
        private readonly IJSRuntime JSRuntime;
        private readonly StackBlazeGrid Grid;

        private readonly DotNetObjectReference<StackBlazeService> serviceRef;

        internal StackBlazeInterop(StackBlazeGrid sender, IJSRuntime jSRuntime, StackBlazeService c)
        {
            this.JSRuntime = jSRuntime ?? throw new ArgumentNullException(nameof(jSRuntime));
            this.Grid = sender;
            this.serviceRef = DotNetObjectReference.Create(c);

        }

        internal async Task Init(GridOptions opts)
        {
            await JSRuntime.InvokeVoidAsync("StackBlaze.registerService", serviceRef);
            await JSRuntime.InvokeVoidAsync("StackBlaze.init", opts);

        }

        internal async Task Callbacks()
        {
            await JSRuntime.InvokeVoidAsync("StackBlaze.callbacks", Grid.ElementID);
        }

        internal async Task RegisterItem(string el)
        {
            await JSRuntime.InvokeVoidAsync("StackBlaze.registerItem", Grid.ElementID, el);
        }

        internal async Task Enable()
        {
            await JSRuntime.InvokeVoidAsync("StackBlazeapi.enablegrid", Grid.ElementID);
        }

        internal async Task Disable()
        {
            await JSRuntime.InvokeVoidAsync("StackBlazeapi.disablegrid", Grid.ElementID);
        }

        internal ValueTask<int> CellHeight()
        {
            return JSRuntime.InvokeAsync<int>("StackBlazeapi.cellheight", Grid.ElementID);
        }

        internal ValueTask<int> CellHeight(int newHeight, bool noUpdate)
        {
            return JSRuntime.InvokeAsync<int>("StackBlazeapi.cellheight", Grid.ElementID, newHeight, noUpdate);
        }

        internal ValueTask<int> CellWidth()
        {
            return JSRuntime.InvokeAsync<int>("StackBlazeapi.cellwidth", Grid.ElementID);
        }

        internal ValueTask<int> CellWidth(int newWidth, bool noUpdate)
        {
            return JSRuntime.InvokeAsync<int>("StackBlazeapi.cellwidth", Grid.ElementID, newWidth, noUpdate);
        }


        internal ValueTask<bool> Float()
        {
            return JSRuntime.InvokeAsync<bool>("StackBlazeapi.float", Grid.ElementID);
        }

        internal ValueTask<bool> Float(bool floating)
        {
            return JSRuntime.InvokeAsync<bool>("StackBlazeapi.float", Grid.ElementID, floating);
        }

        internal ValueTask enableMove(bool newvalue)
        {
            return JSRuntime.InvokeVoidAsync("StackBlazeapi.enableMove", Grid.ElementID, newvalue);
        }

        internal ValueTask enableResize(bool newvalue)
        {
            return JSRuntime.InvokeVoidAsync("StackBlazeapi.enableResize", Grid.ElementID, newvalue);
        }

        internal ValueTask<bool> isAreaEmpty(int x, int y, int width, int height)
        {
            return JSRuntime.InvokeAsync<bool>("StackBlazeapi.isAreaEmpty", Grid.ElementID, x, y, width, height);
        }

        internal ValueTask locked(string elementid, bool newvalue)
        {
            return JSRuntime.InvokeVoidAsync("StackBlazeapi.locked", Grid.ElementID, elementid, newvalue);
        }


        internal async Task update(string elementid, int x, int y, int width, int height)
        {
            await JSRuntime.InvokeVoidAsync("StackBlazeapi.update", Grid.ElementID, elementid, x, y, width, height);
        }


        internal async Task maxHeight(string elementid, int newval)
        {
            await JSRuntime.InvokeVoidAsync("StackBlazeapi.maxHeight", Grid.ElementID, elementid, newval);
        }

        internal async Task minHeight(string elementid, int newval)
        {
            await JSRuntime.InvokeVoidAsync("StackBlazeapi.minHeight", Grid.ElementID, elementid, newval);
        }

        internal async Task maxWidth(string elementid, int newval)
        {
            await JSRuntime.InvokeVoidAsync("StackBlazeapi.maxWidth", Grid.ElementID, elementid, newval);
        }

        internal async Task minWidth(string elementid, int newval)
        {
            await JSRuntime.InvokeVoidAsync("StackBlazeapi.minWidth", Grid.ElementID, elementid, newval);
        }

    }
}


