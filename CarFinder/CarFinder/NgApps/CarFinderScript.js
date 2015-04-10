// controller declaration (DisplayController) for module
angular.module('CarFinderApp').controller('CarFinderController', ['$scope', '$http', function ($scope, $http) {
        $scope.selected = {
            year: '',
            make: '',
            model: '',
            trim: ''
        };
    }
    ]);

// factory declaration for module - this provides the connectivity to the Web API controllers and actions
angular.module('CarFinderApp').factory('carSvc', ['$http', function ($http) {
        var factory = {};

        factory.getMakes = function () {
            return $http.get('/api/makes')
                .then(function (response) { return response.data; });
        }

        factory.getModels = function (selectedmake) {
            var options = { params: { make: selectedmake } };
            return $http.get('/api/models', options)
                .then(function (response) { return response.data; });
        }

        factory.getYears = function (selectedmake, selectedmodel) {
            var options = { params : {make: selectedmake, model: selectedmodel}};
            return $http.get('/api/years', options)
                .then(function (response) { return response.data; });
        };

        factory.getTrims = function (selectedmake, selectedmodel, selectedyear) {
            var options = { params: { make: selectedmake, model: selectedmodel, year: selectedyear } };
            return $http.get('/api/trims', options)
                .then(function (response) { return response.data; });
        }

        factory.getCarsM = function (selectedmake) {
            var options = { params: { make: selectedmake } };
            return $http.get('/api/cars/getcarmake', options)
                .then(function (response) { return response.data; });
        }

        factory.getCarsMM = function (selectedmake, selectedmodel) {
            var options = { params: { make: selectedmake, model: selectedmodel } };
            return $http.get('/api/cars/getcarmakeandmodel', options)
                .then(function (response) { return response.data; });
        }

        factory.getCarsMMY = function (selectedmake, selectedmodel, selectedyear) {
            var options = { params: { make: selectedmake, model : selectedmodel, year : selectedyear } };
            return $http.get('/api/cars/getcarmakemodelandyear', options)
                .then(function (response) { return response.data; });
        }

        factory.getCarsMMYT = function (selectedmake, selectedmodel, selectedyear, selectedtrim) {
            var options = { params: { make: selectedmake, model : selectedmodel, year : selectedyear, trim : selectedtrim } };
            return $http.get('/api/cars/getcarmakemodelyearandtrim', options)
                .then(function (response) { return response.data; });
        }

        factory.getCarPictureId = function (make, model, year) {
            return $http.get('https://api.edmunds.com/api/vehicle/v2/' + make + '/' + model + '/' + year + '/styles?fmt=json&api_key=62nnp5wjmcn9vwfdx6ac3bfy')
            .then(function (response) {
                return response.data;
                
            });
        };

        factory.getCarPictureUrl = function (StyleId) {
            return $http.get('https://api.edmunds.com/v1/api/vehiclephoto/service/findphotosbystyleid?styleId=' + StyleId + '&fmt=json&api_key=62nnp5wjmcn9vwfdx6ac3bfy')
            .then(function (response) {
                return response.data;
            });
        };
        return factory;
    }]);

// directive declarations for module
angular.module('CarFinderApp').directive('carFinder', ['carSvc', function (carSvc) {
        return {
            restrict: 'AEC',
            scope: {
                selectedYear: '=year',
                selectedMake: '=make',
                selectedModel: '=model',
                selectedTrim: '=trim'
            },
            templateUrl: '/NgApps/Templates/CarFinderDirectiveTemplate.html',
            link: function (scope, elem, attrs) {
                scope.showmessage = true;
                scope.hide = function () {
                    scope.showmessage = false;
                };
                scope.makes = [];
                scope.getMakes = function () {
                    carSvc.getMakes().then(function (data) {
                        scope.makes = data;
                    });
                }
                scope.getMakes();

                scope.models = [];
                scope.getModels = function () {
                    carSvc.getModels(scope.selectedMake).then(function (data) {
                        scope.models = data;
                    });
                }

                scope.years = [];
                scope.getYears = function () {
                    carSvc.getYears(scope.selectedMake, scope.selectedModel).then(function (data) {
                        scope.years = data;
                    });
                }
                
                
                scope.trims = [];
                scope.getTrims = function () {
                    carSvc.getTrims(scope.selectedMake, scope.selectedModel, scope.selectedYear).then(function (data) {
                        scope.trims = data;
                    });
                }

                scope.cars = [];
                scope.getCarsM = function () {
                    carSvc.getCarsM(scope.selectedMake).then(function (data) {
                        scope.cars = data;
                    });
                }

                scope.getCarsMM = function () {
                    carSvc.getCarsMM(scope.selectedMake, scope.selectedModel).then(function (data) {
                        scope.cars = data;
                    });
                }

                scope.getCarsMMY = function () {
                    carSvc.getCarsMMY(scope.selectedMake, scope.selectedModel, scope.selectedYear).then(function (data) {
                        scope.cars = data;
                    });
                }

                scope.getCarsMMYT = function () {
                    carSvc.getCarsMMYT(scope.selectedMake, scope.selectedModel, scope.selectedYear, scope.selectedTrim).then(function (data) {
                        scope.cars = data;
                    });
                }

                scope.pictureStyleId = [];
                scope.pictureStyleUrls = [];
                scope.getPicture = function () {
                carSvc.getCarPictureId(scope.selectedMake, scope.selectedModel, scope.selectedYear)
                        .then(function (data) {
                            if (scope.selectedYear > 2000) {
                                scope.pictureStyleId = data.styles[0].id;
                                carSvc.getCarPictureUrl(scope.pictureStyleId)
                                    .then(function (data) {
                                        for (var i = 0; i < data.length; i++)
                                            switch (data[i].shotTypeAbbreviation) {
                                                case "FQ":
                                                case "RQ":
                                                case "S":
                                                case "F":
                                                    scope.pictureStyleUrls.push(data[i].photoSrcs[0]);
                                                    break;
                                                default: break;
                                            }
                                });
                            }                            
                        });
                }

                scope.ShowPicture = function () {
                    if (scope.pictureStyleUrls.length > 0)
                    {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        };
    }]);

angular.module('CarFinderApp').directive('googleImage', function () {
    return {
        scope: {
            searchTerm: "@searchTerm"
        },

        template : '<div >'
        + ' <img alt="{{searchTerm}}"   style= "width: 100%;height: auto;" />'
        + '</div>',

        replace: true,

        link: function (scope, element) {
            var imageSearch = new google.search.ImageSearch();
            imageSearch.setSearchCompleteCallback(this, function () {
                if (imageSearch.results && imageSearch.results.length > 0) {
                    var imgs = element.find("img");                   
                    var number = Math.floor(Math.random()*imageSearch.results.length);
                    imgs[0].src = imageSearch.results[number].tbUrl;
                    scope.theImageUrls = imageSearch.result[0].url;
                }
            })
            imageSearch.execute(scope.searchTerm + "exteriorfrontview");
        }
    }
})