// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('.view-recipe').on('click', function (e) {
        e.preventDefault();
        var recipeDetails = $(this).siblings('.recipe-details');
        var hideRecipeButton = $(this).siblings('.hide-recipe');

        recipeDetails.toggle();
        hideRecipeButton.toggle();
    });

    $('.hide-recipe').on('click', function (e) {
        e.preventDefault();
        var recipeDetails = $(this).siblings('.recipe-details');
        var viewRecipeButton = $(this).siblings('.view-recipe');

        recipeDetails.hide();
        $(this).hide();
        viewRecipeButton.show();
    });
});