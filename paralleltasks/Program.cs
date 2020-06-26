using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

/*
INSTALLED PACKAGES

DotNetEnv
Pomelo.EntityFrameworkCore.Mysql

add this to your .csproj 
  <ItemGroup>
    <PackageReference Include="DotNetEnv" Version="1.4.0" />
    <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="3.1.1" />
  </ItemGroup>
  
  or run command line commands to install them (dotnet add package <package>) or add it thorugh visual studio 

 */
/*
 THINGS TO KNOW:

 - the work performed by a Task<TResult> object typically executes asynchronously on a thread pool thread 
rather than synchronously on the main application thread
Most commonly, a lambda expression is used to specify the work that the task is to perform.
 
 
 
 */



namespace ParallelTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            
            loadEnvFile();

          
            List<Task> tasks = new List<Task>();

            
          //===========================
            // delete a file
            //===========================
            var filePath = "filePath/";

            tasks.Add(Task.Factory.StartNew(() => (new DeleteFile()).run(filePath)));
            
            //===========================
            // simple counter
            //===========================
            // you can also create a Task using Run
            var t = Task<int>.Run(() => {
                // Just loop.
                int max = 1000000;
                int ctr = 0;
                for (ctr = 0; ctr <= max; ctr++)
                {
                    if (ctr == max / 2 && DateTime.Now.Hour <= 12)
                    {
                        ctr++;
                        break;
                    }
                }
                return ctr;
            });
            
            tasks.Add(t);

         
       //===========================
            // delete a table
            //===========================
          var tempTableName = "a_table_name"

          tasks.Add(Task.Factory.StartNew(() => (new DeleteTemporaryTable()).run(tempTableName)));



            try
            {
                Task.WaitAll(tasks.ToArray());
            } catch(AggregateException ae)
            {
                throw ae.Flatten();
            }


        }

        private static void loadEnvFile()
        {
            DotNetEnv.Env.Load();

            var key = DotNetEnv.Env.GetString("KEY_ON_ENV_FILE");

            // IsNullOrEmpty is an extension methiod
            // that can be found in the ObjectHelper class (see that class)
            if (key.IsNullOrEmpty())
            {
                throw new Exception("You should set the env key KEY_ON_ENV_FILE");
            }

        }

        

  
    }
}
