using System;
using System.Timers;
using System.Windows;
using System.Threading;


public class TetrisMino
{
    //roll, y, x
    public int[,,] tmino = new int[4, 4, 4]
    {
        {
            {0,1,0,0},
            {1,1,1,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,1,0,0},
            {0,1,1,0},
            {0,1,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {1,1,1,0},
            {0,1,0,0},
            {0,0,0,0}
        },
        {
            {0,1,0,0},
            {1,1,0,0},
            {0,1,0,0},
            {0,0,0,0}
        }
    };

    public int[,,] zmino = new int[4, 4, 4]
    {
        {
            {1,1,0,0},
            {0,1,1,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,1,0},
            {0,1,1,0},
            {0,1,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {1,1,0,0},
            {0,1,1,0},
            {0,0,0,0}
        },
        {
            {1,0,0,0},
            {1,1,0,0},
            {0,1,0,0},
            {0,0,0,0}
        }
    };

    public int[,,] smino = new int[4, 4, 4]
    {
        {
            {0,0,1,1},
            {0,1,1,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,1,0,0},
            {0,1,1,0},
            {0,0,1,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,1,1},
            {0,1,1,0},
            {0,0,0,0}
        },
        {
            {0,0,1,0},
            {0,1,1,0},
            {0,1,0,0},
            {0,0,0,0}
        }
    };

    public int[,,] lmino = new int[4, 4, 4]
    {
        {
            {0,1,0,0},
            {0,1,0,0},
            {0,1,1,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {1,1,1,0},
            {0,0,1,0},
            {0,0,0,0}
        },
        {
            {0,1,0,0},
            {0,1,0,0},
            {1,1,0,0},
            {0,0,0,0}
        },
        {
            {1,0,0,0},
            {1,1,1,0},
            {0,0,0,0},
            {0,0,0,0}
        }
    };

    public int[,,] jmino = new int[4, 4, 4]
    {
        {
            {0,1,0,0},
            {0,1,0,0},
            {1,1,0,0},
            {0,0,0,0}
        },
        {
            {1,0,0,0},
            {1,1,1,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,1,1,0},
            {0,1,0,0},
            {0,1,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {1,1,1,0},
            {0,0,1,0},
            {0,0,0,0}
        }
    };

    public int[,,] omino = new int[4, 4, 4]
    {
        {
            {0,0,0,0},
            {0,1,1,0},
            {0,1,1,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,1,1,0},
            {0,1,1,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,1,1,0},
            {0,1,1,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,1,1,0},
            {0,1,1,0},
            {0,0,0,0}
        }
    };


    public int[,,] imino = new int[4, 4, 4]
    {
        {
            {0,0,1,0},
            {0,0,1,0},
            {0,0,1,0},
            {0,0,1,0}
        },
        {
            {0,0,0,0},
            {1,1,1,1},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,1,0,0},
            {0,1,0,0},
            {0,1,0,0},
            {0,1,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {1,1,1,1},
            {0,0,0,0}
        }
    };


    public int[,,] GetMino(int type)
    {
        switch (type)
        {
            case 0:
                return tmino;
            case 1:
                return zmino;
            case 2:
                return smino;
            case 3:
                return lmino;
            case 4:
                return jmino;
            case 5:
                return omino;
            case 6:
                return imino;
            default:
                return null;
        }
    }

};



public class TetrisMap
{
    TetrisMino mino = new TetrisMino();

    public int[] point = new int[2] { 0, 0 };
    public int roll;
    public int[] now_mino = new int[4] { 0, 0, 0, 0 };

    int[,] map = new int[22, 14] {
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,0,0,0,0,0,0,0,0,0,0,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    };

    int[,] pre_map = new int[22, 14] {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    };

    void ClearPreMap()
    {
        pre_map = new int[22, 14] {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };
    }

    public int[] GetMino()
    {
        return now_mino;
    }

    public int[] GetPoint()
    {
        return point;
    }

    public void SetPoint(int y, int x)
    {
        point = new int[2] { y, x };
        now_mino[2] = y;
        now_mino[3] = x;
    }
    public void SetTpe(int t)
    {
        now_mino[0] = t;
    }

    public void SetRoll(int r)
    {
        if (r == 4)
        {
            r = 0;
        }
        else if (r == -1)
        {
            r = 3;
        }
        roll = r;
        now_mino[1] = r;
    }

    public int GetRoll()
    {
        return roll;
    }


    public void ShowMap()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if ((map[y, x] == 1) || (pre_map[y, x] == 1))
                    Console.Write("■");
                else if (map[y, x] == 0)
                    Console.Write("　");
            }
            Console.Write("\n");
        }
    }

    public void ShowPreMap()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < pre_map.GetLength(0); y++)
        {
            for (int x = 0; x < pre_map.GetLength(1); x++)
            {
                if (pre_map[y, x] == 0)
                    Console.Write("　");
                else if (pre_map[y, x] == 1)
                    Console.Write("■");
            }
            Console.Write("\n");
        }
    }

    public void DrawPreMap(int type, int roll, int point_y, int point_x)
    {
        if (roll == 4)
        {
            roll = 0;
        }
        else if (roll == -1)
        {
            roll = 3;
        }

        ClearPreMap();
        int[,,] ctrl_mino = mino.GetMino(type);

        for (int i = point_y; i < pre_map.GetLength(0); i++)
        {
            for (int j = point_x; j < pre_map.GetLength(1); j++)
            {
                if (point_y <= i && i < point_y + 4)
                {
                    if (point_x <= j && j < point_x + 4)
                    {
                        pre_map[i, j] = ctrl_mino[roll, i - point_y, j - point_x];
                    }
                }
            }
        }
    }

    public void DrawMap(int type, int roll, int point_y, int point_x)
    {
        int[,,] ctrl_mino = mino.GetMino(type);

        for (int i = point_y; i < map.GetLength(0); i++)
        {
            for (int j = point_x; j < map.GetLength(1); j++)
            {
                if (point_y <= i && i < point_y + 4)
                {
                    if (point_x <= j && j < point_x + 4)
                    {
                        map[i, j] = map[i, j] | ctrl_mino[roll, i - point_y, j - point_x];
                    }
                }
            }
        }
    }


    public int CollisionDetectionMap()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if ((pre_map[i, j] == 1) && (map[i, j] == 1))
                {
                    //衝突判定
                    return 1;
                }
            }
        }

        return 0;
    }


    public int CheckGameOver()
    {
        int check = 0;
        for (int i = 0;i < map.GetLength(1); i++)
        {
            if(2 <= i && i < 11)
            {
                check += map[1, i];
            }
        }
        if(check != 0)
        {
            return 1;
        }
        return 0;
    }

    public void ClearLine()
    {
        for (int i = map.GetLength(0) - 3; i >= 0; i--)
        {
            int check = 0;
            for (int j = 2; j < map.GetLength(1) - 2; j++)
            {
                check += map[i, j];
            }
            //ラインが揃った！
            if (check == 10)
            {
                for (int k = i; k >= 1; k--)
                {
                    for (int l = 0; l < map.GetLength(1); l++)
                    {
                        map[k, l] = map[k - 1, l];
                    }
                }
                for (int l = 0; l < map.GetLength(1); l++)
                {
                    if (2 <= l && l < 12)
                    {
                        map[0, l] = 0;
                    }
                    else
                    {
                        map[0, l] = 1;
                    }
                }
            }
        }
    }
}

