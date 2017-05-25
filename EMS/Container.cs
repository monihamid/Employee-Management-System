/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : Container.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Class definition and functions for Container class library.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllEmployees;
using Supporting;

namespace TheCompany
{
    /// 
    /// \class Container
    ///
    /// \brief The container class holds the database in memory while the program is running.
    /// It allows for immediate access to the database for add/deleting/modifying of employees.
    ///
    /// Attributes:
    /// - None
    /// 
    /// Relationships:
    /// - This class is used by the presentation class and the Supporting class in order to easily access employees
    /// 
    /// Fault Detection:
    /// - Only allows employees to be saved
    /// - Will not allow you to traverse outside the list's index
    /// 
    ///

    public class Container
    {

        Random rand = new Random();
        FileIO fio = new FileIO();
        Logging log = new Logging();
        int listPos = 0; //position
        private List<Employee> container = new List<Employee>(); //create list


        //
        // FUNCTION : getEmployeeAtIndex
        // DESCRIPTION : Finds an employee by its index
        // PARAMETERS :  int index- index to lookup
        // RETURNS : Employee -the found employee
        //
        ///
        /// \brief Retrieves the employee of the given index
        /// \details <b>Details</b>
        ///
        /// \param int index - the index of the employee to look up
        ///
        /// \return Employee - the employee that was found
        /// 
        /// \see getEmployeeAtIndex
        ///
        Employee getEmployeeAtIndex(int index) //lookup by index
        {
            if (index > -1 && index < container.Count)
            {
                return container[index];
            }

            return null;

        }

        //
        // FUNCTION : getEmployeeAtCurrentPosition
        // DESCRIPTION : Finds Info by employee at the given position in the list
        // PARAMETERS : none
        // RETURNS : Employee - found employee
        //
        ///
        /// \brief Retrieves the employee at the current position of the container
        /// \details <b>Details</b>
        ///
        /// \return Employee - the found employee
        /// 
        /// \see getEmployeeAtCurrentPosition
        ///
        public Employee getEmployeeAtCurrentPosition() //get employee at current postion
        {
            return getEmployeeAtIndex(listPos);
        }

        //
        // FUNCTION : stepThroughContainer
        // DESCRIPTION : steps ahead one employee in the list
        // PARAMETERS : 
        // RETURNS : 
        //
        ///
        /// \brief Traverses ahead one in the list by one
        /// \details <b>Details</b>
        /// \return int - 0 on success
        /// 
        /// \see stepThroughContainer
        ///
        public int stepThroughContainer()
        {
            if(listPos == 0 && container.Count == 1)
            {
                listPos++;
                return 0;
            }

            if (listPos < container.Count -1) //step ahead one in index.
            {
                listPos++;
                return 0;
            }

            return 0;
        }


        //
        // FUNCTION : deleteEmployeeAtIndex
        // DESCRIPTION : Deletes the employee at the index provide
        // PARAMETERS :  int index- index to lookup
        // RETURNS : int - 0 on success
        //
        ///
        /// \brief Deletes the employee from the container at the index provide
        /// \details <b>Details</b>
        ///
        /// \param int index - the index of the employee to look up
        ///
        /// \return int - 0 on sucess
        /// 
        /// \see deleteEmployeeAtIndex
        ///
        int deleteEmployeeAtIndex(int index)
        {
            if (index > -1 && index <= container.Count) //does the index exist?
            {
                container.RemoveAt(index); //delete
                return 0;
            }

            return -1; //failed
        }

        //
        // FUNCTION : deleteEmployeeAtCurrentPosition
        // DESCRIPTION : Deletes the employee at the containers current position in the list
        // RETURNS : int - 0 on success
        //
        ///
        /// \brief Deletes the employee at the containers current position in the list
        /// \details <b>Details</b>
        ///
        /// \return int - 0 on sucess
        /// 
        /// \see deleteEmployeeAtCurrentPosition
        ///
       public int deleteEmployeeAtCurrentPosition()
        {
            if (listPos > -1 && listPos <= container.Count) //does the index exist?
            {
                container.RemoveAt(listPos); //delete
                return 0;
            }

            return -1; //failed
        }


       

        //
        // FUNCTION : overwriteEmployeeAtCurrentPosition
        // DESCRIPTION : Overwrites an Employee at the current position in list
        // PARAMETERS :  Employee - new contents
        // RETURNS : Employee -the found employee
        //
        ///
        /// \brief Overwrites an Employee at the current position in list, maintains date created
        /// \details <b>Details</b>
        ///
        /// \param 
        /// Employee emp - the new content of employee
        ///
        /// \return int - 0 on success
        /// 
        /// \see overwriteEmployeeAtCurrentPosition
        ///
        public int overwriteEmployeeAtCurrentPosition(Employee emp)
        {
            if (listPos > -1 && listPos <= container.Count)
            {
                container[listPos] = emp; //overwrite the employee
                return 0;
            }

            return -1; //failed
        }

