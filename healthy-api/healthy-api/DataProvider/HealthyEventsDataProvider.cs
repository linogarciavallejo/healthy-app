﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using healthy_api.Models;

namespace healthy_api.DataProvider
{
    public class HealthyEventsDataProvider : IHealthyEventsDataProvider
    {
        private readonly string connectionString = "Server=localhost;Database=Healthy;MultipleActiveResultSets=true;User ID=sa;Password=CanisMajoris19";

        private SqlConnection sqlConnection;

        //Get the events log for by User Id
        public async Task<IEnumerable<HealthyEvent>> GetEventsLog(int UserId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", UserId);
                /*string sql = "SELECT Logged, et.Name AS EventType, Milliliters, WalkingDistance, TimeElapsed, Calories, Score ";
                sql += " FROM [Healthy_Events] he ";
                sql += " JOIN [Event_Types] et ON he.EventTypeId = et.EventTypeId ";
                sql += " WHERE UserId = @UserId ORDER BY [Logged] DESC";
                string sql2 = "SELECT Logged, et.Name AS EventType, Milliliters, WalkingDistance, TimeElapsed, Calories, Score  FROM [Healthy_Events] he  JOIN [Event_Types] et ON he.EventTypeId = et.EventTypeId  WHERE UserId = 1 ORDER BY [Logged] DESC";
                //sql3 ="SELECT * FROM Healthy_Events WHERE UserId = @UserId"*/
                return await sqlConnection.QueryAsync<HealthyEvent>(
                    sql: "SELECT Logged, et.Name AS EventTypeName, Milliliters, WalkingDistance, TimeElapsed, Calories, Score  FROM [Healthy_Events] he  JOIN [Event_Types] et ON he.EventTypeId = et.EventTypeId  WHERE UserId = @UserId ORDER BY [Logged] DESC",
                    dynamicParameters,
                    commandType: CommandType.Text);
            }
        }

    }
}
