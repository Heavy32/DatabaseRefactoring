using System;
using System.Collections.Generic;

namespace DatabaseRefactoring.DataBase.Builder
{
    public class InjectionFactDataPropertyFiller : IModelPropertyFiller<InjectionFactData>
    {
        public void FillProperty(KeyValuePair<int, object> propertyIdValue, ref InjectionFactData model)
        {
            switch (propertyIdValue.Key)
            {
                case 1:
                    model.Value1 = Convert.ToInt32(propertyIdValue.Value);
                    break;
                case 2: 
                    model.Value2 = Convert.ToInt32(propertyIdValue.Value);
                    break;      
                case 3: 
                    model.Value3 = Convert.ToInt32(propertyIdValue.Value);
                    break;  
                case 4:     
                    model.Value4 = Convert.ToInt32(propertyIdValue.Value);
                    break;  
                case 5:
                    model.Value5 = Convert.ToInt32(propertyIdValue.Value);                       
                    break;
                case 6:
                    model.Value6 = Convert.ToInt32(propertyIdValue.Value);   
                    break;
                case 7:
                    model.Value7 = Convert.ToInt32(propertyIdValue.Value);
                    break;
                case 8:
                    model.Value8 = Convert.ToInt32(propertyIdValue.Value);
                    break;
                case 9:
                    model.Value9 = Convert.ToInt32(propertyIdValue.Value);
                    break;
                default:
                    break;
            }
        }
    }
}
