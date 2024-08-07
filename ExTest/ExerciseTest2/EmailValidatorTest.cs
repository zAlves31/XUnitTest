using Exercise2;

namespace ExerciseTest2
{
    public class EmailValidatorTest
    {
        [Theory]
        [InlineData("joao.alvesemail.com")]
        [InlineData("@mail")]
        [InlineData("joao.alves@.com")]
        public void GiveInvalidEmailsTest(string testedEmail)
        {
            // Act
            bool result = EmailValidator.Validate(testedEmail);

            // Assert
            Assert.False(result);
        }
    }
}