(function () {
    "use strict";

    angular
      .module("app")
      .directive("directive", directive);

    directive.$inject = ['$compile'];

    function directive($compile) {
        return {
            restrict: 'A',
            replace: true,
            link: function (scope, ele, attrs) {
                scope.$watch(attrs.directive, function (html) {
                    ele.html(html);
                    $compile(ele.contents())(scope);
                });
            }
        };
    }
})();