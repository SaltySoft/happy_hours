define([
    'jquery',
    'underscore',
    'backbone'
], function ($, _, Backbone) {

    var initialize = function (SmartBlocks) {

        $("#app_container").html("trololololo");

        Backbone.history.start();
    };

    return {
        initialize: initialize
    };
});