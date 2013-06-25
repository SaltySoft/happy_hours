define([
    'underscore',
    'backbone'
], function (_, Backbone) {
    var User = Backbone.Model.extend({
        urlRoot: "/User/WsRest",
        defaults: {

        }
    });

    return User;
});