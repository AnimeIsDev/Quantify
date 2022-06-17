using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using DiscordRPC;
using System.Collections.Concurrent;
using System.Reflection;
using System.IO.Compression;
using Colorful;
using Console = Colorful.Console;
using System.IO;

namespace Quantify
{
    public static class Utilities
    {
        public static int RefreshRate = 0;
        public static int Loggo;
        public static string Theme = "";
        public static string Theme1 = "";
        public static Color ThemeColor = Color.Red;
        public static Color ThemeColor2 = Color.Red;
        public static string version = "V1.0";
        public static string Module = "";
        public static string Status = "";
        public static DiscordRpcClient client = new DiscordRpcClient("983473314729164830");
        public static void Update(string state)
        {
            client.UpdateState(state);
        } 
        public static void Initialize()
        { 
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = $"Quantify  {Utilities.version}",
                Buttons = new Button[]
                {
                    new Button() { Label = "Discord", Url = "https://discord.gg/vVXbFXAGrr" }
                },
                State = "👻  Status " + Status,
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "small",
                    LargeImageText = "https://discord.gg/vVXbFXAGrr",
                    SmallImageKey = "small",
                    SmallImageText = "Hey Sexy"
                }
            });
        }
        public static void Upd()
        {
            client.SetPresence(new RichPresence()
            {
                Details = $"Quantify  {Utilities.version}",
                Buttons = new Button[]
                {
                    new Button() { Label = "Discord", Url = "https://discord.gg/vVXbFXAGrr" }
                },
                State = "👻  Status: " + Status,
                Assets = new Assets()
                {
                    LargeImageKey = "small",
                    LargeImageText = "https://discord.gg/vVXbFXAGrr",
                    SmallImageKey = "small",
                    SmallImageText = "Hey Sexy"
                }
            }); 
        }

        public static string[] Logga1 =
        {
            "",
            "  ██████╗ ██╗   ██╗ █████╗ ███╗   ██╗████████╗██╗███████╗██╗   ██╗",
            " ██╔═══██╗██║   ██║██╔══██╗████╗  ██║╚══██╔══╝██║██╔════╝╚██╗ ██╔╝",
            " ██║   ██║██║   ██║███████║██╔██╗ ██║   ██║   ██║█████╗   ╚████╔╝ ",
            " ██║▄▄ ██║██║   ██║██╔══██║██║╚██╗██║   ██║   ██║██╔══╝    ╚██╔╝  ",
            " ╚██████╔╝╚██████╔╝██║  ██║██║ ╚████║   ██║   ██║██║        ██║   ",
            "  ╚══▀▀═╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚═╝╚═╝        ╚═╝   ",
            "",
            ""
        };
        public static string[] Logga2 =
        {
            "",
            "   █████   █    ██  ▄▄▄       ███▄    █ ▄▄▄█████▓ ██▓  █████▒▓██   ██▓",
            " ▒██▓  ██▒ ██  ▓██▒▒████▄     ██ ▀█   █ ▓  ██▒ ▓▒▓██▒▓██   ▒  ▒██  ██▒",
            " ▒██▒  ██░▓██  ▒██░▒██  ▀█▄  ▓██  ▀█ ██▒▒ ▓██░ ▒░▒██▒▒████ ░   ▒██ ██░",
            " ░██  █▀ ░▓▓█  ░██░░██▄▄▄▄██ ▓██▒  ▐▌██▒░ ▓██▓ ░ ░██░░▓█▒  ░   ░ ▐██▓░",
            " ░▒███▒█▄ ▒▒█████▓  ▓█   ▓██▒▒██░   ▓██░  ▒██▒ ░ ░██░░▒█░      ░ ██▒▓░",
            " ░░ ▒▒░ ▒ ░▒▓▒ ▒ ▒  ▒▒   ▓▒█░░ ▒░   ▒ ▒   ▒ ░░   ░▓   ▒ ░       ██▒▒▒ ",
            "  ░ ▒░  ░ ░░▒░ ░ ░   ▒   ▒▒ ░░ ░░   ░ ▒░    ░     ▒ ░ ░       ▓██ ░▒░ ",
            "    ░   ░  ░░░ ░ ░   ░   ▒      ░   ░ ░   ░       ▒ ░ ░ ░     ▒ ▒ ░░  ",
            "     ░       ░           ░  ░         ░           ░           ░ ░     ",
            "                                                               ░ ░     ",
            "",
            ""
        };
        public static string[] Logga3 =
       {
            "",
            "    ____                        __   _  ____ ",
            "   / __ \\ __  __ ____ _ ____   / /_ (_)/ __/__  __ ",
            "  / / / // / / // __ `// __ \\ / __// // /_ / / / / ",
            " / /_/ // /_/ // /_/ // / / // /_ / // __// /_/ /      ",
            " \\___\\_\\\\__,_/ \\__,_//_/ /_/ \\__//_//_/   \\__, /   ",
            "                                         /____/ ",
            "",
            ""
        };
        public static string[] Logga4 =
       {
            "",
            "   ___                        _    _   __        ",
            "  / _ \\  _   _   __ _  _ __  | |_ (_) / _| _   _ ",
            " | | | || | | | / _` || '_ \\ | __|| || |_ | | | |",
            " | |_| || |_| || (_| || | | || |_ | ||  _|| |_| |",
            "  \\__\\_\\ \\__,_| \\__,_||_| |_| \\__||_||_|   \\__, |",
            "                                           |___/ ",
            "",
            ""
        };
        public static string[] Logga5 =
      {
            "",
            "  @@@@@@    @@@  @@@   @@@@@@   @@@  @@@  @@@@@@@  @@@  @@@@@@@@  @@@ @@@  ",
            " @@@@@@@@   @@@  @@@  @@@@@@@@  @@@@ @@@  @@@@@@@  @@@  @@@@@@@@  @@@ @@@  ",
            " @@!  @@@   @@!  @@@  @@!  @@@  @@!@!@@@    @@!    @@!  @@!       @@! !@@  ",
            " !@!  @!@   !@!  @!@  !@!  @!@  !@!!@!@!    !@!    !@!  !@!       !@! @!!",
            " @!@  !@!   @!@  !@!  @!@!@!@!  @!@ !!@!    @!!    !!@  @!!!:!     !@!@!",
            " !@!  !!!   !@!  !!!  !!!@!!!!  !@!  !!!    !!!    !!!  !!!!!:      @!!!",
            " !!:!!:!:   !!:  !!!  !!:  !!!  !!:  !!!    !!:    !!:  !!:         !!:    ",
            " :!: :!:    :!:  !:!  :!:  !:!  :!:  !:!    :!:    :!:  :!:         :!:    ",
            " ::::: :!   ::::: ::  ::   :::   ::   ::     ::     ::   ::          ::    ",
            "  : :  :::   : :  :    :   : :  ::    :      :     :     :           :      ",
            "",
            ""
        };
        public static string[] Logga6 =
     {
            "",
            "   /$$$$$$                              /$$    /$$ /$$$$$$         ",
            "  /$$__  $$                            | $$   |__//$$__  $$        ",
            " | $$  \\ $$/$$   /$$ /$$$$$$ /$$$$$$$ /$$$$$$  /$| $$  \\__/$$   /$$",
            " | $$  | $| $$  | $$|____  $| $$__  $|_  $$_/ | $| $$$$  | $$  | $$",
            " | $$  | $| $$  | $$ /$$$$$$| $$  \\ $$ | $$   | $| $$_/  | $$  | $$",
            " | $$/$$ $| $$  | $$/$$__  $| $$  | $$ | $$ /$| $| $$    | $$  | $$",
            " |  $$$$$$|  $$$$$$|  $$$$$$| $$  | $$ |  $$$$| $| $$    |  $$$$$$$",
            "  \\____ $$$\\______/ \\_______|__/  |__/  \\___/ |__|__/     \\____  $$",
            "       \\__/                                               /$$  | $$",
            "                                                         |  $$$$$$/",
            "                                                          \\______/",
            "",
            ""
        };
        public static string[] Logga =
        { 
        };

        public static void SetLogo()
        {
            switch (Utilities.Loggo)
            {
                case 1:
                    Logga = Logga1;
                    break;
                case 2:
                    Logga = Logga2;
                    break;
                case 3:
                    Logga = Logga3;
                    break;
                case 4:
                    Logga = Logga4;
                    break;
                case 5:
                    Logga = Logga5;
                    break;
                case 6:
                    Logga = Logga6;
                    break;
            }
        }

        public static void Logo()
        {
            SetLogo();
            Console.Clear();
            Colorful.Console.ReplaceAllColorsWithDefaults();
            Console.WriteLineWithGradient(Logga, Utilities.ThemeColor, Utilities.ThemeColor2, 5);
            Console.CursorVisible = false;
        }
    }
}
