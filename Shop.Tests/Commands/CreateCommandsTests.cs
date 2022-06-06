using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Commands.CustomerCommands;

namespace Shop.Tests
{
  [TestClass]
  public class CreateCustomerCommandTests
  {
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
      var command = new CreateCustomerCommand();
      command.FirstName = "Vitor";
      command.LastName = "Luquini";
      command.Document = "28659170377";
      command.Email = "test@gmail.com";

      Assert.AreEqual(true, command.Validation());
    }
  }
}