class Tetris
{
    static int timer_count = 0;

    static void TimerInc()
    {
        timer_count++;
        if (timer_count == 20)
        {
            timer_count = 0;
        }
    }

    static bool game_over_flag = true;
    static string input_key;
    static void Main(string[] args)
    {
        TetrisMap map = new TetrisMap();

        map.SetPoint(0, 5);
        map.SetRoll(0);

        int[] now_mino = new int[4];

        int Detect = 0;


        System.Timers.Timer game_timer = new System.Timers.Timer(11);
        game_timer.Elapsed += (sender, e) =>
        {
            game_timer.Stop();
            //キーボード入力
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                input_key = keyInfo.Key.ToString();
            }

            // 1/60分周　自動落下
            if (timer_count == 0)
            {
                now_mino = map.GetMino();
                map.DrawPreMap(now_mino[0], now_mino[1], now_mino[2] + 1, now_mino[3]);

                Detect = map.CollisionDetectionMap();

                if (Detect == 1) //落下確定処理
                {
                    if (map.CheckGameOver() == 1)
                    {
                        Console.WriteLine("Game Over!!!!!");
                        while (true) ;
                    }

                    map.DrawMap(now_mino[0], now_mino[1], now_mino[2], now_mino[3]);
                    map.SetPoint(0, 5);
                    map.SetRoll(0);
                    for (int clr = 0; clr < 4; clr++)
                    {
                        map.ClearLine();
                    }
                    Random r1 = new System.Random();
                    map.SetTpe(r1.Next(0, 7));
                }
                else
                {
                    map.SetPoint(now_mino[2] + 1, now_mino[3]);
                }
            }

            //ASDJK入力操作
            if (input_key == "A")
            {
                now_mino = map.GetMino();
                map.DrawPreMap(now_mino[0], now_mino[1], now_mino[2], now_mino[3] - 1);
                Detect = map.CollisionDetectionMap();
                if (Detect == 0)
                {
                    map.SetPoint(now_mino[2], now_mino[3] - 1);
                }
                input_key = "";
            }
            if (input_key == "S")
            {
                now_mino = map.GetMino();
                map.DrawPreMap(now_mino[0], now_mino[1], now_mino[2] + 1, now_mino[3]);
                Detect = map.CollisionDetectionMap();
                if (Detect == 0)
                {
                    map.SetPoint(now_mino[2] + 1, now_mino[3]);
                }
                input_key = "";
            }
            if (input_key == "D")
            {
                now_mino = map.GetMino();
                map.DrawPreMap(now_mino[0], now_mino[1], now_mino[2], now_mino[3] + 1);
                Detect = map.CollisionDetectionMap();
                if (Detect == 0)
                {
                    map.SetPoint(now_mino[2], now_mino[3] + 1);
                }
                input_key = "";
            }
            if (input_key == "J")
            {
                now_mino = map.GetMino();

                map.DrawPreMap(now_mino[0], now_mino[1] + 1, now_mino[2], now_mino[3]);
                if (Detect == 0)
                {
                    map.SetRoll(now_mino[1] + 1);
                }
                input_key = "";
            }

            if (input_key == "K")
            {
                now_mino = map.GetMino();

                map.DrawPreMap(now_mino[0], now_mino[1] - 1, now_mino[2], now_mino[3]);
                if (Detect == 0)
                {
                    map.SetRoll(now_mino[1] - 1);
                }
                input_key = "";
            }


            //描画
            now_mino = map.GetMino();
            map.DrawPreMap(now_mino[0], now_mino[1], now_mino[2], now_mino[3]);
            map.ShowMap();

            TimerInc();
            game_timer.Start();
        };

        game_timer.Start();
        while (true) ;
    }
}

