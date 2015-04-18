(function () {
    var app = angular.module('notes', []);

    app.controller('DirectoryController', ['$http', function ($http) {
        var cont = this;
        cont.directories = [];

        $http.get('/Directory/GetDirectories').
          success(function (data, status, headers, config) {
              cont.directories = data;
          }).
          error(function (data, status, headers, config) {
          });
    }]);
})();