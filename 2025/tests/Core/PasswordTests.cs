using Application.Core;

namespace Application.Tests.Core;

public class PasswordTests
{
    [Fact]
    public void Verify_ShouldReturnTrue_ForCorrectPassword()
    {
        // Arrange
        var password = "securepassword";
        var (salt, hash) = Password.Create(password);

        // Act
        var isValid = Password.Verify(password, hash, salt);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void Verify_ShouldReturnFalse_ForIncorrectPassword()
    {
        // Arrange
        var correctPassword = "securepassword";
        var wrongPassword = "wrongpassword";
        var (salt, hash) = Password.Create(correctPassword);

        // Act
        var isValid = Password.Verify(wrongPassword, hash, salt);

        // Assert
        Assert.False(isValid);
    }
}
