define([
    'underscore',
    'backbone'
], function (_, Backbone) {
    var Ingredient = Backbone.Model.extend({
        urlRoot: "/Ingredient/WsRest",
        defaults: {

        }
    });

    return Ingredient;
});