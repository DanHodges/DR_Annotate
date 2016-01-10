(function () {

    "use strict";

    angular.module("app")
      .controller("selectChapterController", selectChapterController);

    function selectChapterController($http) {
        var vm = this;
        vm.chapters = [];
        vm.chapter = {};
        vm.annotation = {};

        $http.get("/api/chapters")
            .then(function (response) {
                angular.copy(response.data.results, vm.chapters);
                console.log("response :", response.data.results);
            }, function (error) {
                vm.errorMessage = "Failed to load data " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.uploadChapter = function () {
            vm.chapter = document.getElementById('uploadChapter').files[0];
            $http.post("/api/chapters/" + vm.chapter)
              .then(function (response) {
                  //success
                  console.log("success");
                  console.log("response.data :", response.data);
                  vm.chapters.push(chapter);
                  vm.chapter = {};
              }, function () {
                  //error
                  console.log(vm.newSoundClip);
                  vm.errorMessage = "Failed to save new Instruments";
              });
        }

        vm.uploadAnnotation = function () {
            vm.annotation = document.getElementById('uploadAnnotation').files[0];
            $http.post("/api/chapter/" + vm.annotation)
              .then(function (response) {
                  //success
                  console.log("success");
                  console.log("response.data :", response.data);
                  vm.annotation = {};
              }, function () {
                  //error
                  console.log(vm.newSoundClip);
                  vm.errorMessage = "Failed to save new Instruments";
              });
        }
    }
})();