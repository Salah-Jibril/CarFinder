var app = angular.module('CarFinderApp', ['ngRoute', 'LocalStorageModule']);


angular.module('CarFinderApp').config(['$routeProvider', function ($routeProvider) {
    console.log('configuring');
    $routeProvider.when("/", {
        templateUrl: "NgApps/Templates/Login.html"
    });

    $routeProvider.when("/carfinder", {
        templateUrl: "NgApps/Templates/CarFinderIndex.html"
    });

    $routeProvider.when("/register", {
        templateUrl: "NgApps/Templates/Register.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
}]);

angular.module('CarFinderApp').config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

angular.module('CarFinderApp').run(['authService', function (authService) {
    authService.fillAuthData();
}]);
