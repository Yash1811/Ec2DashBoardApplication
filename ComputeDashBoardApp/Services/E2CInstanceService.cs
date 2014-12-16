using System.Data.Entity;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;
using ComputeDashBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ComputeDashBoardApp.Services
{
    public class E2CInstanceService
    {
        private Pagination pagination;
        private ElasticCloudDataModel elasticCloudDataModel;
        private const string ViewingRange = "viewing {0} - {1} of {2}";

        public E2CInstanceService()
        {
            this.pagination = new Pagination();
            this.elasticCloudDataModel = new ElasticCloudDataModel();
        }

        public ElasticCloudDataModel GetEc2InstancesPagedModel(int pageNum, int pageSize)
        {
            var listOfAllInstances = GetListOfAllInstances();
            var ec2InstancesList = MapInstancesByPage(pageNum, pageSize, listOfAllInstances);
            elasticCloudDataModel.ElasticCloudViewModel = ec2InstancesList;
            elasticCloudDataModel.Pagination = pagination;
            return elasticCloudDataModel;
        }

        private List<ElasticCloudViewModel> MapInstancesByPage(int pageNum, int pageSize, List<Instance> listOfAllInstances)
        {
            if (!listOfAllInstances.Any()) return new List<ElasticCloudViewModel>();

            pagination.PageNum = pageNum;
            pagination.PageSize = pageSize;

            const string notAvailable = "N/A";

            return PageEc2Instances(listOfAllInstances).Select(activeInstance => new ElasticCloudViewModel
            {
                Id = activeInstance.InstanceId,
                Name = activeInstance.Tags.Find(item => item.Key == "Name").Value,
                Type = activeInstance.InstanceType,
                State = activeInstance.State.Name.Value,
                AvailableZone = activeInstance.Placement.AvailabilityZone,
                PrivateIp = !string.IsNullOrEmpty(activeInstance.PrivateIpAddress) ? activeInstance.PrivateIpAddress : notAvailable,
                PublicIp = !string.IsNullOrEmpty(activeInstance.PublicIpAddress) ? activeInstance.PublicIpAddress : notAvailable,
                IsActive = true

            }).ToList();
        }

        private List<Instance> GetListOfAllInstances()
        {
            try
            {
                var ec2Client = new AmazonEC2Client();
                var req = new DescribeInstancesRequest();
                var result = ec2Client.DescribeInstances(req).Reservations;
                return result.SelectMany(reservation => reservation.Instances).ToList();
            }
            catch (Exception serviceException)
            {
                return new List<Instance>();
            }
        }

        private IEnumerable<Instance> PageEc2Instances(List<Instance> ec2ReservationInstances)
        {
            if (pagination.PageSize <= 0) pagination.PageSize = 2;

            //Total result count
            var rowsCount = ec2ReservationInstances.Count();
            //If page number should be > 0 else set to first page
            if (rowsCount <= pagination.PageSize || pagination.PageNum <= 0) pagination.PageNum = 1;

            //Calculate nunber of rows to skip on pagesize
            var excludedRows = (pagination.PageNum - 1) * pagination.PageSize;
            var pageResults = ec2ReservationInstances.Skip(excludedRows).Take(pagination.PageSize);

            pagination.TotalItems = rowsCount;
            pagination.TotalPages = rowsCount < 0 ? 1 : ((rowsCount - 1) / pagination.PageSize) + 1;
            var pageEc2Instances = pageResults as IList<Instance> ?? pageResults.ToList();
            pagination.CurrentRange = string.Format(ViewingRange, pagination.PageNum, excludedRows + pageEc2Instances.Count(), pagination.TotalItems);

            //Skip the required rows for the current page and take the next records of pagesize count
            return pageEc2Instances;
        }
    }
}