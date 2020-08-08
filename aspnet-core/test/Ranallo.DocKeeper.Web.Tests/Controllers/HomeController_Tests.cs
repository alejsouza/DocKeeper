using System.Threading.Tasks;
using Ranallo.DocKeeper.Models.TokenAuth;
using Ranallo.DocKeeper.Web.Controllers;
using Shouldly;
using Xunit;

namespace Ranallo.DocKeeper.Web.Tests.Controllers
{
    public class HomeController_Tests: DocKeeperWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}