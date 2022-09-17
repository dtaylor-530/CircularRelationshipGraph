namespace CircularRelationshipGraph.Data
{
    public class NodeList : List<INode>, INodeList
    {
        public NodeList(IEnumerable<INode> nodes)
          : base(nodes)
        {
        }
    }
}