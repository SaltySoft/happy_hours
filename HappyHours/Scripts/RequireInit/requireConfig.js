var sb_paths = {
    jquery: "/Scripts/javascript/jquery",
    underscore: "/Scripts/javascript/underscore-min",
    underscore_string: '/Scripts/javascript/underscore-string',
    backbone: "/Scripts/javascript/backbone-min",
    text: "/Scripts/javascript/text",
    default: "/Scripts/HhJavascripts/default",
    jqueryui : "/Scripts/jquery-ui"
}

var sb_shims = {
    'underscore': {
        exports: '_'
    },
    underscore_string: {
        deps: ['underscore'],
        exports: '_s'
    },
    'backbone': {
        deps: ['underscore', 'jquery'],
        exports: 'Backbone'
    },
    'jqueryui' : {
        deps : ['jquery'],
        exports: 'JqueryUI'
    }
};