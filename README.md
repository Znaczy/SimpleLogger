"# SimpleLogger" 

Welcome to Simple Logger simple logging application. 
This is a simple logging library with console application attached demonstrating it work. 
It writes logs to file, registry and eventlog. 

In case you want to log something simply with our Logger please follow these steps:
1. Clone or download repository. 
2. To be able to write logs to EventLog SimpleLogger needs to be added to your Registry. 
   Run 'create.reg' with administrator previllages to accomplish it.
3. Open Command Prompt, go to SimpleLogger/Console and write 'dotnet run'
4. Follow the commands on screen. 

You will find log:
  - file at 'SimpleLogger\Console\Logs'
  - registry at 'HKEY_CURRENT_USER\Software\SimpleLogger'
  
Have a good day. 
