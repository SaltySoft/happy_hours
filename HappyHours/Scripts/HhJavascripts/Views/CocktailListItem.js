define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_list_item.html'
], function ($, _, Backbone, CocktailListItemTemplate) {
    var CocktailListItemView = Backbone.View.extend({
        tagName:"li",
        className:"cocktail_item",
        initialize:function (model) {
            var base = this;
            base.model = model;
            base.cocktail = model;
        },
        init:function (app) {
            var base = this;

            base.app = app;

            base.render();
            base.registerEvents();
        },
        render:function () {
            var base = this;
            var template = _.template(CocktailListItemTemplate, {
                cocktail:base.cocktail
            });

            base.$el.html(template);
            var image = base.$el.find(".cocktail_item_image_img");
            image.load(function () {
                image.css("left", 75 - image.width() / 2);
                image.css("top", 75 - image.height() / 2);
            });
            if (base.app.current_user !== undefined && base.app.current_user.get("Favorites") !== undefined) {
                if (base.app.current_user.get("Favorites").get(base.cocktail.get("Id"))) {
                    base.$el.addClass("faved");
                }
            }
        },
        registerEvents:function () {
            var base = this;

            base.$el.delegate(".fav_button", "click", function () {
                base.app.current_user.get("Favorites").add(base.cocktail);
                base.$el.addClass("faved");
                base.app.current_user.save({}, {
                    success:function () {
                        base.app.show_message("Le cocktail a été ajouté à vos favoris");
                    }
                });
            });

            base.$el.delegate(".unfav_button", "click", function () {
                base.app.current_user.get("Favorites").remove(base.cocktail);
                base.$el.removeClass("faved");
                base.app.current_user.save({}, {
                    success:function () {
                        base.app.show_message("Le cocktail a été retiré de vos favoris");
                    }
                });
            });
        }
    });

    return CocktailListItemView;
});