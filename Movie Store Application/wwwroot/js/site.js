// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var urlGlbl = window.location.host;
console.log(urlGlbl+'ji');

$(document).ready(function () {
    $('#searchMovies').on('keyup', function () {
        //debugger
       // if ($(this).val()) {
            var val = $(this).val().toLowerCase();
            $('#moviesTable tbody tr').filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(val) > -1)
            });
       // }
        
    });
});


