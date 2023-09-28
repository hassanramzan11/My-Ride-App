using System;

using LocationLibrary;
using DriverLibrary;
using VehicleLibrary;
using System.Linq.Expressions;
using PassengerLibrary;
using RideLibrary;
using AdminLibrary;

namespace HomeWork_1
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "My Ride App";

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\tWELCOME TO MYRIDE ");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Admin admin = new Admin();
            Driver driverToEnter = new Driver();
            //admin.ReadDrivers();
            admin.readFromDataBases();

            while (true)
            {
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("1. Book a Ride");
                Console.WriteLine("2. Enter as Driver");
                Console.WriteLine("3. Enter as Admin");

                Console.Write("Press 1 to 3 to select an option OR to quit (0 , 4 to 9): ");

                
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        // code block
                        Console.Clear();
                        Console.WriteLine("------------------Book a Ride------------------");
                        Console.WriteLine();
                        
                        Console.Write("Enter Name: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string ?Name = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Enter Phone Number: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string? Phone_Number;
                        while (true) 
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            bool flag = true;
                            Phone_Number = Console.ReadLine();  
                            for (int i = 0; i < Phone_Number.Length; i++)
                            {
                                if (!Char.IsDigit(Phone_Number[i]))
                                {
                                    flag = false;
                                    break;
                                }                                
                            }
                            if (flag)
                            {
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error Enter the Phone number again");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Enter Phone Number: ");

                        }
                        Console.ForegroundColor = ConsoleColor.White;


                        //Start Location 
                        Console.WriteLine("Enter Start Location: ");
                            Console.ForegroundColor= ConsoleColor.DarkCyan;
                            Console.Write("Enter Latitude : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string? LatitudeString1 = Console.ReadLine();
                            float latitude1 = float.Parse(LatitudeString1);                        
                            Console.ForegroundColor = ConsoleColor.White;
                            
                            Console.ForegroundColor= ConsoleColor.DarkCyan;
                            Console.Write("Enter Longitude : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string? LongitudeString1 = Console.ReadLine();
                            float longitude1 = float.Parse(LongitudeString1);
                        //End Location 
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter End Location: ");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("Enter Latitude : ");                        
                            Console.ForegroundColor = ConsoleColor.Green;
                            string? LatitudeString2 = Console.ReadLine();
                            float latitude2 = float.Parse(LatitudeString2);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("Enter Longitude : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string? LongitudeString2 = Console.ReadLine();
                            float longitude2 = float.Parse(LongitudeString2);
                            Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Enter Ride Type: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string ?car = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        Passenger passenger1 = new Passenger(Name, Phone_Number);
                        Location Start = new Location(latitude1, longitude1);
                        Location End = new Location(latitude2, longitude2);
                        Ride ride1 = new Ride();
                        ride1.assignPassenger(passenger1);
                        ride1.getLocation(Start, End);
                        ride1.CalculatePrice(car);                                             
                        ride1.assignDriver(admin,car);
                        
                        

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("------------------Driver Menu------------------:");
                        Console.WriteLine("Enter ID: ");
                        string? Driver_ID ;
                        Console.ForegroundColor = ConsoleColor.Green;
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            bool flag = true;
                            Driver_ID = Console.ReadLine();
                            for (int i = 0; i < Driver_ID.Length; i++)
                            {
                                if (!Char.IsDigit(Driver_ID[i]))
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error Enter the ID again");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Enter ID: ");

                        }
                      
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter Name : ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string? driverName = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        driverToEnter = admin.findDriver(Driver_ID, driverName);
                        if (driverToEnter != null)
                        {
                            Console.WriteLine($"Hello {driverToEnter.Name} !");
                            try
                            {
                                driverToEnter.UpdateLocation();

                                
                                Console.WriteLine("1. Change availability");
                                Console.WriteLine("2. Change location");
                                Console.WriteLine("3. See Drivers Rating");
                                Console.WriteLine("4. Exit as driver");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Your Choice is : ");
                                int inputValue = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;

                                switch (inputValue)
                                {
                                    case 1:
                                        Console.WriteLine("Change Availaibility");
                                        driverToEnter.UpdateAvailability();
                                        admin.updateDataBase(driverToEnter, Driver_ID);
                                        
                                        break;
                                    case 2:
                                        Console.WriteLine("Change Location");
                                        driverToEnter.UpdateLocation();
                                        admin.updateDataBase(driverToEnter, Driver_ID);
                                        break;
                                    case 3:
                                        int rat = driverToEnter.GetRating();
                                        Console.WriteLine($"The Driver Rating is {rat}");
                                        break;
                                    case 4:
                                        Console.WriteLine("You Exit as a Driver");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input");
                                        break;
                                }

                            }
                            catch (NullReferenceException ex)
                            {
                                Console.WriteLine("LATITUDE AND LONGITUDE ARE NULL {0}", ex.Message);
                                // Handle the exception, e.g. throw a custom exception or log the error
                            }
                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Driver not found. Please try again.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                       // admin.WriteDriversToFile();
                        break;
                    case 3:
                        Console.WriteLine("------------------Admin Menu------------------");
                        admin.Case();
                        //admin.WriteDriversToFile();


                        break;

                    default:
                        Console.WriteLine("---------------------BYE-----------------------");
                        break;
                }
                
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.Write("\nDo you want to go To MainMenu (y/n) or (Y/N): ");
                Console.ForegroundColor = ConsoleColor.Green;
                string? input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (input.ToLower() != "y")
                {
                    break; // exit outer loop
                }
                Console.Clear();
                
            }
        }
    }
}

