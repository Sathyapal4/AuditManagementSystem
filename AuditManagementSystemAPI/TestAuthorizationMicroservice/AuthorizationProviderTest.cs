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
    class AuthorizationProviderTest
    {

        public string token_not_null;
        public string token_null;
        [SetUp]
        public void Setup()
        {
            token_not_null = "ThisIsATestingToken";
            token_null = null;

        }

        [Test]
        public void AuthProvider_JWT_Input_tokenNotNull()
        {
            var mock = new Mock<IAuthorizationRepository>();
            mock.Setup(p => p.GenerateJWT()).Returns(token_not_null);
            var res = new AuthorizationProvider(mock.Object);
            var data = res.GetJsonWebToken();
            Assert.AreEqual(token_not_null, data);
        }
        [Test]
        public void AuthProvider_JWT_Input_tokenNull()
        {
            var mock = new Mock<IAuthorizationRepository>();
            mock.Setup(p => p.GenerateJWT()).Returns(token_null);
            var res = new AuthorizationProvider(mock.Object);
            var data = res.GetJsonWebToken();
            Assert.AreEqual(null, data);
        }
    }
}
