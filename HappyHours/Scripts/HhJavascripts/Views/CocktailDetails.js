define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!Templates/cocktail_details.html'
], function ($, _, Backbone, Cocktail, CocktailDetailsTemplate) {
    var CocktailDetailsView = Backbone.View.extend({
        tagName: "div",
        className: "cocktail_details",
        initialize: function () {
            var base = this;
        },
        init: function (app, id) {
            var base = this;
            base.app = app;

            base.cocktail = new Cocktail({ id : id });
            base.cocktail.fetch({
               success:function () {
                   base.render();
               }
            });
        },
        render: function () {
            var base = this;
            var cocktailFeaturedTemplate = _.template(CocktailDetailsTemplate, {
                cocktailFeaturedName:base.cocktail.get("Name"),
                cocktailFeaturedDescription:base.cocktail.get("Description"),
                cocktailFeaturedPictureUrl:base.cocktail.get("Picture_Url")
            });
            console.log("base.cocktail", base.cocktail);
            base.$el.html(cocktailFeaturedTemplate);
            base.registerEvents();
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return CocktailDetailsView;
});