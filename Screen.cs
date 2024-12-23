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
    int _width = 0;
    int _height = 0;
    int _roadWidth = 0;
    Char[,] wall;

    public int Width { get; set; }
    public int Height { get; set; }
    public int RoadWidth { get; set; }

    public Screen()
    {
        Width = 60; //가로 넓이
        Height = 30; //세로 넓이
        RoadWidth = 10; //길의 넓이

    }

    public void SetWall()
    {
        wall = new char[Height, Width];
        int LeftEdge = (Width - RoadWidth) / 2;
        int RightEdge = LeftEdge + RoadWidth;

        for(int i = 0; i < Height; i++)
        {
            for(int j = 0; j < Width; j++)
            {
                if(j < LeftEdge || j > RightEdge)
                {
                    wall[i, j] = 'ο';
                }
                else
                {
                    wall[i, j] = ' ';
                }
            }
        }
    }
    
    public void DrawWall()
    {
        for(int i = 0; i < Height; i++)
        {
            for(int j = 0; j < Width; j++)
            {
                Console.Write(wall[i,j]);
            }
            Console.WriteLine();
        }
    }
}

