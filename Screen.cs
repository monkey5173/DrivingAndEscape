using Sketch;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Screen
{
    int _width;
    int _height;
    int _roadWidth;
    int _score;
    int _beforeRoadUpdate;
    int _roadUpdate;
    int _positon;
    char[,] _wall;
    Player car;
    Game gameInfo;
    Item itemInfo;

    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }
    public int RoadWidth
    {
        get { return _roadWidth; }
        set { _roadWidth = value; }
    }
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    public int BeforeRoadUpdate
    {
        get { return _beforeRoadUpdate; }
        set { _beforeRoadUpdate = value; }
    }
    public int RoadUpdate
    {
        get { return _roadUpdate; }
        set { _roadUpdate = value; }
    }

    public int Position
    {
        get { return _positon; }
        set { _positon = value; }
    }

    public char[,] Wall
    {
        get { return _wall; }
        set { _wall = value; }
    }

    public Screen()
    {
        Width = 50; //가로 넓이
        Height = 30; //세로 넓이
        RoadWidth = 10; //길의 넓이
        Score = 0;
        BeforeRoadUpdate = 0;
        RoadUpdate = 0;
        Position = 0;
    }

    public void IPSinfo(Player player, Game game, Item items)
    {
        car = player;
        gameInfo = game;
        itemInfo = items;
    }

    public void SetWall()
    {
        if (gameInfo.GameIsPlaying == true)
        {
            Wall = new char[Height, Width];
            int LeftEdge = (Width - RoadWidth) / 2;
            int RightEdge = LeftEdge + RoadWidth;
            car.Position = Width / 2;
            car.Velocity = 0;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    // 삼항 연산자를 이용해서 벽과 길 만듬(이게 훨 편하네?)              
                    Wall[i, j] = (j < LeftEdge || j > RightEdge) ? '.' : ' ';
                }
            }
        }
    }

    public void Rendering()
    {
        if (gameInfo.GameIsPlaying == true)
        {
            Console.WindowHeight = 35;
            Console.WindowWidth = 52;
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {                   
                    Console.Write(Wall[i,j]);                   
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\n\n\t\t[점수] : {Score} ");
        }
    }

    public void Update(Stopwatch stopwatch)
    {
        if (gameInfo.GameIsPlaying == true)
        {
            Random roadMove = new Random();

            //레이싱하듯이 길을 한줄씩 위로 이동
            for (int i = 0; i < Height - 1; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Wall[i + 1, j] = Wall[i, j];
                }
            }

            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                RoadUpdate = roadMove.NextDouble() < 0.2 ? BeforeRoadUpdate : roadMove.Next(-1, 2);
                stopwatch.Restart();
            }

            //도로가 화면 끝을 나가지 않도록 조정해야 함

            if (RoadUpdate is -1 && Wall[Height - 1, 0] == ' ') RoadUpdate = 1;
            //도로가 왼쪽으로 움직이면서 끝값이 공백이면 즉 도로면 도로를 오른쪽으로 이동하게 설정
            if (RoadUpdate is 1 && Wall[Height - 1, Width - 1] == ' ') RoadUpdate = -1;
            //도로가 오른쪽으로 움직이면서 끝값이 공백이면 즉 도로면 도로를 왼쪽으로 이동

            switch (RoadUpdate)
            {
                case -1: // 도로가 왼쪽으로 이동 시
                    for (int i = 0; i < Width - 1; i++)
                    {
                        Wall[Height - 1, i] = Wall[Height - 1, i + 1];
                        // 벽 배열에 width(X) 축에 + 1 즉, 한칸 오른쪽 값을 대입
                        // 이렇게 대입하면 한칸 오른쪽 값이 그 전 값에 계속 대입되면서 마치 도로가 왼쪽으로 이동하게끔 만들 수 있음
                    }
                    Wall[Height - 1, Width - 1] = '.'; // 오른쪽 끝은 벽처리
                    break;
                case 1: // 도로가 오른쪽으로 이동 시
                    for (int i = Width - 1; i > 0; i--)
                    {
                        Wall[Height - 1, i] = Wall[Height - 1, i - 1]; //위와 반대로 오른쪽으로 이동하게 보임
                    }
                    Wall[Height - 1, 0] = '.'; // 왼쪽 끝은 벽 처리
                    break;
            }
            BeforeRoadUpdate = RoadUpdate; // 전 로드 상황에 현재 로드의 상황을 대입한다.
            car.Position += car.Velocity; // 플레이어 포지션에 속도(방향)의 값을 업데이트 해준다.

            //충돌 감지 기능
            if (car.Position < 0 || car.Position >= Width || Wall[1, car.Position] != ' ')
            {
                gameInfo.GameOver();
                return;
            }
            Score++;
        }
    }        
}