        //
        // FUNCTION : backupThroughContainer
        // DESCRIPTION : takes a step back in the current position of the list
        // PARAMETERS :
        // RETURNS : int
        //
        ///
        /// \brief takes a step back in the current position of the list
        /// \details <b>Details</b>
        ///
        /// \return int - 0 on success
        /// 
        /// \see backupThroughContainer
        ///
        public int backupThroughContainer() //back up index
        {
            if (listPos > 0)
            {
                listPos--;
                return 0;
            }

            return -1;
        }

        public int getCurrentPosition()
        {
            return listPos;
        }


        //
        // FUNCTION : jumpPostion
        // DESCRIPTION : Jumps to a new position in the list by given index
        // PARAMETERS : int - index
        // RETURNS :int - 0 on success
        //
        ///
        /// \brief takes a step back in the current position of the list
        /// \details <b>Details</b>
        /// \param int index - index to jump to 
        /// \return int - 0 on success
        /// 
        /// \see backupThroughContainer
        ///
        int jumpPosition(int index) //jump to position in index
        {
            if (index > -1 && index <= container.Count)
            {
                listPos = index;
                return 0;
            }

            return -1;
        }

        public int getNumberOfEmployees()
        {
            return container.Count();
        }

        //
        // FUNCTION : addEmployeeToContainer
        // DESCRIPTION : Adds an employee to the container
        // PARAMETERS : Employee
        // RETURNS :int - 0 on success
        //
        ///
        /// \brief Adds an employee to the container
        /// \details <b>Details</b>
        /// \param Employee inc - the new employee to be added
        /// \return int - 0 on success
        /// 
        /// \see addEmployeeToContainer
        ///
        public int addEmployeeToContainer(Employee inc) //add employee
        {
            bool isValid = false;
            if(inc is FulltimeEmployee)
            {
                FulltimeEmployee ft = (FulltimeEmployee)inc;
                isValid = ft.Validate();
            }
            else if(inc is ParttimeEmployee)
            {
                ParttimeEmployee pt = (ParttimeEmployee)inc;
                isValid = pt.Validate();
            }
            else if (inc is SeasonalEmployee)
            {
                SeasonalEmployee s = (SeasonalEmployee)inc;
                isValid = s.Validate();
            }
            else if (inc is ContractEmployee)
            {
                ContractEmployee c = (ContractEmployee)inc;
                isValid = c.Validate();
            }

            if(isValid == true)
            {
                container.Add(inc);
            }
            else
            {
                log.Log("Container", "Invalid Employee", "Container rejected an employee due to failed validation");
            }

            return container.Count();
        }


        ///
        /// \brief saveContainerToDatabase
        /// \details <b>Details</b>
        /// \description: uses the supporting class to save container to database 
        /// \see saveContainerToDatabase
        ///
        public void saveContainerToDatabase()
        {
            log.Log("Container", "Database", "Container has started an update to the database");

            listPos = 0;
           
            fio.deleteDB();
            for (int i = 0; i < container.Count(); i++)
            {
                Employee emp = getEmployeeAtCurrentPosition();

                if (emp is FulltimeEmployee)
                {
                    FulltimeEmployee ft = (FulltimeEmployee)emp;
                    fio.appendToDatabase(ft);
                }
                if (emp is ParttimeEmployee)
                {
                    ParttimeEmployee pt = (ParttimeEmployee)emp;
                    fio.appendToDatabase(pt);
                }
                if (emp is SeasonalEmployee)
                {
                    SeasonalEmployee s = (SeasonalEmployee)emp;
                    fio.appendToDatabase(s);
                }
                if (emp is ContractEmployee)
                {
                    ContractEmployee c = (ContractEmployee)emp;
                    fio.appendToDatabase(c);
                }
                stepThroughContainer();

            }
            listPos = 0;
            log.Log("Container", "Database", "Container has finished an update to the database");
        }

        ///
        /// \brief loadDatabaseToContainer
        /// \details <b>Details</b>
        /// \description: uses the supporting to load the database into the container
        /// \see saveContainerToDatabase
        ///
        public void loadDatabaseToContainer()
        {
            log.Log("Container", "Load", "Container has started loading from the database");
            container.Clear();
            listPos = 0;
            for (int i = 0; i < fio.getAmountOfRecords() +1; i++)
            {
                container.Add(fio.readRow(getCurrentPosition()));
                stepThroughContainer();
            }
            listPos = 0;
            log.Log("Container", "Load", "Container has finished loading from the database");
        }
        }

    }
