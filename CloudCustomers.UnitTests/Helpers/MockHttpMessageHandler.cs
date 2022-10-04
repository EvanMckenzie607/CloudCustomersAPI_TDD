using System;
using Moq;
using Newtonsoft.Json;

namespace CloudCustomers.UnitTests.Helpers
{
    internal class MockHttpMessageHandler
    {
        internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)

        {
            var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
            };
        }
    }
}

