using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Eauth; // Eauth implementation

namespace Eauth_CS_Console
{
    class Assets
    {
        public void PrintLogo()
        {
            ClearConsole();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("███████╗░█████╗░██╗░░░██╗████████╗██╗░░██╗");
            Console.WriteLine("██╔════╝██╔══██╗██║░░░██║╚══██╔══╝██║░░██║");
            Console.WriteLine("█████╗░░███████║██║░░░██║░░░██║░░░███████║");
            Console.WriteLine("██╔══╝░░██╔══██║██║░░░██║░░░██║░░░██╔══██║");
            Console.WriteLine("███████╗██║░░██║╚██████╔╝░░░██║░░░██║░░██║");
            Console.WriteLine("╚══════╝╚═╝░░╚═╝░╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("█-Establishing connection with Eauth...");
        }

        public void ClearConsole()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.Clear();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Console.Write("\u001b[2J\u001b[1;1H");
            }
        }

        EauthPrimaryClass eauthClass = new EauthPrimaryClass(); //  Creates a new instance of the "EauthPrimaryClass" class and assigns it to the "eauthClass" variable

        public void home()
        {
            PrintLogo();
            eauthClass.InitRequest(); // Eauth init request (required)

            Console.WriteLine("[ 1 ] Login | [ 2 ] Register | [3] Upgrade");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    // Code block executed if expression equals to login input
                    login();
                    break;
                case "2":
                    // Code block executed if expression equals to register input
                    register();
                    break;
                case "3":
                    // Code block executed if expression equals to register input
                    upgrade();
                    break;
                default:
                    // Code block executed if expression does not match any case
                    ClearConsole();
                    Console.WriteLine("Please choose a valid input!");
                    break;
            }
        }
        public async Task login()
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine("[ 1 ] Username & Password       |       [ 2 ] License Key");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    // Code block executed if expression equals to username and password input
                    Console.Clear();
                    PrintLogo();
                    Console.WriteLine("█-Username:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    var username = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("█-Password:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string loginPasswordStorage = null;
                    ConsoleKeyInfo loginPassword;
                    do
                    {
                        loginPassword = Console.ReadKey(true);

                        if (loginPassword.Key != ConsoleKey.Backspace)
                        {
                            loginPasswordStorage += loginPassword.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write("\b \b");
                            char[] pas = loginPasswordStorage.ToCharArray();
                            string temp = "";
                            for (int i = 0; i < loginPasswordStorage.Length - 1; i++)
                            {
                                temp += pas[i];
                            }
                            loginPasswordStorage = temp;
                        }
                    }
                    while (loginPassword.Key != ConsoleKey.Enter);
                    var password = loginPasswordStorage.Substring(0, (loginPasswordStorage.Length - 1));
                    ClearConsole();

                    if (await eauthClass.LoginRequest(username, password, ""))
                    {
                        // Code to execute if login is successful
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(eauthClass.loggedMessage);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Username: " + username);
                        Console.WriteLine("Rank: " + eauthClass.userRank);
                        Console.WriteLine("Register Date: " + eauthClass.registerDate);
                        Console.WriteLine("Expire Date: " + eauthClass.expireDate);
                        Console.WriteLine("Hardware ID: " + eauthClass.userHwid);
                    }
                    break;
                case "2":
                    // Code block executed if expression equals to license key input
                    Console.Clear();
                    PrintLogo();
                    Console.WriteLine("█-License Key:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    var LicenseKey = Console.ReadLine();
                    ClearConsole();

                    if (await eauthClass.LoginRequest("", "", LicenseKey))
                    {
                        // Code to execute if login is successful
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(eauthClass.loggedMessage);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("License Key: " + LicenseKey);
                        Console.WriteLine("Rank: " + eauthClass.userRank);
                        Console.WriteLine("Register Date: " + eauthClass.registerDate);
                        Console.WriteLine("Expire Date: " + eauthClass.expireDate);
                        Console.WriteLine("Hardware ID: " + eauthClass.userHwid);
                    }
                    break;
                // ...
                default:
                    // Code block executed if expression does not match any case
                    ClearConsole();
                    Console.WriteLine("Please choose a valid input!");
                    break;
            }
        }

        public async Task register()
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine("█-Username:");
            Console.ForegroundColor = ConsoleColor.Red;
            var username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("█-Password:");
            Console.ForegroundColor = ConsoleColor.Red;
            string registerPasswordStorage = null;
            ConsoleKeyInfo registerPassword;
            do
            {
                registerPassword = Console.ReadKey(true);

                if (registerPassword.Key != ConsoleKey.Backspace)
                {
                    registerPasswordStorage += registerPassword.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b \b");
                    char[] pas = registerPasswordStorage.ToCharArray();
                    string temp = "";
                    for (int i = 0; i < registerPasswordStorage.Length - 1; i++)
                    {
                        temp += pas[i];
                    }
                    registerPasswordStorage = temp;
                }
            }
            while (registerPassword.Key != ConsoleKey.Enter);
            var password = registerPasswordStorage.Substring(0, (registerPasswordStorage.Length - 1));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("█-License Key:");
            Console.ForegroundColor = ConsoleColor.Red;
            var LicenseKey = Console.ReadLine();
            ClearConsole();
            if (await eauthClass.RegisterRequest(username, password, LicenseKey))
            {
                // Code to execute if login is successful
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(eauthClass.registeredMessage);
            }
        }

        public async Task upgrade()
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine("█-Username:");
            Console.ForegroundColor = ConsoleColor.Red;
            var username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("█-License Key:");
            Console.ForegroundColor = ConsoleColor.Red;
            var LicenseKey = Console.ReadLine();
            ClearConsole();
            if (await eauthClass.UpgradeRequest(username, LicenseKey))
            {
                // Code to execute if login is successful
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The account has been successfully upgraded.");
            }
        }
    }
}
