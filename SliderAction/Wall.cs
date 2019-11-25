﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    class Wall : IWall
    {
        bool nowDraw;
        public bool NowDraw => nowDraw;

        WallVO wallVo;
        public override Texture2D Spr => wallVo.Spr;
        public override Vector2 Pos => wallVo.Pos;
        public override Vector2[] DamagePos => wallVo.DamagePos;
        public override float Rot => wallVo.Rot;
        public override Color Cr => wallVo.Cr;
        public override Vector2 Gap => wallVo.Gap;
        public override bool Bend => wallVo.Bend;
        public override List<Vector2[]> RecoverPos => wallVo.RecoverPos;

        //テスト
     public  Texture2D recT;

        public Wall(WallVO wvo, Texture2D rect)
        {
            wallVo = wvo;
            recT = rect;
        }
        public void Init()
        {
            nowDraw = true;
        }

        public void DrawChenge() //***最初はfalse 移ったものだけtrue
        {
        }

        public void Draw(SpriteBatch sb)
        {
            if (!nowDraw) return;
            sb.Draw(Spr, Pos, null, Cr, Rot, new Vector2(HALF_SIZE, HALF_SIZE), Vector2.One, SpriteEffects.None, 0);

            // テスト
            int ul = (int)WallFactory.Square.UP_LEFT;
            int dr = (int)WallFactory.Square.DOWN_RIGHT;
            foreach (var r in RecoverPos)
                sb.Draw(recT, new Rectangle((int)r[ul].X, (int)r[ul].Y, (int)(r[dr].X - r[ul].X), (int)(r[dr].Y -r[ul].Y)), Color.Wheat*0.5f);

        }
    }
}
