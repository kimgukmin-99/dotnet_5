using System;
using System.Collections.Generic;
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

public class Post
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string Author { get; set; }

    public Post(string title, string content, DateTimeOffset createdAt, string author)
    {
        Title = title;
        Content = content;
        CreatedAt = createdAt;
        Author = author;
    }
}


namespace ConsoleApp5
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Post> posts = new List<Post>(); //게시판리스트 생성
            List<Music> musics = new List<Music>();//음악재생리스트 생성

            while (true)
            {
                Console.WriteLine("1. 호텔 예약");
                Console.WriteLine("2. 게시판 ");
                Console.WriteLine("3. 음악 재생");
                Console.WriteLine("4. 주식 투자 시뮬레이션");

                Console.Write("선택: ");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {

                    case "1": //호텔예약
                        return;



                    case "2":   //게시판클래스
                        int temp = 0;
                        while (temp == 0)
                        {
                            Console.WriteLine("1. 글쓰기");
                            Console.WriteLine("2. 글 목록 보기");
                            Console.WriteLine("3. 종료");

                            Console.Write("선택: ");
                            string input_board = Console.ReadLine();
                            Console.WriteLine();
                            switch (input_board)
                            {
                                case "1":
                                    Console.Write("제목: ");
                                    string title = Console.ReadLine();

                                    Console.Write("내용: ");
                                    string content = Console.ReadLine();

                                    Post post = new Post(title, content, DateTimeOffset.Now, "작성자");
                                    posts.Add(post);

                                    Console.WriteLine();
                                    Console.WriteLine("글이 작성되었습니다.");
                                    Console.WriteLine();
                                    break;

                                case "2":
                                    Console.WriteLine("글 목록");
                                    Console.WriteLine("----------------------------------------");

                                    foreach (Post p in posts)
                                    {
                                        Console.WriteLine("{0} {1} {2}", p.CreatedAt, p.Title, p.Author);
                                    }

                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine();
                                    break;

                                case "3":
                                    Console.WriteLine("프로그램을 종료합니다.");
                                    temp = 1;
                                    break;

                                default:
                                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        continue;




                    case "3":   //음악재생 클래스
                        return;

                      

                    case "4":   //주식투자 시뮬레이션

                        return;
                }
            }

        }
    }
}
