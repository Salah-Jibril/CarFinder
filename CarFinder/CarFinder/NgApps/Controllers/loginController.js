angular.module('CarFinderApp').controller('loginController', ['$scope', '$location', 'authService', '$timeout', function ($scope, $location, authService, $timeout) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.description = "Welcome to the JCar Finder App. This web api software will help you look through the Coder Found cars database and provide you with images powered by Google. This software was done using Angular JS";
    $scope.message = "Login to your account";
    $scope.maker = "This App is a show piece made by Salahadin Jibril"
    $scope.isError = false;

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

            $location.path('/CarFinder');

        },
         function (err) {
             $scope.message = err.error_description;
             $scope.isError = true;
             messageDelay(1, loginErrorCallback);
         });
    };

    //Turn this into a directive

    var messageDelay = function (interval, callBack) {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            //Anything I need to do
            callBack();
        }, 1000 * interval);
    }

    var loginErrorCallback = function () {
        $scope.message = 'Login to your account';
        $scope.isError = false;
    }

}]);