appControllers.controller('AdminUserCtrl', ['$scope', '$rootScope', '$location', '$window', 'UserService', 'AuthenticationService',
    function AdminUserCtrl($scope, $rootScope, $location, $window, UserService, AuthenticationService) {
        $scope.message = '';
        $scope.isLoading = false;

        //Admin User Controller (signIn, logOut)
        $scope.signIn = function signIn(username, password) {
            $scope.isLoading = true;
            if (username != "" && password != "") {
                UserService.signIn(username, password).success(function (data) {
                    AuthenticationService.isAuthenticated = true;
                    $window.sessionStorage.token = data.access_token;
                    $window.sessionStorage.userName = data.userName;
                    $location.path('/admin/ec2dashboard');
                    $scope.message = '';
                    $scope.isLoading = false;
                }).error(function (error) {
                    $scope.isLoading = false;
                    $scope.message = error.error_description;
                });
            } else {
                $scope.isLoading = false;
                $scope.message = "Please enter username and Password";
            }
        }

        $scope.logOut = function logOut() {
            if (AuthenticationService.isAuthenticated) {

                UserService.logOut().success(function (data) {
                    AuthenticationService.isAuthenticated = false;
                    delete $window.sessionStorage.token;
                    $location.path("/");
                }).error(function (status, data) {
                    console.log(status);
                    console.log(data);
                });
            }
            else {
                $location.path("/admin/login");
            }
        }

        $scope.register = function register(username, password, passwordConfirm) {
            $scope.isLoading = true;
            if (username != "" && password != "") {
                UserService.register(username, password, passwordConfirm).success(function (data) {
                    $scope.signIn(username, password);
                    $scope.message = '';
                    $scope.isLoading = false;
                }).error(function (error) {
                    var errorMessages = [];
                    angular.forEach(error.ModelState, function (errorMsg) {
                        errorMessages.push(errorMsg);
                    });
                    $scope.message = errorMessages.join(' ');
                    $scope.isLoading = false;
                });
            } else {
                $scope.message = "Please enter username and Password to create an account";
                $scope.isLoading = false;
            }
        }
    }
]);


appControllers.controller('Ec2InstancesCtrl', ['$scope', '$routeParams', '$sce', 'EC2InstanceService',
    function Ec2InstancesCtrl($scope, $routeParams, $sce, EC2InstanceService) {

        $scope.message = '';
        $scope.eC2ActiveInstances = [];
        $scope.eC2Types = [];
        $scope.eC2States = [];
        $scope.eC2TypesSortOptions = [];
        $scope.eC2StatesSortOptions = [];
        //Mapped to the model to sort

        $scope.currentPage = 1;
        $scope.pageSize = 2;

        $scope.getActiveEc2Instances = function () {
            $scope.isLoading = true;
            EC2InstanceService.getActiveEc2InstancesByPage($scope.currentPage, $scope.pageSize).success(function (data) {
                $scope.eC2ActiveInstances = data.ElasticCloudViewModel;
                $scope.totalItems = data.Pagination.TotalItems;
                $scope.currentRange = data.Pagination.CurrentRange;
                $scope.eC2ActiveInstancesCopy = angular.copy($scope.eC2ActiveInstances);
                $scope.predicate = 'Id';
                $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions(data.ElasticCloudViewModel);
                $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions(data.ElasticCloudViewModel);
                $scope.isLoading = false;
            }).error(function (error) {
                $scope.message = error.Message + " Please go to home page to Signin again or Signup";
                $scope.isLoading = false;
            });
        };

        $scope.getActiveEc2Instances();

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        };

        $scope.pageChanged = function () {
            $scope.getActiveEc2Instances();
        };

        $scope.filterByType = function (appliedFilter) {
            $scope.eC2ActiveInstances = EC2InstanceService.filterResultsByType($scope.eC2ActiveInstances, appliedFilter);
            $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions($scope.eC2ActiveInstances);
            $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions($scope.eC2ActiveInstances);
            $scope.open = false;
            $scope.isFilterOn = true;
        };

        $scope.filterByState = function (appliedFilter) {
            $scope.eC2ActiveInstances = EC2InstanceService.filterResultsByState($scope.eC2ActiveInstances, appliedFilter);
            $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions($scope.eC2ActiveInstances);
            $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions($scope.eC2ActiveInstances);
            $scope.openStateDropdown = false;
            $scope.isFilterOn = true;
        };

        $scope.clearFilters = function () {
            $scope.eC2ActiveInstances = angular.copy($scope.eC2ActiveInstancesCopy);
            $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions($scope.eC2ActiveInstances);
            $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions($scope.eC2ActiveInstances);
            $scope.openStateDropdown = false;
            $scope.open = false;
            $scope.isFilterOn = false;
        };
    }
]);

appControllers.controller('AppCtrl', ['$scope', '$rootScope', '$location', '$window', 'UserService', 'AuthenticationService',
    function AppCtrl($scope, $rootScope, $location, $window, UserService, AuthenticationService) {
        $scope.message = '';
        $scope.logOut = function logOut() {
            if (AuthenticationService.isAuthenticated) {
                AuthenticationService.isAuthenticated = false;
                delete $window.sessionStorage.token;
                $location.path("/admin/login");
            }
            else {
                $location.path("/admin/login");
            }
        }
    }
]);