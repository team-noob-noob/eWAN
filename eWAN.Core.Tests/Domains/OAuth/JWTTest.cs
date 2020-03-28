using NUnit.Framework;
using eWAN.Core.Domains.OAuth;

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
        string token = TokenGenerator.createNewToken(this.name, this.permission_code);

        bool result = TokenGenerator.decodeAndVerifyToken(token);

        Assert.IsTrue(result);
    }

}
