Important! This was just a proof-of-principle a while back. 
I am currently working on a new version that is actually good. 
And working with the newer standards in .net 5.0!! 
Please be patient if you like the idea :) 

# StackBlaze
A Gridstack.JS powered Drag-and-Drop component to make beautiful Drag and drop dashboards in blazor
This is a very very pre-alpha version. I'm making this component for a company project, so the polishing will come.

The back-end of this component is completely powered by Gridstack.JS, so be sure to give them a look!

http://gridstackjs.com

## Setup in Blazor
* wwwroot/index.html:
```html
<script src="_content/StackBlaze/stackblaze.js"></script>
```

* Program.cs:
```html
public static async Task Main(string[] args)
{
    ... // other code
    builder.Services.AddStackBlaze(); //Add stackblaze service
    ... // other code
}
```
* _Imports.razor:
```html
@using StackBlaze
```
## Usage

* Minimal example:

```html
<StackBlazeGrid>
    <StackBlazeItem>
        Number 1!
    </StackBlazeItem>

    <StackBlazeItem>
        Number 2!
    </StackBlazeItem>

    @foreach (var item in items)
    {
        <StackBlazeItem Options=@item.options>
            @item.value
        </StackBlazeItem>
    }
</StackBlazeGrid>
```


## Implemented:

#### Functionality:
- [x] Basic Functionality (drag and drop grid)
- [x] JS <-> Blazor connection

#### Item Options

#### Grid Events:
 - [ ] added(event, items)
 - [x] change(event, items)
 - [ ] disable(event)
 - [ ] dragstart(event, ui)
 - [ ] dragstop(event, ui)
 - [ ] dropped(event, previousWidget, newWidget)
 - [ ] enable(event)
 - [ ] removed(event, items)
 - [ ] resizestart(event, ui)
 - [ ] gsresizestop(event, ui)
 
#### Grid API:
 - [ ] addWidget(el, [options])
 - [ ] addWidget(el, [x, y, width, height, autoPosition, minWidth, maxWidth, minHeight, maxHeight, id])
 - [ ] batchUpdate()
 - [ ] compact()
 - [x] cellHeight()
 - [ ] cellHeight(val, noUpdate)
 - [x] cellWidth()
 - [ ] commit()
 - [ ] column(column, doNotPropagate)
 - [ ] destroy([detachGrid])
 - [x] disable()
 - [x] enable()
 - [ ] enableMove(doEnable, includeNewWidgets)
 - [ ] enableResize(doEnable, includeNewWidgets)
 - [ ] float(val?)
 - [ ] getCellFromPixel(position[, useOffset])
 - [x] isAreaEmpty(x, y, width, height)
 - [x] locked(el, val)
 - [ ] makeWidget(el)
 - [ ] maxHeight(el, val)
 - [ ] minHeight(el, val)
 - [ ] maxWidth(el, val)
 - [ ] minWidth(el, val)
 - [ ] movable(el, val)
 - [ ] move(el, x, y)
 - [ ] removeWidget(el[, detachNode])
 - [ ] removeAll([detachNode])
 - [ ] resize(el, width, height)
 - [ ] resizable(el, val)
 - [ ] setAnimation(doAnimate)
 - [ ] setStatic(staticValue)
 - [x] update(el, x, y, width, height)
 - [ ] verticalMargin()
 - [ ] verticalMargin(value, noUpdate)
 - [ ] willItFit(x, y, width, height, autoPosition)


[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
