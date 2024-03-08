using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extension_metody
{
    public static class CollectionExtensions
    {
        private static readonly Random RandomGenerator = new Random();

        public static T RandomElement<T>(this IEnumerable<T> collection)
        {
            if (collection == null || !collection.Any())
            {
                throw new InvalidOperationException("Collection is empty or null.");
            }

            int randomIndex = RandomGenerator.Next(collection.Count());
            return collection.ElementAt(randomIndex);
        }

        public static IEnumerable<T> RandomElementsWith<T>(this IEnumerable<T> collection, int count, Func<T, bool> condition)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (count <= 0)
            {
                throw new ArgumentException("Count must be a positive integer.", nameof(count));
            }

            var filteredCollection = collection.Where(condition).ToList();
            if (filteredCollection.Count < count)
            {
                throw new InvalidOperationException("Not enough elements in the collection that satisfy the condition.");
            }

            var result = new List<T>();
            for (int i = 0; i < count; i++)
            {
                int randomIndex = RandomGenerator.Next(filteredCollection.Count);
                result.Add(filteredCollection[randomIndex]);
                filteredCollection.RemoveAt(randomIndex);
            }

            return result;
        }

        public static IEnumerable<T> AppearanceGreaterThen<T>(this IEnumerable<T> collection, int threshold)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return collection.GroupBy(x => x)
                .Where(group => group.Count() >= threshold)
                .SelectMany(group => group)
                .Distinct();
        }

        public static IEnumerable<T> Every<T>(this IEnumerable<T> collection, int n)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (n <= 0)
            {
                throw new ArgumentException("Parameter 'n' must be a positive integer.", nameof(n));
            }

            return collection.Where((item, index) => (index + 1) % n == 0);
        }

        public static IEnumerable<T> Unique<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return collection.Distinct();
        }
    }
}
