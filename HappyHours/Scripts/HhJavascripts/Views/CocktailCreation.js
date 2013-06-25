define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_creation.html'
], function ($, _, Backbone, CocktailCreationTemplate) {
    var CocktailCreationView = Backbone.View.extend({
        tagName: "div",
        className: "cocktail_creation",
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
            var template = _.template(CocktailCreationTemplate, {});
            base.$el.html(template);
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return CocktailCreationView;
});