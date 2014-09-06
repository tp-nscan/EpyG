﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Sorting.KeyPairs;
using Sorting.Sorters;

namespace Sorting.Json.Sorters
{
    public class SorterToJson
    {
        public int KeyCount { get; set; }

        public List<int> Sequence { get; set; }
    }

    public static class SorterToJsonExt
    {
        public static string ToJsonString(this ISorter sorter)
        {
            return JsonConvert.SerializeObject(sorter.ToJsonAdapter(), Formatting.None);
        }

        public static SorterToJson ToJsonAdapter(this ISorter sorter)
        {
            var chromosomeUintToJson = new SorterToJson
            {
                Sequence = sorter.KeyPairs.Select(kp => kp.Index).ToList(),
                KeyCount = sorter.KeyCount
            };

            return chromosomeUintToJson;
        }

        public static ISorter ToSorter(this string sorterString)
        {
            var sorterToJson = JsonConvert.DeserializeObject<SorterToJson>(sorterString);
            return sorterToJson.ToSorter();
        }

        public static ISorter ToSorter(this SorterToJson sorterToJson)
        {
            return sorterToJson.Sequence.Select(
                KeyPairRepository.AtIndex).ToSorter(keyCount: sorterToJson.KeyCount);
        }
    }
}
