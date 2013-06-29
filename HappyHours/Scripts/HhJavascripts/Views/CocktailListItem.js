define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_list_item.html',
    'Views/CocktailImage'
], function ($, _, Backbone, CocktailListItemTemplate, CocktailImageView) {
    var CocktailListItemView = Backbone.View.extend({
        tagName: "li",
        className: "cocktail_item",
        initialize: function (model) {
            var base = this;
            base.model = model;
            base.cocktail = model;
        },
        init: function (app) {
            var base = this;

            base.app = app;

            base.render();
            base.registerEvents();
        },
        render: function () {
            var base = this;

            var template = _.template(CocktailListItemTemplate, {
                cocktail: base.cocktail
            });
            base.$el.html(template);

            var image_view = new CocktailImageView(base.cocktail);
            base.$el.find(".cocktail_item_image").html(image_view.$el);
            image_view.init(base.app);

            if (base.app.current_user && base.app.current_user.get("Favorites").get(base.cocktail.get("Id"))) {
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

    return CocktailListItemView;
});