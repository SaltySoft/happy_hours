define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!Templates/cocktail_details.html',
    'Views/CocktailImage'
], function ($, _, Backbone, Cocktail, CocktailDetailsTemplate, CocktailImageView) {
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
                cocktailPictureUrl:base.cocktail.get("Picture_Url"),
                ingredients: base.cocktail.get("Ingredients").models
            });
            base.$el.html(cocktailDetailsTemplate);
            base.registerEvents();
            var img_container = base.$el.find(".cocktail_img_container");

            var image_view = new CocktailImageView(base.cocktail);
            img_container.html(image_view.$el);
            image_view.init(base.app);
        },
        registerEvents:function () {
            var base = this;
        }
    });

    return CocktailDetailsView;
});