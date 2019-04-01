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

        public static IEnumerable<TSource> AggregatingStepOver<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, int> func) {

                int index = 0;
                int overstep = 0;
                foreach(var current in source) {
                    if(overstep <= 0) {
                        overstep = func(current, index);
                        if(overstep <= 0) {
                            yield return current;
                            index++;
                            overstep--;
                            continue;
                        }
                    }
                    overstep--;
                    index++;
                }
            }

        public static IEnumerable<TSource> AggregatingStepOver<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, (int oversteps, TSource replacement)> func) {

                int index = 0;
                int overstep = 0;
                TSource replacement = default(TSource);
                foreach(var current in source) {
                    if(overstep <= 0) {
                        (int oversteps, TSource replacement) overstepTuple = func(current, index);
                        overstep = overstepTuple.oversteps;
                        replacement = overstepTuple.replacement;
                        if(overstep <= 0) {
                            yield return current;
                            index++;
                            overstep--;
                            continue;
                        }
                    }
                    if(overstep == 1 && replacement != null) {
                        yield return replacement;
                    }
                    overstep--;
                    index++;
                }
            }

        public static IEnumerable<TSource> AggregatingAddObjects<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, (TSource placement, bool toPlace)> func) {

                int index = 0;
                foreach(var current in source) {
                    (TSource placement, bool toPlace) returnTuple = func(current, index);
                    if(returnTuple.toPlace) {
                        yield return returnTuple.placement;
                    }
                    yield return current;
                    index++;
                    
                }
            }

        
        public static List<TSource> AggregatingRemoveAllDoublings<TSource>(
            this IEnumerable<TSource> source) {
                List<TSource> accu = new List<TSource>();
                foreach(var current in source) {
                    if(!accu.Contains(current)) {
                        accu.Add(current);
                    }
                }
                return accu;
            }

        public static List<TAccumulate> AggregatingAddListsFromInsideListArguments<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            Func<TSource, TAccumulate[]> func) {
                List<TAccumulate> accu = new List<TAccumulate>();
                foreach(var current in source) {
                    TAccumulate[] addList = func(current);
                    accu.AddRange(addList);
                }

                return accu;
            }

        public static List<TSource> AggregatingRemoveNotNeededItems<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> func) {
                List<TSource> accu = new List<TSource>();
                foreach(var current in source) {
                    if(func(current)) {
                        accu.Add(current); 
                    }
                }
                return accu;
            }



    }

}