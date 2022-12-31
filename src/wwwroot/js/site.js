// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

autosize();
function autosize() {
    var text = $('.autosize');

    text.each(function () {
        $(this).attr('rows', 1);
        resize($(this));
    });

    text.on('input', function () {
        resize($(this));
    });

    function resize($text) {
        $text.css('height', 'auto');
        $text.css('height', $text[0].scrollHeight + 'px');
    }
}
