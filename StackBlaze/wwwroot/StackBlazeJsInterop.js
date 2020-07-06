window.StackBlazeService = {};

window.StackBlaze = {
    init: function (opts) {
        var grid = GridStack.init(opts);
        console.log("[js] gridstack initialized!");
        var opts = grid.opts;
        console.log(JSON.stringify(opts));
    },

    callbacks: function (gridid) {
        var grid = document.getElementById(gridid).gridstack;
        grid.on('change', function (event, items) {
            console.log("[gs] OnChanged event!");
            let conv = window.StackBlazeHelpers.convertEvent(items);
            
            console.dir(conv);
            console.log(JSON.stringify(conv));
            for (var i = 0; i < conv.length; i++) {
                window.StackBlazeService.invokeMethodAsync('EventOnChanged', conv[i]);
            }
        });
    },

    registerService: function (objref) {
        window.StackBlazeService = objref;
        console.log("Registered grid service!");
    },

    registerItem: function (gridid, el) {
        var grid = document.getElementById(gridid).gridstack;
        console.log("making widget! with id: " + el);
        grid.makeWidget(document.getElementById(el));
        grid.commit();
    },

    enablegrid: function (gridid) {
        var grid = document.getElementById(gridid).gridstack;
        grid.enable();
    },

    disablegrid: function (gridid) {
        var grid = document.getElementById(gridid).gridstack;
        grid.disable();
    },

    cellheight: function (gridid) {
        var grid = document.getElementById(gridid).gridstack;
         return grid.cellheight();
    },

    cellwidth: function (gridid) {
        var grid = document.getElementById(gridid).gridstack;
        return grid.cellwidth();
    }
};

window.StackBlazeHelpers = {
    convertOnchange: function (value) {
        console.log("converting event item to c#");
        console.dir(value);
        console.log("grid id: " + value._grid.el.id);
        return {
            id: parseInt(value.id),
            width: value.width,
            height: value.height,
            x: value.x,
            y: value.y,
            gridid: value._grid.el.id
        }
    },

    convertEvent: function (items) {
        let result = [];
        let counter = 0;

        for (var i = 0; i < items.length; i++) {
            if (typeof items[i].id === 'undefined')
                break;

            let tmp = StackBlazeHelpers.convertOnchange(items[i]);
            console
            console.dir(tmp);
            result[counter] = tmp;
            counter++;
        }
        return result;
    }
};


