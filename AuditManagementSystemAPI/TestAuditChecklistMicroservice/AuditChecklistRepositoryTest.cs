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
    public class TestsRepository
    {
        List<QuestionModel> list1 = new List<QuestionModel>();
        List<QuestionModel> list2 = null;
        [SetUp]
        public void setup()
        {

            list1 = new List<QuestionModel>()
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
                    Question="For a major change, was there a database backup taken before and after PROD move?"
                },
                new QuestionModel
                {
                    QNo=4,
                    Question="Has the application owner approval obtained while adding a user to the system?"
                },
                new QuestionModel
                {
                    QNo=5,
                    Question="Is data deletion from the system done with application owner approval?"
                }

                
            };
        }

        [TestCase("Internal")]
        public void QuestionsProvider_ValidInput_OkRequest(string type)
        {
            
                Mock<IAuditChecklistRepository> mock = new Mock<IAuditChecklistRepository>();
                mock.Setup(p => p.GetQuestions(type)).Returns(list1);
            AuditChecklistRepository cp = new AuditChecklistRepository();
                List<QuestionModel> result = cp.GetQuestions(type);
                Assert.AreEqual(list1.Count, result.Count);
            
        }

 

        


    }
}