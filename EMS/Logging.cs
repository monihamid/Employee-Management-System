/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : Logging.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Class definition and functions for Logging class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace Supporting
{
    /// 
    /// \class Logging
    ///
    /// \brief The purpose of this class is keep track of certain events by recording the date and time when it happened,
    /// the details of the event, and any comments that should be noted.
    ///
    /// Attributes:
    /// - None
    /// 
    /// Relationships:
    /// - This class is used by every other class to keep track of log important events in a logfile.
    /// 
    /// Fault Detection:
    /// - Due to the nature of the naming of the logs, they will never overwrite.
    /// 
    ///
    public class Logging
    {

        //
        // FUNCTION : Log
        // DESCRIPTION : opens or creates EMS-DB (txt based db) 
        //               and writes a string provided to the DB
        // PARAMETERS : 
        // RETURNS : 
        //
        ///
        /// \brief opens or creates a log named ems."TIMESTAMP" where TIMESTAMP represents the local date and time.
        /// \details <b>Details</b>
        ///
        /// \param eventToLog - <b>string</b> - a string containing the actual events and what triggered the log.
        /// \param comments - <b>string</b> - a string containing any user comments for that particular log.
        /// 
        /// \see Log
        ///

        public void Log(string className, string eventToLog, string comments) 
        {
            //FILE PATH
            string path = @"C:\EMS\";

            //DATE AND TIME
            DateTime localDate = DateTime.Now;

            DateTime dateOnly = localDate.Date;
            string logdate = localDate.ToString();

            string currentDate = dateOnly.ToString("d");

            currentDate = currentDate.Replace("/", "");

            //NAME OF LOG FILE
            string logName = "ems" + currentDate + ".txt";
            path += logName;

            //CREATE LOG FORMAT
            string log = logdate + "|" + className
            + "|" + eventToLog
            + "|" + comments + "|\r\n";

            //CREATE LOG FILE IF !EXIST OTHERWISE APPEND
            if (!File.Exists(path))
            {
                using (StreamWriter emsLog = File.CreateText(path))
                {
                    emsLog.WriteLine(log);
                }
            }
            else
            {
                File.AppendAllText(path, log + "\r\n");
            }
        }
    }
}