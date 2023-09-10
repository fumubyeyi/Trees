using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tree.lib
{
    public class BST
    {
        public Node? root;
        
        public BST(){
            root = null;
        }

        public void Insert(int value){
            root = InsertRecursive(value, root);
        }
        public Node InsertRecursive(int value, Node? root){
            if (root == null){
                root = new Node(value);
                return root;
            }
            if (root.data > value)
                root.left = InsertRecursive(value, root.left);
            else 
                root.right = InsertRecursive(value, root.right);
            return root;
        }

        public Node Search(int value){
            return SearchRecursive(value, root);
        }

        public Node SearchRecursive(int value, Node root){
            if (root == null){
                Console.WriteLine("Tree is empty.");
                return null;
            }
            if (root.data == value) return root;

            if (value < root.data)
                return SearchRecursive(value, root.left);
            else 
                return SearchRecursive(value, root.right);
        }

        public Node Delete(int value, Node root){
            Node x = Search(value);
            if ( x == null)
                return null;
    
            Node ret = x;
            Node parent;
            if (IsLeaf(x)){
                parent = GetParent(x, root);
                if (parent.left.data == x.data)
                    parent.left = null;
                if (parent.right.data == x.data)
                    parent.right = null;
                return ret;
            }
            if (HasOneChild(x)){
                parent = GetParent(x, root);
                if (parent.left.data == x.data){
                    if (x.right == null){
                        parent.left = x.left;
                    }
                    else {
                            parent.left = x.right;                   
                    }
                }
                else {
                    if (x.right == null){
                        parent.right = x.left;
                    }
                    else {
                            parent.right = x.right;                   
                    }
                    
                }
                return ret;
            }
            if(HasTwoChildren(x)){
                parent = GetParent(x, root);
                Node i = GetInOrderNode(x, root);

                if (parent.left.data == x.data){
                    parent.left = i;
                    i.left = x.left;
                    i.right = x.right;
                }
                else{
                    parent.right = i;
                    i.left = x.left;
                    i.right = x.right;
                }
                return ret;
            }
            return ret;
        }
        public bool IsLeaf(Node root){
            return root.left == null && root.right == null;
        }

        public bool HasOneChild(Node root){
            return ((root.left != null && root.right == null) || (root.left == null && root.right != null));
        }
        public bool HasTwoChildren(Node root){
            return root.left != null && root.right != null;
        }

        public Node GetParent(Node child , Node root){
            return root;
        }

        public Node GetInOrderNode(Node node, Node root){
            return root;
        }

        public void Print(string type){
            Console.Write("{0} Order Traversal:", type);
            if (type == "Pre")
                PreOrder(root);
            else if (type == "Post")
                PostOrder(root);
            else
                InOrder(root);
        }
        public void PreOrder(Node root){
            if (root != null){
                Console.Write(root.data + " ");
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }

        public void InOrder(Node root){
            if (root != null){
                InOrder(root.left);
                Console.Write(root.data + " ");
                InOrder(root.right);
            }
        }
        public void PostOrder(Node root){
            if (root != null){
                PostOrder(root.left);
                PostOrder(root.right);
                Console.Write(root.data + " ");
            }
        }

        public int Height(){
            return GetHeight(root);
        }

        public int GetHeight(Node? root){
            if (root == null || (root.left == null && root.right == null)) 
                return 0;
            return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        }
    }
}