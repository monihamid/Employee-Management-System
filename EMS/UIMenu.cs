/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : UIMenu.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Class definition and functions for Presentation class library.
 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllEmployees;
using TheCompany;
using Supporting;




namespace Presentation
{

   


    enum mainMenu
    {
        kMenuNothing = 0,     /// special constant for initialization only
        emsDataBase = 1,
        manageEmployee,
        kMenuQuit = 9
    };

    enum fileManagementMenu
    {
        kMenuNothing = 0,
        loadDatabase,
        saveEmployee,
        returnToMain = 9
    };

    enum employeeManagementMenu
    {
        kMenuNothing = 0,
        displayEmployee = 1,
        creatNewEmployee,
        modifyEmployee,
        removeEmployee,
        returnToMain = 9
    };
    enum employeeDetailsMenu
    {
        kMenuNothing = 0,
        fullTimeEmployee,
        partTimeEmlployee,
        contractEmployee,
        seasonalEmployee,
        baseEmployee,

        returnToEmployeeManagement = 9
    };



    /// 
    /// \class UIMenu  
    ///
    /// \brief The purposr of this class is intaracting between user and the EMS-Net Application.
    ///
    /// The UIMenu class has a reference to all other classes, so it can interact with all other classes to implement the purpose of the project.
    /// attribute  userInputFirstName  - <b>string</b> - takes user input as First name
    /// attribute  userInputLastName - <b>string</b> -  takes user input as Last name
    /// attribute  userInputDateOfBirth- <b>string</b> - takes user input as Date of birth
    /// attribute  userInputSIN - <b>string</b> - takes user input as Sicial Insurence Number
    /// attribute  userInputDateOfHire - <b>string</b> - takes user input as Date of Hire
    /// attribute  userInputDateOfTermination - <b>string</b> - takes user input as Date of termination
    ///  
    /// Relationships:
    /// - This class is intaract between user and the EMS-Net system to manage the data base
    /// 
    /// Fault Detection:
    /// - Confirms user enter a valid data(primary checking).
    /// \author <i>M. Sultana</i>
    /// 

    public class UIMenu
    {


        /* -------------- ATTRIBUTES ------------ */

        string userInputFirstName;                         ///< User input fields
        string userInputLastName;
        string userInputDateOfBirth;
        string userInputSIN;
        string userInputDateOfHire;
        string userInputDateOfTermination;
        string userInputSalary;
        string userInputHourlyRate;
        ///
        /// \brief Calls upon display the Main Menu options.
        /// \details <b>Details</b>       
        /// \It display the Main Menu options what user can do or what information they can save in this Application. 
        ///
        /// \param[in]  Nothing
        /// \return Nothing
        ///
        Logging log = new Logging();
        Container mydata = new Container();
        public void showMainMenu()
        {
            mainMenu choice = mainMenu.kMenuNothing;
            int selection = 0;


            do
            {
                Console.Clear();


                Console.WriteLine("EMS-Net 1.0.0\n");
                Console.WriteLine("===============\n\n");

                Console.WriteLine("MAIN MENU\n");
                Console.WriteLine("1.  Manage EMS Data Base files\n");
                Console.WriteLine("2.  Manage Employees\n");
                Console.WriteLine("9.  Quit\n\n");


                Console.WriteLine("\nMake a selection from the menu\n");
                String input = Console.ReadLine();
                
                if (Int32.TryParse(input, out selection))
                {
                    choice = (mainMenu)selection;
                }
                switch (choice)
                {

                    case mainMenu.emsDataBase:
                        {
                            showFileManageMenu();
                            break;
                        }
                    case mainMenu.manageEmployee:
                        {
                            showEmployeeManageMenu();
                            break;
                        }


                    case mainMenu.kMenuQuit:
                        {
                            Console.WriteLine("\nThank you for using EMS-NET.\n");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid selection. Please try again.\n");
                            break;
                        }

                }



            } while (choice != mainMenu.kMenuQuit);

        }

