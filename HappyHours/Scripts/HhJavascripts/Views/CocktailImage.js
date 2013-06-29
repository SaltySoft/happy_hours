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
        init: function (app, overlay) {
            var base = this;

            base.app = app;
            base.overlay = overlay;
            if (base.$el.parent().hasClass("big")) {
                base.$el.addClass("big");
            }
            if (base.$el.parent().hasClass("small")) {
                base.$el.addClass("small");
            }
            if (base.$el.parent().hasClass("huge")) {
                base.$el.addClass("huge");
            }

            base.render();
            base.registerEvents();


        },
        render: function () {
            var base = this;

            var template = _.template(CoktailImageTemplate, {
                cocktail: base.cocktail
            });
            base.$el.html(template);
            base.$el.find(".cocktail_img").error(function () {
                if ($(this).attr("src") != "/Images/no_picture.png") {
                    $(this).attr("src", "/Images/no_picture.png");
                    base.readjust();
                }

            });
            if (base.overlay) {
                var div = $(document.createElement("div"));
                div.addClass("picture_overlay");
                base.$el.append(div);
                div.html(base.cocktail.get("Name"));
                div.width(base.$el.width() - 2);
            }
        },
        readjust: function () {
            var base = this;
            var img = base.$el.find(".cocktail_img");
            var width = img.width();
            var height = img.height();
            if (width <= height) {
                img.css("height", "auto");
                img.css("width", base.$el.width());
                img.css("top", -img.height() / 2 + base.$el.height() / 2);
                img.css("left", 0);

            } else {
                img.css("width", "auto");
                img.css("height", base.$el.height());
                img.css("top", 0);
                img.css("left", -img.width() / 2 + base.$el.width() / 2);
            }
        },
        registerEvents: function () {
            var base = this;

            base.cocktail.on("change", function () {
                base.$el.find(".cocktail_img").attr("src", base.cocktail.get("Picture_Url") != "" ? base.cocktail.get("Picture_Url") : "/Images/no_picture.png");
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