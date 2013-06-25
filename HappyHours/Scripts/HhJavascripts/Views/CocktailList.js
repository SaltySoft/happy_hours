define([
    'jquery',
    'underscore',
    'backbone'
], function ($, _, Backbone) {
    var CocktailListView = Backbone.View.extend({
        tagName: "div",
        className: "cocktail_list",
        initialize: function () {

        },
        init: function (app) {
            var base = this;
            base.app = app;

            base.render();
            base.registerEvents();
        },
        render: function () {
            var base = this;
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return CocktailListView;
});