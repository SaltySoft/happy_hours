define([
    'jquery',
    'underscore',
    'backbone',
    '/Scripts/HhJavascripts/launcher.js'
], function ($, _, Backbone, Launcher) {
    var initialize = function () {
        Launcher.initialize();
    };
    return {
        initialize: initialize
    };
});