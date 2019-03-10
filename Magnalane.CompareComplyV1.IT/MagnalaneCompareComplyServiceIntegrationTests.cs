using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Hoverfly.Core.Resources;
using Hoverfly.Core;

namespace Magnalane.CompareComplyV1.IT
{
    [TestClass]
    public class MagnalaneCompareComplyServiceIntegrationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        /// <summary>
        /// TODO: eddy edwards
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Magnalane_WhenImportingSimulationAndUsingSimulationMode_Modified()
        {
            using (var hoverfly = new Hoverfly.Core.Hoverfly(HoverflyMode.Simulate, HoverFlyTestConfig1.GetHoverFlyConfigWIthBasePath()))
            {
                hoverfly.Start();

                hoverfly.ImportSimulation(new FileSimulationSource("simulation_test2_modified.json"));

                var httpClient = new HttpClient();

                var content = new StringContent("{\"items\":[{\"sku\":\"6948017\",\"quantity\":2}]}", Encoding.UTF8, "application/json");

                var result = await httpClient.PutAsync("https://echo.jsontest.com/cart", content);

                var contentRestult = await result.Content.ReadAsStringAsync();

                hoverfly.Stop();

                Assert.AreEqual("{\n   \"one\": \"two\",\n   \"key\": \"value\"\n}\n", contentRestult);
            }
        }
    }
}
