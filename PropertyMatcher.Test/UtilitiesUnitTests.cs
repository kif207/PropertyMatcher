using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainPropertyMatcher.Utilities.Extensions;

namespace DomainPropertyMatcher.Test
{
    /// <summary>
    /// Summary description for UtilitiesUnitTests
    /// </summary>
    [TestClass]
    public class UtilitiesUnitTests
    {

        [TestMethod]
        public void StringExtension_RemovePunctuations_Should_RemovePunctuations_from_string()
        {
            string name = "*Super*-High! APARTMENTS (Sydney)";
            Assert.AreEqual("SuperHighAPARTMENTSSydney", name.RemovePunctuations());
        }

        [TestMethod]
        public void StringExtension_Reverse_Should_Reverse_the_string()
        {
            string name = "Apartments Summit The";
            Assert.AreEqual("The Summit Apartments", name.Reverse());
        }
    }
}
