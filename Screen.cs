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
        Wall = new char[Height, Width];
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
            int LeftEdge = (Width - RoadWidth) / 2;
            int RightEdge = LeftEdge + RoadWidth;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    // 삼항 연산자를 이용해서 벽과 길 만듬.             
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

            for (int i = Height - 1; i >= 0; i--)
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

            //랜더링 메서드에서 출력을 거꾸로 !! (0,0)이 아닌 (29,0)부터 시작함 !! 한 상태에서
            //업데이트에서 다시 정상 상태로 반복문을 돌면서 y축 처음값(맨아래)에 다음값(그 위)을 대입하는 식으로
            //반복문을 돌면 맨 아래의 조건에 의해서 맨위에서 바뀌어지는 값들이 한줄씩 계속 내려옴
            //맨위에서부터 업데이트되는 값들이 아래로 한줄씩 내려오는 것을 반복한다.
            //즉, 맵이 한줄씩 내려오면서 플레이어가 전진한다라는 느낌이 들게 된다.
            for (int i = 0; i < Height - 1; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Wall[i, j] = Wall[i + 1, j];
                }
            }

            //1초가 지날때마다
            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                //NextDoule()은 0 ~ 1 사이의 값을 뽑는다. 0.2보다 작을 확률은 약 20프로 정도. 이것이 참이면 움직임 없다.
                //클 확률은 80%다. 즉, 약 80프로 확률로 랜덤한 값을 뽑아 아래의 조건문과 Switch문에 의해서 맵이 업데이트 된다.
                //쉽게 말해, 길을 역동적으로 움직이게 시도를 할 확률이 80%. 물론 0이 나올시에는 변화없다.
                RoadUpdate = roadMove.NextDouble() < 0.2 ? BeforeRoadUpdate : roadMove.Next(-1, 2);
                stopwatch.Restart();
            }

            //도로가 화면 끝을 나가지 않도록 조정해야 함

            if (RoadUpdate is -1 && Wall[Height - 1, 0] == ' ') RoadUpdate = 1;
            //도로가 왼쪽으로 움직이면서 끝값이 공백이면 즉 도로면 도로를 오른쪽으로 이동하게 설정

            if (RoadUpdate is 1 && Wall[Height - 1, Width - 1] == ' ') RoadUpdate = -1;
            //도로가 오른쪽으로 움직이면서 끝값이 공백이면 즉 도로면 도로를 왼쪽으로 이동

            //위에 Stopwatch기능에 의한 확률로 random.Next가 발동했을시에 -1, 0, 1 중 -1과 1이 뽑히면
            //아래의 switch문이 발동한다. -1이면 길이 왼쪽으로 이동, 1이면 오른쪽으로 이동.
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
            Score++; //점수 증가
        }
    }        
}

