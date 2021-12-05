using System;

using Bytewizer.TinyCLR.Identity;
using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Identity
{
    public class UserStoreTests : TestFixture
    {
        private static UserStore _userStore;

        public UserStoreTests()
        {
            _userStore = new UserStore();
        }

        public void CreateUser()
        {
            var username = "bsmith";
            var user = new IdentityUser(username);

            var results = _userStore.Create(user);
            Assert.True(results.Succeeded);

            var expected = _userStore.FindByName(username);

            Assert.AreEqual(expected, user);
        }

        public void DeleteUser()
        {
            var username = "ksmith";
            var user = new IdentityUser(username);

            var results1 = _userStore.Create(user);
            Assert.True(results1.Succeeded);

            var results2 = _userStore.Delete(new IdentityUser("badname"));
            Assert.False(results2.Succeeded);

            var results3 = _userStore.Delete(user);
            Assert.True(results3.Succeeded);

            var expected = _userStore.FindByName(username);
            Assert.IsNull(expected);
        }

        public void ClearUsers()
        {
            var name1 = "kwalker";
            var user1 = new IdentityUser(name1);

            var results1 = _userStore.Create(user1);
            Assert.True(results1.Succeeded);

            var name2 = "g.walker";
            var user2 = new IdentityUser(name2);

            var results2 = _userStore.Create(user2);
            Assert.True(results2.Succeeded);

            Assert.NotZero(_userStore.Users.Count);
            _userStore.Clear();
            Assert.Zero(_userStore.Users.Count);
        }

        public void TryGetUser()
        {
            var name = "kwalker";
            var user = new IdentityUser(name);

            var results = _userStore.Create(user);
            Assert.True(results.Succeeded);

            var expected1 = _userStore.TryGetUser(name, out IIdentityUser user1);
            Assert.True(expected1);
            Assert.IsNotNull(user1);

            var expected2 = _userStore.TryGetUser("baduser", out IIdentityUser user2);
            Assert.False(expected2);
            Assert.IsNull(user2);
        }

        public void FindUserByName()
        {
            var username = "kparker";
            var user = new IdentityUser(username);

            var results = _userStore.Create(user);
            Assert.True(results.Succeeded);

            var expected1 = _userStore.FindByName(username);
            Assert.AreEqual(expected1, user);

            var expected2 = _userStore.FindByName(username + "21");
            Assert.IsNull(expected2);
        }

        public void FindUserById()
        {
            var user = new IdentityUser("markkent");

            var results = _userStore.Create(user);
            Assert.True(results.Succeeded);

            var expected1 = _userStore.FindById(user.Id);
            Assert.AreEqual(expected1, user);

            var expected2 = _userStore.FindById(user.Id + "21");
            Assert.IsNull(expected2);
        }
    }
}