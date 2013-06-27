define([
    'underscore',
    'backbone'
], function (_, Backbone) {
    var Ingredient = Backbone.Model.extend({
        urlRoot: "/Ingredient/WsRest",
        defaults: {

        },
        initialize: function (attributes) {
            if (attributes) {
                this.id = attributes.Id ? attributes.Id : 0;
            }

        },
        parse: function (response) {
            this.id = response.Id;
            return response;
        }
    });

    return Ingredient;
});