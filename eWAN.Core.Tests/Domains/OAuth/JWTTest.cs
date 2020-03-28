using NUnit.Framework;
using eWAN.Core.UseCases.OAuth;

class JWTTest
{
    private string name;
    private string permission_code;
    [SetUp]
    public void Setup()
    {
        this.name = "sample name";
        this.permission_code = "00002000";
    }

    [Test]
    public void ShouldVerifySignature()
    {
        JWTToken TokenGenerator = new JWTToken("Aiko");
        string token = TokenGenerator.CreateNewToken(this.name, this.permission_code);

        bool result = TokenGenerator.DecodeAndVerifyToken(token);

        Assert.IsTrue(result);
    }

}
