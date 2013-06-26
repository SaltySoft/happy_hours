define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!/Scripts/HhJavascripts/Templates/today_cocktail.html'
], function ($, _, Backbone, Cocktail, TodayCocktailTemplate) {
    var TodayCocktail = Backbone.View.extend({
        tagName:"div",
        className:"happy_hours_today_cocktail",
        initialize:function () {
            var base = this;
        },
        init:function (app) {
            var base = this;
            base.app = app;
            base.GetRandomCocktail(function () {
                base.render();
            });
        },
        render:function () {
            var base = this;
            var todayCocktailTemplate = _.template(TodayCocktailTemplate, {
                todayCocktailName:base.todayCocktail.get("Name"),
                todayCocktailDescription:base.todayCocktail.get("Description"),
                picture_url:base.todayCocktail.get("Picture_Url")
           });
            base.$el.html(todayCocktailTemplate);
            base.initializeEvents();
        },
        GetRandomCocktail:function (callback) {
            var base = this;
            $.ajax({
                url:"/Cocktail/GetRandomCocktail",
                type:"get",
                success:function (data, status) {
                    base.todayCocktail = new Cocktail(data);
                    if (callback)
                        callback();
                }
            });
        },
        initializeEvents:function () {
            var base = this;

            base.$el.delegate("#show_cocktail_button", "click", function () {
                base.app.navigate("#cocktail/" + base.todayCocktail.get("id"), {trigger:true});
            });
        }
    });

    return TodayCocktail;
});