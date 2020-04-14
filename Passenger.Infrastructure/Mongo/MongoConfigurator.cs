using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Passenger.Infrastructure.Mongo
{
    public static class MongoConfigurator
    {
        private static bool _initialized;

        public static void Initialize()
        {
            if(_initialized)
            {
                return;
            }
            
            _initialized = true;
        }

        private static void RegisterConfigurations()
        {
            ConventionRegistry.Register("PassengerConventions", new MongoConvention(), x => true);
        }

        private class MongoConvention : IConventionPack
        {

            IEnumerable<IConvention> IConventionPack.Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}