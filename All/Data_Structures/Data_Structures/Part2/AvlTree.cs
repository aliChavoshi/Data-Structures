using System;

namespace Data_Structures.Part2
{
    public class AvlTree
    {
        private AvlNode _root;
        private class AvlNode
        {
            private int _value;
            private AvlNode _leftChild;
            private AvlNode _rightChild;
            private int _height;
            public AvlNode(int value)
            {
                _value = value;
            }
            public AvlNode(int value, int height)
            {
                _value = value;
                _height = height;
            }
            public int GetValue() => _value;
            public int GetHeight() => _height;
            public void SetValue(int value) => _value = value;
            public void SetHeight(int value) => _height = value;

            public AvlNode GetLeftChild() => _leftChild;
            public void SetLeftChild(AvlNode leftNode)
            {
                _leftChild = leftNode;
            }
            public AvlNode GetRightChild() => _rightChild;
            public void SetRightChild(AvlNode rightNode)
            {
                _rightChild = rightNode;
            }
        }
        public void Insert(int value)
        {
            _root = Insert(_root, value);
        }
        private AvlNode Insert(AvlNode root, int value)
        {
            if (root == null)
                return new AvlNode(value);

            if (value > root.GetValue())
                root.SetRightChild(Insert(root.GetRightChild(), value));

            else
                root.SetLeftChild(Insert(root.GetLeftChild(), value));

            SetHeight(root);

            return Balance(root);
        }
        private AvlNode Balance(AvlNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.GetLeftChild()) < 0)
                {
                    //Console.WriteLine("Left Rotate " + root.GetLeftChild().GetValue());
                    root.SetLeftChild(LeftRotate(root.GetLeftChild()));
                }
                //Console.WriteLine("Right Rotate" + root.GetValue());
                return RightRotate(root);
            }
            if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.GetRightChild()) > 0)
                {
                    root.SetRightChild(RightRotate(root.GetRightChild()));
                    //Console.WriteLine("Right Rotate " + root.GetRightChild().GetValue());
                }
                //Console.WriteLine("Left Rotate " + root.GetValue());
                return LeftRotate(root);
            }
            return root;
        }
        private AvlNode RightRotate(AvlNode root)
        {
            var newRoot = root.GetLeftChild();
            root.SetLeftChild(newRoot.GetRightChild());
            newRoot.SetRightChild(root);

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }
        private AvlNode LeftRotate(AvlNode root)
        {
            var newRoot = root.GetRightChild();
            root.SetRightChild(newRoot.GetLeftChild());
            newRoot.SetLeftChild(root);

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }
        private void SetHeight(AvlNode node)
        {
            node.SetHeight(Math.Max(
                Height(node.GetLeftChild()),
                Height(node.GetRightChild())) + 1);
        }
        private bool IsLeftHeavy(AvlNode node)
        {
            return BalanceFactor(node) > 1;
        }
        private bool IsRightHeavy(AvlNode node)
        {
            return BalanceFactor(node) < -1;
        }
        private int BalanceFactor(AvlNode node)
        {
            return node == null ? 0 : Height(node.GetLeftChild()) - Height(node.GetRightChild());
        }
        private int Height(AvlNode node)
        {
            return node == null ? -1 : node.GetHeight();
        }

    }
}