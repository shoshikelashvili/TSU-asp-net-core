namespace TestProject.OOP
{
    //Different class accessibility modifiers:
    //public, private, protected, internal, internal protected

    //Different modifiers:
    //sealed, static, unsafe, abstract, partial
    internal class Customer : Person
    {
        private string _name;

        public int Id;

        private bool _showPrivateInfo = true;

        //Encapsulation example
        public string Name 
        { 
            get { return _name; }
            set 
            { 
                if(value.Length < 10)
                {
                    _name = value;
                }
            } 
        }

        public Customer()
        {
            Id = 1;
            Name = "Test";
        }

        public void WriteToConsole(string text)
        {
            Console.WriteLine(text);
        }

        //Polymorphism example
        public void WriteToConsole(string text, int numberOfTimes)
        {
            for(int i =0; i<numberOfTimes; i++)
                Console.WriteLine(text);
        }

        //Inheritance and Polymorphism example
        public override void PrintPersonalId()
        {
            if(_showPrivateInfo)
                base.PrintPersonalId();
        }
    }
}
