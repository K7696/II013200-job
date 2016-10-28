var app = angular.module("developer", []);

app.controller("developerCtrl", function ($scope, $http) {
    
    // Init lists
    $scope.items = [];
    $scope.stories = [];

    // Init objects
    $scope.user = {};
    $scope.activeItem = {};
    $scope.team = {};

    // Init buttons
    $scope.viewMembersButton = false;
    $scope.hideMembersButton = false;
    $scope.viewProductBacklogButton = false;
    $scope.hideProductBacklogButton = false;

    // Init
    (function () {
        _getUser();
        _getItems();        
        _getTeam();

        $scope.viewMembersButton = true;
        $scope.viewProductBacklogButton = true;

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

    function _getStories() {

        $http({
            method: "GET",
            url: "../../Story/GetList/"
        }).then(function mySucces(response) {
            $scope.stories = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });

    }

    function _getItemDetails(itemId) {
        $http({
            method: "GET",
            url: "../../Item/Get/" + itemId
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

    function _getUser() {
        $http({
            method: "GET",
            url: "../../Person/Get/1"
        }).then(function mySucces(response) {
            $scope.user = response.data;
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
    };

    $scope.getTeam = function () {
        _getTeam();

        $scope.viewMembersButton = false;
        $scope.hideMembersButton = true;
    };

    $scope.hideTeam = function () {
        $scope.viewMembersButton = true;
        $scope.hideMembersButton = false;
    };

    $scope.getProductBacklog = function () {
        _getStories();

        $scope.viewProductBacklogButton = false;
        $scope.hideProductBacklogButton = true;
    };

    $scope.hideProductBacklog = function () {
        $scope.viewProductBacklogButton = true;
        $scope.hideProductBacklogButton = false;
    };

    // #endregion Public methods

});