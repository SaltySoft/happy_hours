define([
    'jquery',
    'underscore',
    'backbone',
    'Views/MainView'
], function ($, _, Backbone, MainView) {

    var initialize = function (app) {

        var main_view = new MainView();
        $("#app_container").html(main_view.$el);
        main_view.init(app);

        Backbone.history.start();
    };

    return {
        initialize: initialize
    };
});