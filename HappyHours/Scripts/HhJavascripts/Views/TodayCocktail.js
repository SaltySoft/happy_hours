define([
    'jquery',
    'underscore',
    'backbone',
    'text!/Scripts/HhJavascripts/Templates/today_cocktail.html'
], function ($, _, Backbone, TodayCocktailTemplate) {
    var TodayCocktail = Backbone.View.extend({
        tagName: "div",
        className: "happy_hours_today_cocktail",
        initialize: function () {
            var base = this;
            console.log("initialize TodayCocktail");
        },
        init: function () {
            var base = this;
            base.render(true);
            base.initializeEvents();
        },
        render: function () {
            var base = this;
            var todayCocktailTemplate = _.template(TodayCocktailTemplate, {
                todayCocktail:"MOJITO"
            });
            base.$el.html(todayCocktailTemplate);
        },
        initializeEvents: function (refetch) {
            var base = this;
        }
    });

    return TodayCocktail;
});