        ///
        /// \brief Calls upon display the File Manage Menu option.
        /// \details <b>Details</b>
        ///
        /// \It display all the options what user can do to manage the database-load the database or save the database. 
        ///
        /// \param[in]  Nothing
        /// \return Nothing
        ///
        public void showFileManageMenu()
        {
            fileManagementMenu choice = fileManagementMenu.kMenuNothing;
            int selection = 0;


            do
            {
                Console.Clear();
                Console.WriteLine("===============\n\n");
                Console.WriteLine("FILE MANAGEMENT MENU\n");
                Console.WriteLine("1.  Load EMS Data Base from file\n");
                Console.WriteLine("2.  Save Employee Set to EMS DBase file\n");
                Console.WriteLine("9.  Return to Mani Menu\n\n");
                Console.WriteLine("\nMake a selection from the menu\n");
                String input = Console.ReadLine();

                if (Int32.TryParse(input, out selection))
                {
                    choice = (fileManagementMenu)selection;
                }

                choice = (fileManagementMenu)selection;

                switch (choice)
                {

                    case fileManagementMenu.loadDatabase:
                        {
                            mydata.loadDatabaseToContainer();
                            break;
                        }
                    case fileManagementMenu.saveEmployee:
                        {
                            mydata.saveContainerToDatabase();
                            break;
                        }


                    case fileManagementMenu.returnToMain:
                        {

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid selection. Please try again.\n");
                            break;
                        }
                }




            } while (choice != fileManagementMenu.returnToMain);

        }


        ///
        /// \brief Calls upon display Employee Manage Menu options.
        /// \details <b>Details</b>       
        /// \It display the Main Menu options what user can do or what information they can save in this Application. 
        ///
        /// \param[in]  Nothing
        /// \return Nothing
        ///
        public void showEmployeeManageMenu()
        {
            employeeManagementMenu choice = employeeManagementMenu.kMenuNothing;
            int selection = 0;


            do
            {
                Console.Clear();
                Console.WriteLine("===============\n\n");
                Console.WriteLine("EMPLOYEE MANAGEMENT MENU\n");
                Console.WriteLine("1.  Display Employee Set\n");
                Console.WriteLine("2.  Create a NEW Employee\n");
                Console.WriteLine("3.  Modify an EXISTING Employee\n");
                Console.WriteLine("4.  Remove an EXISTING Employee\n");
                Console.WriteLine("9.  Return to Main Menu\n\n");
                Console.WriteLine("\nMake a selection from the menu\n");
                String input = Console.ReadLine();

                if (Int32.TryParse(input, out selection))
                {
                    choice = (employeeManagementMenu)selection;
                }

                choice = (employeeManagementMenu)selection;

                switch (choice)
                {

                    case employeeManagementMenu.displayEmployee:
                        {
                            traverseEmployees();
                            

                            break;
                        }
                    case employeeManagementMenu.creatNewEmployee:
                        {
                            showEmployeeDetailMenu();
                            break;
                        }
                    case employeeManagementMenu.modifyEmployee:
                        {
                            traverseEmployees();

                            if (mydata.getNumberOfEmployees() > 0)
                            {
                                Console.WriteLine("What is the new employee type?");
                                Console.WriteLine("1. Fulltime");
                                Console.WriteLine("2. Parttime");
                                Console.WriteLine("3. Seasonal");
                                Console.WriteLine("4. Contract");
                                ConsoleKeyInfo keyInfo = Console.ReadKey();
                                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                                {
                                    createFullTimeEmployee(true);
                                }
                                else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                                {
                                    createPartTimeEmployee(true);
                                }
                                else if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
                                {
                                    createSeasonalEmployee(true);
                                }
                                else if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad4)
                                {
                                    createContractEmployee(true);
                                }
                            }
                                break;
                        }
                    case employeeManagementMenu.removeEmployee:
                        {
                            traverseEmployees();
                            if (mydata.getNumberOfEmployees() > 0)
                            {
                                mydata.deleteEmployeeAtCurrentPosition();
                                Console.WriteLine("Employee deteled. Press any key...");
                            }
                            break;
                        }

                    case employeeManagementMenu.returnToMain:
                        {

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid selection. Please try again.\n");
                            break;
                        }
                }




            } while (choice != employeeManagementMenu.returnToMain);

        }

