using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainPropertyMatcher.Interfaces;
using DomainPropertyMatcher.Entities;
using DomainPropertyMatcher.Matchers;
using DomainPropertyMatcher.Utilities;

namespace DomainPropertyMatcher.Test
{
    [TestClass]
    public class DomainPropertyMatcherUnitTest
    {
        static IPropertyMatcher propertyMatcher;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            propertyMatcher = new PropertyMatcher();
        }

        [TestMethod]
        public void Given_OTBREProperty_AND_BothPropertyNameAndAddressMatch_with_PunctuationRemoved_There_ShouldBe_A_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "OTBRE";
            agencyProperty.Name = "*Super*-High! APARTMENTS (Sydney)";
            agencyProperty.Address = "32 Sir John-Young Crescent, Sydney, NSW.";

            databaseProperty.AgencyCode = "OTBRE";
            databaseProperty.Name = "Super High Apartments, Sydney";
            databaseProperty.Address = "32 Sir John Young Crescent, Sydney NSW";

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(match);
        }

        [TestMethod]
        public void Given_OTBREProperty_But_OnlyhPropertyNameMatches_with_PunctuationRemoved_There_ShouldBe_NO_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "OTBRE";
            agencyProperty.Name = "*Super*-High! APARTMENTS (Sydney)";
            agencyProperty.Address = "32 Sir John-Young Crescent, Sydney, NSW.";

            databaseProperty.AgencyCode = "OTBRE";
            databaseProperty.Name = "Super High Apartments, Sydney";
            databaseProperty.Address = "123 Sir John Old Crescent, Sydney NSW";

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_OTBREProperty_But_OnlyhPropertyAddressMatches_with_PunctuationRemoved_There_ShouldBe_NO_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "OTBRE";
            agencyProperty.Name = "*Super*-High! APARTMENTS (Sydney)";
            agencyProperty.Address = "32 Sir John-Young Crescent, Sydney, NSW.";

            databaseProperty.AgencyCode = "OTBRE";
            databaseProperty.Name = "Super Low Apartments, Sydney";
            databaseProperty.Address = "32 Sir John Young Crescent, Sydney NSW";

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_PropertyIsNOT_OTBRE_But_BothPropertyNameAndAddressMatch_with_PunctuationRemoved_There_ShouldBe_No_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "CRE";
            agencyProperty.Name = "*Super*-High! APARTMENTS (Sydney)";
            agencyProperty.Address = "32 Sir John-Young Crescent, Sydney, NSW.";

            databaseProperty.AgencyCode = "CRE";
            databaseProperty.Name = "Super High Apartments, Sydney";
            databaseProperty.Address = "32 Sir John Young Crescent, Sydney NSW";

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_LREProperty_WithSame_LocationAs_databaseProperty_There_ShouldBe_A_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "LRE";

            agencyProperty.Latitude = 49.4833270M;
            agencyProperty.Longitude = 8.4748935M;

            databaseProperty.AgencyCode = "LRE";
            databaseProperty.Latitude = 49.4833270M;
            databaseProperty.Longitude = 8.4748935M;

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(match);
        }

        [TestMethod]
        public void Given_LREProperty_Within_200MetersOf_databaseProperty_There_ShouldBe_A_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "LRE";

            agencyProperty.Latitude = 49.4833270M;
            agencyProperty.Longitude = 8.4748935M;

            databaseProperty.AgencyCode = "LRE";
            databaseProperty.Latitude = 49.4833200M;
            databaseProperty.Longitude = 8.4748535M;

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(match);
        }

        [TestMethod]
        public void Given_LREProperty_WithDistanceMorethan_200MetersOf_databaseProperty_There_ShouldBe_No_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "LRE";

            agencyProperty.Latitude = 49.4833270M;
            agencyProperty.Longitude = 8.4748935M;

            databaseProperty.AgencyCode = "LRE";
            databaseProperty.Latitude = 49.4833200M;
            databaseProperty.Longitude = 8.4348535M;

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_PropertyIsNOT_LRE_ButWithin_200MetersOf_databaseProperty_There_ShouldBe_No_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "CRE";

            agencyProperty.Latitude = 49.4833270M;
            agencyProperty.Longitude = 8.4748935M;

            databaseProperty.AgencyCode = "LRE";
            databaseProperty.Latitude = 49.4833200M;
            databaseProperty.Longitude = 8.4748535M;

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_CREProperty_AND_NameMatches_when_Reversed_There_ShouldBe_A_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "CRE";
            agencyProperty.Name = "Apartments Summit The";

            databaseProperty.AgencyCode = "CRE";
            databaseProperty.Name = "The Summit Apartments";

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsTrue(match);
        }

        [TestMethod]
        public void Given_CREProperty_But_Name_Doesnot_Match_when_Reversed_There_ShouldBe_No_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "CRE";
            agencyProperty.Name = "Apartments Summit The";

            databaseProperty.AgencyCode = "CRE";
            databaseProperty.Name = "The Lummit Apartments";

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_PropertyIsNOT_CRE_But_NameMatches_when_Reversed_There_ShouldBe_No_Match()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "OTBRE";
            agencyProperty.Name = "Apartments Summit The";

            databaseProperty.AgencyCode = "OTBRE";
            databaseProperty.Name = "The Summit Apartments";

            bool match = propertyMatcher.IsMatch(agencyProperty, databaseProperty);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_NullProperties_There_ShouldBe_No_Match()
        {
            bool match = propertyMatcher.IsMatch(null, null);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_AgencyProperty_But_NullDatabaseProperty_There_ShouldBe_No_Match()
        {
            bool match = propertyMatcher.IsMatch(new Property(), null);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_DatabaseProperty_But_NullAgencyProperty_There_ShouldBe_No_Match()
        {
            bool match = propertyMatcher.IsMatch(null, new Property());

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void Given_AgencyProperty_with_NullAgencyCode_There_ShouldBe_No_Match()
        {
            bool match = propertyMatcher.IsMatch(new Property(), new Property());

            Assert.IsFalse(match);
        }

        [TestMethod]
        [ExpectedException(typeof(AgencyMatcherNotFoundException))]
        public void Given_AgencyProperty_AND_AgencyCode_Is_Not_CRE_OR_LRE_OR_OTBRE_There_ShouldBe_AgencyMatcherNotFoundException()
        {
            Property agencyProperty = new Property();
            Property databaseProperty = new Property();

            agencyProperty.AgencyCode = "NEW";
            agencyProperty.Name = "Apartments Summit The";

            databaseProperty.AgencyCode = "CRE";
            databaseProperty.Name = "The Lummit Apartments";

            propertyMatcher.IsMatch(agencyProperty, databaseProperty);
        }
    }
}
