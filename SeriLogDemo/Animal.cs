using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriLogDemo
{
    public class Animal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Animal(string n, string c)
        {
            Name = n;
            Color = c;
        }

        public void Move() => Console.WriteLine($"{Name} is moving");

        public void Eat() => Console.WriteLine($"{Name} is eating");

        public override string ToString() => Name;
    }
}
