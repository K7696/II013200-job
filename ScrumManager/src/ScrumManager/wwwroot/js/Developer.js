var app = angular.module("developer", []);


app.directive('userDialog', function() {
    return {
        restrict: 'E',
        templateUrl: '../../directives/user-dialog.html',
        transclude: true,
        link: function (scope) {
            
            $("#accountBtn").click(function () {
                $("#user-modal").modal();
            });

        }
    };
});

app.directive('taskDialog', function () {
    return {
        restrict: 'E',
        templateUrl: '../../directives/task-dialog.html',
        transclude: true,
        link: function (scope) {

           /* $(".taskBtn").click(function () {
                alert("");
                $("#task-modal").modal();
            });*/

        }
    };
});

app.controller("developerCtrl", function ($scope, $http) {
    
    // Init lists
    $scope.items = [];
    $scope.stories = [];

    // Init objects
    $scope.me = {};
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

    function _getMyDetails() {
        $http({
            method: "GET",
            url: "../../Person/Get/1"
        }).then(function mySucces(response) {
            $scope.me = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });
    }

    function _saveMyDetails() {
        $http({
            method: "POST",
            url: "../../Person/UPDATE/",
            data: $scope.me
        }).then(function mySucces(response) {
            $scope.me = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });
    }

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

    function _saveItemDetails() {
        $http({
            method: "POST",
            url: "../../Item/Update/",
            data: $scope.activeItem
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

    $scope.getMyDetails = function () {
        _getMyDetails();
    };

    $scope.saveMyDetails = function () {
        _saveMyDetails();
    };

    $scope.getItemDetails = function (itemId) {

        // todo: find new way to handle events
        $("#task-modal").modal();

        _getItemDetails(itemId);
    };

    $scope.saveItemDetails = function () {
        _saveItemDetails();
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