using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LX.PersonalDevelopmentPlan.Tests;

public class DateTimeParsingTests
{
    [Fact]
    public void Parse_FirstStringToDateTime_True()
    {
        //Arrange
        string dateString = "7/10/2024 13:09";
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, out resultDate);

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
        bool parseResult = DateTime.TryParse(dateString, out resultDate);

        //Assert
        Assert.True(parseResult);
        Assert.Equal(new DateTime(2024, 8, 31, 23, 0, 0), resultDate);
    }

    public static DateTime CreateDateTime(params int[] date) => new DateTime(date[0], date[1], date[2], date[3], date[4], date[5]);

    [Theory]
    [InlineData("7/10/2024 13:09", 2024, 7, 10, 13, 9, 0)]
    [InlineData("8/31/2024 23:00", 2024, 8, 31, 23, 0, 0)]
    public void Parse_TwoStringsToDateTime_True(string date, params int[] expectedDate)
    {
        //Arrange
        string dateString = date;
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, out resultDate);

        //Assert
        Assert.True(parseResult);
        Assert.Equal(CreateDateTime(expectedDate), resultDate);
    }
}
