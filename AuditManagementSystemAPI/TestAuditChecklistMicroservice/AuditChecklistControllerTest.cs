using AuditChecklistMicroservice.Controllers;
using AuditChecklistMicroservice.Models;
using AuditChecklistMicroservice.Providers;
using AuditChecklistMicroservice.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestAuditChecklistMicroservice
{
    public class TestsController
    {
        List<QuestionModel> l1 = new List<QuestionModel>();
        List<QuestionModel> l2 = null;
        [SetUp]
        public void setup()
        {

            l1 = new List<QuestionModel>()
            {
                new QuestionModel
                {
                    QNo=1,
                    Question="Have all Change requests followed SDLC before PROD move?"
                },
                new QuestionModel
                {
                    QNo=2,
                    Question="Have all Change requests been approved by the application owner?"
                },
                new QuestionModel
                {
                    QNo=3,
                    Question="Is data deletion from the system done with application owner approval?"
                }

                
            };
        }


        [TestCase("Internal")]
        public void AuditCheckListQuestions_ValidInput_OkRequest(string type)
        {
            Mock<IAuditChecklistProvider> mock = new Mock<IAuditChecklistProvider>();
            mock.Setup(p => p.QuestionsProvider(type)).Returns(l1);
            AuditChecklistController cp = new AuditChecklistController(mock.Object);
            OkObjectResult result = cp.AuditCheckListQuestions(type) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestCase("Internalab")]
        public void AuditCheckListQuestions_InvalidInput_ReturnBadRequest(string a)
        {
            try
            {
                string type = null;
                Mock<IAuditChecklistProvider> mock = new Mock<IAuditChecklistProvider>();
                mock.Setup(p => p.QuestionsProvider(type)).Returns(l2);
                AuditChecklistController cp = new AuditChecklistController(mock.Object);
                OkObjectResult result = cp.AuditCheckListQuestions(type) as OkObjectResult;
                Assert.AreEqual(400, result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }


    }
}