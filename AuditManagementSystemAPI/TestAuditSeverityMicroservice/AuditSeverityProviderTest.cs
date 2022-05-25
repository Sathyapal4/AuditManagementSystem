using AuditSeverityMicroservice.Controllers;
using AuditSeverityMicroservice.Models;
using AuditSeverityMicroservice.Providers;
using AuditSeverityMicroservice.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditSeverityTesting
{
    public class AuditSeverityProviderTest
    {
        List<AuditEvaluationModel> list1 = new List<AuditEvaluationModel>()
        {
            new AuditEvaluationModel()
            {
                AuditType="Internal",
                EvalResponsesNum=3
            }
        };

        List<AuditEvaluationModel> list2 = new List<AuditEvaluationModel>()
        {
            new AuditEvaluationModel()
            {
                AuditType="Internal",
                EvalResponsesNum=1
            }
        };





        [Test]
        public void Internal_SeverityResponse_ValidOutput_OkRequest()
        {
            Mock<IAuditSeverityRepository> mock = new Mock<IAuditSeverityRepository>();
            mock.Setup(p => p.Response()).Returns(list1);
            AuditSeverityProvider provider = new AuditSeverityProvider(mock.Object);
            AuditRequest request = new AuditRequest()
            {
                AuditDetails = new AuditDetail()
                {
                    AuditType = "Internal",
                    auditQuestions = new AuditQuestions()
                    {
                        Question1 = true,
                        Question2 = true,
                        Question3 = false,
                        Question4 = false,
                        Question5 = true
                    }
                }
            };
            AuditResponse result = provider.SeverityResponse(request);
            Assert.AreEqual("GREEN", result.ProjectExecutionStatus);
        }
        

        [Test]
        public void Internal_SeverityResponse_InalidOutput_BadRequest()
        {
            Mock<IAuditSeverityRepository> mock = new Mock<IAuditSeverityRepository>();
            mock.Setup(p => p.Response()).Returns(list2);
            AuditSeverityProvider provider = new AuditSeverityProvider(mock.Object);
            AuditRequest request = new AuditRequest()
            {
                AuditDetails = new AuditDetail()
                {
                    AuditType = "Internal",
                    auditQuestions = new AuditQuestions()
                    {
                        Question1 = true,
                        Question2 = true,
                        Question3 = false,
                        Question4 = false,
                        Question5 = true
                    }
                }
            };
            AuditResponse result = provider.SeverityResponse(request);
            Assert.AreNotEqual("GREEN", result.ProjectExecutionStatus);
        }
 
        


    }
}