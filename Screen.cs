using Sketch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct Vector2
{
    int _x;
    int _y;

    public int X { get; set; }
    public int Y { get; set; }
    
}

class Screen
{
    int _width;
    int _height;
    int _roadWidth;
    int _score;
    int _beforeRoadUpdate;
    Char[,] wall;
    Player Car = new Player();
    Game game = new Game();
    

    public int Width { get; set; }
    public int Height { get; set; }
    public int RoadWidth { get; set; }
    public int Score { get; set; }
    public int BeforeRoadUpdate { get; set; }

    public Screen()
    {
        Width = 50; //가로 넓이
        Height = 30; //세로 넓이
        RoadWidth = 10; //길의 넓이
        Score = 0;
        BeforeRoadUpdate = 0;

    }

    public void SetWall()
    {
        wall = new char[Height, Width];
        int LeftEdge = (Width - RoadWidth) / 2;
        int RightEdge = LeftEdge + RoadWidth;
        Car.Position = Width / 2;
        Car.Velocity = 0;

        for(int i = 0; i < Height; i++)
        {
            for(int j = 0; j < Width; j++)
            {
                // 삼항 연산자를 이용해서 벽과 길 만듬(이게 훨 편하네?)
                wall[i, j] = (j < LeftEdge || j > RightEdge) ? '.' : ' ';                
            }
        }
    }
    
    public void Rendering()
    {
        StringBuilder stringBuilder = new StringBuilder(Width * Height);
        for(int i = Height - 1; i >= 0; i--)
        {
            for(int j = 0; j < Width; j++)
            {
                if(i == 1 && j == Car.Position)
                {
                    stringBuilder.Append(!game.GameIsPlaying? 'X' : Car.Velocity < 0 ? '◀' : Car.Velocity > 0 ? '▶' : '▲' );
                }
                else
                {
                    stringBuilder.Append(wall[i, j]);
                }
            }
            if( i > 0 )
            {
                stringBuilder.AppendLine();
            }
        }
        Console.SetCursorPosition( 0, 0 );
        Console.WriteLine(stringBuilder);
    }

    public void Update()
    {
        Random roadMove = new Random();

        //레이싱하듯이 길을 한줄씩 위로 이동
        for (int i = 0; i < Height - 1; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                wall[i, j] = wall[i + 1, j];
            }
        }

        int roadUpdate = roadMove.NextDouble() < 0.6 ? 0 : roadMove.Next(-1, 2);


        //도로가 화면 끝을 나가지 않도록 조정해야 함

        if (roadUpdate is -1 && wall[Height - 1, 0] == ' ') roadUpdate = 1;
        //도로가 왼쪽으로 움직이면서 끝값이 공백이면 즉 도로면 도로를 오른쪽으로 이동하게 설정
        if (roadUpdate is 1 && wall[Height - 1, Width - 1] == ' ') roadUpdate = -1;
        //도로가 오른쪽으로 움직이면서 끝값이 공백이면 즉 도로면 도로를 왼쪽으로 이동

        switch (roadUpdate)
        {
            case -1: // 도로가 왼쪽으로 이동 시
                for (int i = 0; i < Width - 1; i++)
                {
                    wall[Height - 1, i] = wall[Height - 1, i + 1];
                    // 벽 배열에 width(X) 축에 + 1 즉, 한칸 오른쪽 값을 대입
                    // 이렇게 대입하면 한칸 오른쪽 값이 그 전 값에 계속 대입되면서 마치 도로가 왼쪽으로 이동하게끔 만들 수 있음
                }
                wall[Height - 1, Width - 1] = '.'; // 오른쪽 끝은 벽처리
                break;
            case 1: // 도로가 오른쪽으로 이동 시
                for (int i = Width - 1; i > 0; i--)
                {
                    wall[Height - 1, i] = wall[Height - 1, i - 1]; //위와 반대로 오른쪽으로 이동하게 보임
                }
                wall[Height - 1, 0] = '.'; // 왼쪽 끝은 벽 처리
                break;
        }
        BeforeRoadUpdate = roadUpdate; // 전 로드 상황에 현재 로드의 상황을 대입한다.
        Car.Velocity = Car.Position; // 포지션 값을 속도(방향)에 대입한다. 

        //충돌 감지 기능을 넣어야 할듯?
        if (Car.Position < 0 || Car.Position >= Width || wall[1, Car.Position] != ' ')
        {
            game.GameIsPlaying = false;
        }
    }    
}

