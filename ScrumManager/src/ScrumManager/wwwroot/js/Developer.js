var app = angular.module("developer", []);

app.controller("developerCtrl", function ($scope, $http) {
    
    // Init
    $scope.items = [];
    $scope.activeItem = {};

    $scope.team = {};

    // Init
    (function () {
        _getItems();
        _getTeam();
    }());

    // #region Private methods

    function _getTeam() {

        $http({
            method: "GET",
            url: "../../Team/Get/1"
        }).then(function mySucces(response) {
            $scope.team = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });
    }

    function _getItems() {

        $http({
            method: "GET",
            url: "../../Item/GetList/"
        }).then(function mySucces(response) {
            $scope.items = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });

    }

    function _getItemDetails(itemId) {
        $http({
            method: "GET",
            url: "../../Item/Get/?itemId=" + itemId
        }).then(function mySucces(response) {
            $scope.activeItem = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });
    }

    function _saveItemDetails(item) {
        $http({
            method: "POST",
            url: "../../Item/Save/",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: item
        }).then(function mySucces(response) {
            $scope.activeItem = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });
    }

    // #endregion Private methods

    // #region Public methods

    $scope.getItemDetails = function (itemId) {
        _getItemDetails(itemId);
    };

    $scope.saveItemDetails = function (item) {
        _saveItemDetails(item);
    }

    // #endregion Public methods

});