using System;
using System.Collections.Generic;


namespace ConsoleApp4
{
    public class Matrix
    {
        public int n;
        public int[,] data;

        public Matrix(int n)
        {
            this.n = n;
            data = new int[n, n];
        }

        public class Owner
        {
            public int id;
            public string org;
            public string name;
            public Owner(string name, string org, int id)
            {
                this.name = name;
                this.org = org;
                this.id = id;
            }
        }
        public class Date
        {
            public DateTime time;
            public Date()
            {
                time = DateTime.Now;
            }
            public void Show()
            {
                Console.WriteLine(time);
            }
        }
        
        public void create()
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    data[i, j] = r.Next(1, 9);
                }
            }
        }
        #region comment
        //public int Max()
        //{
        //    int max = data[0, 0];
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (data[i, j] > max)
        //            {
        //                max = data[i, j];
        //            }
        //        }
        //    }
        //    return max;
        //}
        //public int Min()
        //{
        //    int min = data[0, 0];
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (data[i, j] < min)
        //            {
        //                min = data[i, j];
        //            }
        //        }
        //    }
        //    return min;
        //}
        //public int Sum()
        //{
        //    int sum = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        for(int j=0;j<n;j++)
        //        {
        //            sum += data[i, j];
        //        }
        //    }
        //    return sum;
        //}
        #endregion
        public void print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(data[i, j] +"\t" );
                }
                Console.WriteLine();
            }
        }
        public static bool operator >(Matrix A, Matrix B)
        {
            for(int i=0;i<A.n;i++)
            {
                for (int j=0;j<A.n;j++)
                {
                    if (A.data[i, j] > B.data[i, j])
                        return true;
                }
            }
            return false;
        }
        public static bool operator <(Matrix A, Matrix B)
        {
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    if (A.data[i, j] < B.data[i, j])
                        return true;
                }
            }
            return false;
        }
        public static bool operator ==(Matrix A,Matrix B)
        {
            if (A.data[0, 0] == B.data[0, 0])
                return true;
           else
                return false;
        }
        public static bool operator !=(Matrix A, Matrix B)
        {
            if (A.data[0, 0] != B.data[0, 0])
                return true;
           else
                return false;
        }
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.n);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    C.data[i, j] = A.data[i, j] + B.data[i, j];
                }
            }
            return C;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix D = new Matrix(A.n);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    D.data[i, j] = A.data[i, j] - B.data[i, j];
                }
            }
            return D;
        }
        #region rev  
        //public static Matrix operator --(Matrix obj)
        //{   
        //    for(int i=0;i<obj.n;i++)
        //    {
        //        for(int j=0;j<obj.n;j++)
        //        {
        //            obj.data[i, j] = obj.data[j, i];
        //        }
        //    }
        //    return obj;
        //}
        #endregion
        public static Matrix operator --(Matrix obj)
        {
            for (int p=1,i =0;i<obj.n;i++)
            {
                for(int j=0;j<obj.n;j++)
                {
                    if(i==j)
                    {
                        obj.data[i, j] = p;
                    }
                    if(i!=j)
                    {
                        obj.data[i, j] = 0;
                    }
                }
            }
            return obj;
        }
       
    }
    public static class MathOperation
    {
        public static int Sum(this Matrix obj)
        {
            int sum = 0;
            for (int i = 0; i < obj.n; i++)
            {
                for (int j = 0; j < obj.n; j++)
                {
                    sum += obj.data[i, j];
                }
            }
            return sum;
        }
        public static int Min(this Matrix obj )
        {
            
                int min = obj.data[0, 0];
                for (int i = 0; i < obj.n; i++)
                {
                    for (int j = 0; j < obj.n; j++)
                    {
                        if (obj.data[i, j] < min)
                        {
                            min = obj.data[i, j];
                        }
                    }
                }
                return min;           
        }
        public static int Max(this Matrix obj)
        {

            int max = obj.data[0, 0];
            for (int i = 0; i < obj.n; i++)
            {
                for (int j = 0; j < obj.n; j++)
                {
                    if (obj.data[i, j] > max)
                    {
                        max = obj.data[i, j];
                    }
                }
            }
            return max;
        }
        public static int StringCollapse(this string str)
        {
            int count = 1;
            int razn = 0;
            int x = 0;
            for (int i = 0; i < str.Length; i++)
            {
                
                if (char.IsDigit(str[i]))
                {
                    x = Convert.ToInt32(str[i]-48);
                    Console.WriteLine(x);
                    
                    if (count == 1)
                        razn = x;
                    else if (count == 2)
                    {
                        razn -= x;
                    }
                    else
                        return razn;
                    count++;

                }
            }
            return razn;
        }
       
    }


    class Program
    {
        static void Main(string[] args)
        {
            
            string str = "ffg9fdvw1g6";
            int i= MathOperation.StringCollapse(str);
            Console.WriteLine("разность первых 2-х чиcел равна: {0}",i);
            Console.WriteLine("Enter size of matrix: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Matrix A = new Matrix(n);          
            A.create();
            Console.WriteLine("Matrix A: ");
        
            A.print();
            Console.WriteLine(A.Sum());
            Matrix B = new Matrix(n);
            B.create();
            Console.WriteLine("Matrix B: ");
            B.print();
            bool x = A == B;
            Console.WriteLine();
            Console.WriteLine("Is A[0,0]==B[0,0] ? "+x);
            bool f = A > B;
            Console.WriteLine("Is A>B  " + f);
            Matrix C = A + B;           
            Console.WriteLine("SUM A+B = ");
            C.print();
            Matrix D = A - B;
            Console.WriteLine();
            Console.WriteLine("Difference A-B = ");
            D.print();
            Console.WriteLine("Matrix goes to 1-mode:");
            A--;
            A.print();
            
            
            
        }
    }
}