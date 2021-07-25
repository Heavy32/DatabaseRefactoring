using System.Collections.Generic;

namespace DatabaseRefactoring.DataBase.Builder
{
    public interface IModelPropertyFiller<TModel>
    {
        public void FillProperty(KeyValuePair<int, object> propertyIdValue, ref TModel model);
    }
}
