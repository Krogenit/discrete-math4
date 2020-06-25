using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeezMat4
{
    public class Arrow : GameObject
    {
        private int one, two, ost, ots;
        public bool invert = false;
        public Arrow(Texture2D text, Vector2 pos, int one, int two, int ost, int ots) : base(text, pos)
        {
            this.one = one;
            this.two = two;
            this.ost = ost;
            this.ots = ots;
        }
        public override void Render(SpriteBatch spriteBatch)
        {
            base.Render(spriteBatch);
            float cos = (float)Math.Cos(Rotation);
            float sin = (float)Math.Sin(Rotation);
            float cos1 = (float)Math.Cos(Rotation + 1.57F);
            float sin1 = (float)Math.Sin(Rotation + 1.57F);
            float angle = MathHelper.ToDegrees(Rotation);
            if (Text == Core.s0)
            {
                Rotation += 0.01f;
                float x = 10;
                float y = -60;
                Vector2 newPos = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                x = -20;
                y = -45;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos, Color.Black);
                GameObject.DrawLine(new Color(new Vector3(0.5f, 0, 0)), this.Position + newPos, this.Position + newPos1, spriteBatch, 1);
                GameObject.DrawRectangle(new Color(new Vector3(0.5f, 0, 0)), this.Position + newPos, this.Position + newPos + new Vector2(30, 30), spriteBatch, 1);
                x = 0;
                y = 8;
                newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos + new Vector2(8, 7), Color.Black);
            }
            else if(Text == Core.s2)
            {
                float x1 = -10;
                float y1 = 10;
                //if (angle == 90 || angle == 270)
                    x1 *= (ots / 3f);
                //else
                    y1 *= (ots / 3f);
                Vector2 newPos2 = new Vector2(cos1 * y1 - cos * x1, sin1 * y1 - sin * x1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = 20;
                float y = -4;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(new Color(new Vector3(0.7f, 0, 0)), this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(new Color(new Vector3(0.7f, 0, 0)), this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
            else if (Text == Core.s3)
            {
                float x1 = 10;
                float y1 = -30;
                if (angle == 90 || angle == 270)
                    x1 *= (ots / 4f);
                else
                    y1 *= (ots / 4f);
                Vector2 newPos2 = new Vector2(x1, y1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = -20;
                float y = -26;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(new Color(new Vector3(1f, 0, 0)), this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(new Color(new Vector3(1f, 0, 0)), this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
            else if(Text == Core.s4)
            {
                float x1 = 0;
                float y1 = 10;
                    x1 *= (ots / 4f);
                    y1 *= (ots / 4f);
                Vector2 newPos2 = new Vector2(x1, y1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = -20;
                float y = 0;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(new Color(new Vector3(0.0f, 0.25f, 1)), this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(new Color(new Vector3(0.0f, 0.25f, 1)), this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
            else if (Text == Core.s5)
            {
                float x1 = 10;
                float y1 = -30;
                if (angle == 90 || angle == 270)
                    x1 *= (ots / 4f);
                else
                    y1 *= (ots / 4f);
                Vector2 newPos2 = new Vector2(x1, y1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = -20;
                float y = -45;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(Color.Green, this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(Color.Green, this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
            else if (Text == Core.s6)
            {
                float x1 = -30;
                float y1 = 0;
                x1 *= (ots / 4f);
                y1 *= (ots / 4f);
                Vector2 newPos2 = new Vector2(x1, y1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = -20;
                float y = 0;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(new Color(new Vector3(0.0f, 1f, 1)), this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(new Color(new Vector3(0.0f, 1f, 1)), this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
            else if (Text == Core.s7)
            {
                float x1 = 10;
                float y1 = 0;
                x1 *= (ots / 4f);
                y1 *= (ots / 4f);
                Vector2 newPos2 = new Vector2(x1, y1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = -30;
                float y = 44;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(new Color(new Vector3(1f, 1f, 0)), this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(new Color(new Vector3(1f, 1f, 0)), this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
            else if (Text == Core.s8)
            {
                float x1 = 10;
                float y1 = -30;
                if (angle == 90 || angle == 270)
                    x1 *= (ots / 4f);
                else
                    y1 *= (ots / 4f);
                Vector2 newPos2 = new Vector2(x1, y1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = -20;
                float y = -45;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(Color.Orange, this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(Color.Orange, this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
            else if (Text == Core.s9)
            {
                float x1 = 10;
                float y1 = 0;
                x1 *= (ots / 4f);
                y1 *= (ots / 4f);
                Vector2 newPos2 = new Vector2(x1, y1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = -30;
                float y = -8;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(Color.GreenYellow, this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(Color.GreenYellow, this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
            else
            {
                float x1 = 10;
                float y1 = 10;
                if (angle == 90 || angle == 270)
                    x1 *= (ots / 4f);
                else
                    y1 *= (ots / 4f);
                Vector2 newPos2 = new Vector2(x1, y1);
                spriteBatch.DrawString(Core.consoleFont, "" + one + "\n" + two, this.Position + newPos2, Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + ost + ")", this.Position + newPos2 + new Vector2(8, 7), Color.Black);
                float x = -20;
                float y = 0;
                Vector2 newPos1 = new Vector2(cos1 * y - cos * x, sin1 * y - sin * x);
                GameObject.DrawLine(Color.Black, this.Position + newPos1, this.Position + newPos2, spriteBatch, 1);
                GameObject.DrawRectangle(Color.Black, this.Position + newPos2, this.Position + newPos2 + new Vector2(30, 30), spriteBatch, 1);
            }
        }
    }
}
