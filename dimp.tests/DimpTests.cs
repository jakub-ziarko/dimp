using System.Collections.Generic;
using Xunit;

namespace dimp.tests
{
    public class DimpTests
    {
        [Theory]
        [MemberData(nameof(AddEmployees))]
        public void Add_AddItemToDictionary_DoesNotThrow(string key, object value)
        {
            var dict = new Dimp();

            var x = Record.Exception(() => { dict.Add(key, value); });

            Assert.Null(x);
        }

        [Fact]
        public void Add_AddItemsToDictionary_DoesNotThrow()
        {
            var emp = AddEmployees();
            var dict = new Dimp();
            int addingCount = 0;

            var x = Record.Exception(() =>
            {
                foreach (var item in emp)
                {
                    dict.Add(item[0].ToString(), item[1]);
                    addingCount++;
                }
            });

            Assert.Null(x);
            Assert.Equal(emp.Count, addingCount);
        }

        public static List<object[]> AddEmployees()
        {
            return new List<object[]>
            {
                new object[] { "John", 123 },
                new object[] { "Stacy", 123 },
                new object[] { "Margaret", 123 },
                new object[] { "Stefan", 123 },
                new object[] { "Bozydar", 123 },
                new object[] { "Mike", 123 },
                new object[] { "Donald", 123 },
                new object[] { "Yes", 123 },
            };
        }
    }
}
