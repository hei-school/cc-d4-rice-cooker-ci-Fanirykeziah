using NUnit.Framework;

[TestFixture]
public class RiceCookerTests
{
    private IRiceCooker cooker;

    [SetUp]
    public void Setup()
    {
        cooker = new RiceCooker();
    }

    [Test]
    public void TestCookingMode()
    {
        PlugIn(cooker);
        PowerOn(cooker);
        SetCookingMode(cooker, 30);

        Assert.IsTrue(cooker.Cooking);
        Assert.AreEqual(30, cooker.CookingTime);
    }

    [Test]
    public void TestWarmMode()
    {
        PlugIn(cooker);
        PowerOn(cooker);
        SetWarmMode(cooker, 60);

        Assert.IsTrue(cooker.WarmMode);
        Assert.AreEqual(60, cooker.WarmTime);
    }

    [Test]
    public void TestSteamMode()
    {
        PlugIn(cooker);
        PowerOn(cooker);
        SetSteamMode(cooker, 60, 200);

        Assert.IsTrue(cooker.SteamMode);
        Assert.AreEqual(60, cooker.SteamTime);
    }

    [Test]
    public void TestCancel()
    {
        PlugIn(cooker);
        PowerOn(cooker);
        SetCookingMode(cooker, 30);
        SetWarmMode(cooker, 60);
        SetSteamMode(cooker, 60, 200);
        Cancel(cooker);

        Assert.IsFalse(cooker.Cooking);
        Assert.IsFalse(cooker.WarmMode);
        Assert.IsFalse(cooker.SteamMode);
        Assert.AreEqual(0, cooker.CookingTime);
        Assert.AreEqual(0, cooker.WarmTime);
        Assert.AreEqual(0, cooker.SteamTime);
    }

    private void PlugIn(IRiceCooker cooker)
    {
        cooker.PluggedIn = true;
    }

    private void PowerOn(IRiceCooker cooker)
    {
        cooker.PowerOn = true;
    }

    private void SetCookingMode(IRiceCooker cooker, int time)
    {
        cooker.Cooking = true;
        cooker.CookingTime = time;
    }

    private void SetWarmMode(IRiceCooker cooker, int time)
    {
        cooker.WarmMode = true;
        cooker.WarmTime = time;
    }

    private void SetSteamMode(IRiceCooker cooker, int time, int steamLevel)
    {
        cooker.SteamMode = true;
        cooker.SteamTime = time;
    }

    private void Cancel(IRiceCooker cooker)
    {
        cooker.Cooking = false;
        cooker.WarmMode = false;
        cooker.SteamMode = false;
        cooker.CookingTime = 0;
        cooker.WarmTime = 0;
        cooker.SteamTime = 0;
    }
}