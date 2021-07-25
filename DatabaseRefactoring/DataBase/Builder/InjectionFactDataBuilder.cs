using System;
using System.Collections.Generic;

namespace DatabaseRefactoring.DataBase.Builder
{
    public class InjectionFactDataBuilder : IBuilder<InjectionFactData, KeyValuePair<DateTime, Dictionary<int, object>>>
    {
        private readonly IModelPropertyFiller<InjectionFactData> modelPropertyFiller;

        public InjectionFactDataBuilder(IModelPropertyFiller<InjectionFactData> modelPropertyFiller)
        {
            this.modelPropertyFiller = modelPropertyFiller;
        }

        public InjectionFactData Build(KeyValuePair<DateTime, Dictionary<int, object>> source)
        {
            InjectionFactData model = new() { Date = source.Key };

            foreach (var propertyIdValue in source.Value)
            {
                modelPropertyFiller.FillProperty(propertyIdValue, ref model);
            }

            return model;
        }
    }
}
