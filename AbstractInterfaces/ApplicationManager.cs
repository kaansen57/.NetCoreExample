using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInterfaces
{
    class ApplicationManager
    {
        //Method Injection
        public void MakeApplication(ICreditManager creditManager,List<ILoggerService> loggerService)
        {
            creditManager.CreditCalc();
            foreach (var logger in loggerService)
            {
                logger.Log();
            }
        }

        public void CreditPreliminaryInformation(List<ICreditManager> creditManagers , ILoggerService loggerService)
        {
            foreach (var item in creditManagers)
            {
                item.CreditCalc();
            }
            loggerService.Log();
        }
    }
}
