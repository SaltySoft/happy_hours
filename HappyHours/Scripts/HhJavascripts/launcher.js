define([
    'jquery',
    'underscore',
    'backbone',
    'Views/TodayCocktail',
    'Views/MainView'
], function ($, _, Backbone, TodayCocktailView, MainView) {

    var initialize = function (app) {

//        var todayCocktail = new TodayCocktailView();
//        todayCocktail.init();
//
//        $("#app_container").html(todayCocktail.$el);

        var main_view = new MainView();
        $("#app_container").html(main_view.$el);
        main_view.init(app);

        Backbone.history.start();
    };

    return {
        initialize: initialize
    };
});