        ///
        /// \brief Calls upon display Employee details Menu options.
        /// \details <b>Details</b>       
        /// \It display the Menu options what type of employee user wants to enter. And asked for specific information about employee. 
        ///
        /// \param[in]  Nothing
        /// \return Nothing
        ///
        public void showEmployeeDetailMenu()
        {
            employeeDetailsMenu choice = employeeDetailsMenu.kMenuNothing;
            int selection = 0;


            do
            {
                Console.Clear();
                Console.WriteLine("===============\n\n");
                Console.WriteLine("EMPLOYEE DETAILS MENU\n");
                Console.WriteLine(" Select what types Employee would like to add\n");
                Console.WriteLine("1.  full Time Employee \n");         //need to write later details
                Console.WriteLine("2.  Part Time Emlployee \n");
                Console.WriteLine("3.  Contract Employee\n");
                Console.WriteLine("4.  SeasonalEmployee\n");
                Console.WriteLine("9.  Return to Emlpoyee Management Menu\n\n");
                Console.WriteLine("\nMake a selection from the menu\n");
                String input = Console.ReadLine();
                try
                {
                    selection = Int32.Parse(input);
                }
                catch(System.FormatException e)
                {
                    selection = 0;
                    log.Log("Presentation", "Exception", e.ToString());
                }
                

                choice = (employeeDetailsMenu)selection;

                switch (choice)
                {

                    case employeeDetailsMenu.fullTimeEmployee:
                        {
                            createFullTimeEmployee(false);
                            break;
                        }
                    case employeeDetailsMenu.partTimeEmlployee:
                        {
                            createPartTimeEmployee(false);
                            break;
                        }
                    case employeeDetailsMenu.contractEmployee:
                        {
                            createContractEmployee(false);
                            break;
                        }
                    case employeeDetailsMenu.seasonalEmployee:
                        {
                            createSeasonalEmployee(false);
                            break;
                        }
                   

                    case employeeDetailsMenu.returnToEmployeeManagement:
                        {

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid selection. Please try again.\n");
                            break;
                        }
                }




            } while (choice != employeeDetailsMenu.returnToEmployeeManagement);

        }

        
        
