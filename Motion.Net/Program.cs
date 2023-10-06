using System.Reflection;
using Microsoft.Extensions.Configuration;
using Moodle.Net.Extensions;
using Motion.Net.Moodle;

namespace Motion.Net;

public class Program
{
    public static void Main(string[] args)
    {
        var client = MoodleClientManager.Instance;
        var x = client!.GetCourses().Count;
        Console.WriteLine(x);
    }
}