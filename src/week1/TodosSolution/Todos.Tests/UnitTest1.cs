﻿using Todos.Api.Utils;

namespace Todos.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Given
        string firstName = "Bob", lastName = "Smith", fullName;

        // When
        fullName = Formatters.FormatName(firstName, lastName);

        // Then 
        Assert.Equal("Smith, Bob", fullName);
    }

    [Theory]
    [InlineData("Bob", "Smith", "Smith, Bob")]
    [InlineData("Luke", "Skywalker", "Skywalker, Luke")]
    public void CanFormatAnyName(string firstName, string lastName, string expecting)
    {
        var fullName = Formatters.FormatName(firstName, lastName);

        Assert.Equal(expecting, fullName);
    }
}