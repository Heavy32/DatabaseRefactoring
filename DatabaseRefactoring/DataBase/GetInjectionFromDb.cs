using DatabaseRefactoring.DataBase.Builder;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DatabaseRefactoring.DataBase
{
    public class GetInjectionFromDb : IDataBaseOperation<ICollection<InjectionFactData>, InjectionInputParametesModel, SqlConnection>
    {
        private readonly IBuilder<InjectionFactData, KeyValuePair<DateTime, Dictionary<int, object>>> builder;

        public GetInjectionFromDb(IBuilder<InjectionFactData, KeyValuePair<DateTime, Dictionary<int, object>>> builder)
        {
            this.builder = builder;
        }

        public ICollection<InjectionFactData> Execute(InjectionInputParametesModel parameters, SqlConnection connection)
        {
            var injectionFactData = new Dictionary<int, Dictionary<DateTime, Dictionary<int, object>>>();
            var monthData = new Dictionary<DateTime, Dictionary<int, object>>();
            using (connection)
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select * from Things.dbo.InjectionFactValue";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int measureId = Convert.ToInt32(reader["MeasureId"]);
                            object factValue = reader["FactValue"];
                            int planningObject = Convert.ToInt32(reader["PlanningObject"]);
                            DateTime date = Convert.ToDateTime(reader["Date"]);

                            if (!injectionFactData.ContainsKey(planningObject))
                            {
                                injectionFactData.Add(planningObject, new Dictionary<DateTime, Dictionary<int, object>>());
                            }

                            if (!injectionFactData[planningObject].ContainsKey(date))
                            {
                                injectionFactData[planningObject].Add(date, new Dictionary<int, object>());
                            }

                            injectionFactData[planningObject][date].Add(measureId, factValue);
                        }
                    }
                }
            }

            List<InjectionFactData> facts = new List<InjectionFactData>();
            foreach (var month in injectionFactData[254])
            {
                facts.Add(builder.Build(month));
            }
            return facts;
        }
    }
}
