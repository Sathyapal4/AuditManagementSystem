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
    public class AuthorizationRepositoryTest
    {
        public string token_null;
        [SetUp]
        public void Setup()
        {
            token_null = null;

        }

        [Test]
        public void AuthRepository_JWT_Input_tokenNotNull()
        {
            try
            {
                var mock = new Mock<IConfiguration>();
                mock.SetupGet(x => x[It.IsAny<string>()]);
                var res = new AuthorizationRepository(mock.Object);
                var data = res.GenerateJWT();
                Assert.IsNotNull(data);
            }

            catch (Exception e)
            {
                Assert.AreEqual("String reference not set to an instance of a String. (Parameter 's')", e.Message);
            }

        }

        [Test]
        public void AuthRepository_invalidInput_tokenNull()
        {

            try
            {
                var mock = new Mock<IConfiguration>();
                mock.SetupGet(x => x[It.IsAny<string>()]).Returns(token_null);
                var res = new AuthorizationRepository(mock.Object);
                var data = res.GenerateJWT();
                Assert.IsNull(data);

            }
            catch (Exception e) {
                Assert.AreEqual("String reference not set to an instance of a String. (Parameter 's')", e.Message);
            }
        }  
    }
}