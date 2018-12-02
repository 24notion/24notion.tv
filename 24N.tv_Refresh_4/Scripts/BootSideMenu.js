// Fork from http://www.jqueryscript.net/demo/Sliding-Side-Menu-Panel-with-jQuery-Bootstrap-BootSideMenu/
// Tweaked to work with 24Notion.TV and the Bootstrap Navbar.

(function ($) {
    $.fn.BootSideMenu = function(options) {
        var oldCode, newCode, side, autoClose; 
        var settings = $.extend({
            side: "left",
            autoClose: true
        }, options);

        side = settings.side;
        autoClose = settings.autoClose;
        oldCode = this.html();

        this.addClass("sidebar sidebar-" + ((side == "right") ? "right" : "left")).attr('data-side', side);

        newCode = "";
        newCode += oldCode + "\n";
        newCode +=
            "<div class=\"navbar-header\" style=\"z-index:1;\">" +
            "    <button type=\"button\" class=\"navbar-toggle\">" +
            "        <span class=\"sr-only\">Toggle navigation</span>" +
            "        <span class=\"icon-bar\"></span>" +
            "        <span class=\"icon-bar\"></span>" +
            "        <span class=\"icon-bar\"></span>" +
            "    </button>" +
            "</div>";

        this.html(newCode);

        if (autoClose) {
            $(this).find(".navbar-header > button").trigger("click");
        }
    };

    $(document).on('click', '.navbar-header > button', function () {
        var toggler = $(this);
        var container = toggler.parent().parent();
        var containerWidth = container.width();
        var status = container.attr('data-status');
        var side = container.attr('data-side');
        if (!status) {
            status = "opened";
        }
        doAnimation(container, containerWidth, side, status);
    });

    function doAnimation(container, containerWidth, sidebarSide, sidebarStatus) {
        if (sidebarStatus == "opened") {
            if (sidebarSide == "left") {
                container.animate({
                    left: -(containerWidth + 2)
                });
            } else if (sidebarSide == "right") {
                container.animate({
                    right: -(containerWidth + 2)
                });
            }
            container.attr('data-status', 'closed');
        } else {
            if (sidebarSide == "left") {
                container.animate({
                    left: 0
                });
            } else if (sidebarSide == "right") {
                container.animate({
                    right: 0
                });
            }
            container.attr('data-status', 'opened');
        }
    }
}(jQuery));