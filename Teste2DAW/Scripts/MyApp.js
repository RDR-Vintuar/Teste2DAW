(function () {
    var app = angular.module('MyApp', ['ngRoute']);

    app.controller('HomeController', function ($scope) {
        $scope.message = "Ola, angular is working. By RDR";
    });
})();