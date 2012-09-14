using Apigee.Net.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apigee.Net.Tests.ApigeeClientTests
{
    public class ClientTests
    {
        ApigeeClient aClient = new ApigeeClient("http://api.usergrid.com/sympletech1/sandbox/");

        [Test]
        public void GetUsersTest()
        {
            var results = aClient.GetUsers();
            Assert.IsNotNull(results);
        }

        [Test]
        public void CreateAccountTest()
        {
            string un = "apigee_" + Guid.NewGuid();
            var result = aClient.CreateAccount(new ApigeeUserModel {
                Username = un,
                Password = "abc123",
                Email = un + "@sympletech.com"
            });

            Assert.IsNotEmpty(result.Uuid);
        }

        [Test]
        public void UpdateAccountTest()
        {
            string un = "bobby";
            var result = aClient.UpdateAccount(new ApigeeUserModel
            {
                Username = un,
                Password = "abc123",
                Email = un + "@sympletech.com"
            });
        }


        [Test]
        public void GetTokenTest()
        {
            var result = aClient.GetToken("apigee_58461c11-6632-4980-9130-cb43fc5d0dc6", "abc123");
            Assert.IsNotNull(result);
        }

        [Test]
        public void LookUpTokenTest()
        {
            var result = aClient.LookUpToken("");
            Assert.IsNotNull(result);
        }



        public static void temp()
        {
            ApigeeClient apiClient = new ApigeeClient("http://api.usergrid.com/xxx/sandbox/");

            //Get a collection of all users 
            var allUsers = apiClient.GetUsers();

            string un = "apigee_" + Guid.NewGuid();

            //Create a new Account
            apiClient.CreateAccount(new ApigeeUserModel
            {
                Username = un,
                Password = "abc123",
                Email = un + "@sympletech.com"
            });

            //Update an Existing Account
            apiClient.UpdateAccount(new ApigeeUserModel
            {
                Username = un,
                Password = "abc123456",
                Email = un + "@sympletech.com"
            });

            //Login User - Get Token 
            var token = apiClient.GetToken(un, "abc123456");

            //Lookup a user by token ID
            var username = apiClient.LookUpToken(token);
        }
    }
}
