using AuditSeverityMicroservice.Controllers;
using AuditSeverityMicroservice.Models;
using AuditSeverityMicroservice.Providers;
using AuditSeverityMicroservice.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditSeverityTesting
{
    public class AuditSeverityRepositoryTest
    {
        
        List<AuditEvaluationModel> list1 = new List<AuditEvaluationModel>();
        List<AuditEvaluationModel> list2 = null;
        [SetUp]
        public void Setup()
        {

            list1 = new List<AuditEvaluationModel>()
            {

                new AuditEvaluationModel()
                {
                    AuditType="Internal",
                    EvalResponsesNum=3
                }
            };
        }
        

       [Test]
        public void AuditSeverityResponse_WithValidOutput_OkRequest()
        {
            Mock<IAuditSeverityRepository> mock = new Mock<IAuditSeverityRepository>();
            mock.Setup(p => p.Response()).Returns(list1);
            
            AuditSeverityRepository repository = new AuditSeverityRepository();
            
            List<AuditEvaluationModel> result = repository.Response();
            Assert.AreEqual(list2,result);

            
        }

        [Test]
        public void AuditSeverityResponse_WithNoOutput_BadRequestRequest()
        {
            Mock<IAuditSeverityRepository> mock = new Mock<IAuditSeverityRepository>();
            mock.Setup(p => p.Response()).Returns(list2);

            AuditSeverityRepository repository = new AuditSeverityRepository();

            List<AuditEvaluationModel> result = repository.Response();
            Assert.IsNull(result);
        }
        

    }
}