  using System;

    using System.Reflection;
    using System.Linq;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var classInstance = Type.GetType(unitType);
            var instancedClass = Activator.CreateInstance(classInstance);
            return (IUnit)instancedClass;
        }
    }

