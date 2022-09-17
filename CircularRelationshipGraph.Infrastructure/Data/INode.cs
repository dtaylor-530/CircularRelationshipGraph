namespace CircularRelationshipGraph.Data
{
    public interface INodeList : IList<INode>
    {
    }

    public interface INode
    {
        /// <summary>
        /// Gets the number of instances of this node type
        /// </summary>
        double Count { get; }

        /// <summary>
        /// Gets the name of this node
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the nodes that this node instance is related to
        /// </summary>
        List<INodeRelationship> Relationships { get; }
    }

    public interface INodeRelationship
    {
        /// <summary>
        /// Gets the name of the node which this is a relationship to
        /// </summary>
        string To { get; }

        /// <summary>
        /// Gets the strength of this relationship
        /// </summary>
        double Strength { get; }
    }
}