using CircularRelationshipGraph.Data;

namespace CircularRelationshipGraph
{
    /// <summary>
    /// A sort order provider that doesn't actually perform any sorting.
    /// </summary>
    public class NaturalSortOrderProvider : ISortOrderProvider
    {
        public INodeList Sort(INodeList nodes)
        {
            return nodes;
        }
    }
}