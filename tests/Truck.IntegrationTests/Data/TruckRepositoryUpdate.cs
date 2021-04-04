using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Dto;
using Xunit;

namespace Truck.IntegrationTests.Data
{
    public class TruckRepositoryUpdate : BaseTruckRepoTest
    {
        [Fact]
        public async Task UpdateTruck()
        {
            var repository = GetRepository();
            var postTruck = new PostTruck
            {
                Model = Core.Entities.TruckModel.FH,
                ModelYear = (ushort)DateTime.Now.Year,
                ProductionYear = (ushort)DateTime.Now.Year
            };

            var newTruck = await repository.NewTruck(postTruck);

            Assert.True((await repository.GetAllTrucksAsync()).Count() == 1);

            var putTruck = new PutTruck
            {
                TruckId = newTruck.TruckId,
                Model = Core.Entities.TruckModel.FM,
                ModelYear = (ushort)(newTruck.ModelYear + 1)
            };

            await repository.EditTruck(putTruck);

            var updatedTruck = await repository.GetTruckAsync(newTruck.TruckId);

            Assert.Equal(Core.Entities.TruckModel.FM, updatedTruck.Model);
            Assert.Equal((ushort)(postTruck.ModelYear + 1), updatedTruck.ModelYear);
        }
    }
}
