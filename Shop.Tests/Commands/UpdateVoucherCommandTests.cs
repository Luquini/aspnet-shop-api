using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Commands.CustomerCommands;
using Shop.Domain.Commands.ProductCommands;
using Shop.Domain.Enums;

namespace Shop.Tests
{
    [TestClass]
    public class UpdateVoucherCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new UpdateVoucherCommand("dd94b205-a248-44f6-aa4b-22ffac1f06a2",
            "KFJD923", 50.00m, 10.00m, 10, (int)EDiscountType.Percent, true,
            false, DateTime.Now.AddDays(1));

            Assert.AreEqual(true, command.Validation());
        }
        [TestMethod]
        public void ShouldFailWhenCodeIsInvalid()
        {
            var command = new UpdateVoucherCommand("dd94b205-a248-44f6-aa4b-22ffac1f06a2", "", 50.00m, 10.00m, 10,
            (int)EDiscountType.Percent, true, false, DateTime.Now.AddDays(1));
            var commandTwo = new CreateVoucherCommand(@"XXXXXXXXXXXXXXXXXXXXXX
            XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
            50.00m, 10.00m, 10, (int)EDiscountType.Percent, true, false, DateTime.Now.AddDays(1));

            Assert.AreEqual(false, command.Validation());
            Assert.AreEqual(false, commandTwo.Validation());
        }
        [TestMethod]
        public void ShouldFailWhenDiscountPercentIsInvalid()
        {
            var command = new UpdateVoucherCommand("dd94b205-a248-44f6-aa4b-22ffac1f06a2",
            @"KFJD923", 101.00m, 10.00m, 10,
            (int)EDiscountType.Percent, true, false, DateTime.Now.AddDays(1));
            var commandTwo = new CreateVoucherCommand(@"KFJD923", 0m, 10.00m, 10,
            (int)EDiscountType.Percent, true, false, DateTime.Now.AddDays(1));

            Assert.AreEqual(false, command.Validation());
            Assert.AreEqual(false, commandTwo.Validation());
        }
        [TestMethod]
        public void ShouldFailWhenDiscountValueIsInvalid()
        {
            var command = new UpdateVoucherCommand("dd94b205-a248-44f6-aa4b-22ffac1f06a2",
            @"KFJD923", 50.00m, 0m, 10,
            (int)EDiscountType.Percent, true, false, DateTime.Now.AddDays(1));

            Assert.AreEqual(false, command.Validation());
        }
        [TestMethod]
        public void ShouldFailWhenQuantityIsZero()
        {
            var command = new UpdateVoucherCommand("dd94b205-a248-44f6-aa4b-22ffac1f06a2",
            @"KFJD923", 50.00m, 10.00m, 0,
            (int)EDiscountType.Percent, true, false, DateTime.Now.AddDays(1));

            Assert.AreEqual(false, command.Validation());
        }
        [TestMethod]
        public void ShouldFailWhenDiscountTypeIsInvalid()
        {
            var command = new UpdateVoucherCommand("dd94b205-a248-44f6-aa4b-22ffac1f06a2",
            @"KFJD923", 50.00m, 10.00m, 5,
            0, true, false, DateTime.Now.AddDays(1));

            Assert.AreEqual(false, command.Validation());
        }
        [TestMethod]
        public void ShouldFailWhenExpirationDateIsInvalid()
        {
            var command = new UpdateVoucherCommand("dd94b205-a248-44f6-aa4b-22ffac1f06a2",
            @"KFJD923", 50.00m, 10.00m, 5,
            (int)EDiscountType.Percent, true, false, DateTime.Now);

            Assert.AreEqual(false, command.Validation());
        }
    }
}
