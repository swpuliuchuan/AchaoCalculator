﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp9
{
     class BinaryTree
    {
        private Tree root;
        private int num;
        private List<Tree> opeList = new List<Tree>();
        public BinaryTree(int num)
        {
            this.num = num;
        }

        public int getNum()
        {
            return num;
        }

        public void setNum(int num)
        {
            this.num = num;
        }

        public void SetTreeNode(Tree root)
        {
            this.root = root;
        }


        /**
         * 获取最终的表达式
         */
        public String ToString()
        {
            String str = root.toString();
            str = str.Substring(1, str.Length - 2);
            return str;
        }

        /**
         * 计算并验证表达式
         */
        public String CalAndVal()
        {
            return root.getResult();
        }

        /**
         * 计算二叉树的深度(层数) 
         */
        public int getDeep()
        {
            int i = this.num;
            int deep = 2;
            while (i / 2 > 0)
            {
                deep++;
                i /= 2;
            }
            return deep;
        }

        /**
         * 生成二叉树
         */
        public void createBTree()
        {
            Tree lchild, rchild, lnode, rnode;

            if (num == 1)
            {
                lchild = new Tree((Ran.getNumber(30)).ToString(), null, null);
                rchild = new Tree((Ran.getNumber(40)).ToString(), null, null);
                root = new Tree((Ran.getOperator()).ToString(), lchild, rchild);
            }
            else
            {
                int num1 = 0;
                int n = getDeep() - 3;
                bool[] place = Ran.getChildPlace(num);
                root = new Tree((Ran.getOperator()).ToString(), null, null);
                opeList.Add(root);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < (int)Math.Pow(2, i); j++, num1++)
                    {
                        lchild = new Tree((Ran.getOperator()).ToString(), null, null);
                        rchild = new Tree((Ran.getOperator()).ToString(), null, null);
                        opeList[j + num1].setChild(lchild, rchild);
                        opeList.Add(lchild);
                        opeList.Add(rchild);
                    }
                }

                for (int i = 0; i < place.Length; i++)
                {
                    if (place[i])
                    {
                        lnode = new Tree((Ran.getNumber(40)).ToString(), null, null);
                        rnode = new Tree((Ran.getNumber(60)).ToString(), null, null);
                        if (i % 2 == 0)
                        {
                            lchild = new Tree((Ran.getOperator()).ToString(), lnode, rnode);
                            opeList.Add(lchild);
                            opeList[num1].setLchild(lchild);
                        }
                        else
                        {
                            rchild = new Tree((Ran.getOperator()).ToString(), lnode, rnode);
                            opeList.Add(rchild);
                            opeList[num1].setRchild(rchild);
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            lchild = new Tree((Ran.getNumber(15)).ToString(), null, null);
                            opeList[num1].setLchild(lchild);
                        }
                        else
                        {

                            rchild = new Tree((Ran.getNumber(100)).ToString(), null, null);
                            opeList[num1].setRchild(rchild);
                        }
                    }
                    num1 = num1 + i % 2;
                }
            }
        }
    }
}
