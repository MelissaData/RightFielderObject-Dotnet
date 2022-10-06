using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using MelissaData;

namespace MelissaDataRightFielderObjectWindowsNETExample
{
  class Program
  {
    static void Main(string[] args)
    {
      // Variables
      string testInput = "";

      string license = "";
      string dataPath = "";

      ParseArguments(ref license, ref testInput, ref dataPath, args);
      RunAsConsole(license, testInput, dataPath);
    }

    static void ParseArguments(ref string license, ref string testInput, ref string dataPath, string[] args)
    {
      for (int i = 0; i < args.Length; i++)
      {
        if (args[i].Equals("--license") || args[i].Equals("-l"))
        {
          if (args[i + 1] != null)
          {
            license = args[i + 1];
          }
        }
        if (args[i].Equals("--rfinput") || args[i].Equals("-r"))
        {
          if (args[i + 1] != null)
          {
            testInput = args[i + 1];
          }
        }
        if (args[i].Equals("--dataPath") || args[i].Equals("-d"))
        {
          if (args[i + 1] != null)
          {
            dataPath = args[i + 1];
          }
        }
      }

    }

    static void RunAsConsole(string license, string testInput, string dataPath)
    {
      Console.WriteLine("\n\n===== WELCOME TO MELISSA DATA RIGHT FIELDER OBJECT WINDOWS NET EXAMPLE =====\n");

      RightFielderObject rightFielderObject = new RightFielderObject(license, dataPath);

      bool shouldContinueRunning = true;

      if (rightFielderObject.mdRightFielder.GetInitializeErrorString() != "No Error")
      {
        shouldContinueRunning = false;
      }

      while (shouldContinueRunning)
      {
        DataContainer dataContainer = new DataContainer();

        if (string.IsNullOrEmpty(testInput))
        {
          Console.WriteLine("\nFill in each value to see the Right Fielder Object results");

          Console.WriteLine("Right Fielder Input:");
          Console.CursorTop -= 1;
          Console.CursorLeft = 21;
          dataContainer.Input = Console.ReadLine();
        }
        else
        {
          dataContainer.Input = testInput;
        }

        // Print user input
        Console.WriteLine("\n============================== INPUTS ==============================\n");
        Console.WriteLine($"\tRight Fielder Input: {dataContainer.Input}");
        //Console.WriteLine($"\t               Address: {dataContainer.Address}");
        //Console.WriteLine($"\t          CityStateZip: {dataContainer.CityStateZip}");
        //Console.WriteLine($"\t               Company: {dataContainer.Company}");
        //Console.WriteLine($"\t               Country: {dataContainer.Country}");
        //Console.WriteLine($"\t            Department: {dataContainer.Department}");
        //Console.WriteLine($"\t                 Email: {dataContainer.Email}");
        //Console.WriteLine($"\t              FullName: {dataContainer.FullName}");
        //Console.WriteLine($"\t                 Phone: {dataContainer.Phone}");
        //Console.WriteLine($"\t                   Url: {dataContainer.Url}");

        // Execute Right Fielder Object
        rightFielderObject.ExecuteObjectAndResultCodes(ref dataContainer);

        // Print output
        Console.WriteLine("\n============================== OUTPUT ==============================\n");
        Console.WriteLine("\n\tRightFielder Object Information:");
        //Console.WriteLine($"\t   Right Fielder Input: {dataContainer.Input}");
        Console.WriteLine($"\t          AddressLine1: {rightFielderObject.mdRightFielder.GetAddress()}");
        Console.WriteLine($"\t          AddressLine2: {rightFielderObject.mdRightFielder.GetAddress2()}");
        Console.WriteLine($"\t          AddressLine3: {rightFielderObject.mdRightFielder.GetAddress3()}");
        Console.WriteLine($"\t                  City: {rightFielderObject.mdRightFielder.GetCity()}");
        Console.WriteLine($"\t                 State: {rightFielderObject.mdRightFielder.GetState()}");
        Console.WriteLine($"\t                   Zip: {rightFielderObject.mdRightFielder.GetPostalCode()}");
        //rightFielderObject.mdRightFielder.GetFullNameNext();
        //Console.WriteLine($"\t              FullName: {rightFielderObject.mdRightFielder.GetFullName()}");
        //rightFielderObject.mdRightFielder.GetDepartmentNext();
        //Console.WriteLine($"\t            Department: {rightFielderObject.mdRightFielder.GetDepartment()}");
        //rightFielderObject.mdRightFielder.GetCompanyNext();
        //Console.WriteLine($"\t               Company: {rightFielderObject.mdRightFielder.GetCompany()}");
        //Console.WriteLine($"\t               Country: {rightFielderObject.mdRightFielder.GetCountry()}");
        //Console.WriteLine($"\t              LastLine: {rightFielderObject.mdRightFielder.GetLastLine()}");
        //rightFielderObject.mdRightFielder.GetPhoneNext();
        //Console.WriteLine($"\t                 Phone: {rightFielderObject.mdRightFielder.GetPhone()}");
        //rightFielderObject.mdRightFielder.GetPhoneTypeNext();
        //Console.WriteLine($"\t             PhoneType: {rightFielderObject.mdRightFielder.GetPhoneType()}");
        //rightFielderObject.mdRightFielder.GetEmailNext();
        //Console.WriteLine($"\t                 Email: {rightFielderObject.mdRightFielder.GetEmail()}");
        //rightFielderObject.mdRightFielder.GetURLNext();
        //Console.WriteLine($"\t                   Url: {rightFielderObject.mdRightFielder.GetURL()}");
        //rightFielderObject.mdRightFielder.GetUserFieldNext("SSN");
        //Console.WriteLine($"\t             UserField: {rightFielderObject.mdRightFielder.GetUserField("SSN")}");
        //rightFielderObject.mdRightFielder.GetUnrecognizedNext();
        //Console.WriteLine($"\t          Unrecognized: {rightFielderObject.mdRightFielder.GetUnrecognized()}");
        Console.WriteLine($"\tResult Codes: {dataContainer.ResultCodes}");


        String[] rs = dataContainer.ResultCodes.Split(',');
        foreach (String r in rs)
          Console.WriteLine($"        {r}: {rightFielderObject.mdRightFielder.GetResultCodeDescription(r, mdRightFielder.ResultCdDescOpt.ResultCodeDescriptionLong)}");

        bool isValid = false;
        if (!string.IsNullOrEmpty(testInput) )
        {
          isValid = true;
          shouldContinueRunning = false;
        }
        while (!isValid)
        {
          Console.WriteLine("\nTest Right Fielder Again? (Y/N)");
          string testAnotherResponse = Console.ReadLine();

          if (!string.IsNullOrEmpty(testAnotherResponse))
          {
            testAnotherResponse = testAnotherResponse.ToLower();
            if (testAnotherResponse == "y")
            {
              isValid = true;
            }
            else if (testAnotherResponse == "n")
            {
              isValid = true;
              shouldContinueRunning = false;
            }
            else
            {
              Console.Write("Invalid Response, please respond 'Y' or 'N'");
            }
          }
        }
      }

      Console.WriteLine("\n============ THANK YOU FOR USING MELISSA DATA NET OBJECT ===========\n");
    }
  }

