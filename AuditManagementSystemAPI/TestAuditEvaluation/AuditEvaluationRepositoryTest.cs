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
    public class TestsAuditRepository
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
            Mock<IAuditEvaluationRepository> mock = new Mock<IAuditEvaluationRepository>();
            mock.Setup(p => p.GetNolist()).Returns(list1);
            AuditEvaluationRepository evaluationRepository = new AuditEvaluationRepository();
            List<AuditEvaluationModel> result = evaluationRepository.GetNolist();
            Assert.AreEqual(list1.Count, 2);
        }

        [Test]
        public void getEvaluation_InvalidInput_ReturnBadRequest()
        {
            Mock<IAuditEvaluationRepository> mock = new Mock<IAuditEvaluationRepository>();
            mock.Setup(p => p.GetNolist()).Returns(list2);
            AuditEvaluationRepository evaluationRepository = new AuditEvaluationRepository();
            List<AuditEvaluationModel> result = evaluationRepository.GetNolist();
            Assert.AreNotEqual(list1.Count, result.Count);
        }

        
    }
}