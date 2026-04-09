using System;
using Xunit;
using Study.LabWork1.Features.Task1;
using Assert = Xunit.Assert;

namespace Study.LabWork1.Features.Tests;

public class MyVectorTests
{
    [Fact]
    public void Constructor_ShouldSetDirectionXAndDirectionY()
    {
        var vector = new MyVector(7.2f, -4.1f);

        Assert.Equal(7.2f, vector.DirectionX);
        Assert.Equal(-4.1f, vector.DirectionY);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        var vector = new MyVector(8, 12);
        Assert.Equal("(8, 12)", vector.ToString());

        var vector2 = new MyVector(-2.3f, 5.7f);
        Assert.Equal("(-2,3, 5,7)", vector2.ToString());
    }

    [Fact]
    public void OperatorPlus_ShouldSumVectors()
    {
        var v1 = new MyVector(4.1f, 1.9f);
        var v2 = new MyVector(2.3f, 6.8f);
        var expected = new MyVector(6.4f, 8.7f);

        var result = v1 + v2;

        Assert.Equal(expected.DirectionX, result.DirectionX, 3);
        Assert.Equal(expected.DirectionY, result.DirectionY, 3);
    }

    [Fact]
    public void OperatorMinus_ShouldSubtractVectors()
    {
        var v1 = new MyVector(9.5f, 7.3f);
        var v2 = new MyVector(2.2f, 3.1f);
        var expected = new MyVector(7.3f, 4.2f);

        var result = v1 - v2;

        Assert.Equal(expected.DirectionX, result.DirectionX, 3);
        Assert.Equal(expected.DirectionY, result.DirectionY, 3);
    }

    [Fact]
    public void OperatorMultiply_ShouldCountVectorMultiply()
    {
        var v1 = new MyVector(2.5f, 3.5f);
        var v2 = new MyVector(4.0f, 1.5f);

        float expected = 2.5f * 4.0f + 3.5f * 1.5f;

        float result = v1 * v2;

        Assert.Equal(expected, result, 2);
    }

    [Fact]
    public void UnaryPlus_ShouldReturnLength()
    {
        var v = new MyVector(6f, 8f);
        float length = +v;
        float expected = (float)Math.Sqrt(6 * 6 + 8 * 8);

        Assert.Equal(expected, length, 5);
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrueForEqualVectors()
    {
        var v1 = new MyVector(3.3f, 4.4f);
        var v2 = new MyVector(3.3f, 4.4f);

        Assert.True(v1 == v2);
    }
    
}