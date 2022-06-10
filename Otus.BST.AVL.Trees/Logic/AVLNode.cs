﻿using System;

namespace Otus.BST.AVL.Trees.Logic
{
    public class AVLNode
    {
        public int Height { get; set; }

        //public int Key;
        public int Value;

        public AVLNode Parent;
        public AVLNode LeftChild;
        public AVLNode RightChild;

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

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
