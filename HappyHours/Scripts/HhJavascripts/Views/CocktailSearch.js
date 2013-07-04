define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!Templates/cocktail_search.html'
], function ($, _, Backbone, Cocktail, CocktailSearchTemplate) {
    var CocktailSearchView = Backbone.View.extend({
        tagName: "div",
        className: "cocktail_search",
        initialize: function () {
            var base = this;
        },
        init: function (app) {
            var base = this;
            base.app = app;
            base.render();
        },
        render: function () {
            var base = this;
            var cocktailSearchTemplate = _.template(CocktailSearchTemplate, {
            });
            base.$el.html(cocktailSearchTemplate);
            base.registerEvents();
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return CocktailSearchView;
});