/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : ContractEmployee.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Class definition and functions for ContractEmployee class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AllEmployees
{
    /// 
    /// \class ContractEmployee
    ///
    /// \brief The purpose of this class is to validate and temporarily keep the attributes of the contract employee.
    ///
    /// Attributes:
    /// - dateOfIncorporation: the date of incorporation
    /// - businessNumber: the business number of the contract
    /// - contractStartDate: the starting date of the contract
    /// - contractStopDate: the end date of the contract
    /// - fixedContractAmount: the money for this contract
    /// 
    /// Relationships:
    /// - This is the child class of Employee class
    /// 
    /// Fault Detection:
    /// - Return false when there is any bad situation

    public class ContractEmployee : Employee
    {
        /* ------------------------------------------ */
        /* --------------- ATTRIBUTES --------------- */
        /* ------------------------------------------ */
        private string dateOfIncorporation;
        private string businessNumber;
        private string contractStartDate;
        private string contractStopDate;
        private string fixedContractAmount;


        /* ------------------------------------------ */
        /* ---------------- ACCESSORS --------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This accessor is used to get the date of incorporation of the employee
        /// \details <b>Details</b>
        ///
        /// \return the date of incorporation of the employee
        ///
        /// \see getDateOfIncorporation
        ///
        public string getDateOfIncorporation()
        {
            dateOfIncorporation = getDateOfBirth();
            return dateOfIncorporation;
        }

        ///
        /// \brief This accessor is used to get the business number of the employee
        /// \details <b>Details</b>
        ///
        /// \return the business number of the employee
        ///
        /// \see getBusinessNumber
        ///
        public string getBusinessNumber()
        {
            businessNumber = getSocialInsuranceNumber();
            return businessNumber;
        }

        ///
        /// \brief This accessor is used to get the start date of contract of the employee
        /// \details <b>Details</b>
        ///
        /// \return the start date of contract of the employee
        ///
        /// \see getContractStartDate
        ///
        public string getContractStartDate()
        {
            return contractStartDate;
        }

        ///
        /// \brief This accessor is used to get the stop date of contract of the employee
        /// \details <b>Details</b>
        ///
        /// \return the stop date of contract of the employee
        ///
        /// \see getContractStopDate
        ///
        public string getContractStopDate()
        {
            return contractStopDate;
        }

        ///
        /// \brief This accessor is used to get the fixed contract amount of the employee
        /// \details <b>Details</b>
        ///
        /// \return the fixed contract amount of the employee
        ///
        /// \see getFixedContractAmount
        ///
        public string getFixedContractAmount()
        {
            return fixedContractAmount;
        }


        /* ------------------------------------------ */
        /* -------------- CONSTRUCTORS -------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This constructor is used to initialize each attribut to a blank
        ///
        /// \see ContractEmployee
        ///
        public ContractEmployee()
        {
            dateOfIncorporation = "";
            businessNumber = "";
            contractStartDate = "";
            contractStopDate = "";
            fixedContractAmount = "";
        }

        ///
        /// \brief This constructor is used to set the value of attribute dateOfIncorporation
        /// \details <b>Details</b>
        ///
        /// \param inDate - <b>string</b> - representation of the input date from user
        ///
        /// \return True if attribute dateOfIncorporation is set; False otherwise
        ///
        /// \see setDateOfIncorporation
        ///
        public bool setDateOfIncorporation(string inDate)
        {
            if (Validate_Dates(inDate))
            {
                if (setDateOfBirth(inDate))
                {
                    dateOfIncorporation = inDate;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                SendLog_Attempt("Date of Incorporation", inDate);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute businessNumber
        /// \details <b>Details</b>
        ///
        /// \param inBN - <b>string</b> - representation of the input business number from user
        ///
        /// \return True if attribute businessNumber is set; False otherwise
        ///
        /// \see setBusinessNumber
        ///
        public bool setBusinessNumber(string inBN)
        {
            if (Validate_BN(inBN, getDateOfBirth()))
            {
                if (setSocialInsuranceNumber(inBN))
                {
                    businessNumber = inBN;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                SendLog_Attempt("Business Number", inBN);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute contractStartDate
        /// \details <b>Details</b>
        ///
        /// \param inDate - <b>string</b> - representation of the input date from user
        ///
        /// \return True if attribute contractStartDate is set; False otherwise
        ///
        /// \see setContractStartDate
        ///
        public bool setContractStartDate(string inDate)
        {
            if (Validate_Dates(inDate))
            {
                contractStartDate = inDate;
                return true;
            }
            else
            {
                SendLog_Attempt("Contract Start Date", inDate);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute contractStopDate
        /// \details <b>Details</b>
        ///
        /// \param inDate - <b>string</b> - representation of the input date from user
        ///
        /// \return True if attribute contractStopDate is set; False otherwise
        ///
        /// \see setContractStopDate
        ///
        public bool setContractStopDate(string inDate)
        {
            if (Validate_Dates(inDate))
            {
                if(Compare_TwoDates(getContractStartDate(), inDate))
                {
                    contractStopDate = inDate;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                SendLog_Attempt("Contract Stop Date", inDate);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute fixedContractAmount
        /// \details <b>Details</b>
        ///
        /// \param inNumber - <b>string</b> - representation of the input number from user
        ///
        /// \return True if attribute fixedContractAmount is set; False otherwise
        ///
        /// \see setFixedContractAmount
        ///
        public bool setFixedContractAmount(string inNumber)
        {
            if (Validate_Numbers(inNumber))
            {
                fixedContractAmount = inNumber;
                return true;
            }
            else
            {
                SendLog_Attempt("Fixed Contract Amount", inNumber);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set all attributes of a contract employee
        /// \details <b>Details</b>
        ///
        /// \param inFName - <b>string</b> - representation of the input first name from user
        /// \param inLName - <b>string</b> - representation of the input last name from user
        /// \param inBN - <b>string</b> - representation of the input business number from user
        /// \param inDateOfIncorporation - <b>string</b> - representation of the input date of incorporation from user
        /// \param inContractStartDate - <b>string</b> - representation of the input contract start date from user
        /// \param inContractStopDate - <b>string</b> - representation of the input contract stop date from user
        /// \param inFixedContractAmount - <b>string</b> - representation of the input fixed contract amount from user
        ///
        /// \return True if all attributes are set; False otherwise
        ///
        /// \see setAllAttributes
        ///
        public bool setAllAttributes(string inFName, string inLName, string inBN, string inDateOfIncorporation,
            string inContractStartDate, string inContractStopDate, string inFixedContractAmount)
        {
            bool ret = false;
            if (setFirstName(inFName))
            {
                if (setLastName(inLName))
                {
                    if (setDateOfIncorporation(inDateOfIncorporation))
                    {
                        if (setBusinessNumber(inBN))
                        {
                            if (setContractStartDate(inContractStartDate))
                            {
                                if (setContractStopDate(inContractStopDate))
                                {
                                    if (setFixedContractAmount(inFixedContractAmount))
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
        /// \brief This method is used to make sure input business number is valid
        /// \details <b>Details</b>
        ///
        /// \param inBN - <b>string</b> - representation of the input business number from user
        /// \param inDateOfincorp - <b>string</b> - representation of the input date of incorporation from user
        ///
        /// \return True if the input is valid, False otherwise
        ///
        /// \see Validate_BN
        ///
        public bool Validate_BN(string inBN, string inDateOfincorp)
        {
            bool ret = false;
            if (Regex.IsMatch(inBN, @"^[0-9]{5}\s[0-9]{4}$"))
            {
                string year = inDateOfincorp.Split('-').First();
                string ltdyear = year.Substring(year.Length - 2);
                string ftdBN = inBN.Substring(0, 2);

                if (ltdyear == ftdBN)
                {
                    ret = true;
                }
            }
            return ret;
        }

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
                string output ="";
                output += "Business Name: " + getLastName();
                output += "\nBusiness Number: " + getBusinessNumber();
                output += "\nDate of Incorporation: " + getDateOfIncorporation();
                output += "\nContract Start Date: " + getContractStartDate();
                output += "\nContract Stop Date: " + getContractStopDate();
                output += "\nFixed Contract Amount: " + getFixedContractAmount();

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
            if (getFirstName() == "")
            {
                if (Validate_Name(getLastName()))
                {
                    if (Validate_Dates(getDateOfIncorporation()) && 
                        Compare_TwoDates(getDateOfIncorporation(), DateTime.Now.ToString("yyyy-MM-dd"))) 
                    {
                        if (Validate_BN(getBusinessNumber(), getDateOfIncorporation()))
                        {
                            if (Validate_Dates(getContractStartDate()))
                            {
                                if (Validate_Dates(getContractStopDate()) && 
                                    Compare_TwoDates(getContractStartDate(), getContractStopDate())) 
                                {
                                    if (Validate_Numbers(getFixedContractAmount()))
                                    {
                                        ret = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            SendLog_Validate(getFirstName(), getLastName(), getSocialInsuranceNumber(), ret);
            return ret;
        }

        public void setBusinessFirstName()
        {
            firstName = "";
        }


      
    }
}
