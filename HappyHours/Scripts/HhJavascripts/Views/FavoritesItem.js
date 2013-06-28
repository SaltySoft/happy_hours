define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/favorites_item_template.html',
    'Views/CocktailImage'
], function ($, _, Backbone, FavoritesItemTemplate, CocktailImageView) {
    var FavoritesView = Backbone.View.extend({
        tagName: "li",
        className: "favorites_view_item",
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

            var cocktail_image = new CocktailImageView(base.cocktail);
            base.$el.find(".cocktail_image").html(cocktail_image.$el);
            cocktail_image.init(base.app, true);
        },
        registerEvents: function () {
            var base = this;

            base.$el.delegate(".unfav_button", "click", function (e) {
                base.app.current_user.get("Favorites").remove(base.cocktail);
                base.app.current_user.save();
                base.$el.remove();
                e.stopPropagation();
            });

            base.$el.click(function () {
                base.app.router.navigate("#cocktail/" + base.cocktail.get("Id"), {
                    trigger: true
                });
            });
        }
    });

    return FavoritesView;
});