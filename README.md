Ec2DashBoardApplication
=======================

Ec2DashBoardApplication to get active Ec2instances from Aws profile
Ec2DashBoard

Architecture

Design:
This is a single page application built using AngularJS, Asp.net WebApI2, OWIN security framework using OAuth2 provider to secure the Webapi and authenticate against a membership database
Local login. The user registers at the site, entering a username and password. The app stores the password hash in the membership database. When the user logs in, the ASP.NET Identity system verifies the password and sends back the token with the expiry date and time.
Application client saves the token  in session storage and will be used throughout the user session and when user logs out the token will be deleted from the session storage.
Dependent on AWS SDK for .NET to create Amazon EC2 Client represented by an AmazonEC2Client object.
The permissions for the client object are configured in the Web.config file in the appsettings section and the region end point is specified using AWSRegion configuration key.

<add key="AWSAccessKey" value="" />
<add key="AWSSecretKey" value="" />
<add key="AWSRegion" value="us-west-2" /> 

AmazonEc2 client makes a request to AWS service using the information to get the described instances from the reserved running instances.

Technologies Used:

ASP.NET MVC:
ASP.NET MVC  to host that single page served back from the server for the initial page request , to load angular templates, CSS, images, font and Javascipt resources.

Angular Routing:
Single page application front end using angular routing and routes for Login page, Sign up page and EC2 Dashboard page has been defined using angular routing.

Angular two way binding to receive the login inputs from the client and to display error message in case of authentication fails , to page, filter and sorting EC2 instances results .


ASP.NET Web API 2.0 for REST API calls:
Application client calls following REST API’s to  authenticate the user and to get the EC2 instances using Angular Service and  angular two way binding.

1.	Get request method to get all EC2 Instances: GET api/DashBoard/GetEc2Instances?pageNum=<pageNum>&pageSize=<pageSize>
2.	Post request method to Register the user information to the server: /api/Account/Register
3.	Post request method to Signin the user by issuing authentication Token : /Token and storing it in session storage
4.	Logout is just by deleting the authentication token from the session storage

AWS SDK .Net:
AWS SDK.net is used to create Amazon Ec2 client to communicate with AWS services to retrive the EC2 instances.

Model /Database:
Entity framework migration is enabled to generate the .mdf file in the App_Data folder to store the User information.

Seed methods have been used to generate the EC2 instances model for the initial prototyping purpose.

User Interface :
Twitter Bootstrap 3.0 responsive  UI Framework to create the dashboard user interface, user login and registration screen.

Testing:
•	Back end testing is done using NUNIT, MOQ and visual studio Test explorer
•	UI testing using angular-mocks, Jasmine, Chutzpah test runner
Source control:
•	Github 
•	Repository: https://github.com/Yash1811/Ec2DashBoardApplication


Azure:
•	Application is hosted on Azure Cloud platform 
•	URL: https://computedashboardapp.azurewebsites.net/#/admin/login

Dependencies:
All the project dependencies and its version are listed below:
Id                             Version              Description/Release Notes                             
--                             -------              -------------------------                             
AngularJS.Core                 1.3.4                See the AngularJS.* packages for other Angular modules
Antlr                          3.5.0.2              ANother Tool for Language Recognition, is a languag...
AWSSDK                         2.3.13.0             Build applications that tap into the cost-effective...
bootstrap                      3.3.0                Sleek, intuitive, and powerful mobile first front-e...
Chutzpah                       3.2.6                Chutzpah is an open source JavaScript test runner w...
EntityFramework                6.1.1                Entity Framework is Microsoft's recommended data ac...
jasmine-js                     1.3.1.1              Jasmine is a behavior-driven development framework ...
jQuery                         2.1.1                jQuery is a new kind of JavaScript Library....        
Microsoft.AspNet.Identity.Core 2.1.0                Core interfaces for ASP.NET Identity.                 
Microsoft.AspNet.Identity.E... 2.1.0                ASP.NET Identity providers that use Entity Framework. 
Microsoft.AspNet.Identity.Owin 2.1.0                Owin implementation for ASP.NET Identity.             
Microsoft.AspNet.Mvc           5.2.2                This package contains the runtime assemblies for AS...
Microsoft.AspNet.Razor         3.2.2                This package contains the runtime assemblies for AS...
Microsoft.AspNet.Web.Optimi... 1.1.3                ASP.NET Optimization introduces a way to bundle and...
Microsoft.AspNet.WebApi        5.2.2                This package contains everything you need to host A...
Microsoft.AspNet.WebApi.Client 5.2.2                This package adds support for formatting and conten...
Microsoft.AspNet.WebApi.Core   5.2.2                This package contains the core runtime assemblies f...
Microsoft.AspNet.WebApi.Owin   5.2.2                This package allows you to host ASP.NET Web API wit...
Microsoft.AspNet.WebApi.Web... 5.2.2                This package contains everything you need to host A...
Microsoft.AspNet.WebPages      3.2.2                This package contains core runtime assemblies share...
Microsoft.Owin                 3.0.0                Provides a set of helper types and abstractions for...
Microsoft.Owin.Host.SystemWeb  3.0.0                OWIN server that enables OWIN-based applications to...
Microsoft.Owin.Security        3.0.0                Common types which are shared by the various authen...
Microsoft.Owin.Security.Coo... 3.0.0                Middleware that enables an application to use cooki...
Microsoft.Owin.Security.Fac... 3.0.0                Middleware that enables an application to support F...
Microsoft.Owin.Security.Google 3.0.0                Contains middlewares to support Google's OpenId and...
Microsoft.Owin.Security.Mic... 3.0.0                Middleware that enables an application to support t...
Microsoft.Owin.Security.OAuth  3.0.0                Middleware that enables an application to support a...
Microsoft.Owin.Security.Twi... 3.0.0                Middleware that enables an application to support T...
Microsoft.Web.Infrastructure   1.0.0.0              This package contains the Microsoft.Web.Infrastruct...
Moq                            4.2.1409.1722        Moq is the most popular and friendly mocking framew...
Newtonsoft.Json                6.0.4                Json.NET is a popular high-performance JSON framewo...
Newtonsoft.Json                6.0.5                Json.NET is a popular high-performance JSON framewo...
NUnit                          2.6.3                NUnit features a fluent assert syntax, parameterize...
Owin                           1.0                  OWIN IAppBuilder startup interface                    
WebGrease                      1.6.0                Web Grease is a suite of tools for optimizing javas...



