// See https://aka.ms/new-console-template for more information

using TestProject;
using TestProject.OOP;

Console.WriteLine("Hello, World!");

//Without Top-level statements:

//using System;

//namespace MyApp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}

var test = new Product();

//Example of Generated Implicit Usings:
//global using global::System;
//global using global::System.Collections.Generic;
//global using global::System.IO;
//global using global::System.Linq;
//global using global::System.Net.Http;
//global using global::System.Threading;
//global using global::System.Threading.Tasks;


//Example of Null state analysis

if (test.NickName is not null)
    TestFunction(test.NickName);

void TestFunction(string text)
{
    Console.WriteLine(text);
}


var customer = new Customer();
customer.PrintPersonalId();

//String interpolation

var testText = $"Name: {customer.Name}, Id: {customer.Id}";


//Default implementation
ITest testObject = new Test();
testObject.Test("Text from interface");


//Asynchronous call example
Console.WriteLine(await AsyncMethods.GetPageLength());