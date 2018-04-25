using System.Collections.Generic;
using System.Reflection;
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

        [Fact]
        public void Count_AddElemetns_CountMustMutchWithLengthOfMockedData()
        {
            var emp = AddEmployees();
            var dict = new Dimp();

            foreach (var item in emp)
            {
                dict.Add(item[0].ToString(), item[1]);
            }

            Assert.Equal(emp.Count, dict.Count);
        }


        [Fact]
        public void Add_AddMoreElementsThanArraySize_BucketsShouldResizeWhenReachedArrayLimitDesNotThrow()
        {
            var emp = AddEmployees();
            var dict = new Dimp(3);

            foreach (var item in emp)
            {
                dict.Add(item[0].ToString(), item[1]);
            }

            var buckets = typeof(Dimp).GetField("_buckets", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(dict) as LinkedList<DimKvp>[];

            Assert.True(buckets.Length >= emp.Count);
            Assert.Equal(emp.Count, dict.Count);
        }

        [Fact]
        public void GetIndexer_AddElementAndGetElementByKey_ShouldReturnValidValue()
        {
            var dict = new Dimp();
            dict.Add("John", 123);

            var result = dict["John"];

            Assert.Equal(123, result);
        }

        public static List<object[]> AddEmployees()
        {
            return new List<object[]>
            {
                new object[] { "John", 123 },
                new object[] { "Stacy", 234 },
                new object[] { "Margaret", 345 },
                new object[] { "Stefan", 456 },
                new object[] { "Bozydar", 567 },
                new object[] { "Mike", 678 },
                new object[] { "Donald", 789 },
                new object[] { "Yes", 890 },
            };
        }
    }
}
