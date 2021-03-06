﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SliderAction
{
    class PlayerFactory
    {
        //ステータス
        enum ColumnNum
        { Chara, POSX, POSY, SPEED, ROT, POS_FIX }

        //Sprite
        enum SpriteType
        {
            Player01
        }
        static Texture2D[] spr;
        static public void Load(ContentManager c)
        {
            spr = new Texture2D[] { c.Load<Texture2D>("Player") };
        }

        static public Player PlayerCreate(int sn)
        {
            int[] stat = ReadCSV.Status("CSV/playerS.csv", sn + 1);

            int cNum = stat[(int)ColumnNum.Chara];
            Vector2 pos = PosAsk(stat[(int)ColumnNum.POSX], stat[(int)ColumnNum.POSY], Convert.ToBoolean(stat[(int)ColumnNum.POS_FIX]), new Vector2(64, 64), 32);//MAPSIZE***
            float speed = stat[(int)ColumnNum.SPEED] / 10;
            int rotNum = stat[(int)ColumnNum.ROT] * 3;
            Vector2[] cp = ColliPosAsk(pos, new Vector2(32 / 2, 32 / 2));

            PlayerVO pvo = new PlayerVO(cNum, spr, pos, speed, rotNum, cp);

            Player player = new Player(pvo);
            return player;
        }

        static Vector2 PosAsk(int x, int y, bool pFix, Vector2 size, int mapSizeH)
        {
            Vector2 pos;

            pos = new Vector2(x * size.X, y * size.Y);
            if (pFix)
                pos += new Vector2(mapSizeH, 0);

            return pos;
        }
        static Vector2[] ColliPosAsk(Vector2 pos, Vector2 hsize)
        {
            Vector2[] dp = new Vector2[sizeof(WallFactory.Square)];
            int ul = (int)WallFactory.Square.UP_LEFT;
            int dr = (int)WallFactory.Square.DOWN_RIGHT;
            dp[ul] = new Vector2(pos.X - hsize.X, pos.Y - hsize.Y);
            dp[dr] = new Vector2(pos.X + hsize.X, pos.Y + hsize.Y);

            return dp;
        }
    }
}
