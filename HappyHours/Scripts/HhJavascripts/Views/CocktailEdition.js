define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_edition.html',
    'Collections/Ingredients',
    'Views/IngredientItem'
], function ($, _, Backbone, CocktailEditionTemplate, IngredientsCollection, IngredientItemView) {
    var CocktailEditionView = Backbone.View.extend({
        tagName: "div",
        className: "cocktail_edition_view",
        initialize: function (model) {
            var base = this;

            base.model = model;
            base.cocktail = model;
        },
        init: function (app) {
            var base = this;

            base.app = app;

            base.ingredients_collection = new IngredientsCollection();

            base.cocktail.fetch({
                success: function () {
                    base.render();
                    base.registerEvents();
                }
            });

        },
        render: function () {
            var base = this;

            var template = _.template(CocktailEditionTemplate, {
                cocktail:base.cocktail
            });

            base.$el.html(template);

            base.ingredients_collection.fetch({
                success: function () {
                    var list = base.ingredients_collection.models;

                    for (var k in list) {
                        var ingredient = list[k];
                        var ingredient_item = new IngredientItemView(ingredient);
                        base.$el.find(".all_ingredients").append(ingredient_item.$el);
                        ingredient_item.init(base.app);
                    }
                }
            });
        },
        registerEvents: function () {
            var base = this;

            base.$el.delegate(".form_cocktail", "submit", function () {
                var form = $(this);
                var array = form.serializeArray();

                for (var k in array) {
                    base.cocktail.set(array[k].name, array[k].value);
                }
                console.log("about_to_save", base.cocktail);
                base.cocktail.save({}, {
                    success: function () {
                        console.log("Saved cocktail : ", base.cocktail);
                        base.cocktail.fetch({
                            success: function () {

                            }
                        });
                    }
                });


                return false;
            });

            base.$el.find(".form_iframe").load(function () {
                base.cocktail.fetch({
                    success: function () {
                        base.$el.find(".cocktail_picture").attr("src", base.cocktail.get("Picture_Url"));
                    }
                });
            });
        }
    });

    return CocktailEditionView;
});