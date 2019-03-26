using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.api {

    public static class EnumerableExtentions {

        //From StackOverflow: https://stackoverflow.com/questions/39592842/using-linq-to-sum-up-to-a-number-and-skip-the-rest#
        public static IEnumerable<TSource> AggregatingTakeWhile<TSource, TAccumulate>(
            this IEnumerable<TSource> source, 
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TSource, bool> predicate) {
                TAccumulate accu = seed;
                foreach (var current in source)
                {
                    accu = func(accu, current);
                    if (!predicate(accu, current))
                        yield break;
                    yield return current; 
                }
            }



    }

}