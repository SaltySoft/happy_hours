define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!Templates/cocktail_edition.html',
    'Collections/Ingredients',
    'Views/IngredientItem',
    'Views/CocktailImage',
    'jqueryui'
], function ($, _, Backbone, Cocktail, CocktailEditionTemplate, IngredientsCollection, IngredientItemView, CocktailImageView) {
    var CocktailEditionView = Backbone.View.extend({
        tagName:"div",
        className:"cocktail_edition_view",
        initialize:function () {
            var base = this;
        },
        init:function (app, id) {
            var base = this;
            base.app = app;


            base.ingredients_collection = new IngredientsCollection();
            base.cocktail = new Cocktail({ Id : id});

            base.cocktail.fetch({
                success:function () {
                    base.cocktail_image = new CocktailImageView(base.cocktail);
                    if ((!base.app.current_user || base.app.current_user.get("Id") != base.cocktail.get("Creator_Id"))) {
                        base.app.show_message("Vous n'avez pas les droits pour accéder à cette page");
                        base.app.router.navigate("#cocktail/" + base.cocktail.get("Id"), {trigger: true} );
                    }

                    base.render();
                    base.registerEvents();
                }
            });
        },
        render:function () {
            var base = this;
            var template = _.template(CocktailEditionTemplate, {
                cocktail:base.cocktail
            });

            base.$el.html(template);
            window.current_cocktail = base.cocktail;

            base.$el.find(".cocktail_edition_image").html(base.cocktail_image.$el);
            base.cocktail_image.init(base.app);

            base.ingredients_collection.fetch({
                success:function () {
                    var list = base.ingredients_collection.models;
                    base.$el.find(".all_ingredients").find(".ingredient_item").remove();
                    for (var k in list) {
                        var ingredient = list[k];
                        console.log(base.cocktail.get("Ingredients"));

                        var ingredient_item = new IngredientItemView(ingredient);
                        if (base.cocktail.get("Ingredients") !== undefined && base.cocktail.get("Ingredients") != null && base.cocktail.get("Ingredients").get(ingredient.get("Id"))) {
                            base.$el.find(".selected_ingredients").append(ingredient_item.$el);
                        } else {
                            base.$el.find(".all_ingredients").append(ingredient_item.$el);
                        }
                        ingredient_item.init(base.app);
                    }
                }
            });

            console.log(base.cocktail);
            base.$el.find(".all_ingredients").sortable({
                connectWith:".ingredients_list",
                receive:function (event, ui) {
                    base.cocktail.get("Ingredients").remove(base.ingredients_collection.get(ui.item.attr("data-id")));
                    console.log("base.cocktail.get(Ingredients)", base.cocktail.get("Ingredients"));
                }
            });

            base.$el.find(".selected_ingredients").sortable({
                connectWith:".ingredients_list",
                receive:function (event, ui) {
                    base.cocktail.get("Ingredients").add(base.ingredients_collection.get(ui.item.attr("data-id")));
                    console.log("base.cocktail.get(Ingredients)", base.cocktail.get("Ingredients"));
                }
            });
        },
        registerEvents:function () {
            var base = this;

            base.$el.delegate(".form_cocktail", "submit", function () {
                var form = $(this);
                var array = form.serializeArray();

                for (var k in array) {
                    base.cocktail.set(array[k].name, array[k].value);
                }

                base.cocktail.save({}, {
                    success:function () {

                    }
                });

                return false;
            });

            base.$el.find(".form_iframe").load(function () {
                base.cocktail.fetch({
                    success:function () {
                        console.log("FETCHED COCKTAIL AFTER IMAGE", base.cocktail);
                        base.$el.find(".cocktail_picture").attr("src", base.cocktail.get("Picture_Url"));
                    }
                });
            });
        }
    });

    return CocktailEditionView;
});