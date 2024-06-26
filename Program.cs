using System;
using System.Diagnostics;
using System.Reflection;

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


            //Reflection 
            //Reflection inspects the assembly and shows the metadata of that assembly.
            //The namespace System.Reflection enables you to obtain data about the loaded assemblies like
            //what are the type ,methods, properties are they public ,are they private etc.
            //We can invoke methods in runtime.
            var customer = new CutomerReflection(42, "John Doe");
            try
            {

               

                // Get the Type object for CutomerReflection
                Type customerType = typeof(CutomerReflection);

                // Access the Id property using reflection
                var idProperty = customerType.GetProperty("Id");
                int idValue = (int)idProperty.GetValue(customer);
                Console.WriteLine($"Id = {idValue}");

                // Access the Name property using reflection
                var nameProperty = customerType.GetProperty("Name");
                string nameValue = (string)nameProperty.GetValue(customer);
                Console.WriteLine($"Name = {nameValue}");
                Console.WriteLine();
                Console.WriteLine("FullName = {0}", customerType.FullName);
                Console.WriteLine("Name = {0}", customerType.Name);
                Console.WriteLine("Namespace = {0}", customerType.Namespace);

                Console.WriteLine();
                Console.WriteLine("Properties in CustomerReflection:");

                // Get and display properties of the type
                PropertyInfo[] properties = customerType.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(property.PropertyType.Name + " " + property.Name);
                }

                Console.WriteLine();
                Console.WriteLine("Methods in CustomerReflection:");

                // Get and display methods of the type
                MethodInfo[] methods = customerType.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine(method.ReturnType.Name + " " + method.Name);
                }
                // Get and display constructors of the type
                Console.WriteLine();
                Console.WriteLine("Constructors in CustomerReflection:");
                ConstructorInfo[] constructors= customerType.GetConstructors();
                foreach (ConstructorInfo constructor in constructors)
                {
                    Console.WriteLine(constructor.GetType().FullName+ " " + constructor.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            //Another way to do Reflection by using .dll file 
            //load assembly
            var myAssembly = Assembly.LoadFile(@"D:\C# Basic\Delegates\bin\Debug\net5.0\Delegates.dll");
            //fetch types
            var myType = myAssembly.GetTypes();
            Console.WriteLine(myType);
            foreach (var type in myType)
            {
                Console.WriteLine("Name : " + type.Name);
            }
            var MyType = myType[3];
            Console.WriteLine(MyType.Name);
            //create object
            object myObject = Activator.CreateInstance(MyType);
            //Console.WriteLine(myObject);
            //get how many  types of this object
            Type MyProperties = myObject.GetType();

            Console.WriteLine();
            Console.WriteLine("Properties");
            foreach (MemberInfo mf in MyProperties.GetProperties())
            {
                Console.WriteLine(mf.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Methods");
            foreach (MemberInfo mf in MyProperties.GetMethods())
            {
                Console.WriteLine(mf.Name);
            }


            // Events
            EventExample obj = new EventExample();

            // Ensure the event is not null before invoking it
           
              Console.WriteLine(obj.OnMyEvent("Al", "Amin"));
           
            Console.ReadKey();
        }
    }
}
