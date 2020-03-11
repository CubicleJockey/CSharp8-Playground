using System.Runtime.InteropServices.ComTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp8Playground
{
    [TestClass]
    public class Patterns
    {
        [TestMethod]
        public void SwitchExpressions()
        {
            var goodPerson = PersonFactory(Alignment.Good);
            goodPerson.Alignment.Should().Be(Alignment.Good);

            var evilPerson = PersonFactory(Alignment.Evil);
            evilPerson.Alignment.Should().Be(Alignment.Evil);

            var neutralPerson = PersonFactory(Alignment.Neutral);
            neutralPerson.Alignment.Should().Be(Alignment.Neutral);
        }


        /// <summary>
        /// Switch expressions enable you to use more concise expression syntax.
        /// There are fewer repetitive case and break keywords, and fewer curly braces.
        /// As an example, consider the following enum that lists the colors of the rainbow:
        /// </summary>
        public static Person PersonFactory(Alignment alignment) =>
            alignment switch
            {
                Alignment.Good    => new Person(Alignment.Good),
                Alignment.Evil    => new Person(Alignment.Evil),
                Alignment.Neutral => new Person(Alignment.Neutral),
                _                 => new Person(Alignment.Unknown)
            };


        #region Helpers

        public enum Alignment
        {
            Good,
            Evil,
            Neutral,
            Unknown
        }

        public class Person
        {
            public Alignment Alignment { get; }

            public Person(Alignment alignment)
            {
                Alignment = alignment;
            }
        }

        #endregion Helpers
    }
}
