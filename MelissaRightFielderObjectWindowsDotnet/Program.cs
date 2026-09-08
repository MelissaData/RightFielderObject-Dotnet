using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using MelissaData;

namespace MelissaRightFielderObjectWindowsDotnet
{
  /// <summary>
  /// RightFielder Object will identify, parse and reorganize input data into usable data types, 
  /// assuring that even the most inconsistent data entry will be properly validated and stored.
  /// </summary>
  /// <remarks>
  /// High-level flow of this sample:
  ///   1. SETUP     - create an mdRightFielder instance, hand it the license string and
  ///                  the path to the data files, then InitializeDataFiles() (one time).
  ///   2. INPUT     - feed one free-form contact string in.
  ///   3. PROCESS   - Parse() splits the string into typed fields.
  ///   4. READ      - pull the sorted fields back out with the Get* getters
  ///                  (GetAddress, GetCity, GetState, GetPostalCode, ...).
  ///   5. INTERPRET - GetResults() returns comma-separated result codes describing
  ///                  what the object did/found; each code has a human description.
  ///
  /// The pieces in this file map onto that flow:
  ///   - Program            : console harness (argument parsing + the interactive loop).
  ///   - RightFielderObject : thin wrapper around mdRightFielder that owns setup + the call sequence.
  ///   - DataContainer      : plain holder for one record's input and output.
  ///
  /// Where mdRightFielder comes from:
  ///   The MelissaData namespace and its mdRightFielder class live in mdRightFielder_cSharpCode.cs,
  ///   a generated C# wrapper over mdRightFielder.dll that the accompanying
  ///   MelissaRightFielderObjectWindowsDotnet.ps1 script downloads on every run.
  ///
  /// Reference:
  ///   Quickstart    : https://docs.melissa.com/on-premise-api/rightfielder-object/rightfielder-object-quickstart.html
  ///   Release notes : https://releasenotes.melissa.com/on-premise-api/rightfielder-object/
  ///   Result codes  : https://docs.melissa.com/on-premise-api/rightfielder-object/result-codes.html
  /// </remarks>
  class Program
  {
    /// <summary>
    /// Entry point. Reads the optional command-line arguments, then hands control to
    /// RunAsConsole, which performs the actual Right Fielder Object setup and processing.
    /// </summary>
    /// <param name="args">The raw command-line arguments</param>
    static void Main(string[] args)
    {
      // Populated by ParseArguments below.
      string testInput = "";
      string license = "";
      string dataPath = "";

      ParseArguments(ref license, ref testInput, ref dataPath, args);
      RunAsConsole(license, testInput, dataPath);
    }

    /// <summary>
    /// Reads the supported command-line options into the ref parameters.
    ///
    /// Recognized flags (each followed by its value, e.g. "--rfinput \"John Smith 22382 Avenida Empresa\""):
    ///   --license / -l   : the Melissa license string
    ///   --rfinput / -r   : a free-form contact string to test in one-shot mode
    ///   --dataPath / -d  : path to the Right Fielder Object data files
    /// </summary>
    /// <param name="license">Receives the Melissa license string.</param>
    /// <param name="testInput">Receives the free-form contact string to test in one-shot mode.</param>
    /// <param name="dataPath">Receives the path to the Right Fielder Object data files.</param>
    /// <param name="args">The raw command-line arguments to parse.</param>
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

