﻿using FinchAPI;
using System;

namespace FinchTalentShow
{
    class Program
    {
        #region Enums for Menu's

        public enum Menu : byte
        {
            ConnectFinch = 1,
            TalentShow,
            DataRecorder,
            AlarmSystem,
            UserProgramming,
            DisconnectFinch,
            Quit
        }

        public enum TalentShowMenu : byte
        {
            LED = 1,
            Buzzer,
            Wheels,
            Back
        }

        public enum LEDMenu : byte
        {
            On = 1,
            Blink,
            MultipleLED,
            Pulse,
            Back
        }

        public enum BuzzerMenu : byte
        {
            On = 1,
            StarWars,
            HappyBirthday,
            Back
        }

        public enum WheelsMenu : byte
        {
            Forward = 1,
            Backward,
            Right,
            Left,
            Back
        }

        #endregion

        #region Main method of the program

        static Finch myFinch = new Finch();

        /// <summary>
        /// Main Method of the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayConsoleUI("Finch Control v1.0");
                getMenuOption(DisplayMainMenu());
            }
        }

        #endregion

        #region Generate UI

        /// <summary>
        /// Generate the main console for the UI
        /// </summary>
        private static void DisplayConsoleUI(string programName)
        {
            // Setup UI for application
            Console.Clear();
            for (int i = 0; i < 120; i++)
            {
                Console.SetCursorPosition(0 + i, 0);
                Console.Write("-");
            }
            for (int i = 0; i < 120; i++)
            {
                Console.SetCursorPosition(0 + i, 4);
                Console.Write("-");
            }
            for (int i = 0; i < 120; i++)
            {
                Console.SetCursorPosition(0 + i, 28);
                Console.Write("-");
            }
            Console.SetCursorPosition(1, 5);

            DisplayProgramName(programName);
        }

        /// <summary>
        /// Display program name to UI
        /// </summary>
        /// <param name="programName">string - The name of the program</param>
        private static void DisplayProgramName(string programName)
        {
            // Setup program name and colors
            Console.SetCursorPosition(45, 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{programName}");
            Console.ResetColor();
            Console.SetCursorPosition(1, 5);
        }

        /// <summary>
        /// Displays the Closing Screen
        /// </summary>
        private static void DisplayClosingScreen()
        {
            DisplayConsoleUI("Goodbye");
            Console.WriteLine("So our time has come to an end. I enjoyed working with your Finch today!");
            Console.WriteLine();
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("Thank you for using this program. Until next time!");
            DisplayContinuePrompt();
            quit();
        }

        #endregion

        #region Menu's of Application

        /// <summary>
        /// Generate the main menu for the console
        /// </summary>
        private static int DisplayMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"
              Menu

  1. Connect Finch Robot
  
  2. Talent Show
  
  3. Data Recorder (Under Development)

  4. Alarm System (Under Development)

  5. User Programming (Under Development)

  6. Disconnect Finch Robot

  7. Quit Application


  



  Option (1-8): ");
            int.TryParse(Console.ReadLine(), out int userResponse);
            return userResponse;
        }

        /// <summary>
        /// Performs an action based on the menu option selected
        /// </summary>
        /// <param name="option">Menu option chosen</param>
        private static void getMenuOption(int option)
        {
            Menu menuChoice = (Menu)option;

            switch (menuChoice)
            {
                case Menu.ConnectFinch:
                    DisplayConnectFinch();
                    break;
                case Menu.TalentShow:
                    getTalentShowMenuOption(DisplayTalentShowMenu());
                    break;
                case Menu.DataRecorder:
                    DisplayConsoleUI("Under Development");
                    Console.WriteLine("This module is under development");
                    DisplayContinuePrompt();
                    break;
                case Menu.AlarmSystem:
                    DisplayConsoleUI("Under Development");
                    Console.WriteLine("This module is under development");
                    DisplayContinuePrompt();
                    break;
                case Menu.UserProgramming:
                    DisplayConsoleUI("Under Development");
                    Console.WriteLine("This module is under development");
                    DisplayContinuePrompt();
                    break;
                case Menu.DisconnectFinch:
                    DisplayDisconnectFinch();
                    break;
                case Menu.Quit:
                    DisplayClosingScreen();
                    break;
                default:
                    break;

            }
        }

        /// <summary>
        /// Displays the Talent Show Menu
        /// </summary>
        /// <returns>Returns an int of the menu option chosen</returns>
        private static int DisplayTalentShowMenu()
        {
            DisplayConsoleUI("Talent Show Control Menu");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"  
  1. LED Control

  2. Buzzer Control

  3. Wheels Menu

  4. Back














  Option(1-7): ");
            int.TryParse(Console.ReadLine(), out int userResponse);
            Console.Clear();
            return userResponse;
        }

        /// <summary>
        /// Performs an action based on the selected Menu item
        /// </summary>
        /// <param name="option">Menu option chosen</param>
        private static void getTalentShowMenuOption(int option)
        {
            TalentShowMenu menuOption = (TalentShowMenu)option;

            switch (menuOption)
            {
                case TalentShowMenu.LED:
                    getLEDMenuOption(DisplayLEDMenu());
                    break;
                case TalentShowMenu.Buzzer:
                    getBuzzerMenuOption(DisplayBuzzerMenu());
                    break;
                case TalentShowMenu.Wheels:
                    getWheelMenuOption(DisplayWheelsMenu());
                    break;
                case TalentShowMenu.Back:
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Sorry I don't understand your response, please try again.");
                    DisplayContinuePrompt();
                    break;
            }
        }

        /// <summary>
        /// Displays LED Menu
        /// </summary>
        /// <returns>Menu Option Chosen</returns>
        private static int DisplayLEDMenu()
        {
            DisplayConsoleUI("LED Control Menu");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"
             LED Menu

  1. LED On

  2. LED Blink

  3. Multiple LED On

  4. LED Pulse

  5. Back










  Option (1-5): ");
            int.TryParse(Console.ReadLine(), out int userResponse);
            return userResponse;
        }

        /// <summary>
        /// Performs an action based on the selected Menu item
        /// </summary>
        /// <param name="option">Menu Option chosen</param>
        private static void getLEDMenuOption(int option)
        {
            LEDMenu menuChoice = (LEDMenu)option;

            switch (menuChoice)
            {
                case LEDMenu.On:
                    DisplayConnectFinch();
                    DisplayConsoleUI("LED On");
                    setLEDOn();
                    setLEDOff();
                    break;
                case LEDMenu.Blink:
                    DisplayConnectFinch();
                    DisplayConsoleUI("LED Blink");
                    LEDBlink();
                    break;
                case LEDMenu.MultipleLED:
                    DisplayConnectFinch();
                    DisplayConsoleUI("Multiple LED Show");
                    ShowMultipleLED();
                    break;
                case LEDMenu.Pulse:
                    DisplayConnectFinch();
                    DisplayConsoleUI("LED Pulse");
                    LEDPulse();
                    break;
                case LEDMenu.Back:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays Buzzer Menu
        /// </summary>
        /// <returns>Returns Menu Option selected</returns>
        private static int DisplayBuzzerMenu()
        {
            DisplayConsoleUI("Buzzer Control Menu");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"
             Buzzer Menu

  1. Buzzer On

  2. Buzzer Star Wars

  3. Buzzer Happy Birthday

  4. Back












  Option (1-4): ");
            int.TryParse(Console.ReadLine(), out int userResponse);
            return userResponse;
        }

        /// <summary>
        /// Performs an action based on the selected Menu item
        /// </summary>
        /// <param name="option">Menu Option chosen</param>
        private static void getBuzzerMenuOption(int option)
        {
            BuzzerMenu menuChoice = (BuzzerMenu)option;

            switch (menuChoice)
            {
                case BuzzerMenu.On:
                    DisplayConnectFinch();
                    setBuzzerOn();
                    break;
                case BuzzerMenu.StarWars:
                    DisplayConnectFinch();
                    buzzerStarWars();
                    break;
                case BuzzerMenu.HappyBirthday:
                    DisplayConnectFinch();
                    buzzerHappyBirthday();
                    break;
                case BuzzerMenu.Back:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays Wheels Menu
        /// </summary>
        /// <returns>Returns menu option selected</returns>
        private static int DisplayWheelsMenu()
        {
            DisplayConsoleUI("Buzzer Control Menu");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"
             Wheels Menu

  1. Forward

  2. Backward

  3. Right (90 degrees)

  4. Left (90 degrees)

  5. Back










  Option (1-4): ");
            int.TryParse(Console.ReadLine(), out int userResponse);
            return userResponse;
        }

        /// <summary>
        /// Performs an action based on the selected Menu Item
        /// </summary>
        /// <param name="option">Menu option chosen</param>
        private static void getWheelMenuOption(int option)
        {
            WheelsMenu menuOption = (WheelsMenu)option;

            switch (menuOption)
            {
                case WheelsMenu.Forward:
                    DisplayConnectFinch();
                    setWheelsForward();
                    break;
                case WheelsMenu.Backward:
                    DisplayConnectFinch();
                    setWheelsBackwards();
                    break;
                case WheelsMenu.Right:
                    DisplayConnectFinch();
                    setWheelsRight();
                    break;
                case WheelsMenu.Left:
                    DisplayConnectFinch();
                    setWheelsLeft();
                    break;
                case WheelsMenu.Back:
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region LED Control
        /// <summary>
        /// Get's the LED parameters and passes it to the setLEDOn Method
        /// </summary>
        private static (int r, int g, int b, int time) getLEDParams()
        {
            DisplayConsoleUI("Set LED Parameters");
            Console.Write("Red Value (0-255): ");
            int.TryParse(Console.ReadLine(), out int r);
            Console.Write("Green Value (0-255): ");
            int.TryParse(Console.ReadLine(), out int g);
            Console.Write("Blue Value (0-255): ");
            int.TryParse(Console.ReadLine(), out int b);
            Console.Write("Time(ms) Value: ");
            int.TryParse(Console.ReadLine(), out int time);
            return (r, g, b, time);
        }

        /// <summary>
        /// Set the LED to on for a specified time
        /// Default color is white
        /// </summary>
        /// <param name="r">Value for the Red LED</param>
        /// <param name="g">Value for the Green LED</param>
        /// <param name="b">Value for the Blue LED</param>
        /// <param name="time">Value for the Time in milliseconds that the LED is On</param>
        private static void setLEDOn()
        {
            var values = getLEDParams();

            myFinch.setLED(values.r, values.g, values.b);
            myFinch.wait(values.time);
        }

        private static void setLEDOn(int r = 255, int g = 255, int b = 255, int time = 1000)
        {
            myFinch.setLED(r, g, b);
            myFinch.wait(time);

        }

        private static void setLEDOff(int time = 500)
        {
            myFinch.setLED(0, 0, 0);
            myFinch.wait(time);
        }

        private static void LEDBlink()
        {
            var values = getLEDParams();

            Console.Write("Enter the number of blinks, 0 is infinite: ");
            int.TryParse(Console.ReadLine(), out int numberOfBlinks);
            if (numberOfBlinks == 0)
            {
                while (true)
                {
                    setLEDOn(values.r, values.g, values.b, values.time);
                    setLEDOff();
                }
            }
            else
            {
                for (int i = 0; i < numberOfBlinks; i++)
                {
                    setLEDOn(values.r, values.g, values.b, values.time);
                    setLEDOff();
                }
            }
        }

        private static void ShowMultipleLED()
        {

            setLEDOn(255, 255, 255, 1000);
            setLEDOff(500);
            setLEDOn(255, 0, 0, 500);
            setLEDOff(500);
            setLEDOn(0, 255, 0, 2000);
            setLEDOff(500);
            setLEDOn(0, 0, 255, 1500);
            setLEDOff(500);
        }

        private static void LEDPulse()
        {
            for (int i = 0; i < 255; i++)
            {
                setLEDOn(i, 0, 0, 1);
            }
            for (int i = 255; i >= 0; i--)
            {
                setLEDOn(i, 0, 0, 1);
            }

            for (int i = 0; i < 255; i++)
            {
                setLEDOn(0, i, 0, 1);
            }
            for (int i = 255; i >= 0; i--)
            {
                setLEDOn(0, i, 0, 1);
            }

            for (int i = 0; i < 255; i++)
            {
                setLEDOn(0, 0, i, 1);
            }
            for (int i = 255; i >= 0; i--)
            {
                setLEDOn(0, 0, i, 1);
            }
        }

        #endregion

        #region Buzzer Control

        /// <summary>
        /// Gets Buzzer Parameters
        /// </summary>
        /// <returns>Returns Tuple of parameters</returns>
        private static (int hertz, int time) getBuzzerParams()
        {
            DisplayConsoleUI("Get Buzzer Parameters");
            Console.Write("Enter hertz (tone frequency): ");
            int.TryParse(Console.ReadLine(), out int hertz);
            Console.Write("Enter time for tone to play (ms): ");
            int.TryParse(Console.ReadLine(), out int time);
            return (hertz, time);
        }

        /// <summary>
        /// Sets the buzzer to on
        /// </summary>
        private static void setBuzzerOn()
        {
            var values = getBuzzerParams();

            myFinch.noteOn(values.hertz);
            myFinch.wait(values.time);
            myFinch.noteOff();
        }

        /// <summary>
        /// Sets the buzzer to on
        /// </summary>
        /// <param name="hertz">Tone generated in hertz</param>
        /// <param name="time">Time to play tone</param>
        private static void setBuzzerOn(int hertz, int time)
        {
            myFinch.noteOn(hertz);
            myFinch.wait(time);
            myFinch.noteOff();
        }

        /// <summary>
        /// Plays Star Wars Song
        /// </summary>
        private static void buzzerStarWars()
        {
            setBuzzerOn(300, 500);
            myFinch.wait(50);
            setBuzzerOn(300, 500);
            myFinch.wait(50);
            setBuzzerOn(300, 500);
            myFinch.wait(50);
            setBuzzerOn(250, 500);
            myFinch.wait(50);
            setBuzzerOn(350, 250);
            setBuzzerOn(300, 500);
            myFinch.wait(50);
            setBuzzerOn(250, 500);
            myFinch.wait(50);
            setBuzzerOn(350, 250);
            setBuzzerOn(300, 500);
            myFinch.wait(50);
        }

        /// <summary>
        /// Plays Happy Birthday
        /// </summary>
        private static void buzzerHappyBirthday()
        {
            setBuzzerOn(264, 125);
            myFinch.wait(250);
            setBuzzerOn(264, 125);
            myFinch.wait(125);
            setBuzzerOn(297, 500);
            myFinch.wait(125);
            setBuzzerOn(264, 500);
            myFinch.wait(125);
            setBuzzerOn(352, 500);
            myFinch.wait(125);
            setBuzzerOn(330, 1000);
            myFinch.wait(250);
            setBuzzerOn(264, 125);
            myFinch.wait(250);
            setBuzzerOn(264, 125);
            myFinch.wait(125);
            setBuzzerOn(297, 500);
            myFinch.wait(125);
            setBuzzerOn(264, 500);
            myFinch.wait(125);
            setBuzzerOn(396, 500);
            myFinch.wait(125);
            setBuzzerOn(352, 1000);
            myFinch.wait(250);
            setBuzzerOn(264, 125);
            myFinch.wait(250);
            setBuzzerOn(264, 125);
            myFinch.wait(125);
            setBuzzerOn(2642, 500);
            myFinch.wait(125);
            setBuzzerOn(440, 500);
            myFinch.wait(125);
            setBuzzerOn(352, 250);
            myFinch.wait(125);
            setBuzzerOn(352, 125);
            myFinch.wait(125);
            setBuzzerOn(330, 500);
            myFinch.wait(125);
            setBuzzerOn(297, 1000);
            myFinch.wait(250);
            setBuzzerOn(466, 125);
            myFinch.wait(250);
            setBuzzerOn(466, 125);
            myFinch.wait(125);
            setBuzzerOn(440, 500);
            myFinch.wait(125);
            setBuzzerOn(352, 500);
            myFinch.wait(125);
            setBuzzerOn(396, 500);
            myFinch.wait(125);
            setBuzzerOn(352, 1000);
        }

        #endregion

        #region Wheels Control

        /// <summary>
        /// Gets Wheel Parameters
        /// </summary>
        /// <returns>Returns a tuple for wheel parameters</returns>
        private static (int left, int right, int time) getWheelsParams()
        {
            DisplayConsoleUI("Set Wheel Parameters");
            Console.Write("Set Speed of Left Wheel: ");
            int.TryParse(Console.ReadLine(), out int left);
            Console.Write("Set Speed of Right Wheel: ");
            int.TryParse(Console.ReadLine(), out int right);
            Console.Write("Set time to drive: ");
            int.TryParse(Console.ReadLine(), out int time);
            return (left, right, time);
        }

        /// <summary>
        /// Sets the wheels to move forward
        /// </summary>
        private static void setWheelsForward()
        {
            var values = getWheelsParams();

            myFinch.setMotors(values.left, values.right);
            myFinch.wait(values.time);
            myFinch.setMotors(0, 0);
        }

        /// <summary>
        /// Sets the wheels to move backwards
        /// </summary>
        private static void setWheelsBackwards()
        {
            var values = getWheelsParams();

            myFinch.setMotors(-values.left, -values.right);
            myFinch.wait(values.time);
            myFinch.setMotors(0, 0);
        }

        /// <summary>
        /// Sets the wheels to turn right
        /// </summary>
        private static void setWheelsRight()
        {
            myFinch.setMotors(0, 100);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);
        }

        /// <summary>
        /// Sets the wheels to turn left
        /// </summary>
        private static void setWheelsLeft()
        {
            myFinch.setMotors(100, 0);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);
        }

        #endregion

        #region Finch Robot Connection Logic
        /// <summary>
        /// Connect to the Finch Robot
        /// </summary>
        private static void DisplayConnectFinch()
        {
            DisplayConsoleUI("Let's get connected");
            Console.WriteLine("Let's get your Finch connected before proceeding further.");
            Console.WriteLine();
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("I will run an automatic check next to see if you are connected or not");
            DisplayContinuePrompt();
            if (!ConnectFinch())
            {
                DisplayConsoleUI("Oh no, I don't see your Finch");
                Console.WriteLine("Ok, so your Finch is not connected right now. Let's fix that!");
                DisplayContinuePrompt();
                DisplayConsoleUI("Step 1");
                Console.WriteLine("Please plug the USB cable into the PC.");
                DisplayContinuePrompt();
                DisplayConsoleUI("Step 2");
                Console.WriteLine("Please plug the USB cable into the Finch.");
                DisplayContinuePrompt();
                DisplayConsoleUI("Let's get connected!");
                bool connected = ConnectFinch();
                if (!connected)
                {
                    Console.WriteLine("Sorry I am unable to connect to the Finch at this time.");
                    Console.WriteLine();
                    Console.SetCursorPosition(1, 7);
                    Console.WriteLine("Please check that the cable is connected properly and that Windows see's your device");
                    Console.SetCursorPosition(1, 9);
                    Console.WriteLine("Unfortunately, I have to quit the application. Please try again. ");
                    DisplayContinuePrompt();
                    Environment.Exit(0);
                }
            }
            else
            {
                DisplayConsoleUI("Finch is already connected");
                Console.WriteLine("Yay, I can see your Finch!");
                DisplayContinuePrompt();
            }
        }

        /// <summary>
        /// Try to connect to the Finch Robot
        /// </summary>
        private static bool ConnectFinch()
        {
            bool connected = false;
            int MAX_TRIES = 3;
            for (int i = 0; i <= MAX_TRIES; i++)
            {
                myFinch.connect();
                if (myFinch.connect())
                {
                    connected = true;
                    return connected;
                }
                else
                {
                    myFinch.connect();
                    if (i == MAX_TRIES)
                    {
                        return connected;
                    }
                }
            }
            return connected;
        }

        /// <summary>
        /// Displays the Disconnect Finch Screen
        /// </summary>
        private static void DisplayDisconnectFinch()
        {
            DisplayConsoleUI("Let's get disconnected!");
            Console.WriteLine("Let's get your Finch disconnected.");
            DisplayContinuePrompt();
            if (DisconnectFinch())
            {
                DisplayConsoleUI("Finch is disconnected");
                Console.WriteLine("Sweet, your Finch is Disconnected");
                DisplayContinuePrompt();
            }
        }

        /// <summary>
        /// Disconnect the Finch Robot
        /// </summary>
        private static bool DisconnectFinch()
        {
            bool disconnected = false;
            myFinch.disConnect();
            if (myFinch.disConnect())
            {
                disconnected = true;
                return disconnected;
            }
            else
            {
                return disconnected;
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Displays the user Continue Prompt
        /// </summary>
        private static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        /// <summary>
        /// Quits the Application
        /// </summary>
        private static void quit()
        {
            Environment.Exit(0);
        }
        #endregion
    } 
}