using System.Collections.Generic;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace csvimport
{
    public partial class Program
    {
        public class CsvImporter
        {
            public static List<Person> ImportSomeRecords(string fileName)
            {
                var myRecords = new List<Person>();
                using (var reader = new StreamReader(fileName))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<CsvMap>();
                     
                        int currentID;
                        string currentName;
                        string currentGender;
                        int currentBirthdayYear;
                        int currentAge;

                        //Start Reading Csv File
                        csv.Read();
                        //Skip Header
                        csv.ReadHeader();

                        while (csv.Read())
                        {
                            currentID = csv.GetField<int>(0); // TRY -> TRY PARSE
                            currentName = csv.GetField<string>(1);
                            currentGender = csv.GetField<string>(2);
                            currentBirthdayYear = csv.GetField<int>(3);
                            currentAge = csv.GetField<int>(4);
                            myRecords.Add(CreateRecord(currentID, currentName, currentGender, currentBirthdayYear, currentAge));

                        }

                    }

                }
                return myRecords;
            }

            public static Person CreateRecord(int id, string name, string gender, int bDayYear, int age)
            {
                Person record = new Person();

                record.id = id;
                record.name = name;
                record.gender = gender;
                record.birthdayYear = bDayYear;
                record.age = age;

                return record;
            }
        }
    }
}
