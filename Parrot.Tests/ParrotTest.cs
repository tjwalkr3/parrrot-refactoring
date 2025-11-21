using Xunit;

namespace Parrot.Tests
{
    // MAINTENANCE EXERCISE: Several tests in this file are failing due to bugs in the Parrot class.
    // Your task is to:
    // 1. Run the tests and identify which ones are failing
    // 2. Find and fix the bugs in Parrot.cs
    // 3. Consider the refactoring suggestions to improve the code design
    public class ParrotTest
    {
        [Fact]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 0, true);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_nailed_with_voltage()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 1.5, true);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 1.5, false);
            Assert.Equal(18.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 4, false);
            Assert.Equal(24.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            var parrot = new Parrot(ParrotTypeEnum.AFRICAN, 0, 0, false);
            Assert.Equal(12.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            var parrot = new Parrot(ParrotTypeEnum.AFRICAN, 1, 0, false);
            Assert.Equal(7.5, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            var parrot = new Parrot(ParrotTypeEnum.AFRICAN, 2, 0, false);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfEuropeanParrot()
        {
            var parrot = new Parrot(ParrotTypeEnum.EUROPEAN, 0, 0, false);
            Assert.Equal(12.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetCryOfEuropeanParrot()
        {
            var parrot = new Parrot(ParrotTypeEnum.EUROPEAN, 0, 0, false);
            Assert.Equal("Sqoork!", parrot.GetCry());
        }

        [Fact]
        public void GetCryOfAfricanParrot()
        {
            var parrot = new Parrot(ParrotTypeEnum.AFRICAN, 2, 0, false);
            Assert.Equal("Sqaark!", parrot.GetCry());
        }

        [Fact]
        public void GetCryNorwegianBlueParrot_high_voltage()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 4, false);
            Assert.Equal("Bzzzzzz", parrot.GetCry());
        }

        [Fact]
        public void GetCryNorwegianBlueParrot_no_voltage()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 0, false);
            Assert.Equal("...", parrot.GetCry());
        }

        // ===== FAILING TESTS BELOW - These expose bugs in the implementation =====

        [Fact]
        public void GetSpeedOfAfricanParrot_With_Three_Coconuts()
        {
            var parrot = new Parrot(ParrotTypeEnum.AFRICAN, 3, 0, false);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_voltage_2_should_be_22()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 2.0, false);
            Assert.Equal(22.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetCryOfAfricanParrot_Without_Coconuts()
        {
            var parrot = new Parrot(ParrotTypeEnum.AFRICAN, 0, 0, false);
            Assert.Equal("Sqoork!", parrot.GetCry());
        }

        [Fact]
        public void GetCryOfNailedNorwegianBlueParrot()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 4, true);
            Assert.Equal("", parrot.GetCry());
        }

        [Fact]
        public void GetCryOfAfricanParrot_With_Coconuts()
        {
            var parrot = new Parrot(ParrotTypeEnum.AFRICAN, 1, 0, false);
            Assert.Equal("Sqaark!", parrot.GetCry());
        }
    }
}