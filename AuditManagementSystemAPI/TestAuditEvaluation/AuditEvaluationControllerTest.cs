using AuditEvaluation.Controllers;
using AuditEvaluation.Models;
using AuditEvaluation.Providers;
using AuditEvaluation.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestAuditEvaluation
{
    public class AuditEvaluationControllerTest
    {
        List<AuditEvaluationModel> list2 = new List<AuditEvaluationModel>();
        List<AuditEvaluationModel> list1 = new List<AuditEvaluationModel>();
        [SetUp]
        public void Setup()
        {

            list1 = new List<AuditEvaluationModel>()
            {
               new AuditEvaluationModel
            {
                AuditType="Internal",
                EvalResponsesNum=3
            },
                new AuditEvaluationModel
            {
                AuditType="XYZ",
                EvalResponsesNum=1
            }
            };
            list2 = new List<AuditEvaluationModel>()
            {
                new AuditEvaluationModel
                {
                    AuditType="ABC",
                    EvalResponsesNum=4
                }
            };

        
        }


        [Test]
        public void getEvaluation_ValidInput_ReturnOK()
        {
            Mock<IAuditEvaluationProvider> mock = new Mock<IAuditEvaluationProvider>();
            mock.Setup(p => p.GetEvaluation()).Returns(list1);
            AuditEvaluationController cp = new AuditEvaluationController(mock.Object);
            OkObjectResult result = cp.AuditBenchmark() as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);

        }

        

        [Test]
        public void getEvaluation_InvalidInput_ReturnBadRequest()
        {
            try
            {
                Mock<IAuditEvaluationProvider> mock = new Mock<IAuditEvaluationProvider>();
                mock.Setup(p => p.GetEvaluation()).Returns(list2);
                AuditEvaluationController cp = new AuditEvaluationController(mock.Object);
                var result = cp.AuditBenchmark() as BadRequestResult;
                Assert.AreEqual(400, result.StatusCode);
            }

            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }
    }
}