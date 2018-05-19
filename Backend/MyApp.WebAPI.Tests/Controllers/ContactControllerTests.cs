using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApp.SqlServerModel.Repositories;
using MyApp.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MyApp.WebAPI.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task When_trying_to_add_null_contact_should_throws_exception()
        {
            var contactRepoMoq = new Mock<IContactRepo>();

            var controller = new ContactController(contactRepoMoq.Object);
            var result = await controller.Post(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_trying_to_get_contact_with_id_zero_should_throws_exception()
        {
            var contactRepoMoq = new Mock<IContactRepo>();

            var controller = new ContactController(contactRepoMoq.Object);
            var result = controller.Get(0);
        }
    }
}
