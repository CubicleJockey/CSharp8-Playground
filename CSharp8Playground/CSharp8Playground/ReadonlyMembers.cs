using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp8Playground
{
    /// <summary>
    /// 'readonly' can be applied to the members of a struct.
    /// A readonly struct member indicates that it does not modify state.
    /// </summary>
    [TestClass]
    public class ReadonlyMembers
    {
        [TestMethod]
        public void CallingAReadonlyStructMember()
        {
            var playerLocation = new Point
            {
                X = 45,
                Y = -32.5
            };

            playerLocation.Distance.Should().Be(55.509008277936296);
            playerLocation.ToString().Should().Be("(45, -32.5) is 55.509008277936296 from the origin.");
        }
        
        /// <summary>
        /// Struct that contains, new readonly members.
        /// </summary>
        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            #region Readonly Members

            public readonly double Distance => Math.Sqrt(X * X + Y * Y);

            //Distance must also be readonly or a warning is presented.
            public override readonly string ToString() => $"({X}, {Y}) is {Distance} from the origin."; 

            #endregion Readonly Members

            //Compiler enforces the readonly rule. This will not compile unless
            //readonly is removed from the method signature.
            public /*readonly*/ void Translate(int xOffSet, int yOffSet)
            {
                X += xOffSet;
                Y += yOffSet;
            }
        }

    }
}
