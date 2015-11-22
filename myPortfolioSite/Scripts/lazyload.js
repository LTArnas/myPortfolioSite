// TODO: Cleanup file/code.
// local URL. The order reflects the order of loading.
var links = [
    "knowledge",
    "projects",
    "contact"
];

var intervalId = undefined;
var scrollCount = 0;
var scrollCountTrigger = 0;
var scrollEventTimout = 1;
var nextLink = links.shift();
var lzLoadRunning = true;
// cache
var jqDocument = $(document);
var bodyElement = $("body");
var bottomScrollTrigger = 0; // $(document).outerHeight();

// https://en.wikipedia.org/wiki/Immediately-invoked_function_expression
//console.log($("body > [class*=container]")[0].outerHTML);

$(function () {
    intervalId = setInterval(lzload, 1000);
});

// sets scroll trigger value
function calculateScrollTrigger() {
    // TODO: use variable for scroll percentage trigger ...instead of '2'.
    bottomScrollTrigger = jqDocument.outerHeight() / 2; // half way
}

function lzload() {
    if (jqDocument.scrollTop() >= bottomScrollTrigger)
    {
        nextPage();
    }
}

function nextPage() {
    if (nextLink == undefined) {
        console.log("switching off lzload.");
        clearInterval(intervalId);
    }
    else {
        appendPage(nextLink);
        nextLink = links.shift();
    }
}

// Append a page from local link.
function appendPage(localLink) {
    $.get(localLink, function (data) {
        // Add container.
        $("body").append("<div class='container-fluid' id='lzload' />");
        // Add page data to the container.
        $("#lzload").append(
            // TODO: We create container, then select and append the rows? just append the whole container!
            // Do not want the entire HTML page content.
            $(data).children("[class*=container] > .row"));
        // We recalculate scroll trigger here. Because get() is async.
        calculateScrollTrigger();
    }, "html");
}


// --Append/load next page.
// --Provide feedback of page loading.
// ~Add enable/disable button.
