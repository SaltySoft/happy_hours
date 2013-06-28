define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_image.html'
], function ($, _, Backbone, CoktailImageTemplate) {
    var CocktailImageView = Backbone.View.extend({
        tagName: "div",
        className: "cocktail_image",
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
            console.log("stuff");
        },
        render: function () {
            var base = this;

            var template = _.template(CoktailImageTemplate, {
                cocktail: base.cocktail
            });
            base.$el.html(template);
        },
        readjust: function () {
            var base = this;
            var img = base.$el.find(".cocktail_img");
            var width = img.width();
            var height  = img.height();
            if (width < height) {
                img.css("width", base.$el.width());
                img.css("top", -img.height() / 2 + base.$el.height() / 2);
            } else {
                img.css("height", base.$el.height());
                img.css("left", -img.width() / 2 + base.$el.width() / 2);
            }
        },
        registerEvents: function () {
            var base = this;

            base.cocktail.on("change", function () {
                base.$el.find(".cocktail_img").attr("src", base.cocktail.get("Picture_Url"));
                base.readjust();
            });

            base.$el.find(".cocktail_img").load(function () {
                base.readjust();
            });
            base.readjust();
        }
    });

    return CocktailImageView;
});