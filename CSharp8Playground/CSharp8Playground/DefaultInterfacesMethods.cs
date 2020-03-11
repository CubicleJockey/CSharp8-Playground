using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp8Playground
{
    [TestClass]
    public class DefaultInterfacesMethods
    {
        [TestMethod]
        public void InheritedDefaultMethod()
        {
            IVehicle car = new Car("Toyota Highlander", 4);
            car.CurrentMph.Should().Be(0);
            
            car.IncrementCurrentMph(); //<----IncrementCurrentMph was defined as a default method in IVehicle
            car.CurrentMph.Should().Be(1);
            
            car.IncrementCurrentMph(15);
            car.CurrentMph.Should().Be(16);
        }
        
    }

    public interface IVehicle
    {
        string Name { get; }
        int NumberOfWheels { get; }
        int CurrentMph { get; set; }

        //Introducing default methods to interfaces
        void IncrementCurrentMph(int increase = 1)
        {
            CurrentMph += increase;
        }
    }
    
    /// <summary>
    /// Inherits from IVehicle, which defines a default method IncrementCurrentMph
    /// </summary>
    public class Car : IVehicle
    {
        #region Implementation of IVehicle

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public int NumberOfWheels { get; }

        /// <inheritdoc />
        public int CurrentMph { get; set; }

        #endregion

        public Car(string name, int numberOfWheels)
        {
            if(string.IsNullOrWhiteSpace(name)) { throw new ArgumentException(nameof(name)); }
            Name = name;
            NumberOfWheels = numberOfWheels;
        }
    }
}
