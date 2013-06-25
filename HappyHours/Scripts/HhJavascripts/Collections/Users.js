define([
    'underscore',
    'backbone',
    'Models/User'
], function (_, Backbone, User) {
    var UsersCollection = Backbone.Collection.extend({
        model: User,
        url: "/User/WsRest"
    });

    return UsersCollection;
});