        ///
        /// \brief Calls upon create full time Employee as aspecified by user.
        /// \details <b>Details</b>       
        /// \It asked the user details information about employee. 
        ///
        /// \param[in]  Nothing
        /// \return Nothing
        ///
        public void createFullTimeEmployee(bool overwriteMode)
        {

            FulltimeEmployee fEmployee = new FulltimeEmployee();
            while (true)
            {
                Console.WriteLine("Please enter Employee's first name");
                userInputFirstName = Console.ReadLine();
                if (fEmployee.setFirstName(userInputFirstName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's last name");
                userInputLastName = Console.ReadLine();
                if (fEmployee.setLastName(userInputLastName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }

            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's Date of Birth");
                userInputDateOfBirth = Console.ReadLine();
                if (fEmployee.setDateOfHire(userInputDateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }

            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's Social Insurence Number");
                userInputSIN = Console.ReadLine();
                if (fEmployee.setSocialInsuranceNumber(userInputSIN))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's Date of Hire");
                userInputDateOfHire = Console.ReadLine();
                if (fEmployee.setDateOfHire(userInputDateOfHire))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's Date of Termination");
                userInputDateOfTermination = Console.ReadLine();
                if (fEmployee.setDateOfTermination(userInputDateOfTermination))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Plese enter Employee's salary");
                userInputSalary = Console.ReadLine();
                if (fEmployee.setSalary(userInputSalary))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }

            if (overwriteMode == true)
            {
                mydata.overwriteEmployeeAtCurrentPosition(fEmployee);
            }
            else
            {
                mydata.addEmployeeToContainer(fEmployee);
            }
        }

        ///
        /// \brief Calls upon create contract Employee as aspecified by user.
        /// \details <b>Details</b>       
        /// \It asked the user details information about employee. 
        ///
        /// \param[in]  Nothing
        /// \return Nothing
        ///
        public void createContractEmployee(bool overwriteMode) //need to add date of incorporation
        {
            ContractEmployee contractEmployee = new ContractEmployee();

            contractEmployee.setBusinessFirstName();
            while (true)
            {
                Console.WriteLine("Please enter the Business name");
                userInputLastName = Console.ReadLine();
                if (contractEmployee.setLastName(userInputLastName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }

            }
            while (true)
            {
                Console.WriteLine("Please enter date of incorporation");
                userInputDateOfBirth = Console.ReadLine();
                if (contractEmployee.setDateOfIncorporation(userInputDateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }

            }
            while (true)
            {
                Console.WriteLine("Please enter Business Number");
                userInputSIN = Console.ReadLine();
                if (contractEmployee.setBusinessNumber(userInputSIN))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter Contract start date");
                userInputDateOfHire = Console.ReadLine();
                if (contractEmployee.setContractStartDate(userInputDateOfHire))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter contract end date");
                userInputDateOfTermination = Console.ReadLine();
                if (contractEmployee.setContractStopDate(userInputDateOfTermination))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Plese enter contract amount");
                userInputSalary = Console.ReadLine();
                if (contractEmployee.setFixedContractAmount(userInputSalary))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }

            if (overwriteMode == true)
            {
                mydata.overwriteEmployeeAtCurrentPosition(contractEmployee);
            }
            else
            {
                mydata.addEmployeeToContainer(contractEmployee);
            }

        }
    

    ////
    /// \brief Calls upon create part time Employee as aspecified by user.
    /// \details <b>Details</b>       
    /// \It asked the user details information about employee. 
    ///
    /// \param[in]  Nothing
    /// \return Nothing
    ///
    ////
    /// \brief Calls upon create part time Employee as aspecified by user.
    /// \details <b>Details</b>       
    /// \It asked the user details information about employee. 
    ///
    /// \param[in]  Nothing
    /// \return Nothing
    ///
    public void createPartTimeEmployee(bool overwriteMode)
    {
        ParttimeEmployee partTimeEmployee = new ParttimeEmployee();
        while (true)
        {
            Console.WriteLine("Please enter Employee's first name");
            userInputFirstName = Console.ReadLine();
            if (partTimeEmployee.setFirstName(userInputFirstName))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input try again\n");
            }
        }
        while (true)
        {
            Console.WriteLine("Please enter Employee's last name");
            userInputLastName = Console.ReadLine();
            if (partTimeEmployee.setLastName(userInputLastName))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input try again\n");
            }

        }
        while (true)
        {
            Console.WriteLine("Please enter Employee's Date of Birth");
            userInputDateOfBirth = Console.ReadLine();
            if (partTimeEmployee.setDateOfBirth(userInputDateOfBirth))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input try again\n");
            }

        }
        while (true)
        {
            Console.WriteLine("Please enter Employee's Social Insurence Number");
            userInputSIN = Console.ReadLine();
            if (partTimeEmployee.setSocialInsuranceNumber(userInputSIN))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input try again\n");
            }
        }
        while (true)
        {
            Console.WriteLine("Please enter Employee's Date of Hire");
            userInputDateOfHire = Console.ReadLine();
            if (partTimeEmployee.setDateOfHire(userInputDateOfHire))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input try again\n");
            }
        }
        while (true)
        {
            Console.WriteLine("Please enter Employee's Date of Termination");
            userInputDateOfTermination = Console.ReadLine();
            if (partTimeEmployee.setDateOfTermination(userInputDateOfTermination))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input try again\n");
            }
        }
        while (true)
        {
            Console.WriteLine("Plese enter Employee's hourly wage");
            userInputSalary = Console.ReadLine();
            if (partTimeEmployee.setHourlyRate(userInputSalary))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input try again\n");
            }
        }

