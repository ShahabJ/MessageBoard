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

class HomeIndexController {
    isBusy: boolean;
    data: ng.IHttpPromiseCallbackArg<any>;
    static $inject = ['$scope', '$http'];
    constructor(private $scope: ng.IScope, private $http: ng.IHttpService) {
        this.data = [];
        this.isBusy = true;
        $http.get("/api/v1/topics?includeReplies=true")
            .then((result) => {
                //Success
                angular.copy(result.data, this.data);
            }, () => {
                //Error
            })
            .then(() => {
                this.isBusy = false;
            });
    }
}

module.controller('HomeIndexController', HomeIndexController);