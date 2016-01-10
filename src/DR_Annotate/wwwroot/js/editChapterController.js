(function () {

    "use strict";

    angular.module("app")
      .controller("editChapterController", editChapterController);

    function editChapterController($routeParams, $http) {
        var vm = this;
        console.log("$routeParams :", $routeParams);
        vm.chapter = $routeParams.chapter;
        vm.chapter = [];
        console.log("editChapterController");

    }
})();