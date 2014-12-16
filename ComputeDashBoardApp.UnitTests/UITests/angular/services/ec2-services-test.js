/// <reference path="../scripts/jasmine.js" />
/// <reference path="../../../../computedashboardapp/scripts/lib/angular/angular.js" />
/// <reference path="../../../../computedashboardapp/scripts/lib/angular/angular-route.js" />
/// <reference path="../../../../computedashboardapp/scripts/lib/angular/ui-bootstrap-tpls-0.12.0.min.js" />
/// <reference path="../../../../computedashboardapp/scripts/app/app.js" />
/// <reference path="../../../../computedashboardapp/scripts/app/services.js" />
/// <reference path="../../../../computedashboardapp/scripts/lib/angular/angular-mocks.js" />


describe("ec2-services Tests->", function () {

    beforeEach(module('app'));

    var authenticationService;
    beforeEach(inject(function (AuthenticationService) {
        authenticationService = AuthenticationService;
    }));


    var $httpBackend;
    var fakeGetResponse = [
            {
                ElasticCloudViewModel: [
                    {
                        Id: "i-fd688f10",
                        Name: "US East Windows 8",
                        Type: "t2.micro",
                        State: "stopped",
                        AvailableZone: "us-east-1b",
                        PublicIp: "N/A",
                        PrivateIp: "172.31.36.67",
                        IsActive: true
                    }
                ],
                Pagination: {
                    PageNum: 1,
                    PageSize: 2,
                    TotalPages: 1,
                    TotalItems: 1,
                    CurrentRange: "viewing 1 - 1 of 1"
                }
            }
    ];

    beforeEach(inject(function ($injector) {
        $httpBackend = $injector.get("$httpBackend");
        EC2InstanceService = $injector.get('EC2InstanceService');

        $httpBackend.when("GET", "https://localhost:44305/api/DashBoard/GetEc2Instances?pageNum=1&pageSize=2").respond(fakeGetResponse);
    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

    describe("should get Ec2 instances", function () {
        it('Get Ec2 instances service', function () {

            $httpBackend.expectGET("https://localhost:44305/api/DashBoard/GetEc2Instances?pageNum=1&pageSize=2");

            EC2InstanceService.getActiveEc2InstancesByPage("1", "2");
            $httpBackend.flush();

            //expect(angular.equals(ec2Instances, fakeGetResponse)).toBeTruthy();
            expect(EC2InstanceService).toBeDefined();
        });
    });
});
