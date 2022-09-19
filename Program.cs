using System;
using System.Threading;

namespace Helloworld
{
    class Helloworld
    {
        static void Main(string[] args)
        {
            CoffeeMaker coffee = new CoffeeMaker(); // Class instance 생성
            coffee.onState = true;
            coffee.StartCoffeeMaker();

            int n;
            PropertyClass obj = new PropertyClass();
            obj.PrivateValue = 100;
            obj.PrintValue();
            n = obj.PrivateValue;
            Console.WriteLine("Value=" + n);

            Even e = new Even(4);
            e.PrintEven();
            ++e;
            e.PrintEven();
            --e;
            e.PrintEven();

            DelegateClass objj = new DelegateClass();
            SampleDelegate sd = new SampleDelegate(objj.DelegateMethod);
            sd();

            new Event().InvokeEvent();

            ThreadStart ts = new ThreadStart(ThreadBody);
            Thread t=new Thread(ts);
            Console.WriteLine("***Start of Main");
            t.Start();
            Console.WriteLine("***End of Main");

            Stack<int> stk1 = new Stack<int>();
            Stack<double>stk2 = new Stack<double>();
            stk1.Push(1); stk1.Push(2);stk1.Push(3);
            Console.WriteLine("integer stack:" + stk1.Pop() + " " + stk1.Pop() + " " + stk1.Pop());
            stk2.Push(1.5);stk2.Push(2.5);stk2.Push(3.5);
            Console.WriteLine("double stack:" + stk2.Pop() + " " + stk2.Pop() + " "+stk2.Pop());
        }
        static void ThreadBody()
        {
            Console.WriteLine("In the thread body...");
        }
    }
    class CoffeeMaker
    {
        public bool onState;
        public void StartCoffeeMaker()
        {
            if (onState==true)
            {
                Console.WriteLine("The CoffeeMaker is already on");
            }
            else
            {
                onState = true;
                Console.WriteLine("The CoffeeMaker is now On");
            }
        }
    }

    class PropertyClass
    {
        private int privateValue;
        public int PrivateValue
        {
            get { return privateValue; }
            set { privateValue = value; }
        }
        public void PrintValue()
        {
            Console.WriteLine("Hidden Value = " + privateValue);
        }
    }

    class Even
    {
        int evenNumver;
        public Even(int n)
        {
            evenNumver = (n % 2 == 0) ? n : n + 1;
        }
        public static Even operator ++(Even e)
        {
            e.evenNumver += 2;
            return e;
        }
        public static Even operator --(Even e)
        {
            e.evenNumver -= 2;
            return e;
        }
        public void PrintEven()
        {
            Console.WriteLine("EvenNumber =" + evenNumver);
        }
    }

    delegate void SampleDelegate();
    class DelegateClass
    {
        public void DelegateMethod()
        {
            Console.WriteLine("In the DelegateClass DelegateMethod...");
        }
    }

    class Event
    {
        public EventHandler MyEvent;
        void MyEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Hello world");
        }
        public Event()
        {
            this.MyEvent += new EventHandler(MyEventHandler);
        }
        public void InvokeEvent()
        {
            if (MyEvent!=null)
            {
                MyEvent(this, null);
            }
        }
    }

    class Stack<StackType>
    {
        private StackType[] stack=new StackType[100];
        private int sp = -1;
        public void Push(StackType element)
        {
            stack[++sp] = element;
        }
        public StackType Pop()
        {
            return stack[sp--];
        }
    }
}