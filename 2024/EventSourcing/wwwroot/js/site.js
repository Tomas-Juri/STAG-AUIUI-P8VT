// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

onFileUpload = function (event) {
    var element = document.getElementById(event.target.id + "-thumbnail");
    element.classList.remove("d-none")
    element.src = URL.createObjectURL(event.target.files[0])
}