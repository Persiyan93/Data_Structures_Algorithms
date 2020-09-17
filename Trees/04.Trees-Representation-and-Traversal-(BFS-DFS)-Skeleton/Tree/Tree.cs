namespace Tree
{
    using Microsoft.VisualBasic.FileIO;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children = new List<Tree<T>>();
       


        public Tree(T value)
        {

            this.Value = value;
            this.Parent = null;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {

            this._children = children.ToList();
            foreach (var child in _children)
            {
                child.Parent = this;
            }

        }
        public bool IsTreeDeleted { get; set; }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            if (IsTreeDeleted)
            {
                return new List<T>();
            }
            var result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
           
        queue.Enqueue(this);
            while (queue.Count != 0)
            {
                Tree<T> currenttree = queue.Dequeue();
                result.Add(currenttree.Value);
                foreach (var child in currenttree.Children)
                {
                    queue.Enqueue(child);
                }


            }
            return result;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> result = new List<T>();
            if (IsTreeDeleted)
            {
                return result;
            }
            Dfs(this, result);
            return result;


        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parent = SearchElement(this, parentKey);
            if (parent == null)
            {
                throw new ArgumentNullException();
            }
            parent._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> searchedTree= SearchElement(this, nodeKey);
            if (searchedTree==null)
            {
                throw new ArgumentNullException();
            }
            foreach (var child in searchedTree.Children)
            {
                child.Parent = null;
            }
            searchedTree._children.Clear();
            Tree<T> searchedparent = searchedTree.Parent;
            if (searchedparent==null)
            {
                IsTreeDeleted = true;   
            }
            else
            {
                searchedparent._children.Remove(searchedTree);
            }
            searchedTree.Value = default(T);
        }

        public void Swap(T firstKey, T secondKey)
        {
           var firstTreee= SearchElement(this,firstKey);
            var secondTree = SearchElement(this, secondKey);
            
            
            if (firstTreee==null||secondTree==null)
            {
                throw new ArgumentNullException();
            }
            if (firstTreee.Parent!=null&&secondTree.Parent!=null)
            {
                int indexOfFirstree = firstTreee.Parent._children.IndexOf(firstTreee);
                int indexOfSecondTreee = secondTree.Parent._children.IndexOf(secondTree);
                firstTreee.Parent._children[indexOfFirstree] = secondTree;
                secondTree.Parent._children[indexOfSecondTreee] = firstTreee;
            }
            else if(firstTreee.Parent==null)
            {
                SwapRoot(secondTree);
            }

            else
            {
                SwapRoot(firstTreee);
            }
            
            
            
           

        }

        private void SwapRoot(Tree<T> secondTree)
        {
            this.Value = secondTree.Value;
            this._children.Clear();
            foreach (var child in secondTree.Children)
            {
                this._children.Add(child);
            }
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            
            foreach (var children in tree.Children)
            {
                Dfs(children, result);
            }
            result.Add(tree.Value);
        }
        private Tree<T> SearchElement (Tree<T> tree, T parentKey)
        {

            Tree<T> parent = null;
            if (tree.Value.Equals(parentKey))
            {
                parent = tree;
                return parent;
            }
            foreach (var child in tree.Children)
            {
               parent= SearchElement(child, parentKey);
                if (parent != null)
                {
                    return parent;
                }

            }
            return parent;
           
           
            
                
            
            
            
        }
    }
}
