using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercises.EnumSwitch.Model;
using RefactorExercises.EnumSwitch.Refactored.V07;
using System.Collections.Generic;
using OriginalClaimsHelper = RefactorExercises.EnumSwitch.Original.ClaimsHelper;
using RefactoredV01ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V01.ClaimsHelper;
using RefactoredV02ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V02.ClaimsHelper;
using RefactoredV03ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V03.ClaimsHelper;
using RefactoredV04ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V04.ClaimsHelper;
using RefactoredV05ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V05.ClaimsHelper;
using RefactoredV06ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V06.ClaimsHelper;
using RefactoredV07ClaimsHelper = RefactorExercises.EnumSwitch.Refactored.V07.ClaimsHelper;

namespace RefactorExercises.Tests.EnumSwitch
{
    [TestClass]
    public class ClaimsHelperTestsOriginal : ClaimsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new OriginalClaimsHelper(user);
        }
    }

    [TestClass]
    public class ClaimsHelperTestsRefactoredV01 : ClaimsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV01ClaimsHelper(user);
        }
    }

    [TestClass]
    public class ClaimsHelperTestsRefactoredV02 : ClaimsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV02ClaimsHelper(user);
        }
    }

    [TestClass]
    public class ClaimsHelperTestsRefactoredV03 : ClaimsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV03ClaimsHelper(user);
        }
    }

    [TestClass]
    public class ClaimsHelperTestsRefactoredV04 : ClaimsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV04ClaimsHelper(user);
        }
    }

    [TestClass]
    public class ClaimsHelperTestsRefactoredV05 : ClaimsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV05ClaimsHelper(user);
        }
    }

    [TestClass]
    public class ClaimsHelperTestsRefactoredV06 : ClaimsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV06ClaimsHelper(user);
        }
    }

    [TestClass]
    public class ClaimsHelperTestsRefactoredV07 : ClaimsHelperTestsTemplate
    {
        public override IClaimsHelper GetClaimsHelper(User user)
        {
            return new RefactoredV07ClaimsHelper(user as SmartUser);
        }

        protected override User GetUser(Permission claims)
        {
            var originalUser = base.GetUser(claims);
            return new SmartUser()
            {
                Id = originalUser.Id,
                SmartPermissions = GetConvertedPermissions(claims)
            };
        }

        private static IEnumerable<SmartPermission> GetConvertedPermissions(Permission claims)
        {
            foreach (var claim in claims.ToEnumerable())
            {
                yield return SmartPermission.FromValue((int)claim);
            }
        }
    }
}
