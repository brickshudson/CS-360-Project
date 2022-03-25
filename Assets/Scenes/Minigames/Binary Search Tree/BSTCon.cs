//Written by The-Architect01
using BinaryTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BSTCon : MonoBehaviour {

    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;
    public TextMeshProUGUI CurrentText;
    public TextMeshProUGUI GoalText;
    public TextMeshProUGUI MovesUsed;
    public GameWin GameWin;
    public static BinaryTree<int> BinTree;
    public static int Goal;

    int _moves;
    int Moves { get { return _moves; } set { _moves = value; MovesUsed.text = $"Moves Used: {value}"; } }

    public static Node<int> CurrentNode = null;

    public bool IsRight = false;

    private void Awake() {
        Moves = 0;
        BinTree = new BinaryTree<int>();
        List<int> Goals = new List<int>();
        while(BinTree.Count < 12) {
            int x = Random.Range(1, 999);
            BinTree.Insert(x);
            Goals.Add(x);
        }
        Goal = Goals[Random.Range(0, Goals.Count)];
        GoalText.text = $"Goal: {Goal}";
        Moves = 0;

        CurrentText.text = BinTree.Root.Data.ToString();
        LeftText.text = BinTree.Root.Left.Data.ToString();
        RightText.text = BinTree.Root.Right.Data.ToString();
        CurrentNode = BinTree.Root;
    }

    public void OnEnter() {
        GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
    public void OnExit() {
        GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void OnClick() {
        Moves++;
        if (IsRight) {
            if(RightText.text == Goal.ToString()) { Debug.Log("Correct Right"); GameWin.Show(); return; }
            if(CurrentNode.Right != null)
                CurrentNode = CurrentNode.Right;
        } else {
            if (LeftText.text == Goal.ToString()) { Debug.Log("Correct Left"); GameWin.Show(); return; }
            if (CurrentNode.Left != null)
                CurrentNode = CurrentNode.Left;
        }
        CurrentText.text = CurrentNode.Data.ToString();
        try {
            LeftText.text = CurrentNode.Left.Data.ToString();
        } catch { LeftText.text = ""; }
        try {
            RightText.text = CurrentNode.Right.Data.ToString();
        }catch { RightText.text = ""; }
        Debug.Log("Clicked");
    }
}
namespace BinaryTree {

    public class Node<T> where T : System.IComparable<T> {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public bool IsLeaf { get {
                return Left == null && Right == null;
            }
        }
        
        public Node(T data, Node<T> Left, Node<T> Right) {
            Data = data;
            this.Left = Left;
            this.Right = Right;
        }
    }

    public class BinaryTree<T> where T : System.IComparable<T> {
        public Node<T> Root { get; private set; } = null;
        public int Count { get { return CountNodes(Root); } }

        public void Insert(T data) {
            if(Root == null) {
                Root = new Node<T>(data, null, null);
            } else {
                InsertSort(Root, new Node<T>(data,null,null));
            }
        }
        
        void InsertSort(Node<T> Base, Node<T> InsertValue) {
            if(InsertValue.Data.CompareTo(Base.Data) < 0) {
                if(Base.Left == null) {
                    Base.Left = InsertValue;
                } else {
                    InsertSort(Base.Left, InsertValue);
                }
            } else { 
                if(Base.Right == null) {
                    Base.Right = InsertValue;
                } else {
                    InsertSort(Base.Right, InsertValue);
                }
            }
        }

        int CountNodes(Node<T> Root) {
            if(Root == null) { return 0; }
            return 1 + CountNodes(Root.Left) + CountNodes(Root.Right);
        }

        string Tostring(Node<T> node) {
            if(node == null) { return "T"; }
            return Tostring(node.Left) + " " + node.Data.ToString() + " " + Tostring(node.Right);
        } 

        public override string ToString() {
            return Tostring(Root);
        }

    }

}