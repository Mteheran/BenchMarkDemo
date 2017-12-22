using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Filters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using System;

namespace BenchMarkDotnetDemo
{
    class Program
    {        
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<RandomCustom>();

            Console.ReadLine();
        }
    }

    [CoreJob] // used to specify the system core (CoreJob), Mono (MonoJob) and dotnet classic (ClrJob)
    [AnyCategoriesFilter("Run")] //execute all method  with mark NoRun
    public class RandomCustom
    {
        [Params(50, 1000,50000,1000000)]
        public int intlong { get; set; }

        int getRandom()
        {
            int inRandom = 0;
            for (int i = 0; i < intlong; i++)
            {
                inRandom = new Random().Next(i);
            }

            return inRandom;
        }

        [Benchmark]
        [BenchmarkCategory("Run")]
        public int GetintRandom() => getRandom();

        [Benchmark]
        [BenchmarkCategory("NoRun")]
        public int GetintRandom2() => (getRandom() *2);
    }
}
