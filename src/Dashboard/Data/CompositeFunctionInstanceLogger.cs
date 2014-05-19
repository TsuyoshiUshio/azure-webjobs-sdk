﻿using System.Collections.Generic;
using Microsoft.Azure.Jobs;
using Microsoft.Azure.Jobs.Protocols;

namespace Dashboard.Data
{
    internal class CompositeFunctionInstanceLogger : IFunctionInstanceLogger
    {
        private readonly IEnumerable<IFunctionInstanceLogger> _loggers;

        public CompositeFunctionInstanceLogger(params IFunctionInstanceLogger[] loggers)
        {
            _loggers = loggers;
        }

        public void LogFunctionStarted(FunctionStartedSnapshot snapshot)
        {
            foreach (IFunctionInstanceLogger logger in _loggers)
            {
                logger.LogFunctionStarted(snapshot);
            }
        }

        public void LogFunctionCompleted(FunctionCompletedSnapshot snapshot)
        {
            foreach (IFunctionInstanceLogger logger in _loggers)
            {
                logger.LogFunctionCompleted(snapshot);
            }
        }
    }
}