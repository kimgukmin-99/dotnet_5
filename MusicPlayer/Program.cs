using System;
using System.Collections.Generic;
public class Music
{
    // 인스턴스 변수
    private string name;
    private string author;

    // 속성
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    // 클래스 변수
    private static int numInstances = 0;

    // 생성자
    public Music(string name, string author)
    {
        Name = name;
        Author = author;
        numInstances++;
    }

    // 메소드 오버로딩
    public void Music_Start()
    {
        Console.WriteLine(Name + " " + Author + " 재생중입니다.");
    }

    public void Music_Start(string playlistName)
    {
        Console.WriteLine("재생목록 " + playlistName + " 에서 " + Name + " " + Author + " 재생중입니다.");
    }

    public void Music_Stop()
    {
        Console.WriteLine(Name + " " + Author + " 재생 중지");
    }

    // 클래스 메소드
    public static int GetNumInstances()
    {
        return numInstances;
    }
}


class Board
{
    // 클래스 변수
    private static int boardCount = 0;

    // 인스턴스 변수
    private int boardId;
    private string name;
    private List<Post> posts;
    private List<Comment> comments;

    // 속성
    public int BoardId
    {
        get { return boardId; }
        set { boardId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // 생성자
    public Board(string name)
    {
        this.boardId = boardCount;
        this.name = name;
        this.posts = new List<Post>();
        this.comments = new List<Comment>();
        boardCount++;
    }

    // 인스턴스 메서드
    public void AddPost(Post post)
    {
        posts.Add(post);
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // 메소드 오버로딩
    public void DeletePost(int postId)
    {
        foreach (Post p in posts)
        {
            if (p.PostId == postId)
            {
                posts.Remove(p);
                return;
            }
        }
    }

    public void DeletePost(Post post)
    {
        posts.Remove(post);
    }
}


class Post
{
    public int PostId { get; set; }
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

class Comment
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
}


public class Reservation
{
    private static int reservationCount;  // 클래스 변수 - 전체 예약 수

    public string GuestName { get; set; }  // 속성 - 투숙객 이름
    public string PhoneNumber { get; set; }    // 속성 - 휴대폰 번호
    public DateTimeOffset CheckInDate { get; set; }  // 속성 - 체크인 날짜
    public DateTimeOffset CheckOutDate { get; set; } // 속성 - 체크아웃 날짜
    public int ReservationId { get; private set; }  // 속성 - 예약 번호 (읽기 전용)

    public Reservation(string guestName, string phoneNumber, DateTimeOffset checkInDate, DateTimeOffset checkOutDate)
    {
        GuestName = guestName;
        PhoneNumber = phoneNumber;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        reservationCount++;  // 예약 수 증가
        ReservationId = reservationCount;  // 예약 번호 할당
    }

    public void PrintReservationInfo()
    {
        Console.WriteLine("예약 정보:");
        Console.WriteLine("예약 번호: " + ReservationId);
        Console.WriteLine("투숙객 이름: " + GuestName);
        Console.WriteLine("방 번호: " + PhoneNumber);
        Console.WriteLine("체크인 날짜: " + CheckInDate.ToString("yyyy년 MM월 dd일"));
        Console.WriteLine("체크아웃 날짜: " + CheckOutDate.ToString("yyyy년 MM월 dd일"));
    }

    // 메소드 오버로딩 - 예약 수정 기능 추가
    public void ModifyReservation(DateTimeOffset checkInDate, DateTimeOffset checkOutDate)
    {
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Console.WriteLine("예약 정보가 수정되었습니다.");
    }

    // 메소드 오버로딩 - 예약 취소 기능 추가
    public void CancelReservation()
    {
        Console.WriteLine("예약이 취소되었습니다.");
        reservationCount--;  // 예약 수 감소
    }
}

public class StockInvestment
{
    // 인스턴스 변수
    private string company;
    private int numberOfShares;
    private decimal buyPrice;
    private decimal currentPrice;

    // 클래스 변수
    private static decimal commissionRate = 0.05m;

    // 속성
    public string Company
    {
        get { return company; }
        set { company = value; }
    }

    public int NumberOfShares
    {
        get { return numberOfShares; }
        set { numberOfShares = value; }
    }

    public decimal BuyPrice
    {
        get { return buyPrice; }
        set { buyPrice = value; }
    }

    public decimal CurrentPrice
    {
        get { return currentPrice; }
        set { currentPrice = value; }
    }

    // 생성자
    public StockInvestment(string company, int numberOfShares, decimal buyPrice, decimal currentPrice)
    {
        Company = company;
        NumberOfShares = numberOfShares;
        BuyPrice = buyPrice;
        CurrentPrice = currentPrice;
    }

    // 메소드 오버로딩
    public StockInvestment(string company, int numberOfShares, decimal buyPrice)
        : this(company, numberOfShares, buyPrice, 0) { }

    // 메소드
    public decimal GetCurrentTotalValue()
    {
        return NumberOfShares * CurrentPrice;
    }

    public decimal GetProfitOrLoss()
    {
        return GetCurrentTotalValue() - NumberOfShares * BuyPrice;
    }

    public decimal GetProfitOrLoss(decimal commission)
    {
        return GetCurrentTotalValue() - NumberOfShares * BuyPrice - commission;
    }

    public void PrintStockInfo()
    {
        Console.WriteLine("주식 정보:");
        Console.WriteLine("회사명: " + Company);
        Console.WriteLine("주식 수량: " + NumberOfShares);
        Console.WriteLine("매수 가격: " + BuyPrice.ToString("C"));
        Console.WriteLine("현재 가격: " + CurrentPrice.ToString("C"));
        Console.WriteLine("현재 총 가치: " + GetCurrentTotalValue().ToString("C"));
        Console.WriteLine("손익: " + GetProfitOrLoss().ToString("C"));
    }

    // 클래스 메소드
    public static void SetCommissionRate(decimal rate)
    {
        commissionRate = rate;
    }

    public static decimal GetCommissionRate()
    {
        return commissionRate;
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
                        string phoneNumber = Console.ReadLine();
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
                        int temp_music = 0;
                        while (temp_music == 0)
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
                                    Console.WriteLine("제목               가수명          ");
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
                                    input_music = Console.ReadLine();
                                    Console.WriteLine(input_music + "이 재생 중입니다.");
                                    break;
                                    

                                case "4":
                                    Console.WriteLine("프로그램을 종료합니다.");
                                    temp_music = 1;
                                    break;
                                    

                                default:
                                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        continue;
                
                    case "4":   //주식투자 시뮬레이션
                        Console.WriteLine("=== 주식 투자 시뮬레이션 ===");
                        Console.Write("회사명을 입력해주세요: ");
                        string company = Console.ReadLine();
                        Console.Write("주식 수량을 입력해주세요: ");
                        int numberOfShares = int.Parse(Console.ReadLine());
                        Console.Write("매수 가격을 입력해주세요: ");
                        decimal buyPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("현재 가격을 입력해주세요: ");
                        decimal currentPrice = decimal.Parse(Console.ReadLine());

                        StockInvestment stockInvestment = new StockInvestment(company, numberOfShares, buyPrice, currentPrice);

                        stockInvestment.PrintStockInfo();

                        Console.WriteLine();
                        break;
                }
            }

        }
    }
}