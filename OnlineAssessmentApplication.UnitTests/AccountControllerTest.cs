using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineAssessmentApplication.Controllers;
using OnlineAssessmentApplication.DomainModel;
using OnlineAssessmentApplication.Repository;
using OnlineAssessmentApplication.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace OnlineAssessmentApplication.UnitTests
{
    [TestClass]
    public class AccountControllerTest
    {
        private readonly UserRepository userRepository;
        public AccountControllerTest()
        {
            this.userRepository = new UserRepository();
        }
        [TestMethod]
        public void LoginTest()
        {
            //Arrange
            User userDetails = null;

            //Act
            userDetails=userRepository.ValidateUser(new UserViewModel() { EmailID = "student@gmail.com", Password = "123" }).FirstOrDefault();

            //Assert
            Assert.IsNotNull(userDetails);
        }
        [TestMethod]
        public void FindRole()
        {
            string expectedRole = "Student";
            //Arrange
            string role = string.Empty;
            //Act
            role= userRepository.FindRole(new UserViewModel() { EmailID = "student@gmail.com", Password = "123" });
            //Assert
            Assert.AreEqual(role, expectedRole);
        }
        [TestMethod]
        public void CheckIsIsPresentOrNot()
        {
            //Arrange
            int id = 2;
           
            //Act
            User fetchedUserDetails= userRepository.GetUserByUserId(id);

            //Assert
            Assert.IsNotNull(fetchedUserDetails);
        }
        [TestMethod]
        public void CheckUpdateUserProfile()
        {
            //Arrange
            int id = 2;
            bool statusForUserProfileUpdate = false;

            //Act
            User fetchedUserDetails = userRepository.GetUserByUserId(id);
            if (fetchedUserDetails != null)
            {
                userRepository.UpateUserDetails(new User() { UserId = 2, Name = "Prasanth kumar", PhoneNumber = 123456 });
                statusForUserProfileUpdate = true;

            }


            //Assert
            Assert.IsTrue(statusForUserProfileUpdate);

        }
        [TestMethod]
        public void CheckUpdatePassword()
        {
            int id = 2;
            bool statusForPasswordUpdate = false;

            //Act
            User fetchedUserDetails = userRepository.GetUserByUserId(id);
            if (fetchedUserDetails != null)
            {
                userRepository.UpdateUserPasswordDetails(new User() { Password = "123", UserId = 2 });
                statusForPasswordUpdate = true;
            }

            //Assert
            Assert.IsTrue(statusForPasswordUpdate);
        }
        [TestMethod]
        public void CheckView()
        {
            //Arrange
            AccountController accountController = new AccountController();

            //Act
            ViewResult result= accountController.Login() as ViewResult;

            //Assert
            Assert.AreEqual("Login", result.ViewName);
        }
    }
}
