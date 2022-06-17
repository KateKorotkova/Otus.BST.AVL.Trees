﻿using System;

namespace Otus.BST.AVL.Trees.Logic
{
    public class Node
    {
        public int Value;

        public Node Parent;
        public Node LeftChild;
        public Node RightChild;

        public bool WithSingleChildren => (LeftChild == null && RightChild != null) || (RightChild == null && LeftChild != null);

        public Node GetSingleChildren
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


        public Node(int value, Node parent)
        {
            Value = value;
            Parent = parent;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public enum NodeType
    {
        WithoutChildren,
        WithSingleChild,
        WithTwoChildren
    }
}
