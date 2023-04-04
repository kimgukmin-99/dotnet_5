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

public class Reservation
{
    public string GuestName { get; set; }  // 투숙객 이름
    public int PhoneNumber { get; set; }    // 방 번호
    public DateTimeOffset CheckInDate { get; set; }  // 체크인 날짜
    public DateTimeOffset CheckOutDate { get; set; } // 체크아웃 날짜

    public Reservation(string guestName, int phoneNumber, DateTimeOffset checkInDate, DateTimeOffset checkOutDate)
    {
        GuestName = guestName;
        PhoneNumber = phoneNumber;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
    }

    public void PrintReservationInfo()
    {
        Console.WriteLine("예약 정보:");
        Console.WriteLine("투숙객 이름: " + GuestName);
        Console.WriteLine("방 번호: " + PhoneNumber);
        Console.WriteLine("체크인 날짜: " + CheckInDate.ToString("yyyy년 MM월 dd일"));
        Console.WriteLine("체크아웃 날짜: " + CheckOutDate.ToString("yyyy년 MM월 dd일"));
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
            List<Reservation> reservations = new List<Reservation>(); //호텔예약 리스트 생성

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
                        Console.WriteLine("=== 호텔 예약 ===");
                        Console.Write("이름을 입력해주세요: ");
                        string name = Console.ReadLine();
                        Console.Write("전화번호를 입력해주세요: ");
                        int phoneNumber = int.Parse(Console.ReadLine());
                        Console.Write("체크인 날짜를 입력해주세요(yyyy-MM-dd): ");
                        DateTimeOffset checkIn = DateTimeOffset.Parse(Console.ReadLine());
                        Console.Write("체크아웃 날짜를 입력해주세요(yyyy-MM-dd): ");
                        DateTimeOffset checkOut = DateTimeOffset.Parse(Console.ReadLine());

                        Reservation reservation = new Reservation(name, phoneNumber, checkIn, checkOut);
                        reservations.Add(reservation);

                        Console.WriteLine();
                        Console.WriteLine("예약이 완료되었습니다.");
                        Console.WriteLine();
                        break;



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
                        while (true)
                        {
                            Console.WriteLine("1. 재생목록 저장");
                            Console.WriteLine("2. 플레이리스트 보기");
                            Console.WriteLine("3. 음악 재생");
                            Console.WriteLine("4. 종료");
                            Console.Write("선택: ");
                            string input_music = Console.ReadLine();
                            Console.WriteLine();

                            switch (input_music)
                            {
                                case "1":
                                    Console.Write("제목: ");
                                    string name1 = Console.ReadLine();

                                    Console.Write("가수명: ");
                                    string author = Console.ReadLine();

                                    Music music = new Music(name1, author);
                                    musics.Add(music);

                                    Console.WriteLine();
                                    Console.WriteLine("재생목록에 저장되었습니다.");
                                    Console.WriteLine();
                                    break;

                                case "2":
                                    Console.WriteLine("플레이리스트 목록");
                                    Console.WriteLine("제목          가수명          ");
                                    Console.WriteLine("----------------------------------------");

                                    foreach (Music p in musics)
                                        {
                                        Console.WriteLine("{0}           {1}", p.Name, p.Author);
                                        }
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine();
                                    break;

                                case "3":
                                    Console.WriteLine("재생할 음악을 선택해 주세요.");
                                    break;
                                    

                                case "4":
                                    Console.WriteLine("프로그램을 종료합니다.");
                                    break;
                                    

                                default:
                                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                

                      

                    case "4":   //주식투자 시뮬레이션

                        return;
                }
            }

        }
    }
}
