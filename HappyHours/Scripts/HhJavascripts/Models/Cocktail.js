define([
    'underscore',
    'backbone'
], function (_, Backbone) {
    var Cocktail = Backbone.Model.extend({
        urlRoot: "/Cocktail/WsRest",
        defaults: {
            Creator_Id: 1,
            Picture_Url: "http://placehold.it/300x300"
        }
    });

    return Cocktail;
});