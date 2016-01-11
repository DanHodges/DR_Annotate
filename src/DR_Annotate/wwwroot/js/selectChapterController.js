(function () {

    "use strict";

    angular.module("app")
      .controller("selectChapterController", selectChapterController);

    function selectChapterController($http) {
        var vm = this;
        vm.chapters = [];

        $http.get("/api/Chapters")
            .then(function (response) {
                angular.copy(response.data, vm.chapters);
                console.log("response :", response.data.results);
            }, function (error) {
                vm.errorMessage = "Failed to load data " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }
})();

        //vm.uploadChapter = function () {
        //    vm.chapter = document.getElementById('uploadChapter').files[0];
        //    $http.post("/api/chapters/" + vm.chapter)
        //      .then(function (response) {
        //          //success
        //          console.log("success");
        //          console.log("response.data :", response.data);
        //          vm.chapters.push(chapter);
        //          vm.chapter = {};
        //      }, function () {
        //          //error
        //          console.log(vm.newSoundClip);
        //          vm.errorMessage = "Failed to save new Instruments";
        //      });
        //}