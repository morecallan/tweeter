﻿var app = angular.module('Tweeter', []);

app.controller('Register', function ($scope, $q, $http) {

    $scope.userNameExistsCode = null;

    $scope.checkToSeeIfUsernameExists = function () {
        var url = `/api/TwitUsername?usernameCandidate=${$scope.usernameCandidate}`

        return $q(function (resolve, reject) {
            $http.get(url).then(function (response) {
                var data = response.data;
                if (data.exists) {
                    $scope.userNameExistsCode = 1;
                    $("#register").submit(function (e) {
                        e.preventDefault();
                    })
                } else {    
                    $scope.userNameExistsCode = 2;
                    $("#register").unbind('submit');

                }
                resolve(data);
            }, function(error) {
                reject(error)
            })
        })
    }
})