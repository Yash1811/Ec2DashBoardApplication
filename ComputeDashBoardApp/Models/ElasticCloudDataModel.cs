using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ComputeDashBoardApp.Models
{
    public class ElasticCloudDataModel
    {
        public ElasticCloudDataModel()
        {
            Pagination = new Pagination();
        }

        public List<ElasticCloudViewModel> ElasticCloudViewModel { get; set; }
        public Pagination Pagination { get; set; }
    }
}