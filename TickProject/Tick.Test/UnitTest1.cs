namespace Tick.Test;

using Tick.App;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {

    }
    [Fact]
    public void StringToIntReturnsInt()
    {
        // Arrange
        // Act
        var actual = InputManager.StringToInt("4");

        // Assert
        Assert.IsType<int>(actual);
    }
}