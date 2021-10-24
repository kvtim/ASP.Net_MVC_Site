$(document).ready(function () {
    // subscribe pager buttons to click event
    $(".page-link").click(function (e) {
        e.preventDefault();
        // get address
        var uri = this.attributes["href"].value;
        // send an asynchronous request and post a response
        // to a container with id = "list"
        $("#list").load(uri);
        // deselect a button
        $(".active").removeClass("active disabled");
        // highlight the current button
        $(this).parent().addClass("active");
        // change the address in the address bar of the browser
        history.pushState(null, null, uri);
    });
});