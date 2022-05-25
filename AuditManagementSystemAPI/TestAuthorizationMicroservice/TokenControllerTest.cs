using NUnit.Framework;
using System;
using Moq;
using AuthorizationMicroservice.Repositories;
using AuthorizationMicroservice.Providers;
using AuthorizationMicroservice.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace TestAuthorizationMicroservice
{
    class TokenControllerTest
    {

        public string TokenNotNull;
        public string TokenNull;
        [SetUp]
        public void Setup()
        {
            TokenNotNull = "ThisIsATestingToken";
            TokenNull = null;

        }

        [Test]
        public void tokenController_getJWT_correctInput_tokenNotNull()
        {
            var mock = new Mock<IAuthorizationProvider>();
            mock.Setup(p => p.GetJsonWebToken()).Returns(TokenNotNull);
            var res = new AuthTokenController(mock.Object);
            var data = res.GenerateJSONWebToken() as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
        [Test]
        public void tokenController_getJWT_incorrectInput_tokenNull()
        {
            var mock = new Mock<IAuthorizationProvider>();
            mock.Setup(p => p.GetJsonWebToken()).Returns(TokenNull);
            var res = new AuthTokenController(mock.Object);
            var data = res.GenerateJSONWebToken() as BadRequestObjectResult;
            Assert.AreEqual(400, data.StatusCode);
        }

    }
}
