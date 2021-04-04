using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Dto;
using Xunit;

namespace Truck.IntegrationTests.Data
{
    public class TruckRepositoryAdd : BaseTruckRepoTest
    {
        [Fact]
        public async Task AddTruck()
        {
            var repository = GetRepository();
            var postTruck = new PostTruck
            {
                Model = Core.Entities.TruckModel.FH,
                ModelYear = (ushort)DateTime.Now.Year,
                ProductionYear = (ushort)DateTime.Now.Year
            };

            var newTruck = await repository.NewTruck(postTruck);

            var addedTruck = (await repository.GetAllTrucksAsync()).FirstOrDefault();

            Assert.Equal(newTruck, addedTruck);
            Assert.True(newTruck.TruckId > 0);
        }
    }
}
