define([
    'underscore',
    'backbone'
], function (_, Backbone) {
    var Cocktail = Backbone.Model.extend({
        urlRoot: "/Cocktail/WsRest",
        defaults: {

        }
    });

    return Cocktail;
});