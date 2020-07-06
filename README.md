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
    <StackBlazeItem BackgroundColor="#f0f0f0">
        Number 1!
    </StackBlazeItem>

    <StackBlazeItem BackgroundColor="#f1f1f1">
        Number 2!
    </StackBlazeItem>

    @foreach (var item in items)
    {
        <StackBlazeItem BackgroundColor="#f4f4f4">
            @item
        </StackBlazeItem>
    }
</StackBlazeGrid>
```

if you need to debug, look at the git demo/ examples for non min includes.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
