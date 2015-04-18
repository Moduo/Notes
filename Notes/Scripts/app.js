(function () {
    var app = angular.module('notes', []);

    app.controller('DirectoryController', ['$http', '$scope', function ($http, $scope) {
        var cont = this;
        cont.directories = [];

        $http.get('/Directory/GetDirectories').
          success(function (data, status, headers, config) {
              cont.directories = data;
          }).
          error(function (data, status, headers, config) {
          });

        $scope.changeDir = function (id) {
            
            $http.get('/Directory/GetDirectories/' + id).
                success(function (data, status, headers, config) {
                    cont.directories = data;
                }).
                error(function (data, status, headers, config) {
                });
        };

        $scope.goUpOneDir = function (id) {
            $http.get('/Directory/GoTo/' + id).
                success(function (data, status, headers, config) {
                    cont.directories = data;
                }).
                error(function (data, status, headers, config) {
                });
        }

    }]);

    $('[data-toggle="tooltip"]').tooltip()

})();