define([
    'underscore',
    'backbone',
    'Models/Ingredient'
], function (_, Backbone, Ingredient) {
    var IngredientsCollection = Backbone.Collection.extend({
        model: Ingredient,
        url: "/Ingredient/WsRest"
    });

    return IngredientsCollection;
});