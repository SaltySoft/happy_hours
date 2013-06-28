define([
    'underscore',
    'backbone',
    'Models/Ingredient',
    'Collections/Ingredients'
], function (_, Backbone, Ingredient, IngredientsCollection) {
    var Cocktail = Backbone.Model.extend({
        urlRoot: "/Cocktail/WsRest",
        defaults: {
            Creator_Id: 1,
            Picture_Url: "http://placehold.it/300x300"
        },
        initialize: function (attributes) {
            if (attributes) {
                this.id = attributes.Id ? attributes.Id : 0;
            }

            if (attributes && attributes.Ingredients) {
                var ing_array = attributes.Ingredients;
                var ingredients = new IngredientsCollection();
                for (var k in ing_array)
                {
                    var obj = ing_array[k];
                    ingredients.add(new Ingredient(obj));
                }
                attributes.Ingredients = ingredients;
                this.attributes = attributes;
            }
        },
        parse: function (response) {
            this.id = response.Id;

            var ingredients = new IngredientsCollection();
            if (response.Ingredients) {
                var ing_array = response.Ingredients;
                for (var k in ing_array)
                {
                    var obj = ing_array[k];
                    ingredients.add(new Ingredient(obj));
                }
            }
            response.Ingredients = ingredients;
            return response;
        }
    });

    return Cocktail;
});