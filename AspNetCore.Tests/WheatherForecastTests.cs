using AspNetCore.Controllers;
using AspNetCore.Exceptions;

namespace AspNetCore.Tests;

[TestClass]
public class WheatherForescastTests 
{ 
private readonly WeatherForecastService _weatherForecastService;

public WheatherForescastTests()
{
    _weatherForecastService = new WeatherForecastService();
}

    

    [TestMethod]
    public void ShouldThrowAnExceptionWhenCityIsDifferentOfSP()
    {
        const string cityDiffSP = "Gru";
        _weatherForecastService.GetTemperature(cityDiffSP);

    Assert.ThrowsException<CityNotFoundException>(() => _weatherForecastService.GetTemperature(cityDiffSP));
        
    }
}
