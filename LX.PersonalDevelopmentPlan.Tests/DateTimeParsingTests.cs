using System.Globalization;
using Xunit.Abstractions;

namespace LX.PersonalDevelopmentPlan.Tests;

public class DateTimeParsingTests
{
    private readonly ITestOutputHelper _console;
    public DateTimeParsingTests(ITestOutputHelper console)
    {
        _console = console;
    }

    [Fact]
    public void Parse_FirstStringToDateTime_True()
    {
        //Arrange
        var currentCulture = CultureInfo.CurrentCulture;
        _console.WriteLine("Current Culture: " + currentCulture.Name);

        var currentUICulture = CultureInfo.CurrentUICulture;
        _console.WriteLine("Current UI Culture: " + currentUICulture.Name);

        string dateString = "7/10/2024 13:09";
        var invariantCulture = CultureInfo.InvariantCulture;
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, invariantCulture, out resultDate);

        //Assert
        Assert.True(parseResult);
        Assert.Equal(new DateTime(2024, 7, 10, 13, 9, 0), resultDate);
    }

    [Fact]
    public void Parse_SecondStringToDateTime_True()
    {
        //Arrange
        string dateString = "8/31/2024 23:00";
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, TestSettings.USCulture, out resultDate);

        //Assert
        Assert.True(parseResult);
        Assert.Equal(new DateTime(2024, 8, 31, 23, 0, 0), resultDate);
    }
    public static IEnumerable<object[]> GetDate(int num)
    {
        var allDates = new List<object[]>
        {
            new object[] {"7/10/2024 13:09", new DateTime(2024, 7, 10, 13, 9, 0)},
            new object[] {"8/31/2024 23:00", new DateTime(2024, 8, 31, 23, 0, 0)},
        };
        return allDates.Take(num);
    }

    [Theory]
    [MemberData(nameof(GetDate), parameters: 2)]
    public void Parse_StringToDateTime_ShouldReturnsExpectedDate(string date, DateTime expectedDate)
    {
        //Arrange
        string dateString = date;
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, TestSettings.USCulture, out resultDate);

        //Assert
        Assert.True(parseResult);
        Assert.Equal(expectedDate, resultDate);
    }
}
