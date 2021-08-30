using Xunit;
using System.Threading.Tasks;
using Lite_Berry_Pi.Models.Interfaces.Services;
using RaspberryPi;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR.Client;

namespace Tests
{
    public class LiteBerryTests : Mock
  {

    [Fact]
    public void Generated_List_Matches_Expected()
    {
      Lights lights = new Lights();
      string testString = "0111000100001000010000100";

      List<LED> expectedPattern = new List<LED>()
        {
          lights.L2, lights.L3, lights.L4, lights.L8, lights.L13, lights.L18, lights.L23
        };
      List<LED> generatedPattern = lights.CreateLightPattern(testString);

      Assert.True(Enumerable.SequenceEqual(generatedPattern, expectedPattern));
    }

        [Fact]
        public async Task Can_Create_And_Save_User()
        {
            var testUser = await CreateAndSaveTestUser();
            var repository = new UserRepository(_db);

            var resultUser = await repository.GetSingleUser(testUser.Id);

            Assert.Equal("Test", resultUser.Name);
        }

        [Fact]
        public async Task Can_Create_And_Save_Design()
        {
            var testDesign = await CreateAndSaveTestDesign();
            var repository = new DesignRepository(_db);

            var resultUser = await repository.GetDesign(testDesign.Id);

            Assert.Equal("Test", resultUser.Title);
        }

        [Fact]
        public async Task Can_Communicate_With_The_Server()
        {

            var hubConnection = new HubConnectionBuilder()
                .WithUrl($"https://liteberrypiserver.azurewebsites.net/raspberrypi")
                .WithAutomaticReconnect()
                .Build();

            await hubConnection.StartAsync();

            string result = "";

            hubConnection.On<string>("TurnLightsOn", x =>
            {
                result = x;
            });

            await hubConnection.InvokeAsync("SendLiteBerry", "000");
            string expected = "000";

            Assert.Equal(expected, result);
        }

    }

}
