﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"D:\Calculator\Output.txt", FileMode.Create);
            /**
            创建文件流
            */
            StreamWriter sw = new StreamWriter(fs);
            int z;
            BinaryTree bTree;
            Console.WriteLine("How many questions do u need?");
            z = int.Parse(Console.ReadLine());
            for (int i = 0; i < z; i++)
            {
                bTree = new BinaryTree(2);
                bTree.createBTree();
                String result = bTree.CalAndVal();
                Console.WriteLine(bTree.ToString() + "=" + result);
                sw.WriteLine(bTree.ToString() + "=" + result);
            }
            sw.WriteLine(" Time：" + DateTime.Now.ToString());
            /**
            清空缓冲区
            */
            sw.Flush();
            /**
             关闭文件流
             */
            sw.Close();
            fs.Close();
        }
    }
}
