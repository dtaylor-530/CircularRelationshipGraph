using CircularRelationshipGraph.Data;

namespace CircularRelationshipGraph
{
    /// <summary>
    /// Takes a list of nodes and sorts them.
    /// </summary>
    public interface ISortOrderProvider
    {
        INodeList Sort(INodeList nodes);
    }
}