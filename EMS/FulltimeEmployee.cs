
/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : FulltimeEmployee.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Class definition and functions for Fulltime Employee class.
 */
using Supporting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    /// 
/// \class FulltimeEmployee
///
/// \brief The purpose of this class is to validate and temporarily keep the attributes of the full-time employee.
///
/// Attributes:
/// - dateOfHire: the date of hiring
/// - dateOfTermination: the date of termination of the hiring
/// - salary: the money for the hiring
/// 
/// Relationships:
/// - This is the child class of Employee class
/// 
/// Fault Detection:
/// - Return false when there is any bad situation
///
    public class FulltimeEmployee : Employee
    {
        /* ------------------------------------------ */
        /* --------------- ATTRIBUTES --------------- */
        /* ------------------------------------------ */
        private string dateOfHire;
        private string dateOfTermination;
        private string salary;


        /* ------------------------------------------ */
        /* ---------------- ACCESSORS --------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This accessor is used to get the date of hire of the employee
        /// \details <b>Details</b>
        ///
        /// \return the date of hire of the employee
        ///
        /// \see getDateOfHire
        ///
        public string getDateOfHire()
        {
            return dateOfHire;
        }

        ///
        /// \brief This accessor is used to get the date of termination of the employee
        /// \details <b>Details</b>
        ///
        /// \return the date of termination of the employee
        ///
        /// \see getDateOfTermination
        ///
        public string getDateOfTermination()
        {
            return dateOfTermination;
        }

        ///
        /// \brief This accessor is used to get the salary of the employee
        /// \details <b>Details</b>
        ///
        /// \return the salary of the employee
        ///
        /// \see getSalary
        ///
        public string getSalary()
        {
            return salary;
        }


        /* ------------------------------------------ */
        /* -------------- CONSTRUCTORS -------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This constructor is used to initialize each attribut to a blank
        ///
        /// \see FulltimeEmployee
        ///
        public FulltimeEmployee()
        {
            dateOfHire = "";
            dateOfTermination = "";
            salary = "";
        }

        ///
        /// \brief This constructor is used to set the value of attribute dateOfHire
        /// \details <b>Details</b>
        ///
        /// \param inDate - <b>string</b> - representation of the input date from user
        ///
        /// \return True if attribute dateOfHire is set; False otherwise
        ///
        /// \see setDateOfHire
        ///
        public bool setDateOfHire(string inDate)
        {
            if (Validate_Dates(inDate))
            {
                dateOfHire = inDate;
                return true;
            }
            else
            {
                SendLog_Attempt("Date of Hire", inDate);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute dateOfTermination
        /// \details <b>Details</b>
        ///
        /// \param inDate - <b>string</b> - representation of the input date from user
        ///
        /// \return True if attribute dateOfTermination is set; False otherwise
        ///
        /// \see setDateOfTermination
        ///
        public bool setDateOfTermination(string inDate)
        {
            if (inDate == "")
            {
                dateOfTermination = inDate;
                return true;
            }
            else if (Validate_Dates(inDate))
            {
                if (Compare_TwoDates(getDateOfHire(), inDate))
                {
                    dateOfTermination = inDate;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                SendLog_Attempt("Date of Termination", inDate);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute salary
        /// \details <b>Details</b>
        ///
        /// \param inNumber - <b>string</b> - representation of the input number from user
        ///
        /// \return True if attribute salary is set; False otherwise
        ///
        /// \see setSalary
        ///
        public bool setSalary(string inNumber)
        {
            if (Validate_Numbers(inNumber))
            {
                salary = inNumber;
                return true;
            }
            else
            {
                SendLog_Attempt("Salary", inNumber);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set all attributes of a full-time employee
        /// \details <b>Details</b>
        ///
        /// \param inFName - <b>string</b> - representation of the input first name from user
        /// \param inLName - <b>string</b> - representation of the input last name from user
        /// \param inSIN - <b>string</b> - representation of the input social insurance number from user
        /// \param inDateOfBirth - <b>string</b> - representation of the input date of birth from user
        /// \param inDateOfHire - <b>string</b> - representation of the date of hire from user
        /// \param inDateOfTermination - <b>string</b> - representation of the date of termination from user
        /// \param inSalary - <b>string</b> - representation of the input salary from user
        ///
        /// \return True if all attributes are set; False otherwise
        ///
        /// \see setAllAttributes
        ///
        public bool setAllAttributes(string inFName, string inLName, string inSIN, string inDateOfBirth,
            string inDateOfHire, string inDateOfTermination, string inSalary)
        {
            bool ret = false;
            if (setFirstName(inFName))
            {
                if (setLastName(inLName))
                {
                    if (setDateOfBirth(inDateOfBirth))
                    {
                        if (setSocialInsuranceNumber(inSIN))
                        {
                            if (setDateOfHire(inDateOfHire))
                            {
                                if (setDateOfTermination(inDateOfTermination))
                                {
                                    if (setSalary(inSalary))
                                    {
                                        ret = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ret;
        }


        /* ------------------------------------------ */
        /* ----------------- METHODS ---------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This method is used to output (to the screen) all attribute values for an employee
        ///
        /// \return True if all details were displayed; False otherwise
        /// 
        /// \see Details
        ///
        public bool Details()
        {
            bool ret = false;
            if (getLastName() != "")
            {
                string output;
                output = "First Name: " + getFirstName();
                output += "\nLast Name: " + getLastName();
                output += "\nSocial Insurance Number: " + getSocialInsuranceNumber();
                output += "\nDate of Birth: " + getDateOfBirth();
                output += "\nDate of Hire: " + getDateOfHire();
                output += "\nDate of Termination: " + getDateOfTermination();
                output += "\nSalary: " + getSalary();

                try
                {
                    Console.WriteLine(output);
                    SendLog_Details(output);
                    ret = true;
                }
                catch (Exception)
                {
                    ret = false;
                }
            }
            return ret;
        }

        ///
        /// \brief This method is used to ensure all current attribute settings are in fact valid for this employee type
        /// \details <b>Details</b>
        ///
        /// \return True if all current attribute settings are valid; False otherwise
        ///
        /// \see Validate
        ///
        public bool Validate()
        {
            bool ret = false;
            if (Validate_Name(getFirstName()))
            {
                if (Validate_Name(getLastName()))
                {
                    if (Validate_SIN(getSocialInsuranceNumber()))
                    {
                     //   if (Validate_Dates(getDateOfBirth())) //&&
                          //  Compare_TwoDates(getDateOfBirth(), DateTime.Now.ToString("yyyy-MM-dd")))
                       // {
                            if (Validate_Dates(getDateOfHire()))
                            {
                                if (getDateOfTermination() == "")
                                {
                                    if (Validate_Numbers(getSalary()))
                                    {
                                        ret = true;
                                    }
                                }
                                else
                                {
                                    if (Validate_Dates(getDateOfTermination()) &&
                                        Compare_TwoDates(getDateOfHire(), getDateOfTermination()))
                                    {
                                        if (Validate_Numbers(getSalary()))
                                        {
                                            ret = true;
                                        }
                                    }
                                }
                            }
                        }
                 //   }
                }
            }
            //SendLog_Validate(getFirstName(), getLastName(), getSocialInsuranceNumber(), ret);
            return ret;
        }


    }
}
