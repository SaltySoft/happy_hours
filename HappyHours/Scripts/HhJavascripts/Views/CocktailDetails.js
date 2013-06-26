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
            console.log("cocktail", base.cocktail);
            var cocktailDetailsTemplate = _.template(CocktailDetailsTemplate, {
                cocktailName:base.cocktail.get("Name"),
                cocktailDifficulty:base.cocktail.get("Difficulty"),
                cocktailDuration:base.cocktail.get("Duration"),
                cocktailDescription:base.cocktail.get("Description"),
                cocktailRecipe:base.cocktail.get("Recipe"),
                cocktailPictureUrl:base.cocktail.get("Picture_Url")
            });
            base.$el.html(cocktailDetailsTemplate);
            base.registerEvents();
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return CocktailDetailsView;
});