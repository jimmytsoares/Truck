using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Dto;
using Xunit;

namespace Truck.IntegrationTests.Data
{
    public class TruckRepositoryDelete : BaseTruckRepoTest
    {
        [Fact]
        public async Task DeleteTruck()
        {
            var repository = GetRepository();
            var postTruck = new PostTruck
            {
                Model = Core.Entities.TruckModel.FH,
                ModelYear = (ushort)DateTime.Now.Year,
                ProductionYear = (ushort)DateTime.Now.Year
            };

            var newTruck = await repository.NewTruck(postTruck);

            await repository.DeleteTruck(newTruck);

            Assert.True((await repository.GetAllTrucksAsync()).Count() == 0);
        }
    }
}
