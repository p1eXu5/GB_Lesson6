/*
 * 1.	Даны 2 двумерных матрицы. Размерность 100х100 каждая. 
 *      Напишите приложение, производящее параллельное умножение матриц. 
 *      Матрицы заполняются случайными целыми числами от 0 до 10.
 * 
 *                                          В.Г.Лихацкий                */


using System;
using System.Threading.Tasks;

namespace DZ1
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int rank = 100;

            int[,] matrix1 = new int[100, 100];
            int[,] matrix2 = new int[100, 100];
            int[,] matrixMul = new int[100, 100];


            Parallel.For(0, rank * rank,
                i =>
                {
                    matrix1[i / rank, i % rank] = rand.Next(10);
                    matrix2[i / rank, i % rank] = rand.Next(10);
                });

            Parallel.For(0, rank * rank,
                i =>
                {
                    matrixMul[i / rank, i % rank] = matrix1[i / rank, i % rank] * matrix2[i % rank, i / rank];
                });


            for (int i = 0; i < rank; ++i) {
                for (int j = 0; j < rank; ++j) {
                    Console.WriteLine($"matrix1[{i},{j}] = {matrix1[i, j]}; matrix2[{i},{j}] = {matrix2[j, i]}; matrixMul[{i},{j}] = {matrixMul[i, j]}. ");
                }
            }

            Console.ReadKey(true);

        }
    }
}
