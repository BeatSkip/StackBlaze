using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StackBlaze
{
    public class StackBlazeService
    {

        private Dictionary<string, StackBlazeGrid> grids = new Dictionary<string, StackBlazeGrid>();

        private int _idGridCounter = 1;
        private int _idItemCounter = 1;

        public bool registered = false;

        public StackBlazeService()
        {
            
        }


        internal bool IsItemAddedOnRuntime(string gridid)
        {
            return grids[gridid].isRunning();
        }

        internal int GetGridId()
        {
            _idGridCounter++;
            _idItemCounter = 0;
            return _idGridCounter;
        }

        internal void RegisterGrid(StackBlazeGrid g)
        {
            if (grids.ContainsKey(g.ElementID))
            {
                grids[g.ElementID] = g;
            }
            else
            {
                grids.Add(g.ElementID, g);
            }
        }

        internal int GetItemId()
        {
            _idItemCounter++;
            return _idItemCounter;
        }

        internal StackBlazeInterop GetInteropForGrid(string grid)
        {
            return grids[grid].GridJS;
        }

        [JSInvokable("EventOnChanged")]
        public async void EventOnChanged(string json)
        {
            //Console.WriteLine("update event json: ");
            var args = JsonConvert.DeserializeObject<ItemChangedArgs>(json);
            grids[args.Gridid].UpdateItem(args);
        }




    }
}
