define([
    'jquery',
    'underscore',
    'backbone',
    'launcher'
], function ($, _, Backbone, Launcher) {
    var initialize = function (app) {
        Launcher.initialize(app);
    };
    return {
        initialize: initialize
    };
});