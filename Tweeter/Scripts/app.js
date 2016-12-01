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

app.controller('HomePage', function ($scope, $q, $http) {

    $scope.tweetPosted = function () {
        $scope.ListAllTweets();
    }

    $scope.getUsername = function () {
        var url = `/api/TwitUsername/1`

        return $q(function (resolve, reject) {
            $http.get(url).then(function (response) {
                $scope.userName = response.data;
                $scope.checkToSeeIfUserIsFollowing(response.data);
                resolve(response.data)
            }, function (error) {
                reject(error)
            })
        })
    }
    $scope.getUsername();

    $scope.checkToSeeIfUserIsFollowing = function(username) {
        var url = `/api/Tweeter/?username=${username}`

        return $q(function (resolve, reject) {
            $http.get(url).then(function (response) {
                console.log(response)
                $scope.userIsFollowing = response.data;
                resolve(response.data)
            }, function (error) {
                reject(error)
            })
        })
    }
    

    $scope.ListAllTweets = function () {
        var url = `/api/Tweet`
        return $q(function (resolve, reject) {
            $http.get(url).then(function (response) {
                console.log(response)
                var tweets = response.data;
                $scope.tweets = tweets;
                resolve(tweets);
            }, function (error) {
                reject(error)
            })
        })
    }

    $scope.followUser = function () {
        var url = `/api/Tweeter`
        var data = {};
        data.userToFollow = $scope.userName;
        data.alreadyFollowing = $scope.userIsFollowing;

        return $q(function (resolve, reject) {
            $http.post(url, data).then(function (response) {
                $scope.checkToSeeIfUserIsFollowing();
                resolve(response);
            }, function (error) {
                reject(error)
            })
        })
    }

    $scope.unfollowUser = function () {
        var url = `/api/Tweeter`
        var data = {};
        data.userToFollow = $scope.userName;
        data.alreadyFollowing = $scope.userIsFollowing;

        return $q(function (resolve, reject) {
            $http.post(url, data).then(function (response) {
                $scope.checkToSeeIfUserIsFollowing();
                resolve(response);
            }, function (error) {
                reject(error)
            })
        })
    }

    $scope.ListAllTweets().then((tweets) => {
        console.log(tweets)
        $scope.tweets = tweets
    });
})