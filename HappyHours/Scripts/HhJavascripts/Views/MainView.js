﻿define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/main_view.html',
    'Views/CocktailList'
], function ($, _, Backbone, MainViewTemplate, CocktailListView) {
    var MainView = Backbone.View.extend({
        tagName: "div",
            className: "main_view",
        initialize: function () {

        },
        init: function (app) {
            var base = this;

            base.app = app;
            base.render();
            base.registerEvents();

            var AppRouter = Backbone.Router.extend({
                routes: {
                    "cocktails": "cocktails"
                },
                cocktails: function () {
                    var cocktail_list = new CocktailListView();
                    base.$el.find("#sub_app_container").html(cocktail_list.$el);
                    cocktail_list.init(base.app);
                }
            });

            var router = new AppRouter();
        },
        render: function () {
            var base = this;
            var template = _.template(MainViewTemplate, {});

            base.$el.html(template);
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return MainView;
});