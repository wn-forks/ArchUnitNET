/*
 * Copyright 2019 TNG Technology Consulting GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Linq;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNETTests.Dependencies.Attributes;
using ArchUnitNETTests.Dependencies.Members;
using Xunit;

namespace ArchUnitNETTests.Fluent
{
    public class TypeExtensionTests
    {
        private static readonly Architecture Architecture = StaticTestArchitectures.ArchUnitCsTestArchitecture;
        private readonly Class _methodOriginClass;
        private readonly IMember _methodMember;
        private readonly Class _fieldOriginClass;
        private readonly IMember _fieldMember;
        private readonly Class _propertyOriginClass;
        private readonly IMember _propertyMember;

        private readonly Class _exampleAttribute;

        private const string ExpectedAttributeNamespace =
            StaticConstants.ArchUnitCsTestsDependenciesAttributesNamespace;

        private readonly Class _regexUtilsTests;
        private const string ExpectedRegexUtilsTestNamespace = StaticConstants.ArchUnitCsTestsFluentNamespace;

        public TypeExtensionTests()
        {
            _methodOriginClass = Architecture.GetClassOfType(typeof(ClassWithMethodA));
            _methodMember = _methodOriginClass
                .GetMembersWithName(nameof(ClassWithMethodA.MethodA).BuildMethodMemberName()).SingleOrDefault();
            _fieldOriginClass = Architecture.GetClassOfType(typeof(ClassWithFieldA));
            _fieldMember = _fieldOriginClass.GetMembersWithName(nameof(ClassWithFieldA.FieldA)).SingleOrDefault();
            _propertyOriginClass = Architecture.GetClassOfType(typeof(ClassWithPropertyA));
            _propertyMember = _propertyOriginClass.GetMembersWithName(nameof(ClassWithPropertyA.PropertyA))
                .SingleOrDefault();

            _exampleAttribute = Architecture.GetClassOfType(typeof(ExampleAttribute));
            _regexUtilsTests = Architecture.GetClassOfType(typeof(RegexUtilsTest));
        }

        [Fact]
        public void MethodMemberFoundFromMembers()
        {
            Assert.True(_methodMember is MethodMember);
            Assert.NotNull(_methodOriginClass.Members[_methodMember.Name]);
        }

        [Fact]
        public void FieldMemberFoundFromMembers()
        {
            Assert.True(_fieldMember is FieldMember);
            Assert.NotNull(_fieldOriginClass.Members[_fieldMember.Name]);
        }
        
        [Fact]
        public void PropertyMemberFoundFromMembers()
        {
            Assert.True(_propertyMember is PropertyMember);
            Assert.NotNull(_propertyOriginClass.Members[_propertyMember.Name]);
        }

        [Fact]
        public void NamespaceMatchAsExpected()
        {
            Assert.True(_exampleAttribute.ResidesInNamespace(ExpectedAttributeNamespace));
            Assert.True(_regexUtilsTests.ResidesInNamespace(ExpectedRegexUtilsTestNamespace));
            Assert.True(_exampleAttribute.ResidesInNamespace(string.Empty));
        }
    }
}