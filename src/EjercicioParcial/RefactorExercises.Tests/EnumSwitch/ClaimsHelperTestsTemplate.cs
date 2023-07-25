using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.Tests.EnumSwitch
{
    public abstract class ClaimsHelperTestsTemplate
    {
        private readonly string _userId = "UserId01";

        public abstract IClaimsHelper GetClaimsHelper(User user);

        [TestMethod]
        public void UserWithReadPermission_WhenAskForClaims_ThenReturnsRead()
        {
            var permissions = Permission.Read;
            var result = GetClaimsForUser(permissions);
            result.Should().Contain("Read");
        }

        [TestMethod]
        public void UserWithReadPermission_WhenAskForClaims_ThenDoesNotReturnWriteOrDelete()
        {
            var permissions = Permission.Read;
            var result = GetClaimsForUser(permissions);
            result.Should().NotContain("Write")
                .And.NotContain("Delete");
        }

        [TestMethod]
        public void UserWithWritePermission_WhenAskForClaims_ThenReturnsWrite()
        {
            var permissions = Permission.Write;
            var result = GetClaimsForUser(permissions);
            result.Should().Contain("Write");
        }

        [TestMethod]
        public void UserWithWritePermission_WhenAskForClaims_ThenDoesNotReturnReadOrDelete()
        {
            var permissions = Permission.Write;
            var result = GetClaimsForUser(permissions);
            result.Should().NotContain("Read")
                .And.NotContain("Delete");
        }

        [TestMethod]
        public void UserWithDeletePermission_WhenAskForClaims_ThenReturnsDelete()
        {
            var permissions = Permission.Delete;
            var result = GetClaimsForUser(permissions);
            result.Should().Contain("Delete");
        }

        [TestMethod]
        public void UserWithDeletePermission_WhenAskForClaims_ThenDoesNotReturnReadOrWrite()
        {
            var permissions = Permission.Delete;
            var result = GetClaimsForUser(permissions);
            result.Should().NotContain("Read")
                .And.NotContain("Write");
        }

        [TestMethod]
        public void UserWithReadWritePermission_WhenAskForClaims_ThenReturnsReadWrite()
        {
            var permissions = new[] { Permission.Read, Permission.Write };
            var result = GetClaimsForUser(permissions.ToFlagsEnum());
            result.Should().Contain("Read")
                .And.Contain("Write");
        }

        [TestMethod]
        public void UserWithReadWritePermission_WhenAskForClaims_ThenDoesNotReturnDelete()
        {
            var permissions = new[] { Permission.Read, Permission.Write };
            var result = GetClaimsForUser(permissions.ToFlagsEnum());
            result.Should().NotContain("Delete");
        }

        [TestMethod]
        public void UserWithReadWriteDeletePermission_WhenAskForClaims_ThenReturnsReadWriteDelete()
        {
            var permissions = new[] { Permission.Read, Permission.Write, Permission.Delete };
            var result = GetClaimsForUser(permissions.ToFlagsEnum());
            result.Should().Contain("Read")
                .And.Contain("Write")
                .And.Contain("Delete");
        }

        private string GetClaimsForUser(Permission claims)
        {
            var user = GetUser(claims);
            var claimsHelper = GetClaimsHelper(user);
            return claimsHelper.GetClaimsForUser();
        }

        protected virtual User GetUser(Permission claims)
        {
            return new User()
            {
                Id = _userId,
                Permissions = claims
            };
        }
    }
}
