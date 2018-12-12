using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018AdventOfCode.Day8
{
    public class TreeNode
    {
        private static readonly Random Random = new Random();

        public TreeNode(IList<int> nodes)
        {
            Id = Random.Next(1, Int32.MaxValue);
            ChildNodes = new List<TreeNode>();
            MetaData = new List<int>();

            var childCount = nodes[0];
            var metadataCount = nodes[1];
            nodes.RemoveAt(0);
            nodes.RemoveAt(0);

            for (var i = 0; i < childCount; i++)
            {
                ChildNodes.Add(new TreeNode(nodes));
            }

            for (var i = 0; i < metadataCount; i++)
            {
                MetaData.Add(nodes[0]);
                nodes.RemoveAt(0);
            }
        }

        public int Id { get; set; }
        private List<TreeNode> ChildNodes { get; }
        private List<int> MetaData { get; }

        public int MetadataSum
        {
            get
            {
                var sum = MetaData.Sum(x => x);
                foreach (var childNode in ChildNodes)
                {
                    sum += childNode.MetadataSum;
                }
                return sum;
            }
        }

        public int NodeValue
        {
            get
            {
                if (ChildNodes.Count == 0)
                {
                    return MetadataSum;
                }
                var value = 0;
                foreach (var metadataEntry in MetaData)
                {
                    if (metadataEntry == 0) continue;

                    if (ChildNodes.Count >= metadataEntry)
                    {
                        value += ChildNodes[metadataEntry-1].NodeValue;
                    }
                }
                return value;
            }
        }
    }
}