using System;
using Otus.BST.AVL.Trees.Logic.Base;

namespace Otus.BST.AVL.Trees.Logic.AVL
{
    public class AVLNode : BaseNode
    {
        public int LeftHeight => GetHeight(LeftChild);

        public int RightHeight => GetHeight(RightChild);


        #region Support mehods

        private int GetHeight(BaseNode node)
        {
            if (node == null)
                return 0;

            var maxChildHeight = Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));

            return maxChildHeight + 1;
        }

        #endregion
    }
}
