using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wojna
{
    abstract class Human
    {
        private int age;
        private string name;

        public abstract string getCard();
        public abstract int getPower();
        public abstract void addCard(string card);
        public abstract void write_cards();
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }



    }
}
