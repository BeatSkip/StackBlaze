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
            //console.log("[gs] OnChanged event!");
            let conv = window.StackBlazeHelpers.convertEvent(items);

            console.dir(conv);
            console.log(JSON.stringify(conv));
            for (var i = 0; i < conv.length; i++) {
                window.StackBlazeService.invokeMethodAsync('EventOnChanged', JSON.stringify(conv[i]));
            }
        });
    },

    registerService: function (objref) {
        window.StackBlazeService = objref;
        console.log("Registered grid service!");
    },

    registerItem: function (gridid, el) {
        var grid = document.getElementById(gridid).gridstack;
        //console.log("making widget! with id: " + el);
        grid.makeWidget(document.getElementById(el));
        grid.commit();
    }

};

window.StackBlazeapi = {
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

    cellheight: function (gridid, newHeight, noUpdate) {
        var grid = document.getElementById(gridid).gridstack;
        return grid.cellheight(newHeight, noUpdate);
    },

    cellwidth: function (gridid) {
        var grid = document.getElementById(gridid).gridstack;
        return grid.cellwidth();
    },

    cellwidth: function (gridid, newWidth, noUpdate) {
        var grid = document.getElementById(gridid).gridstack;
        return grid.cellwidth(newWidth, noUpdate);
    },

    float: function (gridid) {
        var grid = document.getElementById(gridid).gridstack;
        return grid.cellwidth();
    },

    float: function (gridid, newval) {
        var grid = document.getElementById(gridid).gridstack;
        return grid.float(newval);
    },

    enableMove: function (gridid, doEnable, includeNewWidgets) {
        var grid = document.getElementById(gridid).gridstack;
        grid.enableMove(doEnable, includeNewWidgets);
    },

    enableResize: function (gridid, doEnable, includeNewWidgets) {
        var grid = document.getElementById(gridid).gridstack;
        grid.enableResize(doEnable, includeNewWidgets);
    },

    isAreaEmpty: function (gridid, x, y, width, height) {
        var grid = document.getElementById(gridid).gridstack;
        return grid.isAreaEmpty(x, y, width, height);
    },

    locked: function (gridid, elid, newval) {
        var grid = document.getElementById(gridid).gridstack;
        let el = document.getElementById(elid).gridstack;
        grid.locked(el, newval);
    },

    maxHeight: function (gridid, elid, newval) {
        var grid = document.getElementById(gridid).gridstack;
        let el = document.getElementById(elid).gridstack;
        //console.log("set max height to: " + newval);
        grid.maxHeight(el, newval);
        grid.batchUpdate();
        grid.commit();
    },

    minHeight: function (gridid, elid, newval) {
        var grid = document.getElementById(gridid).gridstack;
        let el = document.getElementById(elid).gridstack;
        grid.minHeight(el, newval);
    },

    maxWidth: function (gridid, elid, newval) {
        var grid = document.getElementById(gridid).gridstack;
        let el = document.getElementById(elid).gridstack;
        grid.maxWidth(el, newval);
    },

    minWidth: function (gridid, elid, newval) {
        var grid = document.getElementById(gridid).gridstack;
        let el = document.getElementById(elid).gridstack;
        grid.minWidth(el, newval);
    },

    update: function (gridid, elid, x, y, width, height) {
        var grid = document.getElementById(gridid).gridstack;
        let el = document.getElementById(elid).gridstack;
        grid.update(el, x, y, width, height);
    }

}

window.StackBlazeHelpers = {
    convertOnchange: function (value) {
        return {
            autoPosition: value.autoPosition,
            X: value.x,
            Y: value.y,
            Width: value.width,
            minWidth: value.minWidth,
            maxWidth: value.maxWidth,
            Height: value.height,
            minHeight: value.minHeight,
            maxHeight: value.maxHeight,
            Locked: value.locked,
            noResize: value.noResize,
            noMove: value.noMove,
            ID: parseInt(value.id),
            gridid: value._grid.el.id
        };
    },

    convertEvent: function (items) {
        let result = [];
        let counter = 0;

        for (var i = 0; i < items.length; i++) {
            if (typeof items[i].id === 'undefined')
                break;

            let tmp = StackBlazeHelpers.convertOnchange(items[i]);

            console.log("original event:");
            console.dir(items[i]);
            console.log("converted event:");
            console.dir(tmp);
            result[counter] = tmp;
            counter++;
        }
        return result;
    }
};


