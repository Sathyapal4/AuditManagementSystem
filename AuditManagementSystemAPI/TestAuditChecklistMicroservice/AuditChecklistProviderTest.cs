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
    public class TestsProvider
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
        public void QuestionsProvider_ValidInput_OkRequest(string type)
        {
            Mock<IAuditChecklistRepository> mock = new Mock<IAuditChecklistRepository>();
            mock.Setup(p => p.GetQuestions(type)).Returns(l1);
            AuditChecklistProvider cp = new AuditChecklistProvider(mock.Object);
            List<QuestionModel> result = cp.QuestionsProvider(type);
            Assert.AreEqual(3, result.Count);
        }

        [TestCase("Internalab")]
        public void GetQuestions_InvalidInput_ReturnBadRequest(string a)
        {
            try
            {
                string type = null;
                Mock<IAuditChecklistRepository> mock = new Mock<IAuditChecklistRepository>();
                mock.Setup(p => p.GetQuestions(type)).Returns(l2);
                AuditChecklistProvider cp = new AuditChecklistProvider(mock.Object);
                List<QuestionModel> result = cp.QuestionsProvider(type);
                Assert.AreEqual(0, result.Count);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }

        


    }
}