define([
    'underscore',
    'backbone',
    'Models/Cocktail'
], function (_, Backbone, Cocktail) {
    var CocktailsCollection = Backbone.Collection.extend({
        model: Cocktail,
        url: "/Cocktail/WsRest"
    });

    return CocktailsCollection;
});