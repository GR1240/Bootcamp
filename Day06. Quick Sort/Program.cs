// Быстрая сортировка O(log2(n) * n)
// Напишите программу, которая сложит числа a и b без прямого сложения.
/*
1. Импорт всех модулей/библиотек
2. Объекты/классы
3. Функции/процедуры
4. Основной программный код
*/
// int sumNumbers(int n, int m){
//     if (m == 0)
//         return n;
//     return sumNumbers(n + 1, m - 1);
// }
/* f = sumNumbers
f(5, 3) -> f(6, 2) -> f(7, 1) -> f(8, 0) -> 8

*/

// Console.Clear();
// Console.Write("Введите 1-ое число: ");
// int a = int.Parse(Console.ReadLine()!);
// Console.Write("Введите 2-ое число: ");
// int b = int.Parse(Console.ReadLine()!);
// Console.WriteLine($"{a} + {b} = {sumNumbers(a, b)}");


/*
array = [7, 4, 1, 3, 5, 2, 6] -> [1, 2, 3, 4, 5, 6, 7]
pivot = 7
[4, 1, 3, 5, 2, 6] + [7] + [] = [] + [1] + [2] + [3] + [] + [4] + [] + [5] + [6] + [7] + []

array = [4, 1, 3, 5, 2, 6]
pivot = 4
[1, 3, 2] + [4] + [5, 6] = [] + [1] + [2] + [3] + [] + [4] + [] + [5] + [6]

array = [1, 3, 2]
pivot = 1
[] + [1] + [3, 2]


array = [3, 2]
pivot = 3
[2] + [3] + []


array = [5, 6]
pivot = 5
[] + [5] + [6]
*/
using System.Linq;

T[] Concat<T>(params T[][] arrays){
    var result = new T[arrays.Sum(a => a.Length)];
    int offset = 0;
    foreach (T[] array in arrays){
        array.CopyTo(result, offset);
        offset += array.Length;
    }
    
    return result;
}

int[] quickSort(int[] array){
    if (array.Length < 2)
        return array;
    else{
        int pivot = array[0];
        int count = 0;
        foreach (int element in array){
            if (element < pivot)
                count++;
        }
        int[] less = new int[count];
        int j = 0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] < pivot){
                less[j] = array[i];
                j++;
            }
        }
        count = 0;
        foreach (int element in array){
            if (element > pivot)
                count++;
        }
        int[] greater = new int[count];
        j = 0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] > pivot){
                greater[j] = array[i];
                j++;
            }
        }
        count = 0;
        foreach (int element in array){
            if (element == pivot)
                count++;
        }
        int[] pivotArray = new int[count];
        for (int i = 0; i < pivotArray.Length; i++)
        {
            pivotArray[i] = pivot;
        }
        int[] result = Concat(quickSort(less), pivotArray, quickSort(greater));
        return result;
    }

}


Console.Clear();
int[] array = {7, 4, 1, 3, 5, 2, 6};
Console.WriteLine($"Начальный массив: [{string.Join(", ", array)}]");
Console.WriteLine($"Конечный массив: [{string.Join(", ", quickSort(array))}]");