var app = angular.module("myApp", []);



app.service("loginSvc", ["$http", function ($http) {
    //获取协议
    var protocol = location.protocol;
    //获取主机名
    var hostname = location.hostname;
    //获取端口号
    var port = location.port;
    //获取主机名+端口号
    var host = location.host;
    this.url = protocol + "//" + host;

    this.login = function (user) {
        return $http({
            url: this.url + "/am/login",
            method: "Post",
            data: user
        });
    };
}]);

app.controller("myCtrl", ["$scope", "loginSvc", function ($scope, loginSvc) {
    $scope.user = {
        email: "",
        password: ""
    };

    $scope.login = function (user) {
        loginSvc.login(user);
    }
}]);