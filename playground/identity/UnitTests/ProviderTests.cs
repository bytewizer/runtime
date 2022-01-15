using System;
using System.Diagnostics;

using Bytewizer.TinyCLR.Identity;
using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Identity
{
    public class ProviderTests : TestFixture
    {
        private static IdentityProvider _identityProvider;

        public ProviderTests()
        {
            _identityProvider = new IdentityProvider();
            _identityProvider.StoreChanged += StoreChanged;
        }

        private void StoreChanged(object sender)
        {
            var storage = (IdentityProvider)sender;

            Debug.WriteLine(storage.Users.Count.ToString());
        }

        public void CreateProvider()
        {
            var provider = new IdentityProvider();
            Assert.NotZero(provider.PasswordValidators.Count);
            Assert.NotZero(provider.UserValidators.Count);
            Assert.Zero(provider.Users.Count);
        }

        public void CreateUser()
        {
            var username = "b.smith";
            var user = new IdentityUser(username);

            var password = "password";
            var results = _identityProvider.Create(user, password);
            Assert.True(results.Succeeded);

            var expected = _identityProvider.FindByName(username);
            Assert.AreEqual(expected, user);

            _identityProvider.Users.Clear();
        }

        public void CreateUserWithInvalidNamePasswordLength()
        {
            var username = "b";
            var user = new IdentityUser(username);

            var password = "p";
            var results = _identityProvider.Create(user, password);
            Assert.False(results.Succeeded);

            foreach (Exception error in results.Errors)
            {
                Debug.WriteLine(error.Message);
            }

            _identityProvider.Users.Clear();
        }

        public void CheckUserPassword()
        {
            var username = "y.parker";

            var user = new IdentityUser(username);
            var password = "goodpassword";

            var results1 = _identityProvider.Create(user, "badpassword");
            Assert.True(results1.Succeeded);

            var condition = _identityProvider.CheckPassword(user, password);
            Assert.False(condition);

            var results2 = _identityProvider.UpdatePassword(user, "toshort");
            Assert.False(results2.Succeeded);

            foreach (Exception error in results2.Errors)
            {
                Debug.WriteLine(error.Message);
            }

            _identityProvider.Users.Clear();
        }

        public void UpdateUserPassword()
        {
            var username = "w.parker";

            var user = new IdentityUser(username);
            var password = "goodpassword";

            var results1 = _identityProvider.Create(user, password);
            Assert.True(results1.Succeeded);

            var condition = _identityProvider.CheckPassword(user, password);
            Assert.True(condition);

            var results2 = _identityProvider.UpdatePassword(user, "newpassword");
            Assert.True(results2.Succeeded);

            var results3 = _identityProvider.UpdatePassword(user, "toshort");
            Assert.False(results3.Succeeded);

            foreach (Exception error in results3.Errors)
            {
                Debug.WriteLine(error.Message);
            }

            var results4 = _identityProvider.VerifyPassword(user, "newpassword");
            Assert.True(results4.Succeeded);

            _identityProvider.Users.Clear();
        }

        public void CreateCustomUser()
        {
            var username = "b.smith";
            var user = new User(username, "Bob", "Smith");

            var password = "password";
            var results1 = _identityProvider.Create(user, password);
            Assert.True(results1.Succeeded);

            var expected = (User)_identityProvider.FindByName(username);
            Assert.AreEqual(expected, user);

            var results2 = _identityProvider.VerifyPassword(user, password);
            Assert.True(results2.Succeeded);

            _identityProvider.Users.Clear();
        }

        public class User : IIdentityUser
        {
            public User(string name, string firstName, string lastName)
            {
                Id = DateTime.Now.Ticks.ToString();
                UserName = name;    
                FirstName = firstName;
                LastName = lastName;
            }

            public string Id { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public byte[] PasswordHash { get; set; }
            public byte[] PasswordSalt { get; set; }
            public object Metadata { get; set; }
        }
    }
}