    /// <summary>
    /// Sets up the Right Fielder Object once, then drives the input -> process -> output cycle.
    ///
    /// In interactive mode (no --rfinput) it loops, asking for a new string each pass until
    /// the user answers "N". In one-shot mode (--rfinput supplied) it runs a single pass
    /// and exits.
    /// </summary>
    /// <param name="license">The Melissa license string used to initialize the object.</param>
    /// <param name="testInput">A free-form contact string to process in one-shot mode; if empty, the program prompts interactively.</param>
    /// <param name="dataPath">Path to the Right Fielder Object data files.</param>
    static void RunAsConsole(string license, string testInput, string dataPath)
    {
      Console.WriteLine("\n\n========= WELCOME TO MELISSA RIGHT FIELDER OBJECT WINDOWS DOTNET =========\n");

      // Construct the wrapper. This is where the object is licensed, pointed at the
      // data files, and initialized (see the RightFielderObject constructor below).
      RightFielderObject rightFielderObject = new RightFielderObject(license, dataPath);

      bool shouldContinueRunning = true;

      // Gate the program on a successful initialization. If the data files could not
      // be loaded (bad/expired license, missing or wrong-path data files, ...),
      // GetInitializeErrorString() returns the reason instead of "No Error" and we
      // skip the processing loop entirely.
      if (rightFielderObject.mdRightFielder.GetInitializeErrorString() != "No Error")
      {
        shouldContinueRunning = false;
      }

      while (shouldContinueRunning)
      {
        // Holder for this pass's input and result codes.
        DataContainer dataContainer = new DataContainer();

        if (string.IsNullOrEmpty(testInput))
        {
          // Interactive mode: prompt the user for a free-form contact string.
          Console.WriteLine("\nFill in each value to see the Right Fielder Object results");

          Console.WriteLine("Right Fielder Input:");
          Console.CursorTop -= 1;
          Console.CursorLeft = 21;
          dataContainer.Input = Console.ReadLine();
        }
        else
        {
          // One-shot mode: use the string passed on the command line.
          dataContainer.Input = testInput;
        }

        // Print user input
        Console.WriteLine("\n================================= INPUTS =================================\n");
        Console.WriteLine($"\t  Right Fielder Input: {dataContainer.Input}");

        // Execute Right Fielder Object
        // Runs the Parse and stores the result codes on dataContainer.
        rightFielderObject.ExecuteObjectAndResultCodes(ref dataContainer);

        // Print output
        // Each Get* getter below returns one field the object pulled out of the input
        // string. These read directly from the mdRightFielder instance, which still holds
        // the results from the Execute call above. (Many more getters are available - see
        // the commented lines for the full set.)
        Console.WriteLine("\n================================= OUTPUT =================================\n");
        Console.WriteLine("\n\tRightFielder Object Information:");
        //Console.WriteLine($"\t   Right Fielder Input: {dataContainer.Input}");
        Console.WriteLine($"\t        Address Line 1: {rightFielderObject.mdRightFielder.GetAddress()}");
        Console.WriteLine($"\t        Address Line 2: {rightFielderObject.mdRightFielder.GetAddress2()}");
        Console.WriteLine($"\t        Address Line 3: {rightFielderObject.mdRightFielder.GetAddress3()}");
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
        Console.WriteLine($"\t          Result Codes: {dataContainer.ResultCodes}");

        // Result codes come back as a single comma-separated string (e.g. "RA01,RF01").
        // Split it and ask the object for a readable description of each code.
        // ResultCodeDescriptionLong requests the long-form text; a short form is also
        // available via ResultCodeDescriptionShort
        String[] rs = dataContainer.ResultCodes.Split(',');
        foreach (String r in rs)
          Console.WriteLine($"        {r}: {rightFielderObject.mdRightFielder.GetResultCodeDescription(r, mdRightFielder.ResultCdDescOpt.ResultCodeDescriptionLong)}");

        bool isValid = false;

        // In one-shot mode there is nothing more to do after a single pass: mark the
        // input handled and stop the outer loop.
        if (!string.IsNullOrEmpty(testInput) )
        {
          isValid = true;
          shouldContinueRunning = false;
        }

        // Interactive mode: ask whether to process another string. Keep prompting until
        // we get a valid Y/N. "N" ends the program; "Y" falls through to another pass.
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
      Console.WriteLine("\n================ THANK YOU FOR USING MELISSA DOTNET OBJECT ===============\n");
    }
  }

