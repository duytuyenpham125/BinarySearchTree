using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            Console.Write("CAY TIM KIEM NHI PHAN");
            Console.Write("\nNhap so nut:");

            int N = Convert.ToInt32(Console.ReadLine());
            int x;

            for(int i=0;i< N; i++)
            {
                Console.Write("Nhap gia tri khoa thu {0}:", i + 1);
                x = Convert.ToInt32(Console.ReadLine());
                tree.Add(x);

            }

            Console.Write("\n\nDuyet Thu tu truoc:\t");
            tree.PreOrder(tree.root);
            Console.Write("\n\nDuyet Thu tu giua:\t");
            tree.InOrder(tree.root);
            Console.Write("\n\nDuyet Thu tu sau:\t");
            tree.PostOrder(tree.root);

            Console.Write("\nChieu cao cay:{0}", tree.CalTreeHeight(tree.root));
            Console.Write("\nGia tri nut max:{0}", tree.FindMax(tree.root));
            Console.Write("\nGia tri nut min:{0}", tree.FindMin(tree.root));

            int countAll = 0;
            int sumAll = 0;
            tree.CountAndSumAllNodes(tree.root, ref countAll, ref sumAll);
            Console.Write("\nGia tri trung binh cua tat ca nut={0}", (float)sumAll / countAll);
            Console.Write("\n\nNhap gia tri nut muon tim: ");
            int X = Convert.ToInt32(Console.ReadLine());
            if (tree.Search(X) != null)
                Console.Write("Nut {0} tim thay!", X);
            else
                Console.Write("Nut {0} khong tim thay!", X);
            Console.Write("\nNhap gia tri muon huy:");
            int X1 = Convert.ToInt32(Console.ReadLine());
            tree.Remove(X1);

            Console.Write("Duyet thu tu truoc sau huy {0}:\t", X1);
            tree.PreOrder(tree.root);

            Console.Write("\n Nhap gia tri nut muon huy: ");
            int X2 = Convert.ToInt32(Console.ReadLine());
            tree.Remove(X2);

            Console.Write("\nDuyet thu tu truoc sau huy {0}:\t", X2);
            tree.PreOrder(tree.root);

            Console.Read();

        }
    }
}
