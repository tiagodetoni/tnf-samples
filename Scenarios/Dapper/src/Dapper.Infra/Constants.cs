﻿using System;

namespace Dapper.Infra
{
    public static class Constants
    {
        public static string ConnectionStringName = "SqlServer";

        private const string ENVIRONMENT_VARIABLE = "ASPNETCORE_ENVIRONMENT";
        private const string DEV_ENVIRONMENT_VARIABLE = "DEVELOPMENT";

        public static bool IsDevelopment()
        {
            var environmentName = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE);
            if (environmentName.ToUpperInvariant() == DEV_ENVIRONMENT_VARIABLE)
                return true;

            return false;
        }
    }
}
