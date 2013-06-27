define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_edition.html',
    'Collections/Ingredients',
    'Views/IngredientItem',
    'jqueryui'
], function ($, _, Backbone, CocktailEditionTemplate, IngredientsCollection, IngredientItemView) {
    var CocktailEditionView = Backbone.View.extend({
        tagName:"div",
        className:"cocktail_edition_view",
        initialize:function (model) {
            var base = this;

            base.model = model;
            base.cocktail = model;
        },
        init:function (app) {
            var base = this;

            base.app = app;

            base.ingredients_collection = new IngredientsCollection();

            base.cocktail.fetch({
                success:function (cocktail) {
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

                var ingredients = base.cocktail.get("Ingredients");
                console.log("ingredients", ingredients);
                for (var k in array) {
                    base.cocktail.set(array[k].name, array[k].value);
                }
                for (var k in ingredients) {
                    base.cocktail.get("Ingredients").add(ingredients[k]);
                }

                console.log("about_to_save", base.cocktail);
                base.cocktail.save({}, {
                    success:function () {
                        console.log("Saved cocktail : ", base.cocktail);
                        base.cocktail.fetch({
                            success:function () {
                            }
                        });
                    }
                });

                return false;
            });

            base.$el.find(".form_iframe").load(function () {
                base.cocktail.fetch({
                    success:function () {
                        base.$el.find(".cocktail_picture").attr("src", base.cocktail.get("Picture_Url"));
                    }
                });
            });
        }
    });

    return CocktailEditionView;
});