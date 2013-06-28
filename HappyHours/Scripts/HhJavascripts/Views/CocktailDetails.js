define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!Templates/cocktail_details.html'
], function ($, _, Backbone, Cocktail, CocktailDetailsTemplate) {
    var CocktailDetailsView = Backbone.View.extend({
        tagName:"div",
        className:"cocktail_details",
        initialize:function () {
            var base = this;
        },
        init:function (app, id) {
            var base = this;
            base.app = app;

            if (base.app.isNormalInteger(id)) {
                base.cocktail = new Cocktail({ id: id, Id: id });

                base.cocktail.fetch({
                    success:function () {
                        base.render();

                    }
                });
            }
            else {
                base.app.router.navigate("#", { trigger:true })
            }
        },
        render:function () {
            var base = this;
            var cocktailDetailsTemplate = _.template(CocktailDetailsTemplate, {
                cocktail: base.cocktail,
                user: base.app.current_user,
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
        registerEvents:function () {
            var base = this;
        }
    });

    return CocktailDetailsView;
});