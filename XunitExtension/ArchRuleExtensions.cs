﻿using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;

// ReSharper disable once CheckNamespace
namespace Xunit
{
    public static class ArchRuleExtensions
    {
        /// <summary>
        ///     Verifies that the architecture meets the criteria of the archrule.
        /// </summary>
        /// <param name="archRule">The rule to test the architecture with</param>
        /// <param name="architecture">The architecture to be tested</param>
        public static void Check(this IArchRule archRule, Architecture architecture)
        {
            Assert.ArchRule(architecture, archRule);
        }

        /// <summary>
        ///     Verifies that the architecture meets the criteria of the archrule.
        /// </summary>
        /// <param name="architecture">The architecture to be tested</param>
        /// <param name="archRule">The rule to test the architecture with</param>
        public static void CheckRule(this Architecture architecture, IArchRule archRule)
        {
            Assert.ArchRule(architecture, archRule);
        }
    }
}