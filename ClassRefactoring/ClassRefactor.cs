using System;

namespace DeveloperSample.ClassRefactoring
{
    // Enum for swallow types
    public enum SwallowType
    {
        African, European
    }

    // Enum for swallow loads
    public enum SwallowLoad
    {
        None, Coconut
    }

    // Interface for Airspeed Strategy
    public interface IAirspeedStrategy
    {
        double GetAirspeed(SwallowLoad load);
    }

    // Strategy for African Swallow
    public class AfricanSwallowAirspeedStrategy : IAirspeedStrategy
    {
        public double GetAirspeed(SwallowLoad load)
        {
            switch (load)
            {
                case SwallowLoad.None:
                    return 22;
                case SwallowLoad.Coconut:
                    return 18;
                default:
                    throw new InvalidOperationException("Invalid load for African Swallow.");
            }
        }
    }

    // Strategy for European Swallow
    public class EuropeanSwallowAirspeedStrategy : IAirspeedStrategy
    {
        public double GetAirspeed(SwallowLoad load)
        {
            switch (load)
            {
                case SwallowLoad.None:
                    return 20;
                case SwallowLoad.Coconut:
                    return 16;
                default:
                    throw new InvalidOperationException("Invalid load for European Swallow.");
            }
        }
    }

    // Swallow class
    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }
        private readonly IAirspeedStrategy _airspeedStrategy;

        // Constructor
        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;

            // Assign strategy based on swallow type
            _airspeedStrategy = swallowType switch
            {
                SwallowType.African => new AfricanSwallowAirspeedStrategy(),
                SwallowType.European => new EuropeanSwallowAirspeedStrategy(),
                _ => throw new ArgumentException("Unknown swallow type")
            };
        }

        // Apply load
        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        // Get airspeed velocity using strategy
        public double GetAirspeedVelocity()
        {
            return _airspeedStrategy.GetAirspeed(Load);
        }
    }

    // Swallow factory to produce swallows
    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }
}
