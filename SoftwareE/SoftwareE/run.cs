﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
        public class Ran
        {

        /**
         * 获取随机的符号
         */

        static int GetRandomSeed()
            {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
             }
        public static char getOperator()
            {
                char operator1 = '0';
                Random ran = new Random(GetRandomSeed());
                int i = ran.Next(4);
                switch (i)
                {
                    case 0:
				operator1 = '+';
                        break;
                    case 1:
				operator1 = '-';
                        break;
                    case 2:
				operator1 = '*';
                        break;
                    case 3:
				operator1 = '/';
                        break;
                }
                return operator1;
            }


            /**
             * 根据输入的范围获取随机数
             */

            public static int getNumber(int max)
            {
                int number = 0;
                Random ran = new Random(GetRandomSeed());
                number = ran.Next(max + 1);
                return number;
            }

            /**
             * 根据运算符的个数随机产生子节点的位置
             */

            public static bool[] getChildPlace(int num)
            {
                int d = 0;
                int size = 0, j = 1;
                while (num >= (int)Math.Pow(2, j))
                {
                    j++;
                }
                d = (int)Math.Pow(2, j) - 1 - num;
                size = (int)Math.Pow(2, j - 1);
                bool[] k = new bool[size];
                for (int i = 0; i < size; i++)
                {
                    k[i] = true;
                }
                for (int i = 0; i < d; i++)
                {
                    Random ran = new Random(GetRandomSeed());
                    int f = ran.Next(size);
                    while (k[f] == false)
                    {
                        f = ran.Next(size);
                    }
                    k[f] = false;
                }
                return k;
            }
        }


    
}
