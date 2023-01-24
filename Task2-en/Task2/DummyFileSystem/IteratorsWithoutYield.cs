using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Task2
{
    //public abstract class BaseIterator : IEnumerable<DummyNode>
    //{
    //    protected DummyNode root;
    //    protected bool isRootOnlyInRecursion;
    //    protected BaseIterator(DummyNode rt)
    //    {
    //        root = rt;
    //        isRootOnlyInRecursion = false;
    //    }
    //    protected BaseIterator(DummyNode rt,bool isInRecursion)
    //    {
    //        root = rt;
    //        isRootOnlyInRecursion = true;
    //    }
    //    public abstract IEnumerator<DummyNode> GetEnumerator();
    //    //{
    //    //    yield break;
    //    //}
    //    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}


//    public class BFSIterator:BaseIterator
//    {

//        public BFSIterator(DummyNode rt) : base(rt) { }
//        private BFSIterator(DummyNode rt, bool isInRecursion) : base(rt, isInRecursion) { }

//        public override IEnumerator<DummyNode> GetEnumerator()
//        {

//            DummyNode currentNode = root;
//            List<DummyNode> folders=new List<DummyNode>();
//            if (currentNode == root)
//            {
//                yield return root;
//                folders.Add(root);
//                currentNode.visited = true;
//                while (currentNode.Next != null)
//                {
//                    currentNode = currentNode.Next;
//                    //                    while ((currentNode.visited) || (!currentNode.IsDir()))
//                    while (currentNode.visited)
//                    {
//                        currentNode.visited = true;
//                        currentNode = currentNode.Next;
//                        if (currentNode == null)
//                        {
//                            yield break;
//                        }
//                    }
//                    if (currentNode.IsDir())
//                    {
//                        folders.Add(currentNode);
//                        yield return currentNode;
//                    }
//                    else
//                    {
//                        yield return currentNode;
//                    }
//                }
//                foreach (var folder in folders)
//                {
//                    //if(folder.FirstChild.IsDir())
//                    if (folder.FirstChild != null)
//                    {
//                        //I'm assuming folders are always first, just like windows, linux, and MacOS
//                        foreach (var subItr in new BFSIterator(folder.FirstChild, true))
//                        {
//                            yield return subItr;
//                        }
//                    }
//                    //else
//                    //{
//                    //    foreach (var file in new BFSIterator(folder.FirstChild))
//                    //    {
//                    //        yield return 
//                    //    }
//                    //}
//                }
//                if(!isRootOnlyInRecursion)
//                {
//                    SetVisitedFlagsToFalseRecursively(root);
//                }
//                yield break;
//            }
//        }
//        private void SetVisitedFlagsToFalseRecursively(DummyNode root)
//        {
//            DummyNode currentNode = root;
//            List<DummyNode> folders = new List<DummyNode>();
//            root.visited = false;
//            folders.Add(root);
//            currentNode.visited = false;
//            while (currentNode.Next != null)
//            {
//                currentNode = currentNode.Next;
//                //                    while ((currentNode.visited) || (!currentNode.IsDir()))
//                while (!currentNode.visited)
//                {
//                    currentNode = currentNode.Next;
//                    if (currentNode == null)
//                    {
//                        break;
//                    }
//                }
//                if (currentNode == null)
//                {
//                    break;
//                }
//                if (currentNode.IsDir())
//                {
//                    folders.Add(currentNode);
//                }
//                currentNode.visited = false;
//                foreach (var folder in folders)
//                {
//                    //if(folder.FirstChild.IsDir())
//                    if (folder.FirstChild != null)
//                    {
//                        //I'm assuming folders are always first, just like windows, linux, and MacOS
//                        foreach (var subItr in new BFSIterator(folder.FirstChild,true))
//                        {
//                            subItr.visited = false;
//                        }
//                    }
//                    //else
//                    //{
//                    //    foreach (var file in new BFSIterator(folder.FirstChild))
//                    //    {
//                    //        yield return 
//                    //    }
//                    //}
//                }
//            }
//        }
//    }

//    public class DFSIterator : BaseIterator
//    {
//        private int depthOfParent;
//        public DFSIterator(DummyNode rt) : base(rt) { depthOfParent = 0; }
//        private DFSIterator(DummyNode rt, bool isInRecursion, int dOP) : base(rt, isInRecursion) { depthOfParent = dOP; }
        
//        public override IEnumerator<DummyNode> GetEnumerator()
//        {
//            if (root == null)
//            {
//                yield break;
//            }
//            if (isRootOnlyInRecursion)
//            {
//                root.depth = depthOfParent + 1;
//            }
//            else
//            {
//                root.depth = 0;
//            }
//            if (!root.IsDir())
//            {
//                yield return root;
//            }
//            else
//            {
//                DummyNode currentNode = root;
//                yield return root;
//                List<DummyNode> children = new List<DummyNode>();
//                List<int> depthOfEveryBranch;
//                currentNode.visited = true;
//                DummyNode temp = currentNode.FirstChild;
//                if (temp == null)
//                {
//                    yield break;
//                }
//                while (temp != null && temp.Parent==currentNode)
//                {
//                    children.Add(temp);
//                    temp = temp.Next;
//                }
//                while (currentNode != null)
//                {
//                    foreach (var child in children)
//                    {
//                        //yield eturn child;
//                        foreach (var subItr in new DFSIterator(child, true,root.depth))
//                        {
//                            yield return subItr;
//                        }
//                    }
//                    children.Clear();
//                    while (temp != null && temp.Parent == currentNode)
//                    {
//                        children.Add(temp);
//                        temp = temp.Next;
//                    }
//                    currentNode = currentNode.Next; 
//               }
//                yield break;

//            }
//        }


    public interface Iterator

    {
        //        public DummyNode root();
        public DummyNode First();
        public DummyNode Next();
       // public DummyNode FirstChild();
        public bool IsDone();
        public int itemsLeftToIterateOver();
        public DummyNode CurrentItem();
//        public DummyNode CurrentItem();
    }
    public class BFSIterator : Iterator
    {
        private Queue<DummyNode> nodes;
        //private Collectiton collectiton;
        private DummyNode _CurrentItem=null;
        public BFSIterator(DummyNode root)
        {
            _CurrentItem = root;
            nodes = new Queue<DummyNode>();
            fillNodesQueue(root,nodes);
            SetVisitedFlagsToFalseRecursively(nodes);
        }
        protected void fillNodesQueue(DummyNode root, Queue<DummyNode> nodeQ)
        {
            //start gathering nodes
            DummyNode currentNode = root;
            List<DummyNode> folders = new List<DummyNode>();
            if (currentNode == root)
            {
                nodes.Enqueue(root);
                folders.Add(root);
                root.visited = true;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    //                    while ((currentNode.visited) || (!currentNode.IsDir()))
                    while (currentNode.visited&&currentNode.Next!=null)
                    {
                        currentNode = currentNode.Next;
                        if (currentNode == null)
                        {
                            break;
                        }
                    }
                    if (currentNode.IsDir())
                    {
                        folders.Add(currentNode);
                        nodeQ.Enqueue(currentNode);
                    }
                    else
                    {
                        nodeQ.Enqueue(currentNode);
                    }
                }
                foreach (var folder in folders)
                {
                    if (folder.FirstChild != null)
                    {
                        fillNodesQueue(folder.FirstChild, nodeQ);
                    }
                }
                //end gathering nodes
                return;
            }
        }
        private void SetVisitedFlagsToFalseRecursively(Queue<DummyNode> nq)
        {
            foreach(var n in nq)
            {
                n.visited = false;
            }
        }
        //public BFSIterator(Collectiton newcollectiton)
        //{
        //    collectiton = newcollectiton;
        //}
        public DummyNode CurrentItem()
        {
            return _CurrentItem;
        }
        public DummyNode First()
        {
            return nodes.Peek();
        }

        public bool IsDone()
        {
            if(nodes.Count==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DummyNode Next()
        {
            DummyNode temp;
            if (nodes.TryPeek(out temp))
            {
                nodes.Dequeue();
                bool succesfulPeek= nodes.TryPeek(out _CurrentItem);
                return _CurrentItem;
            }
            else
            {
                return null;
            }
        }

        public int itemsLeftToIterateOver()
        {
            return nodes.Count;
        }
    }
    public class DFSIterator : Iterator
    {
        private Queue<DummyNode> nodes;
        //private Collectiton collectiton;
        private DummyNode _CurrentItem = null;
        private bool isInRecursion = false;
        public DFSIterator(DummyNode root)
        {
            _CurrentItem = root;
            nodes = new Queue<DummyNode>();
            fillNodesQueue(root, nodes);
            SetVisitedFlagsToFalseRecursively(nodes);
        }
        protected void fillNodesQueue(DummyNode root, Queue<DummyNode> nodeQ)
        {
            //start gathering nodes
            DummyNode currentNode = root;
            List<DummyNode> folders = new List<DummyNode>();
            if (currentNode == root)
            {
                if (root == null)
                {
                    return;
                }
                if (isInRecursion)
                {
                    root.depth = root.GetParent().depth + 1;
                }
                else
                {
                    root.depth = 0;
                }
                if (!root.IsDir())
                {
                    nodeQ.Enqueue(root);
                }
                else
                {
                    currentNode = root;
                    nodeQ.Enqueue(root);
                    List<DummyNode> children = new List<DummyNode>();
                    List<int> depthOfEveryBranch;
                    currentNode.visited = true;
                    DummyNode temp = currentNode.FirstChild;
                    if (temp == null)
                    {
                        return;
                    }
                    while (temp != null && temp.Parent == currentNode)
                    {
                        children.Add(temp);
                        temp = temp.Next;
                    }
                    while (currentNode != null)
                    {
                        foreach (var child in children)
                        {
                            isInRecursion=true;
                            fillNodesQueue(child, nodeQ);
                        }
                        children.Clear();
                        while (temp != null && temp.Parent == currentNode)
                        {
                            children.Add(temp);
                            temp = temp.Next;
                        }
                        currentNode = currentNode.Next;
                    }
                    isInRecursion = false;
                    return;
                }
            }
        }
        private void SetVisitedFlagsToFalseRecursively(Queue<DummyNode> nq)
        {
            foreach (var n in nq)
            {
                n.visited = false;
            }
        }
        //public BFSIterator(Collectiton newcollectiton)
        //{
        //    collectiton = newcollectiton;
        //}
        public DummyNode CurrentItem()
        {
            return _CurrentItem;
        }
        public DummyNode First()
        {
            return nodes.Peek();
        }

        public bool IsDone()
        {
            if (nodes.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DummyNode Next()
        {
            DummyNode temp;
            if (nodes.TryPeek(out temp))
            {
                nodes.Dequeue();
                bool succesfulPeek = nodes.TryPeek(out _CurrentItem);
                return _CurrentItem;
            }
            else
            {
                return null;
            }
        }

        public int itemsLeftToIterateOver()
        {
            return nodes.Count;
        }
    }
   
}
