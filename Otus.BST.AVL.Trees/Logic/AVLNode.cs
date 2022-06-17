using System;

namespace Otus.BST.AVL.Trees.Logic
{
    public class AVLNode
    {
        public int Value;

        public AVLNode Parent { get; set; }
        
        public AVLNode LeftChild { get; set; }
        public int LeftHeight => GetHeight(LeftChild);

        public AVLNode RightChild { get; set; }
        public int RightHeight => GetHeight(RightChild);

        public bool WithSingleChildren => (LeftChild == null && RightChild != null) || (RightChild == null && LeftChild != null);

        public AVLNode GetSingleChildren
        {
            get
            {
                if (!WithSingleChildren)
                    throw new ApplicationException("Node has more than one child");

                return LeftChild ?? RightChild;
            }
        }

        public NodeType NodeType
        {
            get
            {
                if (LeftChild == null && RightChild == null)
                    return NodeType.WithoutChildren;

                if (WithSingleChildren)
                    return NodeType.WithSingleChild;

                return NodeType.WithTwoChildren;
            }
        }


        public AVLNode(int value, AVLNode parent)
        {
            Value = value;
            Parent = parent;
        }


        #region Support mehods

        public override string ToString()
        {
            return Value.ToString();
        }

        private int GetHeight(AVLNode node)
        {
            if (node == null)
                return 0;

            var maxChildHeight = Math.Max(node.LeftHeight, node.RightHeight);

            return maxChildHeight + 1;
        }

        #endregion
    }
}
