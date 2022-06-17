using System;

namespace Otus.BST.AVL.Trees.Logic.Base
{
    public abstract class BaseNode
    {
        public int Value;

        public BaseNode Parent;
        public BaseNode LeftChild;
        public BaseNode RightChild;

        public bool WithSingleChildren => (LeftChild == null && RightChild != null) || (RightChild == null && LeftChild != null);

        public BaseNode GetSingleChildren
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



        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
