/*using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public abstract class BaseIterator : IEnumerable<DummyNode>
    {
        protected DummyNode root;
        protected bool isRootOnlyInRecursion;
        protected BaseIterator(DummyNode rt)
        {
            root = rt;
            isRootOnlyInRecursion = false;
        }
        protected BaseIterator(DummyNode rt,bool isInRecursion)
        {
            root = rt;
            isRootOnlyInRecursion = true;
        }
        public abstract IEnumerator<DummyNode> GetEnumerator();
        //{
        //    yield break;
        //}
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class BFSIterator:BaseIterator
    {

        public BFSIterator(DummyNode rt) : base(rt) { }
        private BFSIterator(DummyNode rt, bool isInRecursion) : base(rt, isInRecursion) { }

        public override IEnumerator<DummyNode> GetEnumerator()
        {

            DummyNode currentNode = root;
            List<DummyNode> folders=new List<DummyNode>();
            if (currentNode == root)
            {
                yield return root;
                folders.Add(root);
                currentNode.visited = true;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    //                    while ((currentNode.visited) || (!currentNode.IsDir()))
                    while (currentNode.visited)
                    {
                        currentNode.visited = true;
                        currentNode = currentNode.Next;
                        if (currentNode == null)
                        {
                            yield break;
                        }
                    }
                    if (currentNode.IsDir())
                    {
                        folders.Add(currentNode);
                        yield return currentNode;
                    }
                    else
                    {
                        yield return currentNode;
                    }
                }
                foreach (var folder in folders)
                {
                    //if(folder.FirstChild.IsDir())
                    if (folder.FirstChild != null)
                    {
                        //I'm assuming folders are always first, just like windows, linux, and MacOS
                        foreach (var subItr in new BFSIterator(folder.FirstChild, true))
                        {
                            yield return subItr;
                        }
                    }
                    //else
                    //{
                    //    foreach (var file in new BFSIterator(folder.FirstChild))
                    //    {
                    //        yield return 
                    //    }
                    //}
                }
                if(!isRootOnlyInRecursion)
                {
                    SetVisitedFlagsToFalseRecursively(root);
                }
                yield break;
            }
        }
        private void SetVisitedFlagsToFalseRecursively(DummyNode root)
        {
            DummyNode currentNode = root;
            List<DummyNode> folders = new List<DummyNode>();
            root.visited = false;
            folders.Add(root);
            currentNode.visited = false;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                //                    while ((currentNode.visited) || (!currentNode.IsDir()))
                while (!currentNode.visited)
                {
                    currentNode = currentNode.Next;
                    if (currentNode == null)
                    {
                        break;
                    }
                }
                if (currentNode == null)
                {
                    break;
                }
                if (currentNode.IsDir())
                {
                    folders.Add(currentNode);
                }
                currentNode.visited = false;
                foreach (var folder in folders)
                {
                    //if(folder.FirstChild.IsDir())
                    if (folder.FirstChild != null)
                    {
                        //I'm assuming folders are always first, just like windows, linux, and MacOS
                        foreach (var subItr in new BFSIterator(folder.FirstChild,true))
                        {
                            subItr.visited = false;
                        }
                    }
                    //else
                    //{
                    //    foreach (var file in new BFSIterator(folder.FirstChild))
                    //    {
                    //        yield return 
                    //    }
                    //}
                }
            }
        }
    }

    public class DFSIterator : BaseIterator
    {
        private int depthOfParent;
        public DFSIterator(DummyNode rt) : base(rt) { depthOfParent = 0; }
        private DFSIterator(DummyNode rt, bool isInRecursion, int dOP) : base(rt, isInRecursion) { depthOfParent = dOP; }
        
        public override IEnumerator<DummyNode> GetEnumerator()
        {
            if (root == null)
            {
                yield break;
            }
            if (isRootOnlyInRecursion)
            {
                root.depth = depthOfParent + 1;
            }
            else
            {
                root.depth = 0;
            }
            if (!root.IsDir())
            {
                yield return root;
            }
            else
            {
                DummyNode currentNode = root;
                yield return root;
                List<DummyNode> children = new List<DummyNode>();
                List<int> depthOfEveryBranch;
                currentNode.visited = true;
                DummyNode temp = currentNode.FirstChild;
                if (temp == null)
                {
                    yield break;
                }
                while (temp != null && temp.Parent==currentNode)
                {
                    children.Add(temp);
                    temp = temp.Next;
                }
                while (currentNode != null)
                {
                    foreach (var child in children)
                    {
                        //yield return child;
                        foreach (var subItr in new DFSIterator(child, true,root.depth))
                        {
                            yield return subItr;
                        }
                    }
                    children.Clear();
                    while (temp != null && temp.Parent == currentNode)
                    {
                        children.Add(temp);
                        temp = temp.Next;
                    }
                    currentNode = currentNode.Next; 
               }
                yield break;

            }
        }

        
    }
}

*/