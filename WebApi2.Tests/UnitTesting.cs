using System;
using WebApi.Domain;
using System.Web.Mvc;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi;

namespace WebApi2.Tests
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void TestMethodLogin()
        {
            USUARIOS user = new USUARIOS();
            var controller = new WebApi.Controllers.LoginController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index",result.ViewName);
        }

       
    }
}
