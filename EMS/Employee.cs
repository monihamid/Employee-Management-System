/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : Employee.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Class definition and functions for Employee class library.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Supporting;

namespace AllEmployees
{
    /// 
/// \class Employee
///
/// \brief The purpose of this class is to validate and temporarily keep the base attributes of the employee.
///
/// Attributes:
/// - firstName: the first name of the employee
/// - lastName: the last name of the employee
/// - socialInsuranceNumber: the SIN of the employee
/// - dateOfBirth: the date of birth of the employee
/// 
/// Relationships:
/// - This is the parent class of ContractEmployee, FulltimeEmployee, ParttimeEmployee and SeasonalEmployee classes
/// 
/// Fault Detection:
/// - Return false when there is any bad situation
///
    public class Employee
    {
        /* ------------------------------------------ */
        /* --------------- ATTRIBUTES --------------- */
        /* ------------------------------------------ */
        protected string firstName;
        protected string lastName;
        private string socialInsuranceNumber;
        private string dateOfBirth;


        /* ------------------------------------------ */
        /* ---------------- ACCESSORS --------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This accessor is used to get the first name of the employee
        /// \details <b>Details</b>
        ///
        /// \return the first name of the employee
        ///
        /// \see getFirstName
        ///
        public string getFirstName()
        {
            return firstName;
        }

        ///
        /// \brief This accessor is used to get the last name of the employee
        /// \details <b>Details</b>
        ///
        /// \return the last name of the employee
        ///
        /// \see getLastName
        ///
        public string getLastName()
        {
            return lastName;
        }

        ///
        /// \brief This accessor is used to get the SIN of the employee
        /// \details <b>Details</b>
        ///
        /// \return the SIN of the employee
        ///
        /// \see getSocialInsuranceNumber
        ///
        public string getSocialInsuranceNumber()
        {
            return socialInsuranceNumber;
        }

        ///
        /// \brief This accessor is used to get the date of birth of the employee
        /// \details <b>Details</b>
        ///
        /// \return the date of birth of the employee
        ///
        /// \see getDateOfBirth
        ///
        public string getDateOfBirth()
        {
            return dateOfBirth;
        }


        /* ------------------------------------------ */
        /* -------------- CONSTRUCTORS -------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This constructor is used to initialize each attribut to a blank
        ///
        /// \see Employee
        ///
        public Employee()
        {
            firstName = "";
            lastName = "";
            socialInsuranceNumber = "";
            dateOfBirth = "";
        }

        ///
        /// \brief This constructor is used to set the value of attributes firstName and lastName
        /// \details <b>Details</b>
        ///
        /// \param inFNmae - <b>string</b> - representation of the input first name from user
        /// \param inLName - <b>string</b> - representation of the input last name from user
        ///
        /// \return True if attributes firstName and lastName are set; False otherwise
        ///
        /// \see setFullName
        ///
        public bool setFullName(string inFNmae, string inLName)
        {
            if (setFirstName(inFNmae))
            {
                if (setLastName(inLName))
                {
                    return true;
                }
                else
                {
                    SendLog_Attempt("Last Name", inLName);
                }
            }
            else
            {
                SendLog_Attempt("First Name", inFNmae);
            }
            return false;
        }

        ///
        /// \brief This constructor is used to set the value of attribute firstName
        /// \details <b>Details</b>
        ///
        /// \param inName - <b>string</b> - representation of the input name from user
        ///
        /// \return True if attribute firstName is set; False otherwise
        ///
        /// \see setFirstName
        ///
        public bool setFirstName(string inName)
        {
            if (Validate_Name(inName))
            {
                firstName = inName;
                return true;
            }
            else
            {
                SendLog_Attempt("First Name", inName);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute lastName
        /// \details <b>Details</b>
        ///
        /// \param inName - <b>string</b> - representation of the input name from user
        ///
        /// \return True if attribute lastName is set; False otherwise
        ///
        /// \see setLastName
        ///
        public bool setLastName(string inName)
        {
            if (Validate_Name(inName))
            {
                lastName = inName;
                return true;
            }
            else
            {
                SendLog_Attempt("Last Name", inName);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute socialInsuranceNumber
        /// \details <b>Details</b>
        ///
        /// \param inSIN - <b>string</b> - representation of the input SIN from user
        ///
        /// \return True if attribute socialInsuranceNumber is set; False otherwise
        ///
        /// \see setSocialInsuranceNumber
        ///
        public bool setSocialInsuranceNumber(string inSIN)
        {
            if (Validate_SIN(inSIN))
            {
                socialInsuranceNumber = inSIN;
                return true;
            }
            else
            {
                SendLog_Attempt("Social Insurance Number", inSIN);
                return false;
            }
        }

      

        ///
        /// \brief This constructor is used to set the value of attribute dateOfBirth
        /// \details <b>Details</b>
        ///
        /// \param inDate - <b>string</b> - representation of the input date from user
        ///
        /// \return True if attribute dateOfBirth is set; False otherwise
        ///
        /// \see setDateOfBirth
        ///
        public bool setDateOfBirth(string inDate)
        {
            if (Validate_Dates(inDate))
            {
                if(Compare_TwoDates(inDate, DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    dateOfBirth = inDate;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                SendLog_Attempt("Date of Birth", inDate);
                return false;
            }
        }

        ///
        /// \brief This method is used to make sure input name only contains letters, apostophe or a dash.
        /// \details <b>Details</b>
        ///
        /// \param inName - <b>string</b> - representation of the input name from user
        ///
        /// \return True if the input is valid, False otherwise
        ///
        /// \see Validate_Name
        ///
        public bool Validate_Name(string inName)
        {
            bool ret = false;
            if(Regex.IsMatch(inName, @"^[a-zA-Z'-]+$"))
            {
                ret = true;
            }
            return ret;
        }


        /* ------------------------------------------ */
        /* ----------------- METHODS ---------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This method is used to make sure input SIN is a valid number in Canada.
        /// \details <b>Details</b>
        ///
        /// \param inSIN - <b>string</b> - representation of the input SIN from user
        ///
        /// \return True if the input is valid, False otherwise
        ///
        /// \see Validate_SIN
        ///
        public bool Validate_SIN(string inSIN)
        {
            bool ret = false;
            if (Regex.IsMatch(inSIN, @"^[0-9]{3}\s[0-9]{3}\s[0-9]{3}$"))
            {
                char[] tmpdigits = inSIN.Where(Char.IsDigit).ToArray();
                int[] digits = new int[tmpdigits.Length];

                int j = 0;
                int sum = 0;
                for (int i = 0; i < tmpdigits.Length; i++)
                {
                    digits[i] = int.Parse(tmpdigits[i].ToString());
                    if (j == 0)
                    {
                        j = 1;
                        digits[i] *= 1;
                    }
                    else
                    {
                        j = 0;
                        digits[i] *= 2;
                    }
                    if (digits[i] >= 10)
                    {
                        digits[i] = digits[i] % 10 + digits[i] / 10;
                    }
                    sum += digits[i];
                }
                if (sum % 10 == 0 && sum != 0)
                {
                    ret = true;
                }
            }
            else if(Regex.IsMatch(inSIN, @"^[0-9]{5}\s[0-9]{4}$"))
            {
                ret = true;
            }
            return ret;
        }

        ///
        /// \brief This method is used to make sure the date input meets the real dates requirements.
        /// \details <b>Details</b>
        ///
        /// \param inDate - <b>string</b> - representation of the input date from user
        ///
        /// \return True if the input is valid, False otherwise
        ///
        /// \see Validate_Dates
        ///
        public bool Validate_Dates(string inDate)
        {
            bool ret = false;
            if (Regex.IsMatch(inDate, @"^[0-9]{4}-[0-9]{2}-[0-9]{2}$"))
            {
                string[] tmpymd = inDate.Split('-');
                int[] ymd = new int[tmpymd.Length];
                for (int i = 0; i < tmpymd.Length; i++)
                {
                    ymd[i] = Int32.Parse(tmpymd[i]);
                }

                try
                {
                    DateTime dt = new DateTime(ymd[0], ymd[1], ymd[2]);
                    ret = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    ret = false;
                }
            }
            return ret;
        }

        ///
        /// \brief This method is used to ensure the input early date is actually earlier than the input late date
        /// \details <b>Details</b>
        ///
        /// \param earlyDate - <b>string</b> - representation of the input early date
        /// \param lateDate - <b>string</b> - representation of the input late date
        ///
        /// \return True if the input early date is earlier than the input late date, False otherwise
        ///
        /// \see Compare_TwoDates
        ///
        public bool Compare_TwoDates(string earlyDate, string lateDate)
        {
            bool ret = false;

            string[] tmpEymd = earlyDate.Split('-');
            string[] tmpLymd = lateDate.Split('-');
            int[] Eymd = new int[tmpEymd.Length];
            int[] Lymd = new int[tmpLymd.Length];
            int[] subELymd = new int[tmpLymd.Length];

            for (int i = 0; i < tmpEymd.Length; i++)
            {
                Eymd[i] = Int32.Parse(tmpEymd[i]);
                Lymd[i] = Int32.Parse(tmpLymd[i]);
                subELymd[i] = Lymd[i] - Eymd[i];
            }

            int result = subELymd[0] * 10000 + subELymd[1] * 100 + subELymd[2];

            if (result >= 0)
            {
                ret = true;
            }

            return ret;
        }

        ///
        /// \brief This method is used to make sure the number input is equal or greater than zero.
        /// \details <b>Details</b>
        ///
        /// \param inNumber - <b>string</b> - representation of the input number from user
        ///
        /// \return True if the input is valid, False otherwise
        ///
        /// \see Validate_Numbers
        ///
        public bool Validate_Numbers(string inNumber)
        {
            bool ret = false;
            if (inNumber != "")
            {
                if (!Regex.IsMatch(inNumber, @"^[0]*$"))
                {
                    if (Regex.IsMatch(inNumber, @"^\d*\.?\d*$"))
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        ///
        /// \brief This method is used to send the log to logger when an attribute is attempting to be set
        /// \details <b>Details</b>
        ///
        /// \param attributeName - <b>string</b> - representation of attempting attribute name
        /// \param attemptValue - <b>string</b> - representation of attempting value
        ///
        /// \see SendLog_Attempt
        ///
        public void SendLog_Attempt(string attributeName, string attemptValue)
        {
            string nLog, nComments;

            nLog = "Attribute is attempting to be set, but is invalid";
            nComments = "\nAttribute Name: " + attributeName;
            nComments += "\nInvaild Value: " + attemptValue;

            Logging newLog = new Logging();
            newLog.Log("Employee", nLog, nComments);
        }

        ///
        /// \brief This method is used to send the log to logger when Validate method is called
        /// \details <b>Details</b>
        ///
        /// \param vfName - <b>string</b> - representation of validating frist name
        /// \param vlName - <b>string</b> - representation of validating last name
        /// \param vSIN - <b>string</b> - representation of validating social insurance number
        /// \param isValid - <b>string</b> - representation of whether the object is valid or not
        ///
        /// \see SendLog_Validate
        ///
        public void SendLog_Validate(string vfName, string vlName, string vSIN, bool isValid)
        {
            string nLog, nComments;

            nLog = "Validate method is called";
            nComments = "\nFirst Name: " + vfName;
            nComments += "\nLast Name: " + vlName;
            nComments += "\nSocial Insurance Number: " + vSIN;

            if (isValid == true)
            {
                nComments += "\nIsValid: True";
            }
            else
            {
                nComments += "\nIsValid: False";
            }
            
            Logging newLog = new Logging();
            newLog.Log("Employee", nLog, nComments);
        }

        ///
        /// \brief This method is used to send the log to logger when Details method is called
        /// \details <b>Details</b>
        ///
        /// \param details - <b>string</b> - representation of details of being displayed on the screen
        ///
        /// \see SendLog_Details
        ///
        public void SendLog_Details(string details)
        {
            string nLog, nComments;

            nLog = "Details method is called";
            nComments = "\n" + details;

            Logging newLog = new Logging();
            newLog.Log("Employee", nLog, nComments);
        }


    }
}
