define([
    'underscore',
    'backbone',
    'Models/Cocktail',
    'Collections/Cocktails'
], function (_, Backbone, Cocktail, CocktailsCollection) {
    var User = Backbone.Model.extend({
        urlRoot: "/User/WsRest",
        defaults: {

        },
        initialize: function (attributes) {
            if (attributes && attributes.Favorites) {
                var favorites_array = attributes.Favorites;
                var favorites = new CocktailsCollection();
                for (var k in favorites_array)
                {
                    var obj = favorites_array[k];
                    favorites.add(new Cocktail(obj));
                }
                attributes.Favorites = favorites;
            }
//            console.log("PARSED", attributes);
            this.attributes = attributes;
        },
        parse: function (response) {
            var favorites_array = response.Favorites;
            var favorites = new CocktailsCollection();
            for (var k in favorites_array)
            {
                var obj = favorites_array[k];
                favorites.add(new Cocktail(obj));
            }
            response.Favorites = favorites;
//            console.log("PARSED", response);
            return response;
        },
        hasRole: function (role) {
            var base = this;
            var roles = base.get("Roles");
            for (var k in roles) {
                if (role === roles[k] ) {
                    return true;
                }
            }
            return false;
        }
    });

    return User;
});