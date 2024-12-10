using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LX.PersonalDevelopmentPlan.Tests;

public class DateTimeParsingTests
{
    [Fact]
    public void ParseFirstStringToDateTime()
    {
        //Arrange
        string dateString = "7/10/2024 13:09";
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, out resultDate);

        //Assert
        Assert.True(parseResult, "Date string could not be parsed into a DateTime.");
        Assert.Equal(new DateTime(2024, 7, 10, 13, 9, 0), resultDate);
    }

    [Fact]
    public void ParseSecondStringToDateTime()
    {
        //Arrange
        string dateString = "8/31/2024 23:00:00";
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, out resultDate);

        //Assert
        Assert.True(parseResult, "Date string could not be parsed into a DateTime.");
        Assert.Equal(new DateTime(2024, 8, 31, 23, 0, 0), resultDate);
    }

    [Theory]
    [InlineData("7/10/2024 13:09", 2024, 7, 10, 13, 9, 0)]
    [InlineData("8/31/2024 23:00", 2024, 8, 31, 23, 0, 0)]
    public void ParseTwoStrings(string date, int year, int month, int day, int hour, int minute, int second)
    {
        //Arrange
        string dateString = date;
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, out resultDate);

        //Assert
        Assert.True(parseResult, $"Date string {dateString} could not be parsed into a DateTime.");
        Assert.Equal(new DateTime(year, month, day, hour, minute, second), resultDate);
    }
}