            if (overwriteMode == true)
            {
                mydata.overwriteEmployeeAtCurrentPosition(partTimeEmployee);
            }
            else
            {
                mydata.addEmployeeToContainer(partTimeEmployee);
            }
        }


        ///
        /// \brief Calls upon create seasonal Employee as aspecified by user.
        /// \details <b>Details</b>       
        /// \It asked the user details information about employee. 
        ///
        /// \param[in]  Nothing
        /// \return Nothing
        ///
        public void createSeasonalEmployee(bool overwriteMode)
        {
            SeasonalEmployee seasonalEmployee = new SeasonalEmployee();
            while (true)
            {
                Console.WriteLine("Please enter Employee's first name");
                userInputFirstName = Console.ReadLine();
                if (seasonalEmployee.setFirstName(userInputFirstName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's last name");
                userInputLastName = Console.ReadLine();
                if (seasonalEmployee.setLastName(userInputLastName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }

            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's Date of Birth");
                userInputDateOfBirth = Console.ReadLine();
                if (seasonalEmployee.setDateOfBirth(userInputDateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }

            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's Social Insurence Number");
                userInputSIN = Console.ReadLine();
                if (seasonalEmployee.setSocialInsuranceNumber(userInputSIN))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter Employee's Date of Hire");
                userInputDateOfHire = Console.ReadLine();
                if (seasonalEmployee.setSeason(userInputDateOfHire))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }
            //while (true)
            //{
            //    Console.WriteLine("Please enter Employee's Date of Termination");
            //    userInputDateOfTermination = Console.ReadLine();
            //    if (seasonalEmployee.setDateOfTermination(userInputDateOfTermination))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid input try again\n");
            //    }
            //}
            while (true)
            {
                Console.WriteLine("Plese enter Employee's salary");
                userInputSalary = Console.ReadLine();
                if (seasonalEmployee.setPiecePay(userInputSalary))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input try again\n");
                }
            }

            if (overwriteMode == true)
            {
                mydata.overwriteEmployeeAtCurrentPosition(seasonalEmployee);
            }
            else
            {
                mydata.addEmployeeToContainer(seasonalEmployee);
            }


        }

      
        public void traverseEmployees()
        {
            while(true)
            {
                Console.Clear();

                if (mydata.getNumberOfEmployees() < 1)
                {
                    Console.WriteLine("Container is empty... Press any key");
                    Console.ReadKey();
                    break;
                }

                
                Console.Write("Employee {0} of {1}\n",mydata.getCurrentPosition() + 1, mydata.getNumberOfEmployees());
                Console.WriteLine("===========================");
                Employee emp = mydata.getEmployeeAtCurrentPosition();

                if (emp is FulltimeEmployee)
                {
                    Console.WriteLine("FULLTIME EMPLOYEE");
                    FulltimeEmployee ft = (FulltimeEmployee)emp;
                    ft.Details();
                }
                else if (emp is ParttimeEmployee)
                {
                    Console.WriteLine("PARTTIME EMPLOYEE");
                    ParttimeEmployee pt = (ParttimeEmployee)emp;
                    pt.Details();
                }
                else if(emp is SeasonalEmployee)
                {
                    Console.WriteLine("SEASONAL EMPLOYEE");
                    SeasonalEmployee s = (SeasonalEmployee)emp;
                    s.Details();
                }
                else if (emp is ContractEmployee)
                {
                    Console.WriteLine("CONTRACT EMPLOYEE");
                    ContractEmployee c = (ContractEmployee)emp;
                    c.Details();

                }
                Console.WriteLine("===========================");
                Console.Write("Use arrow keys to traverse\n");
                Console.Write("Press 9 or Enter to return\n");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    mydata.backupThroughContainer();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    
                    mydata.stepThroughContainer();
                }
                else if (keyInfo.Key == ConsoleKey.D9 || keyInfo.Key == ConsoleKey.Enter)
                {
                    
                    break;
                }
            }
        }
    }
}



