using System;
using System.Diagnostics;

namespace Delegates
{
    //step 1 defining a delegate
    public  delegate int AddDelegate(int x, int y);
    public delegate void RectDelegate(double x, double y);
    public delegate string GreetingDel(string name);

    class Program
    {
       
        public static int AddNum(int num1,int num2)
        {
            return num1 + num2;
        }
        static void Main(string[] args)
        {

            //same type method that means return Type same and parameter same then we use delegate;same method signature
            // step 2 instansiated delegate
            AddDelegate addNums = new AddDelegate(AddNum);//sigle cast delegate
            //step 3 invoke 
            var result=addNums(10, 40);
            Console.WriteLine(result);
            Test rect = new Test();
            //multicast delegate
            RectDelegate re = new RectDelegate(rect.GetArea);
            re += rect.GetPerimeter;
            re.Invoke(17.77, 40.33);
            //Console.WriteLine(re(10.0, 20.0));
            // AnonymousMethods ano = new AnonymousMethods();

            //GreetingDel greet = new GreetingDel(AnonymousMethods.Greetings);
            //Console.WriteLine(greet("Al Amin"));


            //call anonymous function through delegate
            //GreetingDel greet = delegate(string name)
            //  {
            //    return "Hello " + name + " Have A Good Day!";
            //  };


            //anonymous function with lambda expression 
            GreetingDel greet=(name)=>
              {
                return "Hello " + name + " Have A Good Day!";
              };
            Console.WriteLine(greet("Al Amin"));

            //Attribute
            var attributes = typeof(AttributeTest).GetCustomAttributes(true);
            foreach(var att in attributes){
                if (att is AttributeTest)
                {
                    var attValue = (AttributeTest)att;
                    Console.WriteLine($"Name :{attValue.Name}, Quantity:{attValue.quantity}");
                }
               

            }
            var attributes1 = typeof(ConditionalAttribute).GetCustomAttributes(true);
            foreach (var att in attributes1)
            {
                
                if (att is ConditionalAttribute)
                {
                    var attValue = (ConditionalAttribute)att;
                    Console.WriteLine($"ConditionString: {attValue.ConditionString} Message :{attValue.ToString()}");
            
                }

            }
        }
    }
}
