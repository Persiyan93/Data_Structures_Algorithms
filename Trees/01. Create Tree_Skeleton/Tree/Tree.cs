namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private static Tree<T> deepestNode;
        private static int maxLevel = -1;

        public Tree(T key)
        {
            this._children = new List<Tree<T>>();
            this.Key = key;
        }
        public Tree(T key, params Tree<T>[] children) : this(key)

        {

            this._children = children.ToList();
            foreach (var child in children)
            {
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            string additionalstring = "";
            DfsToString(this, sb,additionalstring);
            return sb.ToString().TrimEnd();


        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            FindDeepestElement(this, -1);
            return deepestNode;

        }

        public List<T> GetLeafKeys()
        {
            List<T> result = new List<T>();
            result = FindLeafsDfs(this, result);
            result.Sort();
            return result;

        }

        public List<T> GetMiddleKeys()
        {
            List<T> result = new List<T>();
            FindMiddlenodes(this, result);
            result.Sort();
            return result;
        }

        public List<T> GetLongestPath()
        {
            FindDeepestElement(this, 0);
            Stack<T> result = new Stack<T>();
            Tree<T> currentree = deepestNode;
            result.Push(currentree.Key);
            while (currentree.Parent != null)
            {
                
                currentree = currentree.Parent;
                result.Push(currentree.Key);
            }
            return result.ToList();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            throw new NotImplementedException();
            
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
        public Tree<T> FindNodeByDfs(Tree<T> tree, T key)
        {
            Tree<T> searchedKey = null;
            foreach (var child in tree.Children)
            {
                searchedKey = FindNodeByDfs(child, key);
            }
            if (searchedKey.Key.Equals(key))
            {
                searchedKey = this;
            }
            return searchedKey;
        }
        public void DfsToString(Tree<T> tree, StringBuilder sb, string additionstring)
        {
             
            sb.AppendLine(additionstring+tree.Key.ToString());
            additionstring = additionstring + "  ";
            foreach (var child in tree.Children)
            {
                DfsToString(child, sb,additionstring);
            }
        }
        private List<T> FindLeafsDfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                FindLeafsDfs(child, result);
            }
            if (tree._children.Count == 0)
            {
                result.Add(tree.Key);
            }
            return result;
        }
        private void FindMiddlenodes(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree._children)
            {
                FindMiddlenodes(child, result);
            }
            if (tree._children.Count != 0 && tree.Parent != null)
            {
                result.Add(tree.Key);
            }
        }
        private void FindDeepestElement(Tree<T> tree, int counter)
        {

            counter++;
            foreach (var child in tree._children)
            {
                FindDeepestElement(child, counter);

            }
            if (counter > maxLevel)
            {
                maxLevel = counter;
                deepestNode = tree;


            }

        }
        private void PathSum(Tree<T>tree,T sum, Queue<Tree<T>> result) 
        {
            result.Enqueue(tree);
            foreach (var child in tree.Children)
            {
                PathSum(child, sum, result);
            }
            if (true)
            {

            }
        }
       
    }
}
