using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;

namespace DomainTest
{
    [TestClass]
    public class MobileUnitTest
    {
        [TestMethod]
        public void TestCreateMobileUnitAndSetName()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.Name = "Name";
            Assert.AreEqual(mobile.Name, "Name");
        }

        [TestMethod]
        public void TestCreateMobileUnitAndSetPlate()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.SetPlate("ACX2234");
            Assert.AreEqual(mobile.Plate, "ACX2234");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlateException), "It is not a valid plate, the lenght has to be 7.")]
        public void TestCreateMobileUnitAndSetPlateIncorrectWithLessCharacters()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.SetPlate("223ACX");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlateException), "It is not a valid plate, the lenght has to be 7.")]
        public void TestCreateMobileUnitAndSetPlateIncorrectWithMoreCharacters()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.SetPlate("2234ACXA");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlateException), "It is not a valid plate, the format is three letters and four numbers")]
        public void TestCreateMobileUnitAndSetPlateIncorrectFormatAllNumbers()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.SetPlate("1234567");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlateException), "It is not a valid plate, the format is three letters and four numbers")]
        public void TestCreateMobileUnitAndSetPlateIncorrectFormatAllLetters()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.SetPlate("ABCDEFG");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlateException), "It is not a valid plate, the format is three letters and four numbers")]
        public void TestCreateMobileUnitAndSetPlateIncorrectFormatNumbersAndLettersMixed()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.SetPlate("1A2B3C5");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlateException), "It is not a valid plate, the format is three letters and four numbers")]
        public void TestCreateMobileUnitAndSetPlateIncorrectFormatFirstNumbers()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.SetPlate("123ABCD");
        }

        [TestMethod]
        public void TestCreateMobileUnitAndSetDescription()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.Description = "any text";
            Assert.AreEqual(mobile.Description, "any text");
        }

        [TestMethod]
        public void TestCreateMobileUnitAndSetAvailableTrue()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.Available = true;
            Assert.IsTrue(mobile.Available);
        }

        [TestMethod]
        public void TestCreateMobileUnitAndSetAvailableFalse()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.Available = false;
            Assert.IsFalse(mobile.Available);
        }
    }
}
