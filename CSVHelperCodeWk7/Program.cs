using static csvimport.Program;
using System.IO;
using CsvHelper;
using System.Globalization;


string fileName = @"C:\Users\User\source\repos\CSVHelperCodeWk7\CSVHelperCodeWk7\some-data.csv";
List<Person> importedRecords = CsvImporter.ImportSomeRecords(fileName);

MenuCall();

void MenuCall()
{
    bool exitRequested = false;

    while (!exitRequested)
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Print Records");
        Console.WriteLine("2. Save Records");
        Console.WriteLine("3. Option 3");
        Console.WriteLine("0. Exit");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                PrintRecords();
                break;

            case "2":
                SaveRecords();
                break;

            case "3":
                Option3();
                break;

            case "0":
                Console.WriteLine("Exiting the program.");
                exitRequested = true;
                break;

            default:
                Console.WriteLine("Invalid choice. Please select a valid option.");
                break;
        }

        Console.WriteLine(); // Add an empty line for spacing
    }
}

void PrintRecords()
{
    PrintTable(importedRecords);

    //foreach (Person record in importedRecords)
    //{
    //    Console.WriteLine("Record ID: " + record.id);
    //    Console.WriteLine("Name: " + record.name);
    //    Console.WriteLine("Gender: " + record.gender);

    //    if (record.birthdayYear >= 2000)
    //    {
    //        Console.WriteLine("Born in the 2000's : " + record.birthdayYear);
    //    }
    //    else
    //    {
    //        Console.WriteLine("Born in the 90's : " + record.birthdayYear);
    //    }
    //    Console.WriteLine("Age : " + record.age);
    //}

}

void PrintTable(List<Person> people)
{
    //LINK https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting?redirectedfrom=MSDN
    Console.WriteLine("{0,-5} {1,-15} {2,-10} {3,-10}", "Id", "Name", "Age", "Gender");
    Console.WriteLine(new string('-', 52));
    foreach (Person person in people)
    {
        Console.WriteLine("{0,-5} {1,-15} {2,-10} {3,-10}", person.id, person.name, person.age, person.gender);
    }
}

void SaveRecords()
{
    //var dateNow = DateTime.Now;
    string savePath = @"C:\Users\User\source\repos\CSVHelperCodeWk7\CSVHelperCodeWk7\export.csv";
    List<Person> saveNewRecord = new List<Person>();

    foreach (Person record in importedRecords)
    {
        if (record.birthdayYear < 2000) //>= 200
        {
            saveNewRecord.Add(record);
        }
    }

    foreach (Person record in saveNewRecord)
    {
        // Using statement ensures that the StreamWriter is properly disposed of.
        using (StreamWriter writer = new StreamWriter(savePath)) //File.AppendText(savePath))
        {
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(saveNewRecord);
            }
            //writer.WriteLine("Name,BdayYear,Age"); // Write CSV header -> Dupes
            //writer.WriteLine($"{record.name},{record.birthdayYear},{record.age}"); // Write person data
        }
    }
    Console.WriteLine($"Save Complete");
}

void Option3()
{
    Console.WriteLine($"You selected Option 3.");
    //ADD THE CODE FOR FINDING THE CORRECT AGE
}


