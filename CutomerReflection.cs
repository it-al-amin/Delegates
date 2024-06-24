using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //definition:  is the ability of inspecting an assemlies's metadata at runtime.
    //when uses: late binding 
    class CutomerReflection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CutomerReflection(int Id,string name)
        {
            this.Id = Id;
            this.Name = name;
        }
        public CutomerReflection()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }
        public void PrintId()
        {
            Console.WriteLine("Id = {0}", this.Id);

        }
        public void PrintName()
        {
            Console.WriteLine("Name = {0}", this.Name);

        }

    }
}
