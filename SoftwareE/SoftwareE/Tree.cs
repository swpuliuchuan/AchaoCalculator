﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Tree
    {
        private String str;
        private Tree rchild = null;
        private Tree lchild = null;

        public Tree(String str)
        {
            this.str = str;

        }
        public Tree(String str, Tree lchild, Tree rchild)
        {
            this.str = str;
            this.rchild = rchild;
            this.lchild = lchild;
        }
        public void setChild(Tree lchild, Tree rchild)
        {
            this.lchild = lchild;
            this.rchild = rchild;
        }

        public Tree getRchild()
        {
            return rchild;
        }
        public void setRchild(Tree rchild)
        {
            this.rchild = rchild;
        }
        public Tree getLchild()
        {
            return lchild;
        }
        public void setLchild(Tree lchild)
        {
            this.lchild = lchild;
        }

        public String getStr()
        {
            return str;
        }

        /**
         * 获取每个节点的运算结果，并检验除法
         * 1)除数为0
         * 2)不能整除
         * 出现以上两种情况的话将该运算符转换成其他三种运算符
         * 
         * @return result
         */
        public String getResult()
        {
            if (hasChild())
            {
                switch (str)
                {
                    case "+":
                        return (int.Parse(getLchild().getResult()) + int.Parse(getRchild().getResult())).ToString();
                    case "-":
                        return (int.Parse(getLchild().getResult()) - int.Parse(getRchild().getResult())).ToString();
                    case "*":
                        return (int.Parse(getLchild().getResult()) * int.Parse(getRchild().getResult())).ToString();
                    case "/":
                        if (getRchild().getResult().Equals("0"))
                        {
                            while (str.Equals("/"))
                            {
                                str = (Ran.getOperator().ToString());
                            }
                            return this.getResult();
                        }
                        else if (int.Parse(getLchild().getResult()) % int.Parse(getRchild().getResult()) != 0)                          
                        {
                            while (str.Equals("/"))
                            {
                                str = (Ran.getOperator()).ToString();
                            }
                            return this.getResult();
                        }
                        else
                            return (int.Parse(getLchild().getResult()) / int.Parse(getRchild().getResult())).ToString();
                }
            }
            return str;
        }

        /**
         * 先对每个运算式添加括号，然后根据去括号法则，去掉多余的子式的括号
         * 
         * @return string
         */
        public String toString()
        {
            String Lstr = "", Rstr = "", Str = "";
            if (hasChild())
            {
                //右子树如果有孩子，说明右子树是一个表达式，而不是数字节点。
                if (getRchild().hasChild())
                {
                    //判断左邻括号的运算符是否为'/'
                    if (str.Equals("/"))
                    {
                        //获取右子树的表达式，保留括号
                        Rstr = getRchild().toString();
                    }
                    //判断左邻括号的运算符是否为'*'或'-'
                    else if (str.Equals("*") || str.Equals("-"))
                    {
                        //判断op是否为'+'或'-'
                        if (getRchild().str.Equals("+") || getRchild().str.Equals("-"))
                        {
                            Rstr = getRchild().toString();
                        }
                        else
                        {
                            //获取右子树的表达式，并且去括号 
                            Rstr = getRchild().toString().Substring(1, getRchild().toString().Length - 2);
                        }
                    }
                    else
                    {
                        //右子树除此之外都是可以去括号的。
                        Rstr = getRchild().toString().Substring(1, getRchild().toString().Length - 2);
                    }
                }
                else
                {
                    Rstr = getRchild().str;
                }
                //左子树的情况同右子树类似
                if (getLchild().hasChild())
                {
                    if (str.Equals("*") || str.Equals("/"))
                    {
                        if (getLchild().str.Equals("+") || getLchild().str.Equals("-"))
                        {
                            Lstr = getLchild().toString();
                        }
                        else
                        {
                            Lstr = getLchild().toString().Substring(1, getLchild().toString().Length - 2);
                        }
                    }
                    else
                    {
                        Lstr = getLchild().toString().Substring(1, getLchild().toString().Length - 2);
                    }
                }
                else
                {
                    Lstr = getLchild().str;
                }
                //获取当前的运算式，并加上括号
                Str = "(" + Lstr + str + Rstr + ")";
            }
            else
            {
                //若没有孩子，说明是数字节点，直接返回数字
                Str = str;
            }
            return Str;
        }

        public bool hasChild()
        {
            if (lchild == null && rchild == null)
                return false;
            else
                return true;
        }
    }
    
}
