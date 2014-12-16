using System.Collections.Generic;
using System.Linq;
using Amazon;
using Amazon.EC2;
using Amazon.Util;
using ComputeDashBoardApp.Models;
using ComputeDashBoardApp.Services;
using Moq;
using NUnit.Framework;

namespace ComputeDashBoardApp.UnitTests
{
    [TestFixture]
    public class Ec2InstancesServiceTest
    {
        [Test]
        public void EC2_Instances_Should_Not_Be_Null_When_Valid_AWS_Credentials_Are_Passed()
        {
            //Arrange
            var sut = new E2CInstanceService();
            var pagination = new Pagination();
            pagination.PageNum = 1;
            pagination.PageSize = 5;
            CreateValidProfile();

            //Act
            var ec2DataModel = sut.GetEc2InstancesPagedModel(1, 5);

            //Assert
            Assert.That(ec2DataModel.ElasticCloudViewModel.Any(), Is.True);
        }


        [Test]
        public void EC2_Instances_Should_Be_Zero_When_InValid_AWS_Credentials_Are_Passed()
        {
            //Arrange
            var sut = new E2CInstanceService();
            var pagination = new Pagination();
            pagination.PageNum = 1;
            pagination.PageSize = 5;
            CreateInValidProfile();

            //Act
            var ec2DataModel = sut.GetEc2InstancesPagedModel(1, 5);

            //Assert
            Assert.That(ec2DataModel.ElasticCloudViewModel.Count(), Is.EqualTo(0));
        }

        [Test]
        public void EC2_Instances_Should_Be_Zero_When_Region_Is_Not_Specified_Or_Invalid()
        {
            //Arrange
            var sut = new E2CInstanceService();
            var pagination = new Pagination();
            pagination.PageNum = 1;
            pagination.PageSize = 5;
            CreateProfileButNoRegion();

            //Act
            var ec2DataModel = sut.GetEc2InstancesPagedModel(1, 5);

            //Assert
            Assert.That(ec2DataModel.ElasticCloudViewModel.Count(), Is.EqualTo(0));
        }

        [Test]
        public void EC2_Instances_Should_Be_Zero_When_There_Are_No_Instances_Available_For_That_Region()
        {
            //Arrange
            var sut = new E2CInstanceService();
            var pagination = new Pagination();
            pagination.PageNum = 1;
            pagination.PageSize = 5;
            CreateProfileForRegionWithNoEc2Instances();

            //Act
            var ec2DataModel = sut.GetEc2InstancesPagedModel(1, 5);

            //Assert
            Assert.That(ec2DataModel.ElasticCloudViewModel.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Number_Of_Instances_Returned_Should_Be_Less_Than_Or_Equal_To_ItemsDisplayedPerPage()
        {
            //Arrange
            var sut = new E2CInstanceService();
            var pagination = new Pagination();
            pagination.PageNum = 1;
            pagination.PageSize = 5;
            CreateValidProfile();

            //Act
            var ec2DataModel = sut.GetEc2InstancesPagedModel(1, 5);

            //Assert
            Assert.That(ec2DataModel.ElasticCloudViewModel.Count, Is.LessThanOrEqualTo(5));
        }

        private static void CreateValidProfile()
        {
            var first = ProfileManager.ListProfileNames().First();

            if (!string.IsNullOrEmpty(first))
            {
                AWSConfigs.AWSProfileName = "default";
            }
            else
            {
                const string profileName = "default";
                const string accessKey = "";
                const string secretKey = "";
                ProfileManager.RegisterProfile(profileName, accessKey, secretKey);
                AWSConfigs.AWSProfileName = profileName;
            }

            AWSConfigs.AWSRegion = "us-west-2";
        }

        private static void CreateInValidProfile()
        {
            AWSConfigs.AWSProfileName = "Invalid";
            AWSConfigs.AWSRegion = "us-west-2";
        }

        private static void CreateProfileButNoRegion()
        {
            var first = ProfileManager.ListProfileNames().First();

            if (!string.IsNullOrEmpty(first))
            {
                AWSConfigs.AWSProfileName = "default";
            }
            else
            {
                const string profileName = "default";
                const string accessKey = "";
                const string secretKey = "";
                ProfileManager.RegisterProfile(profileName, accessKey, secretKey);
                AWSConfigs.AWSProfileName = profileName;
            }

            AWSConfigs.AWSRegion = "";
        }
        private static void CreateProfileForRegionWithNoEc2Instances()
        {
            var first = ProfileManager.ListProfileNames().First();

            if (!string.IsNullOrEmpty(first))
            {
                AWSConfigs.AWSProfileName = "default";
            }
            else
            {
                const string profileName = "default";
                const string accessKey = "";
                const string secretKey = "";
                ProfileManager.RegisterProfile(profileName, accessKey, secretKey);
                AWSConfigs.AWSProfileName = profileName;
            }

            AWSConfigs.AWSRegion = "ap-southeast-1";
        }
    }
}
