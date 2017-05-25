/*	PROJECT			: EMS-Net Project(INFO1280)
 *	CLASS LIBRARY	: Presentation 
 *	FILE            : Program.cs
 *	PROGRAMMER		: Dustin Brown, M. Sultana, Sean Moulton, Xingguang Zhen
 *	FIRST VERSION	: 2016-11-22
 *	DESCRIPTION		: Main, calls the presentation class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation;

namespace EMS
{
    class Program
    {
        static void Main(string[] args)
        {
            UIMenu menu = new UIMenu();
            menu.showMainMenu();

        }
    }
}
