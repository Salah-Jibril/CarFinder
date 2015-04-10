angular.module('CarFinderApp')
        // Path: /
        .controller('menuController', ['$scope', '$location', 'authService', function ($scope, $location, authSvc) {
            $scope.authentication = authSvc.authentication;
            console.log($scope.authentication);
            $scope.logout = function () {
                authSvc.logOut();
                $location.path('/Login');
            }
        }])