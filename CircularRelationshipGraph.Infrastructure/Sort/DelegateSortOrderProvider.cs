using CircularRelationshipGraph.Data;

namespace CircularRelationshipGraph
{
    /// <summary>
    /// A sort provider that orders the nodes via the given delegate
    /// </summary>
    public class DelegateSortOrderProvider : ISortOrderProvider
    {
        private Func<IList<INode>, IEnumerable<INode>> _func;

        public DelegateSortOrderProvider(Func<IList<INode>, IEnumerable<INode>> func)
        {
            _func = func;
        }

        public INodeList Sort(INodeList nodes)
        {
            return new NodeList(_func(nodes));
        }
    }
}