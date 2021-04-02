using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Dto;
using Xunit;

namespace Truck.UnitTests
{
    public class TruckValidation
    {
        [Fact]
        public void PostDtoWithInvalidProperties_ThrowsArgumentException()
        {
            // Initialize with default values to cause error
            var postTruck = new PostTruck();
            Assert.Throws<ArgumentException>(() => Core.Entities.Truck.CheckPost(postTruck));
        }

        [Fact]
        public void PutDtoWithInvalidProperties_ThrowsArgumentException()
        {
            // Initialize with default values to cause error
            var putTruck = new PutTruck();
            Assert.Throws<ArgumentException>(() => Core.Entities.Truck.CheckPut(putTruck));
        }
    }
}
