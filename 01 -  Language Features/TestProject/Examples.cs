namespace TestProject
{
    internal class Examples
    {
        public void Test()
        {
            //Target-Typed new expression
            Dictionary<int, Product> products = new()
            {
                { 1, new Product() },
                { 2, new Product() }
            };

            //is expression pattern match
            if (products is not null)
            {
                //.. Do some operations
            }

            if (products is Dictionary<int, Product>)
            {
                //.. Do some operations
            }

            //Extension method
            var testText = "Text";
            testText.ChangeString();
        }

        //Lambda expression example

        public string TransformText(string text)
        {
            return text.Length < 5 ? text.ToLower() : text.ToUpper();
        }
        public string TransformText1(string text) => text.Length < 5 ? text.ToLower() : text.ToUpper();

        public static long MultiplyFunction(int x, int y)
        {
            return x * y;
        }

        Func<int, int, long> multiply = MultiplyFunction;
        Func<int, int, long> multiply1 = (x, y) => x * y;
    }

    public static class ExtensionMethods
    {
        public static string ChangeString(this string text)
        {
            text += " ChangedText";
            return text;
        }
    }

    public interface ITest
    {
        void Test(string text) => Console.WriteLine(text); 
    }

    public class Test : ITest
    {
            
    }

    public class AsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var message = await client.GetAsync("http://google.com");
            return message.Content.Headers.ContentLength;
        }
    }
}
