namespace EnumerableConcat
{
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Engines;
    using BenchmarkDotNet.Jobs;

    [SimpleJob(RuntimeMoniker.Net462)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [RPlotExporter]

    public class BenchmarkCore
    {
        private const int N = 1_000_000;

        private static readonly IList<int>[] Numbers = new IList<int>[2];
        private static readonly IList<string>[] Strings = new IList<string>[2];
        private static readonly IList<DataItem>[] Objects = new IList<DataItem>[2];

        private static readonly Consumer Consumer = new Consumer();

        static BenchmarkCore()
        {
            Numbers[0] = new int[N];
            Numbers[1] = new int[N];

            for (int i = 0; i < N; i++)
            {
                Numbers[0][i] = i;
                Numbers[1][i] = i;
            }

            Strings[0] = Numbers[0].Select(i => i.ToString()).ToArray();
            Strings[1] = Numbers[1].Select(i => i.ToString()).ToArray();

            Objects[0] = Numbers[0].Select(i => new DataItem(i)).ToArray();
            Objects[1] = Numbers[1].Select(i => new DataItem(i)).ToArray();
        }

        [BenchmarkCategory("String"), Benchmark(Description = "concat_s")]
        public void StringConcat() => Concat(Strings).Consume(Consumer);

        [BenchmarkCategory("String"), Benchmark(Baseline = true, Description = "foreach_s")]
        public void StringForEach() => ForEach(Strings).Consume(Consumer);

        [BenchmarkCategory("Int32"), Benchmark(Description = "concat_n")]
        public void NumberConcat() => Concat(Numbers).Consume(Consumer);

        [BenchmarkCategory("Int32"), Benchmark(Baseline = true, Description = "foreach_n")]
        public void NumberForEach() => ForEach(Numbers).Consume(Consumer);

        [BenchmarkCategory("Object"), Benchmark(Description = "concat_o")]
        public void ObjectConcat() => Concat(Numbers).Consume(Consumer);

        [BenchmarkCategory("Object"), Benchmark(Baseline = true, Description = "foreach_o")]
        public void ObjectForEach() => ForEach(Numbers).Consume(Consumer);

        private static IEnumerable<T> Concat<T>(IEnumerable<T>[] data, int startingIndex = 0)
        {
            return data[startingIndex].Concat(data[startingIndex + 1]);
        }

        private static IEnumerable<T> ForEach<T>(IEnumerable<T>[] data, int startingIndex = 0)
        {
            foreach (var value in data[startingIndex])
                yield return value;

            foreach (var value in data[startingIndex + 1])
                yield return value;
        }
    }

    class DataItem
    {
        int x;
        int y;

        public DataItem(int value)
        {
            x = value;
            y = value;
        }
    }
}