using RestSharp;

using Newtonsoft.Json.Linq;

class Program
{
    //create a new class with properties that match the endpoint that you want to send Data
    //in this case the endpoint requires two properties that is the Title and the Body
    public class Post
        {
        public string? Title { get; set; }
        public string? Body { get; set; }

    }
    //main method, the entry point of the Application
     static void Main(string[] args)
    {
        //an instance of the Post class created above 
        var post = new Post()
        {
            Title = "My Award winning Title",
            Body ="A story about  practice beats Talent"

        };

        //RestSharp  POST method using the built-in serialization
        //This Post Request will send Data to a Fake API endpoint provided
        //this method requires that you create a class, a post class has been created, then instantiate it in the main Method
        using (var client = new RestClient("https://jsonplaceholder.typicode.com/posts"))
        {
           
            var request = new RestRequest();
            request.AddJsonBody(post);


            var result = client.PostAsync(request).Result;
        }
        //RestSharp  POST method using the NewtonSoft serialization
        //This Post Request will send Data to a Fake API endpoint provided

        using (var client = new RestClient("https://jsonplaceholder.typicode.com/posts"))
        {
            var payload = new JObject();
            payload.Add("Title", "My Awesome Title");
            payload.Add("Body", "My awesome post content");
            var request = new RestRequest();
            request.AddStringBody(payload.ToString(), DataFormat.Json);
            var result = client.PostAsync(request).Result;
        }

        //RestSharp Get Method to fetch Data from an API endpoint( get request method)
        using (var client = new RestClient("https://jsonplaceholder.typicode.com/posts"))
        {
            var request = new RestRequest();
            var results = client.GetAsync(request).Result;

        }


    }
}