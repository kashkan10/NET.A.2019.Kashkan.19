namespace Day19Task
{
    interface IParser
    {
        string GetHost(string str);

        string[] GetParameters(string str);

        string[] GetSegments(string str);
    }
}
