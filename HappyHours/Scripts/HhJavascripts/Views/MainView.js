define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/main_view.html',
    'Views/CocktailList',
    'Views/CocktailCreation'
], function ($, _, Backbone, MainViewTemplate, CocktailListView, CocktailCreationView) {
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
                    "cocktails": "cocktails",
                    "add_cocktail" : "add_cocktail"
                },
                cocktails: function () {
                    var cocktail_list = new CocktailListView();
                    base.$el.find("#sub_app_container").html(cocktail_list.$el);
                    cocktail_list.init(base.app);
                },
                add_cocktail: function () {
                    var add_cocktail_view = new CocktailCreationView();
                    base.$el.find("#sub_app_container").html(add_cocktail_view.$el);
                    add_cocktail_view.init(base.app);
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