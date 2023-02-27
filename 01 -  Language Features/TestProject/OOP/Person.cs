namespace TestProject.OOP
{
    //Abstraction
    internal class Person : IPerson
    {
        public string PersonalId { get; set; } = "010101010101";

        public virtual void PrintPersonalId()
        {
            Console.WriteLine(PersonalId);
        }
    }
}
