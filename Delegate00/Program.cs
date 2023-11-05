using System.Runtime.CompilerServices;

namespace Delegate00
{
   
    internal class Program
    {
        /*
         委派型別FirstDelegate宣告的物件：
         指向没有回傳值的方法，
         方法具兩個參數，第一個參數為整數型態，第二個參數也是整數型態
         */
       internal delegate void FirstDelegate(int i1, int i2);
        /*
        委派型別FirstDelegate宣告的物件：
        指向回傳floa資料的方法，
        方法具兩個參數，二個參數都是float型態
        */
        internal delegate float SecondDelegate(float p1, float p2);
        
        static void Main(string[] args)
        {
            var f = new forDelegate();

            #region 宣告委派物件
            FirstDelegate delegate1 = f.VoidAdd;
            FirstDelegate delegate2 = f.VoidSub;
            SecondDelegate delegate3 = f.RtnIntAdd;
            #endregion

            #region 委派叫用
            Console.WriteLine("委派叫用");
            InvokeDelegateA(delegate1, 2, 3);
            InvokeDelegateA(delegate2, 4, 2);
            var feedBack = InvokeDelegateB(delegate3, 7.1f, 2.4f);
            /* 
            這樣寫也是可以的
            InvokeDelegateA(f.VoidAdd, 2, 3);
            InvokeDelegateA(f.VoidSub, 4, 2);
            var feedBack = InvokeDelegateB(f.RtnIntAdd, 7, 2);
            */
            Console.WriteLine($"feedBackB={feedBack}");
            #endregion
            //------

            Console.WriteLine("委派加減");
            var delegates = f.VoidAdd + delegate2;
            delegates(100, 5);//先執行 f.VoidAdd , 再執行  delegate2
            delegates = delegates - delegate2;  //將delegate2 移除
            delegates(100, 5);  // 只有執行 f.VoidAdd
            Console.ReadKey();
        }

        static void InvokeDelegateA(FirstDelegate myDelegate,int a,int b)
        {
            myDelegate(a, b);
            /* 這樣寫也以
               myDelegate.Invoke(a,b);
             */
        }
        static float InvokeDelegateB(SecondDelegate myDelegate, float a, float b)
        {
           var rtnV= myDelegate(a, b);
            return rtnV;
        }
    }
    public class forDelegate
    {
        /// <summary>
        /// 兩個整數相加並列出結果
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void VoidAdd(int a, int b)
        {
            Console.WriteLine(a + "+" + b + "=" + (a + b));
        }

        /// <summary>
        /// 兩個整數相減並列出結果
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public void VoidSub(int p1, int p2)
        {
            Console.WriteLine(p1 + "-" + p2 + "=" + (p1 - p2));
        }
        
        /// <summary>
        /// 兩個浮點數相加並回傳浮點數
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public float RtnIntAdd(float a, float b)
        {
            return a + b;
        }
    }

}