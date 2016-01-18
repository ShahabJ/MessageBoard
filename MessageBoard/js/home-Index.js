
//home-Index.js
var module = angular.module('homeIndex', []);


module.controller('homeIndexController', ['$scope', '$http', function ($scope, $http) {

    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/api/v1/topics?includeReplies=true")
    .then(function (result) {
        //Success
        angular.copy(result.data, $scope.data);
    }, function () {
        //Error
        Alert("Could not load topics.");
    }).then(function () {
        $scope.isBusy = false;
    });
}])