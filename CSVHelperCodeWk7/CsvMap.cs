using CsvHelper.Configuration;

namespace csvimport
{
    public partial class Program
    {
        public sealed class CsvMap : ClassMap<Person>
        {
            public CsvMap()
            {
                Map(m => m.id).Index(0);
                Map(m => m.name).Index(1);
                Map(m => m.gender).Index(2);
                Map(m => m.birthdayYear).Index(3);
                Map(m => m.age).Index(4);
            }
        }
    }
}
