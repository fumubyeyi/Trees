using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tree.lib
{
    public class BST
     {
        public Node<int> root;

        public BST(){
            root = null;
        }

        public void Insert(int value){
            root = InsertRecursive(value, root);
        }

        public static void InsertRecursive(int value, Node<int> root){
            Node<int> newNode = new(value);
            if(root == null){ 
                root = newNode;
                return root;
            }
            if (value < root.data){
                root.left = InsertRecursive(value, root.left);
            }
            else{
                root.right = InsertRecursive(value, root.right);
            }  
            return root;    
        }

        public static Node<int> Search(int value){
            return SearchRecursive(value, root);
        }

        public static Node<int> SearchRecursive(int value, Node<int> root){
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

        public static Node<int> Delete(int value, Node<int> root){
            Node<int> x = Search(value, root);
            if ( x == null){
                return null;
            }
            Node<int> ret = x;
            Node<int> parent;
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
                    return ret;
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
                Node<int> i = GetInorderNode(x, root);

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
        }
        public static bool IsLeaf(Node<int> root){
            return root.left == null && root.right == null;
        }

        public static bool HasOneChild(Node<int> root){
            return return ((root.left != null && root.right == null) || (root.left == null && root.right != null));
        }
        public static bool HasOneChild(Node<int> root){
            return root.left != null && root.right != null;
        }

        public static void Print(string type){
            if (type == "Pre")
                Pre_Order(root);
            else if (type == "Post")
                In_Order(root);
            else
                Post_Order(root);
        }
        public static void Pre_Order(Node<int> root){
            if (root == null){
                Console.WriteLine("Tree is empty.");
                return;
            }
            Console.Write(root.data + " ");
            Pre_Order(root.left);
            Pre_Order(root.right);
        }

        public static void In_Order(Node<int> root){
            if (root == null){
                Console.WriteLine("Tree is empty.");
                return;
            }         
            Pre_Order(root.left);
            Console.Write(root.data + " ");
            Pre_Order(root.right);
           
        }
         public static void Post_Order(Node<int> root){
            if (root == null){
                Console.WriteLine("Tree is empty.");
                return;
            }         
            Pre_Order(root.left);
            Pre_Order(root.right);
            Console.Write(root.data + " ");
        }
    }
}