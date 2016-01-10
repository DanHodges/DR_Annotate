(function () {

    "use strict";

    angular.module("app", ["ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "selectChapterController",
                controllerAs: "vm",
                templateUrl: "/views/selectChapterView.html"
            });
            $routeProvider.when("/edit/:chapter", {
                controller: "editChapterController",
                controllerAs: "vm",
                templateUrl: "/views/editChapterView.html"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        });

})();