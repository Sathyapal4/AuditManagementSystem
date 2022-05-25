using AuditSeverityMicroservice.Controllers;
using AuditSeverityMicroservice.Models;
using AuditSeverityMicroservice.Providers;
using AuditSeverityMicroservice.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestAuditSeverityMicroservice
{
    public class AuditSeverityControllerTest
    {
        List<AuditEvaluationModel> list1 = new List<AuditEvaluationModel>()
        {
            new AuditEvaluationModel()
            {
                AuditType="Internal",
                EvalResponsesNum=3
            }
        };


        [TestCase("Internal")]
        public void ProjectExecutionStatus_WithValidOutput_OkRequest(string type)
        {
            Mock<IAuditSeverityProvider> mock = new Mock<IAuditSeverityProvider>();
            AuditResponse rp = new AuditResponse();
            AuditRequest req = new AuditRequest()
            {
                AuditDetails = new AuditDetail()
                {
                    AuditType = type,
                    auditQuestions = new AuditQuestions()
                    {
                        Question1 = true,
                        Question2 = false,
                        Question3 = false,
                        Question4 = false,
                        Question5 = false
                    }
                }
            };
            mock.Setup(p => p.SeverityResponse(req)).Returns(rp);
            AuditSeverityController cp = new AuditSeverityController(mock.Object);

            OkObjectResult result = cp.ProjectExecutionStatus(req) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestCase("Internal123")]
        public void ProjectExecutionStatus_WithInvalidOutput_ReturnBadRequest(string type)
        {
            try
            {
                Mock<IAuditSeverityProvider> mock = new Mock<IAuditSeverityProvider>();
                AuditResponse rp = new AuditResponse();
                AuditRequest req = new AuditRequest()
                {
                    AuditDetails = new AuditDetail()
                    {
                        AuditType = type,
                        auditQuestions = new AuditQuestions()
                        {
                            Question1 = true,
                            Question2 = false,
                            Question3 = false,
                            Question4 = false,
                            Question5 = false
                        }
                    }
                };
                mock.Setup(p => p.SeverityResponse(req)).Returns(rp);
                AuditSeverityController cp = new AuditSeverityController(mock.Object);

                OkObjectResult result = cp.ProjectExecutionStatus(req) as OkObjectResult;
                Assert.AreEqual(400, result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }
    }
}