namespace WBG.BiscuitMachine.ConsoleSimulator.Constants;
public static class StartingLogo
{
    public static void DisplayLogo()
    {
        string asciiArt = @"
          ____   _                    _  _                        
         |  _ \ (_)                  (_)| |                       
         | |_) | _  ___   ___  _   _  _ | |_                      
         |  _ < | |/ __| / __|| | | || || __|                     
         | |_) || |\__ \| (__ | |_| || || |_                      
         |____/ |_||___/ \___| \__,_||_| \__|                     
          __  __               _      _                           
         |  \/  |             | |    (_)                          
         | \  / |  __ _   ___ | |__   _  _ __    ___              
         | |\/| | / _` | / __|| '_ \ | || '_ \  / _ \             
         | |  | || (_| || (__ | | | || || | | ||  __/             
         |_|  |_| \__,_| \___||_| |_||_||_| |_| \___|             
           _____  _                    _         _                
          / ____|(_)                  | |       | |               
         | (___   _  _ __ ___   _   _ | |  __ _ | |_  ___   _ __  
          \___ \ | || '_ ` _ \ | | | || | / _` || __|/ _ \ | '__| 
          ____) || || | | | | || |_| || || (_| || |_| (_) || |    
         |_____/ |_||_| |_| |_| \__,_||_| \__,_| \__|\___/ |_|    
             Welcome to the Biscuit Machine Simulator Console!
                    Feel free to explore and have fun!
        ";

        Console.WriteLine(asciiArt);
    }
}