  /// <summary>
  /// Wrapper that owns a single Melissa Right Fielder Object instance and encapsulates the
  /// two things every Melissa object needs: one-time setup (license + data files) and the
  /// per-record processing sequence. Reuse one instance across many inputs; do NOT
  /// re-initialize per input.
  /// </summary>
  class RightFielderObject
  {
    // Path to the Right Fielder Object data files.
    string dataFilePath;

    // The underlying Melissa Right Fielder Object instance.
    public mdRightFielder mdRightFielder = new mdRightFielder();

    /// <summary>
    /// Performs the mandatory one-time setup, in this required order:
    ///   1. SetLicenseString            - authorize the object.
    ///   2. SetPathToRightFielderFiles  - tell it where the data files live.
    ///   3. InitializeDataFiles         - load the data into memory.
    /// </summary>
    /// <param name="license">The Melissa license string used to authorize the object.</param>
    /// <param name="dataPath">Path to the folder containing the Right Fielder Object data files.</param>
    public RightFielderObject(string license, string dataPath)
    {
      // Set license string and set path to data files
      mdRightFielder.SetLicenseString(license);
      dataFilePath = dataPath;
      
      // Point the object at the Right Fielder Object data files.
      mdRightFielder.SetPathToRightFielderFiles(dataFilePath);

      // Load the data files. The returned ProgramStatus reports whether initialization succeeded.
      // If you see a different date than expected, check your license string and either download the new data files
      // or use the Melissa Updater program to update your data files.
      mdRightFielder.ProgramStatus pStatus = mdRightFielder.InitializeDataFiles();

      // If an issue occurred, please investigate the common causes.
      // Common causes: an invalid/expired license, or missing/wrong-path data files.
      if (pStatus != mdRightFielder.ProgramStatus.NoError)
      {
        Console.WriteLine("Failed to Initialize Object.");
        Console.WriteLine(pStatus);
        return;
      }
      
      // Diagnostic information, handy for confirming the object loaded the data you expect:

      // Build date of the data files
      Console.WriteLine($"                DataBase Date: {mdRightFielder.GetDatabaseDate()}");

      // When the license stops working
      Console.WriteLine($"              Expiration Date: {mdRightFielder.GetLicenseExpirationDate()}");

      // This number should match with the file properties of the Melissa Object binary file.
      // If TEST appears with the build number, there may be a license key issue.
      Console.WriteLine($"               Object Version: {mdRightFielder.GetBuildNumber()}\n");
    }

    /// <summary>
    /// Runs the full Right Fielder Object processing sequence for one input string and
    /// captures its result codes. This is the canonical per-record call pattern to copy
    /// into your own application:
    ///   Parse -> GetResults
    /// </summary>
    /// <param name="data">
    /// The record to process. Its Input is read as input, and ResultCodes is populated
    /// with this run's result codes.
    /// </param>
    public void ExecuteObjectAndResultCodes(ref DataContainer data)
    {
      // Optional: register a custom field pattern (e.g. a Social Security Number) so the
      // object recognizes and extracts it. Uncomment the SetUserPattern call to use one.
      //mdRightFielder.SetUserPattern("SSN", "[0-9]{3}-[0-9]{2}-[0-9]{4}");

      // Split the free-form input into typed fields
      mdRightFielder.Parse(data.Input);

      // Collect the result codes for this run
      // ResultsCodes explain any issues Right Fielder Object has with the object.
      // List of result codes for Right Fielder Object
      // https://docs.melissa.com/on-premise-api/rightfielder-object/result-codes.html
      data.ResultCodes = mdRightFielder.GetResults();
    }
  }

  /// <summary>
  /// Data holder for a single record: carries the input string in and the result codes out.
  /// </summary>
  public class DataContainer
  {
    // Input: the free-form contact string to parse.
    public string Input             { get; set; }

    // Output: comma-separated result codes from GetResults().
    public string ResultCodes       { get; set; } = "";
  }
}
