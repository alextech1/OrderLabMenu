using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMenu
{
    public static class Program
    {
        public static PreferredCustomer[] preferredCustomers;

        public static string firstName { get; set; }
        public static string lastName { get; set; }
        public static double flashlight { get; private set; }
        public static double iphone { get; private set; }
        public static double printer { get; private set; }
        public static double laptop { get; private set; }
        public static double playstation { get; private set; }


        static void Main(string[] args)
        {
            GetPreferredCustomers(@"CustomerInfo.txt"); //Gets CustomerInfo.txt from bin/Debug/
            DisplayMainMenu();
        }

        //the method below uses text file to add elements to the array
        static void GetPreferredCustomers(string path)
        {
            List<string> customers = new List<string>();
            int count = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    count++;
                    customers.Add(sr.ReadLine());
                }
            }
            preferredCustomers = new PreferredCustomer[count];
            for (int i = 0; i < count; i++)
            {
                string[] info = customers[i].Split(':');
                PreferredCustomer pc = new PreferredCustomer(info[0], info[1], info[2], info[3], info[4], Int32.Parse(info[5]), Boolean.Parse(info[6]));
                preferredCustomers[i] = pc; //the array prefferedCustomers contains values
            }

        }
        public static void DisplayMainMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Menu!");
                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Make An Order");
                Console.WriteLine("2. Manage Customers");

                switch (ConsoleHelper.ReadInt32(0, 2))
                {
                    case 0: return;
                    case 1: DisplayCustomersMenu(); break;
                    case 2: GetID(); break;
                };

            } while (true);
        }

        private static void DisplayCustomersMenu()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Make An Order");

                Console.WriteLine($"What is your first name?");
                firstName = Console.ReadLine();
                Console.WriteLine($"What is your last name?");
                lastName = Console.ReadLine();

                string strTarget = String.Format("Hello, {0} {1}.", firstName, lastName);

                Console.WriteLine("{0}{1}{0}",
                                  Environment.NewLine, strTarget);

                Console.WriteLine("1) Select Customer");
                Console.WriteLine("0) Return to Manage Customers");

                switch (ConsoleHelper.ReadInt32(0, 3))
                {
                    case 0: return;
                    case 1:
                        {
                            do
                            {
                                Console.WriteLine("Enter the customer ID: ");
                                var id = ConsoleHelper.ReadRegexStringValue("10{5}\\d", "Enter Valid Customer ID"); //Read regular exp.

                                foreach (var customer in preferredCustomers)
                                {
                                    if (customer.CustomerID == id)
                                    {
                                        DisplayCustomerMenu(customer);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You are not in the database");
                                        break;
                                    }
                                }

                            } while (true);

                        }
                };
            } while (true);
        }


        public static void DisplayCustomerMenu(Customer customer)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Manage Customers");

                Console.WriteLine($"Custumer name, ID and current order");


                Console.WriteLine("1) Add to Order");
                Console.WriteLine("2) Remove from Order");
                Console.WriteLine("3) Finalize Order");
                Console.WriteLine("0) Return to Manage Customers");

                switch (ConsoleHelper.ReadInt32(0, 3))
                {
                    case 0: return;
                    case 1: AddToOrder(customer); break;
                    case 2: RemoveFromOrder(customer); break;
                    case 3: FinalizeOrder(customer); break;
                };
            } while (true);
        }


        public static void AddToOrder(Customer id)
        {
            Console.Clear();

            int numberOfInputForFlashlight = 0;
            int numberOfInputForIphone = 0;
            int numberOfInputForPrinter = 0;
            int numberOfInputForLaptop = 0;
            int numberOfInputForPlaystation = 0;

            int myint = -1;

            while (myint != 0)
            {
                string group;

                Console.WriteLine("Add To Order");
                Console.WriteLine("1) Flashlight");
                Console.WriteLine("2) iPhone 7");
                Console.WriteLine("3) Printer");
                Console.WriteLine("4) Dell Laptop");
                Console.WriteLine("5) Playstation 4");
                Console.WriteLine("6) View Total");

                Console.WriteLine("[Press 0 to quit]");

                group = Console.ReadLine();
                myint = Int32.Parse(group);

                switch (myint)
                {
                    case 0:
                        break;
                    case 1:
                        double input1;
                        string inputString1;
                        Console.WriteLine("How many flashlights do you want?");
                        inputString1 = Console.ReadLine();
                        input1 = Convert.ToDouble(inputString1);
                        flashlight += input1; //sets a counter
                        numberOfInputForFlashlight++;
                        break;
                    case 2:
                        double input2;
                        string inputString2;
                        Console.WriteLine("How many iPhone 7 do you want?");
                        inputString2 = Console.ReadLine();
                        input2 = Convert.ToDouble(inputString2);
                        iphone += input2;
                        numberOfInputForIphone++;
                        break;
                    case 3:
                        double input3;
                        string inputString3;
                        Console.WriteLine("How many Printers do you want?");
                        inputString3 = Console.ReadLine();
                        input3 = Convert.ToDouble(inputString3);
                        printer += input3;
                        numberOfInputForPrinter++;
                        break;
                    case 4:
                        double input4;
                        string inputString4;
                        Console.WriteLine("How many Dell Laptops do you want?");
                        inputString4 = Console.ReadLine();
                        input4 = Convert.ToDouble(inputString4);
                        laptop += input4;
                        numberOfInputForLaptop++;
                        break;
                    case 5:
                        double input5;
                        string inputString5;
                        Console.WriteLine("How many Playstion 4 do you want?");
                        inputString5 = Console.ReadLine();
                        input5 = Convert.ToDouble(inputString5);
                        playstation += input5;
                        numberOfInputForPlaystation++;
                        break;
                    case 6:  //views the total
                        Console.WriteLine("Flashlist quantity is {0}", flashlight.ToString("F"));
                        Console.WriteLine("iPhone 7 quantity is {0}", iphone.ToString("F"));
                        Console.WriteLine("Printer quantity is {0}", printer.ToString("F"));
                        Console.WriteLine("Dell Laptop quantity is {0}", laptop.ToString("F"));
                        Console.WriteLine("Playstation 4 quantity is {0}", playstation.ToString("F"));
                        Console.WriteLine("Flashlight total is {0}", (flashlight * 15.00).ToString("C"));
                        Console.WriteLine("iPhone 7 total is {0}", (iphone * 700.00).ToString("C"));
                        Console.WriteLine("Printer total is {0}", (printer * 80.00).ToString("C"));
                        Console.WriteLine("Dell Laptop total is {0}", (laptop * 500.00).ToString("C"));
                        Console.WriteLine("Playstation 4 total is {0}", (playstation * 380.00).ToString("C"));
                        break;

                    default:
                        Console.WriteLine("Incorrect input", myint);
                        break;
                }
            }

        }

        public static void FinalizeOrder(Customer customer)
        {
            do
            {
                Console.Clear();
                return;
            } while (true);
        }

        static void RemoveFromOrder(Customer customer)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Remove From Order:");
                Console.WriteLine("1) Flashlight total is {0}", (flashlight * 15.00).ToString("C"));
                Console.WriteLine("2) iPhone 7 total is {0}", (iphone * 700.00).ToString("C"));
                Console.WriteLine("3) Printer total is {0}", (printer * 80.00).ToString("C"));
                Console.WriteLine("4) Dell Laptop total is {0}", (laptop * 500.00).ToString("C"));
                Console.WriteLine("5) Playstation 4 total is {0}", (playstation * 380.00).ToString("C"));

                switch (ConsoleHelper.ReadInt32(0, 5))
                {
                    case 0: break;
                    case 1:
                        double input1;
                        string inputString1;
                        Console.WriteLine("How many flashlights do you want to remove?");
                        inputString1 = Console.ReadLine();
                        input1 = Convert.ToDouble(inputString1);
                        flashlight -= input1;  //sets a counter for removing
                        break;
                    case 2:
                        double input2;
                        string inputString2;
                        Console.WriteLine("How many iPhone 7 do you remove?");
                        inputString2 = Console.ReadLine();
                        input2 = Convert.ToDouble(inputString2);
                        iphone -= input2;
                        break;

                    case 3:
                        double input3;
                        string inputString3;
                        Console.WriteLine("How many Printers do you remove?");
                        inputString3 = Console.ReadLine();
                        input3 = Convert.ToDouble(inputString3);
                        printer -= input3;
                        break;
                    case 4:
                        double input4;
                        string inputString4;
                        Console.WriteLine("How many Dell Laptops do you remove?");
                        inputString4 = Console.ReadLine();
                        input4 = Convert.ToDouble(inputString4);
                        laptop += input4;
                        break;
                    case 5:
                        double input5;
                        string inputString5;
                        Console.WriteLine("How many Playstion 4 do you remove?");
                        inputString5 = Console.ReadLine();
                        input5 = Convert.ToDouble(inputString5);
                        playstation += input5;
                        break;

                };

            } while (true);
        }

        public static void GetID()
        {
            //id the user enters as input
            bool isFound = false;
            PreferredCustomer customer = null;
            do
            {
                Console.Write("Please enter user ID: "); //ID = 1000000
                var enteredID = ConsoleHelper.ReadRegexStringValue("10{5}\\d", "Enter Valid Customer ID"); //validates user Id using Regular expression 


                foreach (var cust in preferredCustomers)
                {
                    if (cust.CustomerID == enteredID)
                    {
                        isFound = true;
                        customer = cust;
                    }

                }
                if(!isFound)
                    Console.Write("ID does not exist. ");

            } while (!isFound);
            ShowCustomerInfo(customer);
        }

        public static void ShowCustomerInfo(PreferredCustomer customer)
        {
            using (var reader = new StreamReader("CustomerInfo.txt"))
            {
                var index = 0;
                preferredCustomers = new PreferredCustomer[5];
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(':');
                    var name = line[0];
                    var address = line[1];
                    var phone = line[2];
                    var id = line[3];
                    var email = line[4];
                    var spentAmount = Convert.ToInt32(line[5]);
                    var onEmailList = Convert.ToBoolean(line[6]);
                    preferredCustomers[index] = new PreferredCustomer(name, address, phone, id, email, spentAmount,
                        onEmailList);
                    index++;

                    Console.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}:{6}",
                        name, address, phone, id, email, spentAmount, onEmailList); //Shows customers info
                }
            }
            Console.WriteLine("Enter CustomerID which you want to delete (1-5):");
            var customerId = ConsoleHelper.ReadRegexStringValue("10{5}\\d", "Enter Valid Customer ID"); //Regular Expression

            var newCusomers = new List<PreferredCustomer>();
            foreach (var preferredCustomer in preferredCustomers)
            {
                if (preferredCustomer.CustomerID != customerId)
                {
                    newCusomers.Add(preferredCustomer);
                }
            }

            if (preferredCustomers.Length == newCusomers.Count)
            {
                Console.WriteLine("Customer was not found");
                return;
            }
            
            preferredCustomers = newCusomers.ToArray();
            using (var writer = new StreamWriter("CustomerInfo.txt"))
            {
                foreach (var pc in preferredCustomers)
                {
                    writer.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}:{6}",
                        pc.CustomerName, pc.Address, pc.Phone, pc.CustomerID, pc.CustomerEmail, pc.CalcAmount(), pc.OnEmailList);
                }
            }
            Console.WriteLine($"Customer {customerId} deleted successfully");
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("1. Display Customer Info");
            Console.WriteLine("2. Update Customer Info");
            Console.Write("Please enter your choice: ");
        }
    }
}

