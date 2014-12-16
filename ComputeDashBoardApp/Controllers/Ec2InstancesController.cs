using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ComputeDashBoardApp.Models;
using ComputeDashBoardApp.Services;

namespace ComputeDashBoardApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/DashBoard")]
    public class Ec2InstancesController : ApiController
    {
        private ApplicationDbContext db;
        private E2CInstanceService e2CInstanceService;

        public Ec2InstancesController()
        {
            this.e2CInstanceService = new E2CInstanceService();
        }
        // GET api/DashBoard/GetEc2Instances?pageNum=<pageNum>&pageSize=<pageSize>
        [Route("GetEc2Instances")]
        public ElasticCloudDataModel Get(int pageNum, int pageSize)
        {
            var e2CActiveInstances = this.e2CInstanceService.GetEc2InstancesPagedModel(pageNum, pageSize);
            return e2CActiveInstances;
        }
       
    }
}
