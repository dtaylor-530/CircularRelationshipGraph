namespace CircularRelationshipGraph.Data
{
    public class NodeRelationship : INodeRelationship
    {
        private string _to;

        private double _strength;

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        public double Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }
    }
}