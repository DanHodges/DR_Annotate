(function () {

    "use strict";

    angular.module("app")
      .controller("editChapterController", editChapterController);

    editChapterController.$inject = ['$routeParams', '$http', '$sce', '$scope'];

    function editChapterController($routeParams, $http, $sce, $scope) {
        var vm = this;
        vm.chapter = {};
        vm.annotations = [];
        vm.chapterString = "";
        $scope.domString = '';

        $http.get("/api/Chapters/" + $routeParams.chapter)
            .then(function (response) {
                vm.chapterString += response.data[0].entireChapterString;
                vm.chapter = response.data[0];
            }, function (error) {
                vm.errorMessage = "Failed to load data " + error;
            })
            .finally(function () {
                $http.get("/api/Annotations")
                    .then(function (response) {
                        vm.annotations = response.data.results;
                        $scope.domString = vm.makeDomString(vm.chapterString, vm.annotations);
                        console.log("vm.domString :", vm.domString);
                    }, function (error) {
                        vm.errorMessage = "Failed to load data " + error;
                    });
            });

        vm.makeDomString = function (inputString, array) {
            var outputString = '';
            var length = array.length;
            for (var i = 0; i < length; i++) {
                var iPlus = i + 1, nextStringStart = array[i].end + 1;
                if (i < length - 1) { var nextStringEnd = array[iPlus].start - 1; }
                outputString +=
                '<span id="' + array[i].id + '"' + ' class="' + array[i].category + '"' + 'ng-click=' +
                '"' + 'vm.click(' + array[i].id +')' + '"' + '>' + ' ' + array[i].content + '</span>';
                if (nextStringStart < nextStringEnd) { outputString += inputString.substring(nextStringStart, nextStringEnd); }
                if(i === length - 1 && array[i].end < inputString.length){ outputString+= inputString.substring(nextStringStart, inputString.length)}
            }
            return outputString;
        }

        vm.click = function (arg) {
            console.log("id ===", arg);
        }
        vm.viewjson = function () {
            console.log("Annotations :", vm.annotations);
        }

    }
})();