  class RightFielderObject
  {
    // Path to right fielder object data files (.dat, etc)
    string dataFilePath;

    // Create instance of Melissa Data Right Fielder Object
    public mdRightFielder mdRightFielder = new mdRightFielder();

    public RightFielderObject(string license, string dataPath)
    {
      // Set license string and set path to data files (.dat, etc)
      mdRightFielder.SetLicenseString(license);
      dataFilePath = dataPath;
      
      /**
       * DatabaseDate is the date of your data files. The data files should be one month behind the DQT release.  
       * If you are using the 2020-10-15 release, the DatabaseDate should be 2020-09-15.
       * 
       * If you see a different date either download the new data files or use the Melissa Updater program to
       * update your data files. 
       * 
       * If 1970-00-00 is the DatabaseDate, the Right Fielder Object was unable to reach the data files.
       * 
       * ---------------------------READING THIS MAY SAVE YOU HOURS OF YOUR TIME-------------------------------
       * If the DatabaseDate is not consistent with the data files and your are having issues getting results
       * using mdRightFielder, it is likely a license string issue and yours may have expired.
       */

      mdRightFielder.SetPathToRightFielderFiles(dataFilePath);
      mdRightFielder.ProgramStatus pStatus = mdRightFielder.InitializeDataFiles();

      if (pStatus != mdRightFielder.ProgramStatus.NoError)
      {
        Console.WriteLine("Failed to Initialize Object.");
        Console.WriteLine($"Program Status: {pStatus}");
        return;
      }
      
      Console.WriteLine($"                DataBase Date: {mdRightFielder.GetDatabaseDate()}");
      Console.WriteLine($"              Expiration Date: {mdRightFielder.GetLicenseExpirationDate()}");

      /**
       * This number should match with file properties of the mdRightFielder.dll File Version.
       * If TEST appears with the build number, there may be a license key issue.
       */
      Console.WriteLine($"               Object Version: {mdRightFielder.GetBuildNumber()}\n");
    }

    // This will call the lookup function to process the input as well as generate the result codes
    public void ExecuteObjectAndResultCodes(ref DataContainer data)
    {

      // These are the configuarble pieces of the right fielder object. We are setting what kind of information we want to be looked up
      // SetUserPattern Method - Ex. Social Security Number

      //mdRightFielder.SetUserPattern("SSN", "[0-9]{3}-[0-9]{2}-[0-9]{4}");
      mdRightFielder.Parse(data.Input);
      data.ResultCodes = mdRightFielder.GetResults();

      // ResultsCodes explain any issues phone object has with the object.
      // List of result codes for Phone object
      // https://wiki.melissadata.com/index.php?title=Result_Code_Details#RightFielder_Object

    }
  }

  public class DataContainer
  {
    public string Input             { get; set; }
    public string ResultCodes       { get; set; } = "";
  }
}
