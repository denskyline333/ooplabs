using System;
using System.Collections.Generic;
using System.Text;

using System;


namespace OPP3
{
    partial class Arr
    {
        private static int count = 0;
        private int[] arr;
        private int size;
        private int sum = 0;
        private string nameArr = "WHOUTNAME";
        private static string[] namesArr;
        private const int maxSize = 1000;
        private bool state = false;

        public int[] GetArrRef => arr;

        static Arr()
        {
            Console.Beep(2000, 300);
            Console.WriteLine("StatConstr");
        }

        public Arr()
        {
            count++;
            size = 0;
            if (count != 0)
            {
                string[] tempArr = new string[count - 1];
                for (int i = 0; i < count - 1; ++i)
                    tempArr[i] = namesArr[i];
                namesArr = new string[count];
                namesArr[count - 1] = nameArr;
                for (int i = 0; i < count - 1; ++i)
                    namesArr[i] = tempArr[i];
            }
            else
            {
                namesArr = new string[count];
                namesArr[count - 1] = nameArr;
            }
        }

        public Arr(int[] argArr)
        {
            count++;
            arr = argArr;
            size = argArr.Length;
            state = true;
            if (count != 0)
            {
                string[] tempArr = new string[count - 1];
                for (int i = 0; i < count - 1; ++i)
                    tempArr[i] = namesArr[i];
                namesArr = new string[count];
                namesArr[count - 1] = nameArr;
                for (int i = 0; i < count - 1; ++i)
                    namesArr[i] = tempArr[i];
            }
            else
            {
                namesArr = new string[count];
                namesArr[count - 1] = nameArr;
            }
        }

        public string NameArr
        {
            get => nameArr;
            set => nameArr = value;
        }

        public int this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        public int GetSumElem()
        {
            int sum = default(int);
            for (int i = 0; i < size; ++i)
                sum = sum + arr[i];
            return sum;
        }

        public static void GetInfArr()
        {
            Console.WriteLine("Number of copies: " + count);
            Console.WriteLine("Name of array");
            foreach (string i in namesArr)
                Console.WriteLine(" — " + i);
        }

        public void GetEvenEl()
        {
            Console.WriteLine("Even num");
            for (int i = 0; i < size; ++i)
            {
                if (i % 2 == 0)
                {
                    Console.Write(arr[i] + ' ');
                }
            }
        }

        public void GetSum(out int sumArr)
        {
            foreach (int i in arr)
            {
                sum += i;
            }
            sumArr = sum;
        }

        public bool CNIAR(ref int arg)
        {
            foreach (int i in arr)
            {
                if (i == arg)
                    return true;
            }
            arg = 32;
            return false;
        }

        public void CreateNewArr(int argSize)
        {
            if (size == 0)
            {
                arr = new int[argSize];
                size = argSize;
            }
            else if (maxSize > argSize)
            {
                Console.WriteLine("Max size: {0}\n Size: {1}", maxSize, argSize);
            }
            else
            {
                Console.WriteLine("Array has already been allocated (Size: {0})", size);
            }
        }

        public void GetArray()
        {
            if (size == 0)
            {
                Console.WriteLine("Size of array is 0");
            }
            else if (!state)
            {
                Console.WriteLine("Array is empty");
            }
            else
            {
                foreach (int i in arr)
                    Console.Write(i + " ");
                Console.WriteLine();
            }
        }

        public int GetId() => count;

        public void PutArray()
        {
            for (int i = 0; i < size; ++i)
            {
                string temp = Console.ReadLine();
                arr[i] = (int)Convert.ChangeType(temp, typeof(int));
            }
            state = true;
        }

        public override string ToString() => "ObjectArray";
        public override int GetHashCode() => count;
        public override bool Equals(object argArr)
        {
            int[] arr = ((Arr)argArr).GetArrRef;
            if (arr.Length != this.arr.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != this.arr[i])
                        return false;
                }
            }
            return true;
        }
    };

    class Program
    {
        public static void evenArr(Arr[] objs)
        {
            for (int i = 0; i < objs.Length; ++i)
            {
                bool state = true;
                for (int j = 0; j < objs[i].GetArrRef.Length; ++j)
                {
                    if (objs[i].GetArrRef[j] % 2 != 0)
                    {
                        state = false;
                        break;
                    }
                }

                if (state)
                {
                    objs[i].GetArray();
                }
            }
        }

        public static void maxSumArr(Arr[] objs)
        {
            var maxArr = (array: objs[0].GetArrRef, sum: objs[0].GetSumElem());
            for (int i = 1; i < objs.Length; ++i)
            {
                if (maxArr.sum < objs[i].GetSumElem())
                {
                    maxArr.sum = objs[i].GetSumElem();
                    maxArr.array = objs[i].GetArrRef;
                }
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("MaxArr sum =: " + maxArr.sum);
            foreach (int i in

            maxArr.array)
                Console.Write(i + " ");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");

        }

        static void Main(string[] args)
        {
            Arr arr1 = new Arr();
            Arr arr2 = new Arr(5);

            Arr[] arr5 = { new Arr(5), new Arr(5), new Arr(5) };
            Console.WriteLine("Input 3 array");

            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine("---------------------");
                arr5[i].PutArray();
            }

            Console.WriteLine("Even array");
            evenArr(arr5);
            Console.WriteLine("Max sum of arr5");
            maxSumArr(arr5);
            arr5[2].GetArray();
            Console.WriteLine("Id arr1");
            Console.WriteLine(arr1.GetId());


            Console.WriteLine("Array 2 INPUT");
            arr2.GetArray();
            arr1.CreateNewArr(3);

            arr1.PutArray();
            Console.WriteLine("Array 1 INPUT");
            arr1.GetArray();

            arr2.PutArray();
            Console.WriteLine("Array 2");
            arr2.GetArray();

            Console.WriteLine("Sum of array 2");
            arr2.GetSum(out int sum);
            Console.WriteLine("Sum: " + sum);

            Console.WriteLine("Ref ");

            int chekRef = 5;
            arr2.CNIAR(ref chekRef);
            Console.WriteLine("chekRef = " + chekRef);

            Console.WriteLine("Information about object array");
            Arr.GetInfArr();

            Console.WriteLine("2: {0} , {1} | 0: {2}, {3}", arr1[2], arr2[2], arr1[0], arr2[0]);

            //arr3.Get(); 
            Console.WriteLine("AnonType");

            var anonType = new { ArrayAnon1 = new int[] { 1, 2, 3, 4 }, ArrayAnon2 = new int[] { 10, 20, 30, 40 } };
            Console.WriteLine(anonType.ArrayAnon1.ToString());
            foreach (var i in anonType.ArrayAnon1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n" + anonType.ArrayAnon2.ToString());
            foreach (var i in anonType.ArrayAnon2)
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }
    }
}