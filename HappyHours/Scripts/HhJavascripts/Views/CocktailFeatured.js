define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!Templates/cocktail_featured.html',
    'Views/CocktailImage'
], function ($, _, Backbone, Cocktail, CocktailFeaturedTemplate, CocktailImageView) {
    var CocktailFeatured = Backbone.View.extend({
        tagName:"div",
        className:"cocktail_featured",
        initialize:function () {
            var base = this;
        },
        init:function (app) {
            var base = this;
            base.app = app;
            base.GetRandomCocktail(function () {
                base.render();
            });
        },
        render:function () {
            var base = this;
            var cocktailFeaturedTemplate = _.template(CocktailFeaturedTemplate, {
                cocktailFeaturedName:base.cocktailFeatured.get("Name"),
                cocktailFeaturedDescription:base.cocktailFeatured.get("Description"),
                cocktailFeaturedPictureUrl:base.cocktailFeatured.get("Picture_Url")
            });
            base.$el.html(cocktailFeaturedTemplate);

            var image_view = new CocktailImageView(base.cocktailFeatured);
            base.$el.find(".featured_cocktail_img_container").html(image_view.$el);
            image_view.init(base.app);
            base.initializeEvents();
        },
        GetRandomCocktail:function (callback) {
            var base = this;
            $.ajax({
                url:"/Cocktail/GetRandomCocktail",
                type:"get",
                success:function (data, status) {
                    base.cocktailFeatured = new Cocktail(data);
                    if (callback)
                        callback();
                }
            });
        },
        initializeEvents:function () {
            var base = this;

            base.$el.delegate("#show_cocktail_button", "click", function () {
                base.app.router.navigate("#cocktail/" + base.cocktailFeatured.get("Id"), {trigger:true});
            });
        }
    });

    return CocktailFeatured;
});