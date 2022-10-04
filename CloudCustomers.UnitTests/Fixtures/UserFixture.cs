using System;
using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UserFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Name= "Test User 1",
                    Email = "test1.@juniorDev.com",
                    Address = new Address
                    {
                        Street = "123 test st",
                        City = "Somewhere",
                        Zipcode = 12345,

                    }
                },new User
                {
                    Name= "Test User 2",
                    Email = "test2.@juniorDev.com",
                    Address = new Address
                    {
                        Street = "213 test rd",
                        City = "Someway",
                        Zipcode = 54321,

                    }
                },new User
                {
                    Name= "Test User 3",
                    Email = "test3.@juniorDev.net",
                    Address = new Address
                    {
                        Street = "321 test blvd",
                        City = "Somehow",
                        Zipcode = 10293,

                    }
                },
            };

    }
}

