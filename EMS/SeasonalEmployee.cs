/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : SeasonalEmployee.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Class definition and functions for SeasonalEmployee class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    /// 
/// \class SeasonalEmployee
///
/// \brief The purpose of this class is to validate and temporarily keep the attributes of the seasonal employee.
///
/// Attributes:
/// - season: the season of the hiring
/// - piecePay: the payment for each unit-of-work
/// 
/// Relationships:
/// - This is the child class of Employee class
/// 
/// Fault Detection:
/// - Return false when there is any bad situation
///
    public class SeasonalEmployee : Employee
    {
        /* ------------------------------------------ */
        /* --------------- ATTRIBUTES --------------- */
        /* ------------------------------------------ */
        private string season;
        private string piecePay;


        /* ------------------------------------------ */
        /* ---------------- ACCESSORS --------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This accessor is used to get the season of the employee
        /// \details <b>Details</b>
        ///
        /// \return the season of the employee
        ///
        /// \see getSeason
        ///
        public string getSeason()
        {
            return season;
        }

        ///
        /// \brief This accessor is used to get the piece pay of the employee
        /// \details <b>Details</b>
        ///
        /// \return the piece pay of the employee
        ///
        /// \see getPiecePay
        ///
        public string getPiecePay()
        {
            return piecePay;
        }


        /* ------------------------------------------ */
        /* -------------- CONSTRUCTORS -------------- */
        /* ------------------------------------------ */
        ///
        /// \brief This constructor is used to initialize each attribut to a blank
        ///
        /// \see SeasonalEmployee
        ///
        public SeasonalEmployee()
        {
            season = "";
            piecePay = "";
        }

        ///
        /// \brief This constructor is used to set the value of attribute season
        /// \details <b>Details</b>
        ///
        /// \param inSeason - <b>string</b> - representation of the input season from user
        ///
        /// \return True if attribute season is set; False otherwise
        ///
        /// \see setSeason
        ///
        public bool setSeason(string inSeason)
        {
            if (Validate_Season(inSeason))
            {
                season = inSeason;
                return true;
            }
            else
            {
                SendLog_Attempt("Season", inSeason);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set the value of attribute piecePay
        /// \details <b>Details</b>
        ///
        /// \param inNumber - <b>string</b> - representation of the input number from user
        ///
        /// \return True if attribute piecePay is set; False otherwise
        ///
        /// \see setPiecePay
        ///
        public bool setPiecePay(string inNumber)
        {
            if (Validate_Numbers(inNumber))
            {
                piecePay = inNumber;
                return true;
            }
            else
            {
                SendLog_Attempt("Piece Pay", inNumber);
                return false;
            }
        }

        ///
        /// \brief This constructor is used to set all attributes of a seasonal employee
        /// \details <b>Details</b>
        ///
        /// \param inFName - <b>string</b> - representation of the input first name from user
        /// \param inLName - <b>string</b> - representation of the input last name from user
        /// \param inSIN - <b>string</b> - representation of the input social insurance number from user
        /// \param inDateOfBirth - <b>string</b> - representation of the input date of birth from user
        /// \param inSeason - <b>string</b> - representation of the season from user
        /// \param inPiecePay - <b>string</b> - representation of the input piece pay from user
        ///
        /// \return True if all attributes are set; False otherwise
        ///
        /// \see setAllAttributes
        ///
        public bool setAllAttributes(string inFName, string inLName, string inSIN, string inDateOfBirth,
            string inSeason, string inPiecePay)
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
                            if (setSeason(inSeason))
                            {
                                if (setPiecePay(inPiecePay))
                                {
                                    ret = true;
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
        /// \brief This method is used to make sure input season is one of the season in a year.
        /// \details <b>Details</b>
        ///
        /// \param inSeason - <b>string</b> - representation of the input season from user
        ///
        /// \return True if the input is valid, False otherwise
        ///
        /// \see Validate_Season
        ///
        public bool Validate_Season(string inSeason)
        {
            bool ret = false;
            string[] seasonoptions = new string[4] { "Winter", "Spring", "Autumn", "Summer" };

            for (int i = 0; i < 4; i++)
            {
                if (string.Equals(inSeason, seasonoptions[i], StringComparison.OrdinalIgnoreCase))
                {
                    ret = true;
                    break;
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
                string output;
                output = "First Name: " + getFirstName();
                output += "\nLast Name: " + getLastName();
                output += "\nSocial Insurance Number: " + getSocialInsuranceNumber();
                output += "\nDate of Birth: " + getDateOfBirth();
                output += "\nSeason: " + getSeason();
                output += "\nPiece Pay: " + getPiecePay();

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
                        if (Validate_Dates(getDateOfBirth()))
                        {
                            if (Validate_Season(getSeason()))
                            {
                                if (Validate_Numbers(getPiecePay()))
                                {
                                    ret = true;
                                }
                            }
                        }
                    }
                }
            }
            SendLog_Validate(getFirstName(), getLastName(), getSocialInsuranceNumber(), ret);
            return ret;
        }


    }
}
