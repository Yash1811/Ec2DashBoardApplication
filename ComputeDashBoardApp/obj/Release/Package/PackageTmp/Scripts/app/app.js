'use strict';

var app = angular.module('app', ['ngRoute', 'ui.bootstrap', 'appControllers', 'appServices', 'appDirectives']);

var appServices = angular.module('appServices', []);
var appControllers = angular.module('appControllers', []);
var appDirectives = angular.module('appDirectives', []);

var options = {};
options.api = {};
options.api.base_url = "https://computedashboardapp.azurewebsites.net";

//options.api.base_url = "https://localhost:44305";

app.config(['$locationProvider', '$routeProvider',
  function ($location, $routeProvider) {
      $routeProvider.
          when('/', {
              templateUrl: 'content/templates/login/admin.signin.html',
              controller: 'AdminUserCtrl'
          }).
           when('/admin/register', {
               templateUrl: 'content/templates/login/admin.register.html',
               controller: 'AdminUserCtrl'
           }).
          when('/admin/ec2dashboard', {
              templateUrl: 'content/templates/login/ec2.dashboard.html',
              controller: 'Ec2InstancesCtrl'
          }).
          when('/admin/login', {
              templateUrl: 'content/templates/login/admin.signin.html',
              controller: 'AdminUserCtrl'
          }).
        when('/admin/logout', {
            templateUrl: 'content/templates/login/admin.logout.html',
            controller: 'AdminUserCtrl',
            access: { requiredAuthentication: true }
        }).
          otherwise({
              redirectTo: '/'
          });
  }]);


app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('TokenInterceptor');
});

app.run(function ($rootScope, $location, $window, $timeout, AuthenticationService) {
    $rootScope.$on("$routeChangeStart", function (event, nextRoute, currentRoute) {
        //redirect only if both isAuthenticated is false and no token is set
        if (AuthenticationService.isAuthenticated) {
            $rootScope.pageTitle = $window.sessionStorage.userName;
        } else {
            $rootScope.pageTitle = "to Compute Dashboard Admin site";
        };
    });
});