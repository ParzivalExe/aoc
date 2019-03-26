using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.api {

    public static class EnumerableExtentions {

        

        //From StackOverflow with some modification: https://stackoverflow.com/questions/39592842/using-linq-to-sum-up-to-a-number-and-skip-the-rest#
        public static IEnumerable<TSource> AggregatingTakeWhile<TSource, TAccumulate>(
            this IEnumerable<TSource> source, 
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TSource, bool> predicate) {
                TAccumulate accu = seed;
                foreach (var current in source)
                {
                    if (predicate(accu, current))
                    {
                        accu = func(accu, current);
                        yield return current;
                    }
                    else {
                        yield break;
                    }
                }
            }

        //From StackOverflow with some modification: https://stackoverflow.com/questions/39592842/using-linq-to-sum-up-to-a-number-and-skip-the-rest#
        public static IEnumerable<TSource> AggregatingTakeDoWhile<TSource, TAccumulate>(
            this IEnumerable<TSource> source, 
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TSource, bool> predicate) {
                TAccumulate accu = seed;
                foreach (var current in source)
                {
                    accu = func(accu, current);
                    yield return current;
                    if(!predicate(accu, current))
                        yield break;
                }
            }



    }

}