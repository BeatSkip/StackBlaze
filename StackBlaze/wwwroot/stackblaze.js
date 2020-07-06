var gsmainid = 'stackblazemainjs';  // you could encode the css path itself to generate id..
var gscssid = 'stackblazemaincss';  // you could encode the css path itself to generate id..
var gsInteropId = 'stackblazeinterop';  // you could encode the css path itself to generate id..

if (!document.getElementById(gscssid)) {
    var head = document.getElementsByTagName('head')[0];
    var link = document.createElement('link');
    link.id = gscssid;
    link.href = '_content/StackBlaze/gridstack.css';
    link.rel = "stylesheet";
    head.appendChild(link);
    console.log("gridstack css loaded!");
}

if (!document.getElementById(gsmainid)) {
    var head = document.getElementsByTagName('head')[0];
    var link = document.createElement('script');
    link.id = gsmainid;
    link.src = '_content/StackBlaze/gridstack.all.js';
    head.appendChild(link);
    console.log("gridstack js loaded!");
}

if (!document.getElementById(gsInteropId)) {
    var head = document.getElementsByTagName('head')[0];
    var link = document.createElement('script');
    link.id = gsInteropId;
    link.src = '_content/StackBlaze/StackBlazeJsInterop.js';
    head.appendChild(link);
    console.log("StackBlaze loaded!");
}

