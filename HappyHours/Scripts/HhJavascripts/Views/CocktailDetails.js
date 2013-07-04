define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!Templates/cocktail_details.html',
    'Views/CocktailImage'
], function ($, _, Backbone, Cocktail, CocktailDetailsTemplate, CocktailImageView) {
    var CocktailDetailsView = Backbone.View.extend({
        tagName: "div",
        className: "cocktail_details",
        initialize: function (cocktail) {
            var base = this;
            base.model = cocktail;
            base.cocktail = cocktail;
        },
        init: function (app) {
            var base = this;
            base.app = app;

            base.cocktail.fetch({
                success: function () {
                    base.render();
                }
            });
        },
        render: function () {
            var base = this;
            var cocktailDetailsTemplate = _.template(CocktailDetailsTemplate, {
                cocktail: base.cocktail,
                user: base.app.current_user,
                cocktailName: base.cocktail.get("Name"),
                cocktailDifficulty: base.cocktail.get("Difficulty"),
                cocktailDuration: base.cocktail.get("Duration"),
                cocktailDescription: base.cocktail.get("Description"),
                cocktailRecipe: base.cocktail.get("Recipe"),
                cocktailPictureUrl: base.cocktail.get("Picture_Url"),
                ingredients: base.cocktail.get("Ingredients").models
            });
            base.$el.html(cocktailDetailsTemplate);
            base.registerEvents();
            var img_container = base.$el.find(".cocktail_img_container");

            var image_view = new CocktailImageView(base.cocktail);
            img_container.html(image_view.$el);
            image_view.init(base.app);

            var fav_cocktail = base.app.current_user.get("Favorites").get(base.cocktail.get("Id"));
            if (fav_cocktail !== undefined && fav_cocktail != null) {
                base.$el.find(".favoriting").addClass("faved");
            }
        },
        registerEvents: function () {
            var base = this;

            base.$el.delegate(".fav_button", "click", function () {
                base.app.current_user.get("Favorites").add(base.cocktail);
                base.$el.find(".favoriting").addClass("faved");
                base.app.current_user.save({}, {
                    success: function () {
                        base.app.show_message("Le cocktail a été ajouté à vos favoris");
                    }
                });
            });

            base.$el.delegate(".unfav_button", "click", function () {
                base.app.current_user.get("Favorites").remove(base.cocktail);
                base.$el.find(".favoriting").removeClass("faved");
                base.app.current_user.save({}, {
                    success: function () {
                        base.app.show_message("Le cocktail a été retiré de vos favoris");
                    }
                });
            });
        }
    });

    return CocktailDetailsView;
});