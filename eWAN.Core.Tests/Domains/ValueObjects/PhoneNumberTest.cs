using NUnit.Framework;
using eWAN.Core.Domains.Account;

class PhoneNumberTest
{

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void ShouldParseInternationalNumber()
    {
        // Arrange
        string number = "+639291231234";
        var sut = new PhoneNumber(number);

        // Act
        string result = sut.ToString();

        // Assert
        Assert.AreEqual(result, number);
    }

    [Test]
    public void ShouldParsePhilippineNumber()
    {
        // Arrange
        string number = "09291231234";
        var sut = new PhoneNumber(number);

        // Act
        string result = sut.ToString();

        // Assert
        Assert.AreEqual(result, "+639291231234");
    }

}
