/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : FileIO.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Class definition and functions for FileIO class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using TheCompany;
using AllEmployees;


namespace Supporting
{
    /// 
    /// \class FileIO
    ///
    /// \brief The purpose of this class is to open and close the DB, 
    /// To add entries to the DB, and to find member information upon request from the DB
    ///
    /// Attributes:
    /// - None
    /// 
    /// Relationships:
    /// - This class is used by other classes to add entries to the DB
    /// 
    /// Fault Detection:
    /// - Confirms existance of DB before writing to it otherwise creates it.
    /// 
    ///
    public class FileIO
    {
        Logging logger = new Logging();

        string path = @"c:\EMS\DBase.txt";
        ///
        /// \brief This method is used to delete the current database.
        /// \details <b>Details</b>
        ///
        /// \param inName - <b>string</b> - representation of the input name from user
        ///
        /// \return True if deleted successfully.
        ///
        /// \see deleteDB
        ///
        public bool deleteDB()
        {
            try
            {
                //OVERWRITES OLD DB WITH BLANK FILE
                StreamWriter deleteDB = new StreamWriter(path, false);
                deleteDB.Dispose();
                return true;
            }
            catch(Exception e)
            {
                string exception = e.ToString();
                return false;
            }
           
        }
        ///
        /// \brief This method is used to parse the contents of an employee object into a string.
        /// \details <b>Details</b>
        ///
        /// \param inName - <b>FulltimeEmployee</b> - FulltimeEmployee object to be converted to a string
        ///
        /// \return ret - <b>string</b> - Final string containing parsed information.
        ///
        /// \see convertEmployeeToString
        ///
        public string convertEmployeeToString(FulltimeEmployee emp)
        {
            string SIN = emp.getSocialInsuranceNumber().Replace(" ", "");
            string ret = emp.getLastName() + " "
            + emp.getFirstName() + " "
            + SIN + " "
            + emp.getDateOfBirth() + " "
            + emp.getDateOfHire() + " "
            + emp.getDateOfTermination() + " "
            + emp.getSalary(); 
            return ret;
        }
        ///
        /// \brief This method is used to parse the contents of an employee object into a string.
        /// \details <b>Details</b>
        ///
        /// \param inName - <b>ParttimeEmployee</b> - ParttimeEmployee object to be converted to a string
        ///
        /// \return ret - <b>string</b> - Final string containing parsed information.
        ///
        /// \see convertEmployeeToString
        ///
        public string convertEmployeeToString(ParttimeEmployee emp)
        {
            string SIN = emp.getSocialInsuranceNumber().Replace(" ", "");
            string ret = emp.getLastName() + " "
            + emp.getFirstName() + " "
            + SIN + " "
            + emp.getDateOfBirth() + " "
            + emp.getDateOfHire() + " "
            + emp.getDateOfTermination() + " "
            + emp.getHourlyRate();
            return ret;
        }
        ///
        /// \brief This method is used to parse the contents of an employee object into a string.
        /// \details <b>Details</b>
        ///
        /// \param inName - <b>ContractEmployee</b> - ContractEmployee object to be converted to a string
        ///
        /// \return ret - <b>string</b> - Final string containing parsed information.
        ///
        /// \see convertEmployeeToString
        ///
        public string convertEmployeeToString(ContractEmployee emp)
        {
            string ret = emp.getLastName() + " "      
            + emp.getDateOfIncorporation() + " "
            + emp.getBusinessNumber().Replace(" ", "") + " "
            + emp.getContractStartDate() + " "
            + emp.getContractStopDate() + " "
            + emp.getFixedContractAmount();
            return ret;
        }
        ///
        /// \brief This method is used to parse the contents of an employee object into a string.
        /// \details <b>Details</b>
        ///
        /// \param inName - <b>SeasonalEmployee</b> - SeasonalEmployee object to be converted to a string
        ///
        /// \return ret - <b>string</b> - Final string containing parsed information.
        ///
        /// \see convertEmployeeToString
        ///
        //SEASONAL TO STRING
        public string convertEmployeeToString(SeasonalEmployee emp)
        {
            string SIN = emp.getSocialInsuranceNumber().Replace(" ", "");
            string ret = emp.getLastName() + " "
            + emp.getFirstName() + " "
            + SIN + " "
            + emp.getDateOfBirth() + " " 
            + emp.getSeason() + " "
            + emp.getPiecePay();
            return ret;
        }
        ///
        /// \brief This method is used to add an entry to the database. If the database is not created it will be.
        /// \details <b>Details</b>
        ///
        /// \param emp - <b>FulltimeEmployee</b> - FulltimeEmployee to be added to the database
        ///
        /// \return VOID
        ///
        /// \see appendToDatabase
        ///
        //FULLTIME APPEND
        public void appendToDatabase(FulltimeEmployee emp)
        {
            string empData = "";
            empData = "FT " + convertEmployeeToString(emp);
           
            //PARSE FIELD WITH PIPES "|"
            string[] splitString = empData.Split(null);
            string buff = "";
            foreach (string i in splitString)
            {
                buff += " | " + i;
            }
            empData = buff;
        
                File.AppendAllText(path, empData + Environment.NewLine);
           
        }

