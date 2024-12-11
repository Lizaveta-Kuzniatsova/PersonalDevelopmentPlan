using System.Collections.Generic;
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
    public void Parse_TwoStringsToDateTime_True(string date, DateTime expectedDate)
    {
        //Arrange
        string dateString = date;
        DateTime resultDate;

        //Act
        bool parseResult = DateTime.TryParse(dateString, out resultDate);

        //Assert
        Assert.True(parseResult);
        Assert.Equal(expectedDate, resultDate);
    }
}
