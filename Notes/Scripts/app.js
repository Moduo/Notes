(function () {
    var app = angular.module('notes', []);

    app.controller('DirectoryController', ['$http', '$scope', function ($http, $scope) {
        var cont = this;
        cont.directories = [];

        //For new directories
        this.directory = {};

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

        this.addDirectory = function (directories) {
            console.log(directories);
            directories.directorylist.push(this.directory);
            var res = $http.post("/Directory/Create", this.directory);
            res.success(function (data, status, headers, config) {
                $scope.message = data;
            });
            res.error(function (data, status, headers, config) {
                alert("failure message: " + JSON.stringify({ data: data }));
            });

            $('.directory-new').hide();
            $('.add-dir-btn').prop('disabled', true);
            this.directory = {};
        }
    }]);

    $('[data-toggle="tooltip"]').tooltip()

})();