        ///
        /// \brief This method is used to add an entry to the database. If the database is not created it will be.
        /// \details <b>Details</b>
        ///
        /// \param emp - <b>ParttimeEmployee</b> - ParttimeEmployee to be added to the database
        ///
        /// \return VOID
        ///
        /// \see appendToDatabase
        ///       
        //PART TIME APPEND
        public void appendToDatabase(ParttimeEmployee emp)
        {
            string empData = "";
            empData = "PT " + convertEmployeeToString(emp);

            //PARSE FIELD WITH PIPES "|"
            string[] splitString = empData.Split(null);
            string buff = "";
            foreach (string i in splitString)
            {
                buff += " | " + i;
            }
            empData = buff;
          
            
                File.AppendAllText(path, empData + Environment.NewLine);
            
        }
        ///
        /// \brief This method is used to add an entry to the database. If the database is not created it will be.
        /// \details <b>Details</b>
        ///
        /// \param emp - <b>ContractEmployee</b> - ContractEmployee to be added to the database
        ///
        /// \return VOID
        ///
        /// \see appendToDatabase
        ///     
        //CONTRACT APPEND
        public void appendToDatabase(ContractEmployee emp)
        {
            string empData = "";
            empData = "CT " + convertEmployeeToString(emp);

            //PARSE FIELD WITH PIPES "|"
            string[] splitString = empData.Split(null);
            string buff = "";
            foreach (string i in splitString)
            {
                buff += " | " + i;
            }
            empData = buff;
         
                File.AppendAllText(path, empData + Environment.NewLine);
            
        }

        ///
        /// \brief This method is used to add an entry to the database. If the database is not created it will be.
        /// \details <b>Details</b>
        ///
        /// \param emp - <b>SeasonalEmployee</b> - Seasonal Employee to be added to the database
        ///
        /// \return VOID
        ///
        /// \see appendToDatabase
        ///
        //SEASONAL APPEND
        public void appendToDatabase(SeasonalEmployee emp)
        {
            string empData = "";

            //DETERMINE CLASS ORIGIN AND MARK ACCORDINGLY
            empData = "SN " + convertEmployeeToString(emp);

            //PARSE FIELD WITH PIPES "|"
            string[] splitString = empData.Split(null);
            string buff = "";
            foreach (string i in splitString)
            {
                buff += " | " + i;
            }
            empData = buff;
        
                File.AppendAllText(path, empData + Environment.NewLine);
            
        }

