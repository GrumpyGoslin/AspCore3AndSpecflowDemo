using AspNetCore3SpecflowModels;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AspNetCore3SpecflowBehaviourTests.Steps
{
    [Binding]
    public class ProductSteps
    {
        Product Entity { get; set; }

        ISystemUnderTest SUT { get; set; }

        public ProductSteps(ISystemUnderTest sut)
        {
            SUT = sut;
        }

        [Given(@"I have a Product called ""(.*)""")]
        public void GivenIHaveAProductCalled(string productName)
        {
            Entity = new Product
            {
                Name = productName
            };
        }

        [When(@"I create the Product")]
        public Task WhenICreateTheProduct() => SUT.PostAsync(Routes.Create<Product>(), Entity);
        
        [Then(@"I received a ""(.*)"" response code")]
        public void ThenIReceivedAResponseCode(int responseCode)
        {
            Assert.AreEqual(responseCode, (int)SUT.Response.StatusCode, SUT.Response.Content.ReadAsStringAsync().Result);
        }

        [Then(@"I received a valid Product called ""(.*)""")]
        public void ThenIReceivedAValidProductCalled(string productName)
        {
            var entity = SUT.Response.Content.AsEntity<Product>();

            Assert.AreEqual(productName, entity.Name);

            Assert.Greater(entity.Id, 0);
        }

    }
}
