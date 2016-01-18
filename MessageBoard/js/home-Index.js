/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
//import * as ng from 'angular';
var module = angular.module('homeIndex', []);
//module.controller('homeIndexController', ['$scope', '$http', function ($scope, $http) {
//    $scope.data = [];
//    $scope.isBusy = true;
//    $http.get("/api/v1/topics?includeReplies=true")
//        .then(function (result) {
//            //Success
//            angular.copy(result.data, $scope.data);
//        }, function () {
//            //Error            
//        }).then(function () {
//            $scope.isBusy = false;
//        });
//}])
var HomeIndexController = (function () {
    function HomeIndexController($scope, $http) {
        var _this = this;
        this.$scope = $scope;
        this.$http = $http;
        this.data = [];
        this.isBusy = true;
        $http.get("/api/v1/topics?includeReplies=true")
            .then(function (result) {
            //Success
            angular.copy(result.data, _this.data);
        }, function () {
            //Error
        })
            .then(function () {
            _this.isBusy = false;
        });
    }
    HomeIndexController.$inject = ['$scope', '$http'];
    return HomeIndexController;
})();
module.controller('HomeIndexController', HomeIndexController);
//# sourceMappingURL=home-Index.js.map