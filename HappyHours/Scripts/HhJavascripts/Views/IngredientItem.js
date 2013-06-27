define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/ingredient_item.html',
    'jqueryui'
], function ($, _, Backbone, IngredientItemTemplate) {
    var IngredientItemView = Backbone.View.extend({
        tagName: "li",
        className: "ingredient_item",
        initialize: function (model) {
            var base = this;

            base.model = model;
            base.ingredient = model;
            base.$el.attr("data-id", model.get("Id"));
        },
        init: function (app) {
            var base = this;
            base.app = app;

            base.render();
            base.registerEvents();
        },
        render: function () {
            var base = this;

            var template = _.template(IngredientItemTemplate, {
                ingredient: base.ingredient
            });

            base.$el.html(template);
            base.$el.disableSelection();
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return IngredientItemView;
});