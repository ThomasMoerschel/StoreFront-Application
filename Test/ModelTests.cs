using System;
using StoreAppModels;
using Xunit;

namespace Test
{
    public class ModelTests
    {
        [Theory]
        [InlineData("Jeremy")]
        public void NameShouldSetValidData(string input)
        {
            //Arrange
            Customer test = new Customer();
            //Act
            test.Name = input;
            //Assert
            Assert.Equal(input, test.Name);
        }
        [Fact]
        public void PhoneNumberShouldSetValidData()
        {
            Customer test = new Customer();
            string _number = "1234567890";
            test.PhoneNumber = _number;
            Assert.Equal(test.PhoneNumber, _number);
        }
        [Fact]
        public void EmailShouldSetValidData()
        {
            Customer test = new Customer();
            string _email = "random@gmail.com";
            test.Email = _email;
            Assert.Equal(test.Email, _email);
        }
        [Fact]
        public void AddressShouldSetValidData()
        {
            Customer test = new Customer();
            string _address = "123 Random Address St";
            test.Address = _address;
            Assert.Equal(test.Address, _address);
        }
        [Fact]
        public void PasswordShouldSetValidData()
        {
            Customer test = new Customer();
            string password = "randomPassword123!";
            test.Password = password;
            Assert.Equal(test.Password, password);
        }
    }
}