define([
    'jquery',
    'underscore',
    'backbone',
    'text!/Scripts/HhJavascripts/Templates/today_cocktail.html'
], function ($, _, Backbone, TodayCocktailTemplate) {
    var TodayCocktail = Backbone.View.extend({
            tagName:"div",
            className:"happy_hours_today_cocktail",
            initialize:function () {
                var base = this;
            },
            init:function (app) {
                var base = this;
                base.app = app;
                base.render();
                base.initializeEvents();
            },
            render:function () {
                var base = this;
                var todayCocktailTemplate = _.template(TodayCocktailTemplate, {
                    todayCocktail:"MOJITO",
                    todayCocktailDescription:"Très parfumé, légèrement sucré et avec une pointe d'acidité, ce Cocktail élégant et cosmopolite a fait sa place parmi les grands classiques et c'est aujourd'hui le Cocktail le plus célèbre. Certaines variantes sont réalisées avec du citron jaune, ou sans eau gazeuse et en mettant des morceaux de citron vert au fond du verre, d'autres avec de la glace pilée ou avec un bitter, mais la recette originale est celle-ci.",
                    picture_url:"http://www.pariszigzag.fr/wp-content/themes/LondonLive/thumb.php?src=/wp-content/uploads/2011/07/mojito.jpg"
                });
                base.$el.html(todayCocktailTemplate);
            },
            initializeEvents:function () {
                var base = this;
            }
        })
        ;

    return TodayCocktail;
})
;