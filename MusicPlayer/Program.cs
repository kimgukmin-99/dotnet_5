using System;
public class Music
{
    public string Name { get; set; }
    public string Author { get; set; }
    public Music(string name, string author)
    {
        Name = name;
        Author = author;
    }

    public void Music_Start(Music name)
    {
        string str = name.Name + " " + Author + " " + " 재생중입니다.";
        Console.WriteLine(str);
    }

    public void Music_Stop()
    {
        Console.WriteLine("재생중인 음악 종료");
    }
}

namespace ConsoleApp5
{

    class Program
    {
        static void Main(string[] args)
        {
            Music music1 = new Music("love dive", "ive");
            music1.Music_Start(music1);
        }
    }
}
