namespace CircularRelationshipGraph
{
    public static class Util
    {
        /// <summary>
        /// Swaps the items at the given indices
        /// </summary>
        public static void Swap<T>(this List<T> items, int from, int to)
        {
            T itemOne = items[from];
            T itemTwo = items[to];
            items[from] = itemTwo;
            items[to] = itemOne;
        }
    }
}