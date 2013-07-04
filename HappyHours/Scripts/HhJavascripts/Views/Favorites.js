define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/favorites_template.html',
    'Views/FavoritesItem'
], function ($, _, Backbone, FavoritesTemplate, FavoritesItem) {
    var FavoritesView = Backbone.View.extend({
        tagName: "div",
        className: "favorites_view",
        initialize: function () {

        },
        init: function (app) {
            var base = this;
            base.app = app;

            if (!base.app.current_user) {
                base.app.show_message("Vous devez être connecté pour voir vos favoris.");
                base.app.router.navigate("#", {
                    trigger: true
                });
            }

            base.render();
            base.registerEvents();
        },
        render: function () {
            var base = this;

            var template = _.template(FavoritesTemplate, {});

            base.$el.html(template);
            var favs_list = base.app.current_user.get("Favorites").models;
            for (var k in favs_list) {
                var cocktail = favs_list[k];
                var fav_item_view = new FavoritesItem(cocktail);
                base.$el.find(".favorites_list").append(fav_item_view.$el);
                fav_item_view.init(base.app);
            }
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return FavoritesView;
});