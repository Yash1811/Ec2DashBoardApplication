using System.Collections.Generic;
using Amazon.EC2;
using Amazon.EC2.Model;
using ComputeDashBoardApp.Models;

namespace ComputeDashBoardApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ComputeDashBoardApp.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Ec2Instances.Any())
            {
                return;
            }

            context.Ec2Instances.AddRange(CreateEc2Instance());
            context.SaveChanges();
        }

        private static IEnumerable<ElasticCloudViewModel> CreateEc2Instance()
        {
            var ec2Instances = new List<ElasticCloudViewModel> 
            {
                new ElasticCloudViewModel
                { 
                    Id = " ap-northeast-1",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-1b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-1",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-1a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-2",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-2c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-1",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-1a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-1",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-1",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-1",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-1b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-1",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-2",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-3",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-3c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }//kkk
                ,new ElasticCloudViewModel
                { 
                    Id = "ap-northeast-3",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-3b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-3",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-3a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-4",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-4c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-3",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-3a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-3",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-3",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-3",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-3b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-12",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-12a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-31",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-31c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-2",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }//12/14
                ,
                new ElasticCloudViewModel
                { 
                    Id = " ap-northeast-50",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-1b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-51",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-1a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-52",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-2c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-53",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-1a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-54",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-55",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-56",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-1b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-57",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-58",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-59",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-3c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }//kkk
                ,new ElasticCloudViewModel
                { 
                    Id = "ap-northeast-60",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-3b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-61",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-3a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-62",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-4c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-63",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-3a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-64",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-65",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-66",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-3b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-67",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-12a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-68",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-31c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-69",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }//69 end
                ,
                new ElasticCloudViewModel
                { 
                    Id = " ap-northeast-70",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-1b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-71",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-1a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-72",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-2c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-73",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-1a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-74",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-75",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-76",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-1b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-77",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-78",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-79",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-3c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }
                ,new ElasticCloudViewModel
                { 
                    Id = "ap-northeast-80",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-3b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-81",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-3a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-82",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-4c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-83",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-3a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-84",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-85",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-86",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-3b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-87",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-12a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-88",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-31c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-89",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                },//end 89
                new ElasticCloudViewModel
                { 
                    Id = " ap-northeast-90",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-1b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-91",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-1a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-92",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-2c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-93",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-1a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-94",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-95",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-96",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-1b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-97",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-98",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-99",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-3c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }//kkk
                ,new ElasticCloudViewModel
                { 
                    Id = "ap-northeast-100",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-3b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-101",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-3a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-102",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-4c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-103",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-3a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-104",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-105",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-106",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-3b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-107",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-12a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-108",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-31c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-109",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }
            };

            return ec2Instances;
        }

    }
}
