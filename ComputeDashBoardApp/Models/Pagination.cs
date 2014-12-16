using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace ComputeDashBoardApp.Models
{
    public class Pagination
    {
        public Pagination()
        {
            PageNum = 0;
            PageSize = 0;
            TotalPages = 0;
        }

        public int PageNum { get; set; }

        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public string CurrentRange { get; set; }

    }

}