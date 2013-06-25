define([
    'jquery',
    'underscore',
    'backbone',
    '/Scripts/HhJavascripts/Views/TodayCocktail.js'
], function ($, _, Backbone, TodayCocktailView) {

    var initialize = function () {

        var todayCocktail = new TodayCocktailView();
        todayCocktail.init();

        $("#app_container").html(todayCocktail.$el);

        Backbone.history.start();
    };

    return {
        initialize: initialize
    };
});