var app = angular.module("developer", []);

app.controller("developerCtrl", function ($scope, $http) {
    
    // Init
    $scope.items = [];
    $scope.activeItem = {};

    // Init
    (function () {
        _getItems();
    }());

    // #region Private methods

    function _getItems() {

        $http({
            method: "GET",
            url: "../../Item/GetItems/"
        }).then(function mySucces(response) {
            $scope.items = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });

    }

    function _getItemDetails(itemId) {
        $http({
            method: "GET",
            url: "../../Item/GetItemDetails/?itemId=" + itemId
        }).then(function mySucces(response) {
            $scope.activeItem = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });
    }

    function _saveItemDetails(item) {
        $http({
            method: "POST",
            url: "../../Item/SaveItemDetails/",
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