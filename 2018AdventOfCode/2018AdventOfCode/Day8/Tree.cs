using System.Linq;

namespace _2018AdventOfCode.Day8
{
    public class Tree
    {
        private readonly TreeNode _rootNode;

        public Tree(string rawNodes)
        {
            var nodes = rawNodes.Split(' ').Select(int.Parse).ToList();

            _rootNode = new TreeNode(nodes);
        }

        public int MetadataSum => _rootNode.MetadataSum;
        public int RootNodeValue => _rootNode.NodeValue;
    }
}