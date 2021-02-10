using System;
using System.Collections.Generic;

namespace AbstractInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            ICreditManager ihtiyacKredi = new IhtiyacKrediManager();
            ICreditManager konutKredi = new KonutKrediManager();
            ICreditManager tasitKredi = new TasitKrediManager();
            

            ApplicationManager applicationManager = new ApplicationManager();

            List<ILoggerService> loggerServices = new List<ILoggerService>() 
            { 
                new FileLogService() ,
                new DatabaseLogService()
            };

            applicationManager.MakeApplication(ihtiyacKredi, loggerServices);
            //applicationManager.MakeApplication(konutKredi);
            //applicationManager.MakeApplication(tasitKredi);

            List<ICreditManager> creditList = new List<ICreditManager>() { };

            creditList.Add(ihtiyacKredi);
            creditList.Add(konutKredi);
            creditList.Add(tasitKredi);
           
            applicationManager.CreditPreliminaryInformation(creditList,new DatabaseLogService());
        }
    }
}