        ///
        /// \brief This method is used to retrieve a certain line from the database.
        /// \details <b>Details</b>
        ///
        /// \param row - <b>int</b> - represents what row is to be retrieved.
        ///
        /// \return specific employee object found.
        ///
        /// \see readRow
        ///
        //READ ROW
        public Employee readRow(int row)
        {   
            //find matching entry in DB
            using (StreamReader r = new StreamReader(path))
            {
                string line;
                int i = 0;
                while ((line = r.ReadLine()) != null)
                {
                    if (i == row)
                    {
                        //COPY CURRENT LINE TO STRING
                        string empToParse = line.ToString();
                        // PARSE DB ENTRY TO STRING ARRAY
                        
                        string[] splitString = empToParse.Split('|');
                       
                        int c = 0;
                        foreach(string str in splitString)
                        {
                            splitString[c] = str.Trim();
                            c++;
                        }

                            
                        

                        if (splitString[1] == "FT")
                        {
                            FulltimeEmployee ft = new FulltimeEmployee();
                            ft.setLastName(splitString[2]);
                            ft.setFirstName(splitString[3]);
                            
                            ft.setSocialInsuranceNumber(formatSIN(splitString[4]));
                            ft.setDateOfBirth(splitString[5]);
                            ft.setDateOfHire(splitString[6]);
                            ft.setDateOfTermination(splitString[7]);
                            ft.setSalary(splitString[8]);
                            r.Close();
                            return ft;
                        }
                        else if (splitString[1] == "PT")
                        {
                            ParttimeEmployee pt = new ParttimeEmployee();
                            pt.setLastName(splitString[2]);
                            pt.setFirstName(splitString[3]);
                            pt.setSocialInsuranceNumber(formatSIN(splitString[4]));
                            pt.setDateOfBirth(splitString[5]);
                            pt.setDateOfHire(splitString[6]);
                            pt.setDateOfTermination(splitString[7]);
                            pt.setHourlyRate(splitString[8]);
                            r.Close();
                            return pt;
                        }
                        else if (splitString[1] == "CT")
                        {
                            ContractEmployee ce = new ContractEmployee();
                            ce.setBusinessFirstName();
                            ce.setLastName(splitString[2]);
                            ce.setDateOfBirth(splitString[3]);
                            ce.setBusinessNumber(formatBN(splitString[4]));
                            ce.setContractStartDate(splitString[5]);
                            ce.setContractStopDate(splitString[6]);
                            ce.setFixedContractAmount(splitString[7]);
                            r.Close();
                            return ce;
                        }
                        else if (splitString[1] == "SN")
                        {
                            SeasonalEmployee se = new SeasonalEmployee();
                            se.setLastName(splitString[2]);
                            se.setFirstName(splitString[3]);
                            se.setSocialInsuranceNumber(formatSIN(splitString[4]));
                            se.setDateOfBirth(splitString[5]);
                            se.setSeason(splitString[6]);
                            se.setPiecePay(splitString[7]);
                            r.Close();
                            return se;
                        }  
                    }
                    i++;
                }
                r.Close();
                // THIS IS JUST TO CLOSE A RETURN PATH READDRESS LATER.
                return null;
            }
        }

        ///
        /// \brief This method is used count all the entries in the database
        /// \details <b>Details</b>
        ///
        /// 
        ///
        /// \return Int value of how many records found.
        ///
        /// \see getAmountOfRecords
        ///
        //GET RECORD AMOUNT
        public int getAmountOfRecords()
        {
            //ReadDB();
            //int count = Dbase.Count();
            //return count;
            return File.ReadLines(path).Count();
        }


        ///
        /// \brief takes the sin from the database and formats it in a way the container can read it
        /// \details <b>Details</b>
        ///
        /// \return String the formated SIN
        ///
        /// \see formatSIN
        ///
        public string formatSIN(string inSin)
        {
            string sin = "";
            for (int j = 0; j < 9; j++)
            {
                sin = sin + inSin[j].ToString();
                if (j == 2 || j == 5)
                {
                    sin = sin + " ";
                }
            }

            return sin;
        }

        ///
        /// \brief takes the business number from the database and formats it in a way the container can read it
        /// \details <b>Details</b>
        ///
        /// \return String the formated Business Number
        ///
        /// \see formatBN
        ///
        public string formatBN(string inBN)
        {
            string bn = "";
            for (int j = 0; j < 9; j++)
            {
                bn = bn + inBN[j].ToString();
                if (j == 4)
                {
                    bn = bn + " ";
                }
            }

            return bn;
        }
      

      
    }
}