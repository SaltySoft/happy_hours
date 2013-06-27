define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/favorites_item_template.html'
], function ($, _, Backbone, FavoritesItemTemplate) {
    var FavoritesView = Backbone.View.extend({
        tagName: "li",
        className: "favorites_view",
        initialize: function (cocktail) {
            var base = this;
            base.model = cocktail;
            base.cocktail = cocktail;
        },
        init: function (app) {
            var base = this;
            base.app = app;

            base.render();
            base.registerEvents();
        },
        render: function () {
            var base = this;

            var template = _.template(FavoritesItemTemplate, {
                cocktail: base.cocktail
            });

            base.$el.html(template);
        },
        registerEvents: function () {
            var base = this;

            base.$el.delegate(".unfav_button", "click", function () {
                base.app.current_user.get("Favorites").remove(base.cocktail);
                base.app.current_user.save();
                base.$el.remove();
            });
        }
    });

    return FavoritesView;
});