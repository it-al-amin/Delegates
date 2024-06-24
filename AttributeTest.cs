using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //Attribute is a metadata which carries information to a class ,methods properties etc inside of a class ;
    //metadata is an information of to components which are known to each other
    [Serializable]
    [AttributeTest("Attribute Test",quantity =10)]//custom Attribute
    [AttributeTest("Attribute Another", quantity = 20)]//custom Attribute
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=true)]
   

    
    class AttributeTest:Attribute
    {
        private readonly string name;
        public int quantity;
        public AttributeTest(string name)
        {
            this.name = name;
        }
        public string Name => name;
        

    }
    // ConditionalAttribute as a separate class
    [Conditional("DEBUG")]
    internal class ConditionalAttribute : Attribute
    {
        private string v;

        public ConditionalAttribute(string v)
        {
            this.v = v;
        }

        public string ConditionString => v;

        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }


}
