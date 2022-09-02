using AutoFixture;
using System.Reflection;

namespace UniUti.Test.MockObjects
{
    public static class BaseMockTest
    {
        public static T Create<T>()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture.Create<T>();
        }

        public static T NewModelMock<T>(bool isValid = true)
        {
            if (isValid)
            {
                return Create<T>();
            }
            else
            {
                return default(T);
            }
        }

        public static IList<T> ListNewModelMock<T>(int total, bool isValid = true)
        {
            var listRtn = new List<T>();
            for (int i = 0; i < total; i++)
            {
                listRtn.Add(NewModelMock<T>(isValid));
            }
            return listRtn;
        }

        /// <summary>
        /// Check is null all itens in an class
        /// this test is to classbase and class that retun of bd
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<bool> TestModelNotNullProp<T>(T item)
        {
            List<bool> listAssert = new List<bool>();
            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {
                listAssert.Add(propertyInfo.GetValue(item) != null);
            }
            return listAssert;
        }
    }
}
