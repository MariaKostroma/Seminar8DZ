//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы 
//каждой строки двумерного массива.

//var a = new Int32[4, 5];
//var random = new Random();
//for (var i = 0; i < a.GetLength(0); i++, Console.WriteLine())
//{
//   for (var j = 0; j < a.GetLength(1); j++)
//   {
//        a[i, j] = random.Next(100);
//       Console.Write("{0,4}", a[i, j]);
//    }
//}
//Console.WriteLine("---");

//for (var i = 0; i < a.GetLength(0); i++)
//   
//    for (var j = 0; j < a.GetLength(1); j++)
//        for (var k = 0; k < a.GetLength(1); k++)
//        {
//            if (a[i, j] <= a[i, k]) continue;
//            var temp = a[i, j];
//            a[i, j] = a[i, k];
//            a[i, k] = temp;
//        }
//for (var i = 0; i < a.GetLength(0); i++, Console.WriteLine())
//    for (var j = 0; j < a.GetLength(1); j++)
//    {
//        Console.Write("{0,4}", a[i, j]);
//    }
//Console.Read();


//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет 
//находить строку с наибольшей суммой элементов.

//var rand = new Random();
//var arr = new int[5, 5];

//var sum = new int[5];

//for (int i = 0; i < 5; i++)
//{
//    for (int j = 0; j < 5; j++)
//    {
//        arr[i, j] = rand.Next(10);
//        sum[i] += arr[i, j];
//        Console.Write(arr[i, j] + " ");
//    }
//    Console.WriteLine();
//}

//int max = 0;
//int maxIndex = 0;

//for (int i = 0; i < sum.Length; i++)
//{
//    if (sum[i] < max) continue;
//    max = sum[i];
//    maxIndex = i;
//}

//Console.WriteLine($"Максимальная строка {maxIndex + 1} с суммой {max}");


//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение
// двух матриц.

int[,] GetRandomMatrix(int rows, int columns, int minVal, int maxVal) 
{ 
int[,] matrix = new int[rows, columns]; 
var random = new Random(); 
for (int i = 0; i < rows; i++) 
{ 
    for (int j = 0; j < columns; j++) 
    { 
        matrix[i,j] = random.Next(minVal, maxVal+1); 
    } 
} 
return matrix; 
} 
 
void PrintMatrix(int[,] matrix) 
{ 
    for (int i = 0; i < matrix.GetLength(0); i++) 
{ 
  for (int j = 0; j < matrix.GetLength(1); j++)   
  { 
    Console.Write(matrix[i,j] + " "); 
  } 
  Console.WriteLine();  
} 
} 

int[,] matrixRandom1 = GetRandomMatrix(2, 2, 0, 10);
PrintMatrix(matrixRandom1); 
System.Console.WriteLine( );
int[,] matrixRandom2 = GetRandomMatrix(2, 2, 0, 10);
PrintMatrix(matrixRandom2); 
Console.WriteLine("\nМатрица1*Матрица2:");
int[,] newMatrix = Multyplication(matrixRandom1, matrixRandom2);
PrintMatrix(newMatrix);

int[,] Multyplication(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя пермножить");
    int[,] r = new int[a.GetLength(0), b.GetLength(1)];
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
           for (int k = 0; k < b.GetLength(0); k++)
           {
            r[i,j] += a[i,k] * b[k,j];
            
           } 
        }
    }
    return r;
}

//Задача 60.Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет 
//построчно выводить массив, добавляя индексы каждого элемента.

Console.WriteLine("Введите размер массива x, y, z");
int x = SetNumber("Введите x: ");
int y = SetNumber("Введите y: ");
int z = SetNumber("Введите z: ");
Console.WriteLine();

int[,,] array3D = new int[x,y,z];
CreateArray(array3D);
WriteArray(array3D);

int SetNumber(string str) 
{ 
    Console.WriteLine(str); 
    int num = Convert.ToInt32(Console.ReadLine()); 
    return num; 
}

void CreateArray(int[,,] array3D)
{
    int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
    int number;
    for (int i = 0; i < temp.GetLength(0); i++)
    {
        temp[i] = new Random().Next(10,100);
        number = temp[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temp[i] == temp[j])
                {
                  temp[i] = new Random().Next(10,100);
                  j = 0; 
                  number = temp[i]; 
                }
                number = temp[i];
            }
        }

    }
    int count = 0;
    for (int x = 0; x < array3D.GetLength(0); x++)
    {
        for (int y = 0; y < array3D.GetLength(1); y++)
        {
          for (int z = 0; z < array3D.GetLength(2); z++)
          {
           array3D[x, y, z] = temp[count];
           count++; 
          }  
        }
    }
}

void WriteArray(int[,,] array3D)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            Console.Write($"x({i}) y({j}) ");
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"z({k})={array3D[i, j, k]}; ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

//Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
int n = 4;
int[,] sqareMatrix = new int[n, n];
int temp = 1;
int i = 0;
int j = 0;
while (temp <= sqareMatrix.GetLength(0) * sqareMatrix.GetLength(1))
{
  sqareMatrix[i, j] = temp;
  temp++;
  if (i <= j + 1 && i + j < sqareMatrix.GetLength(1) - 1)
    j++;
  else if (i < j && i + j >= sqareMatrix.GetLength(0) - 1)
    i++;
  else if (i >= j && i + j > sqareMatrix.GetLength(1) - 1)
    j--;
  else
    i--;
}
WriteArraySpiral(sqareMatrix);
void WriteArraySpiral (int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      if (array[i,j] / 10 <= 0)
      Console.Write($" {array[i,j]} ");

      else Console.Write($"{array[i,j]} ");
    }
    Console.WriteLine();
  }
}
