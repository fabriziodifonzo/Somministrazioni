using log4net;
using Oracle.ManagedDataAccess.Client;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Web.Interceptors
{
    /// <summary>
    /// This class is an interceptor for Entity framework. It allows to EF to log query in a certain appender.
    /// </summary>
    public class LoggedEFInterceptor : IDbCommandInterceptor
    {

        public void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            if (command.Parameters is SqlParameterCollection)
            {
                LogInfo("NonQueryExecuted", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((SqlParameterCollection)command.Parameters)));
            }
            else if (command.Parameters is OracleParameterCollection)
            {
                LogInfo("NonQueryExecuted", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((OracleParameterCollection)command.Parameters)));
            }
            else
            {
                _log.Info("ERROR WHILE LOGGING: " + GenericConstants.ERRMSG_INVALIDDATATYPE + GenericConstants.CHR_SPACE + command.Parameters.GetType());
            }
        }

        public void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            if (command.Parameters is SqlParameterCollection)
            {
                LogInfo("NonQueryExecuting", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((SqlParameterCollection)command.Parameters)));
            }
            else if (command.Parameters is OracleParameterCollection)
            {
                LogInfo("NonQueryExecuting", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((OracleParameterCollection)command.Parameters)));
            }
            else
            {
                _log.Info("ERROR WHILE LOGGING: " + GenericConstants.ERRMSG_INVALIDDATATYPE + GenericConstants.CHR_SPACE + command.Parameters.GetType());
            }
        }

        public void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            if (command.Parameters is SqlParameterCollection)
            {
                LogInfo("ReaderExecuted", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((SqlParameterCollection)command.Parameters)));
            }
            else if (command.Parameters is OracleParameterCollection)
            {
                LogInfo("ReaderExecuted", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((OracleParameterCollection)command.Parameters)));
            }
            else
            {
                _log.Info("ERROR WHILE LOGGING: " + GenericConstants.ERRMSG_INVALIDDATATYPE + GenericConstants.CHR_SPACE + command.Parameters.GetType());
            }
        }

        public void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            if (command.Parameters is SqlParameterCollection)
            {
                LogInfo("ReaderExecuting", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((SqlParameterCollection)command.Parameters)));
            }
            else if (command.Parameters is OracleParameterCollection)
            {
                LogInfo("ReaderExecuting", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo(((OracleParameterCollection)command.Parameters))));
            }
            else
            {
                _log.Info("ERROR WHILE LOGGING: " + GenericConstants.ERRMSG_INVALIDDATATYPE + GenericConstants.CHR_SPACE + command.Parameters.GetType());
            }
        }

        public void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (command.Parameters is SqlParameterCollection)
            {
                LogInfo("ScalarExecuted", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((SqlParameterCollection)command.Parameters)));

            }
            else if (command.Parameters is OracleParameterCollection)
            {
                LogInfo("ScalarExecuted", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((OracleParameterCollection)command.Parameters)));
            }
            else
            {
                _log.Info("ERROR WHILE LOGGING: " + GenericConstants.ERRMSG_INVALIDDATATYPE + GenericConstants.CHR_SPACE + command.Parameters.GetType());
            }
        }
        public void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (command.Parameters is SqlParameterCollection)
            {
                LogInfo("ScalarExecuting", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((SqlParameterCollection)command.Parameters)));
            }
            else if (command.Parameters is OracleParameterCollection)
            {
                LogInfo("ScalarExecuting", String.Format(" IsAsync: {0}, Command Text: {1} Command Parameters {2}", interceptionContext.IsAsync, command.CommandText, ParameterInfo((OracleParameterCollection)command.Parameters)));
            }
            else
            {
                _log.Info("ERROR WHILE LOGGING: " + GenericConstants.ERRMSG_INVALIDDATATYPE + GenericConstants.CHR_SPACE + command.Parameters.GetType());
            }
        }

        private void LogInfo(string command, string commandText)
        {
            _log.Info(String.Format("Intercepted on: {0} :- {1} ", command, commandText));
        }

        readonly ILog _log = log4net.LogManager.GetLogger(GenericConstants.QUERY_APPENDER);


        string ParameterInfo(SqlParameterCollection sqlParameterCollection)
        {

            var parameterInfoBuilder = new StringBuilder();
            parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);
            parameterInfoBuilder.Append(GenericConstants.BRACKET_CURLYOPEN);
            parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);

            foreach (var sqlParameter in sqlParameterCollection.Cast<SqlParameter>().ToList())
            {
                parameterInfoBuilder.Append(GenericConstants.LOG_PARAMETERNAME);
                parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);
                parameterInfoBuilder.Append(sqlParameter.ParameterName);
                parameterInfoBuilder.Append(GenericConstants.CHR_COMMA);
                parameterInfoBuilder.Append(GenericConstants.LOG_PARAMETERVALUE);
                parameterInfoBuilder.Append(sqlParameter.SqlValue);
                parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);
            }

            parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);
            parameterInfoBuilder.Append(GenericConstants.BRACKET_CURLYCLOSED);

            return parameterInfoBuilder.ToString();

        }

        string ParameterInfo(OracleParameterCollection oracleParameterCollection)
        {

            var parameterInfoBuilder = new StringBuilder();
            parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);
            parameterInfoBuilder.Append(GenericConstants.BRACKET_CURLYOPEN);
            parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);

            var empEnumerator = oracleParameterCollection.GetEnumerator();
            while (empEnumerator.MoveNext())
            {
                var parameter = (OracleParameter)empEnumerator.Current;
                parameterInfoBuilder.Append(GenericConstants.LOG_PARAMETERNAME);
                parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);
                parameterInfoBuilder.Append(parameter.ParameterName);
                parameterInfoBuilder.Append(GenericConstants.CHR_COMMA);
                parameterInfoBuilder.Append(GenericConstants.LOG_PARAMETERVALUE);
                parameterInfoBuilder.Append(parameter.Value);
                parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);
            }

            parameterInfoBuilder.Append(GenericConstants.CHR_SPACE);  
            parameterInfoBuilder.Append(GenericConstants.BRACKET_CURLYCLOSED);

            return parameterInfoBuilder.ToString();

        }
    }
}
