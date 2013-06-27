define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/ingredient_item.html'
], function ($, _, Backbone, IngredientItemTemplate) {
    var IngredientItemView = Backbone.View.extend({
        tagName: "li",
        className: "ingredient_item",
        initialize: function (model) {
            var base = this;

            base.model = model;
            base.ingredient = model;
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

            base.$el.find(".ingredient_name").draggable();
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return IngredientItemView;
});