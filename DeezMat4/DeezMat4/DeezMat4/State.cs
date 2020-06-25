using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeezMat4
{
    public class State : GameObject
    {
        private int[] newStates = new int[4];
        private int[] restStates = new int[4];
        private int value, a, b;
        private Core f;
        private int num, i, j;
        public State(int a, int b, int value, Core f, int i, int j, int num):base(Core.q, new Vector2(400 + i * 150, 150 + j * 150))
        {
            this.value = value;
            this.a = a;
            this.b = b;
            this.f = f;
            this.i = i;
            this.j = j;
            this.num = num;
        }

        public void calculateStates()
        {
            int a = toTen(this.a.ToString());
            int b = toTen(this.b.ToString());
            int value = toTen(this.value.ToString());
            getNewState(a * 0 + b * 0 + value, 0);
            int[] output = f.addState(newStates[0]);
            if (output != null)
                createArrow(output[0], output[1], 0, 0, restStates[0]);
            getNewState(a * 0 + b * 1 + value, 1);
            output = f.addState(newStates[1]);
            if (output != null)
                createArrow(output[0], output[1], 0, 1, restStates[1]);
            getNewState(a * 1 + b * 0 + value, 2);
            output = f.addState(newStates[2]);
            if (output != null)
                createArrow(output[0], output[1], 1, 0, restStates[2]);
            getNewState(a * 1 + b * 1 + value, 3);
            output = f.addState(newStates[3]);
            if (output != null)
                createArrow(output[0], output[1], 1, 1, restStates[3]);
        }

        public static string toDouble(int x)
        {
            if(x < 0) { return "-" + Convert.ToString(x*-1, 2); }
            else { return Convert.ToString(x, 2); }
        }

        public static int toTen(string x)
        {
            if (x[0].Equals('-')) 
            {
                string s1 = x.Substring(1, x.Length-1);
                return Convert.ToInt32(s1, 2)*-1;
            }
            else
            {
                return Convert.ToInt32(x, 2);
            }
        }
        private int getArrowCount(Texture2D text, int i, int j)
        {
            List<Arrow>[,] arrows = f.arrowsGrid;
            int c = 0;
            if (arrows[i, j] != null)
            foreach (Arrow a in arrows[i, j])
                if (a != null && a.Text == text)
                    c += 1;
            return c;
        }
        private void createArrow(int i, int j, int one, int two, int ost)
        {
            List<Arrow>[,] arrows = f.arrowsGrid;
            Arrow o = null;
            State s = f.getState(i, j);
            float range = Vector2.Distance(s.Position, Position);
            int x = (int)((this.Position.X + s.Position.X) / 2f);
            int y = (int)((this.Position.Y + s.Position.Y) / 2f);
            if (this == s)
            {
                o = new Arrow(Core.s0, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f),
                    one, two, ost, 1);
                o.Rotation = MathHelper.ToRadians(getArrowCount(Core.s0, x, y) * 70);
            }
            else
            {
                float angle = (float)(Math.Atan2(-this.Position.Y + s.Position.Y, -this.Position.X + s.Position.X));
                float ang = MathHelper.ToDegrees(angle);
                int ot = 10;
                if (range == 150)
                {
                    int count = getArrowCount(Core.s1, x, y);
                    if (count == 0)
                    {
                        if (ang == 0 || ang == 180)
                            o = new Arrow(Core.s1, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f - ot),
                   one, two, ost, 1);
                        else
                            o = new Arrow(Core.s1, new Vector2((this.Position.X + s.Position.X) / 2f - ot, (this.Position.Y + s.Position.Y) / 2f),
                   one, two, ost, 1);
                    }
                    else
                    {
                        if (ang == 0 || ang == 180)
                            o = new Arrow(Core.s1, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f - ot + ot * count),
                   one, two, ost, ot * count);
                        else
                            o = new Arrow(Core.s1, new Vector2((this.Position.X + s.Position.X) / 2f - ot + ot * count, (this.Position.Y + s.Position.Y) / 2f),
                       one, two, ost, ot * count);
                    }
                }
                else if (range > 211 && range < 213)
                {
                    int count = getArrowCount(Core.s2, x, y);
                    if (count == 0)
                    {
                        if (ang == 0 || ang == 180)
                            o = new Arrow(Core.s2, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f - ot),
                   one, two, ost, 1);
                        else
                            o = new Arrow(Core.s2, new Vector2((this.Position.X + s.Position.X) / 2f - ot, (this.Position.Y + s.Position.Y) / 2f),
                   one, two, ost, 1);
                    }
                    else
                    {
                        if (ang == 0 || ang == 180)
                            o = new Arrow(Core.s2, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f - ot + ot * count),
                   one, two, ost, ot * count);
                        else
                            o = new Arrow(Core.s2, new Vector2((this.Position.X + s.Position.X) / 2f - ot + ot * count, (this.Position.Y + s.Position.Y) / 2f),
                       one, two, ost, ot * count);
                    }
                }
                else if (range == 300)
                {
                    int count = getArrowCount(Core.s3, x, y);
                    if (count == 0)
                    {
                        if (ang == 0 || ang == 180)
                            o = new Arrow(Core.s3, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f - ot),
                   one, two, ost, 1);
                        else
                            o = new Arrow(Core.s3, new Vector2((this.Position.X + s.Position.X) / 2f - ot, (this.Position.Y + s.Position.Y) / 2f),
                   one, two, ost, 1);
                    }
                    else
                    {
                        if (ang == 0 || ang == 180)
                            o = new Arrow(Core.s3, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f - ot + ot * count),
                   one, two, ost, ot * count);
                        else
                            o = new Arrow(Core.s3, new Vector2((this.Position.X + s.Position.X) / 2f - ot + ot * count, (this.Position.Y + s.Position.Y) / 2f),
                       one, two, ost, ot * count);
                    }
                }
                else if (range > 334 && range < 336)
                {
                    int count = getArrowCount(Core.s4, x, y);
                    if (count == 0)
                    {
                        o = new Arrow(Core.s4, new Vector2((this.Position.X + s.Position.X) / 2f - ot, (this.Position.Y + s.Position.Y) / 2f - ot),
               one, two, ost, 1);
                    }
                    else
                    {
                        o = new Arrow(Core.s4, new Vector2((this.Position.X + s.Position.X) / 2f - ot + ot * count, (this.Position.Y + s.Position.Y) / 2f - ot + ot * count),
                       one, two, ost, ot * count);
                    }
                }
                else if (range > 424 && range < 425)
                {
                    int count = getArrowCount(Core.s7, x, y);
                    if (count == 0)
                    {
                        o = new Arrow(Core.s7, new Vector2((this.Position.X + s.Position.X) / 2f - ot, (this.Position.Y + s.Position.Y) / 2f - ot),
                        one, two, ost, 1);
                    }
                    else
                    {
                        o = new Arrow(Core.s7, new Vector2((this.Position.X + s.Position.X) / 2f - ot + ot * count, (this.Position.Y + s.Position.Y) / 2f - ot + ot * count),
                       one, two, ost, ot * count);
                    }
                }
                else if (range == 450)
                {
                    int count = getArrowCount(Core.s5, x, y);
                    if (count == 0)
                    {
                        if (ang == 0 || ang == 180)
                            o = new Arrow(Core.s5, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f + ot),
                   one, two, ost, 1);
                        else
                            o = new Arrow(Core.s5, new Vector2((this.Position.X + s.Position.X) / 2f + ot, (this.Position.Y + s.Position.Y) / 2f),
                   one, two, ost, 1);
                    }
                    else
                    {
                        if (ang == 0 || ang == 180)
                            o = new Arrow(Core.s5, new Vector2((this.Position.X + s.Position.X) / 2f, (this.Position.Y + s.Position.Y) / 2f + ot + ot * count),
                   one, two, ost, ot * count);
                        else
                            o = new Arrow(Core.s5, new Vector2((this.Position.X + s.Position.X) / 2f + ot + ot * count, (this.Position.Y + s.Position.Y) / 2f),
                       one, two, ost, ot * count);
                    }
                }
                else if (range > 473 && range < 475)
                {
                    int count = getArrowCount(Core.s6, x, y);
                    if (count == 0)
                    {
                        o = new Arrow(Core.s6, new Vector2((this.Position.X + s.Position.X) / 2f - ot, (this.Position.Y + s.Position.Y) / 2f - ot),
               one, two, ost, 1);
                    }
                    else
                    {
                        o = new Arrow(Core.s6, new Vector2((this.Position.X + s.Position.X) / 2f - ot + ot * count, (this.Position.Y + s.Position.Y) / 2f - ot + ot * count),
                       one, two, ost, ot * count);
                    }
                }
                else if (range > 540 && range < 541)
                {
                    int count = getArrowCount(Core.s9, x, y);
                    if (count == 0)
                    {
                        o = new Arrow(Core.s9, new Vector2((this.Position.X + s.Position.X) / 2f - ot, (this.Position.Y + s.Position.Y) / 2f - ot),
               one, two, ost, 1);
                    }
                    else
                    {
                        o = new Arrow(Core.s9, new Vector2((this.Position.X + s.Position.X) / 2f - ot + ot * count, (this.Position.Y + s.Position.Y) / 2f - ot + ot * count),
                       one, two, ost, ot * count);
                    }
                }
                else if (range > 635 && range < 637)
                {
                    int count = getArrowCount(Core.s8, x, y);
                    if (count == 0)
                    {
                        o = new Arrow(Core.s8, new Vector2((this.Position.X + s.Position.X) / 2f - ot, (this.Position.Y + s.Position.Y) / 2f - ot),
               one, two, ost, 1);
                    }
                    else
                    {
                        o = new Arrow(Core.s8, new Vector2((this.Position.X + s.Position.X) / 2f - ot + ot * count, (this.Position.Y + s.Position.Y) / 2f - ot + ot * count),
                       one, two, ost, ot * count);
                    }
                }
                if (o != null)
                    o.Rotation = angle;
                else
                    Console.WriteLine(range);
            }
            f.arrows.Add(o);
            if (arrows[x, y] != null)
                arrows[x, y].Add(o);
            else
            {
                arrows[x, y] = new List<Arrow>();
                arrows[x, y].Add(o);
            }
        }

        private int getRestState(int value)
        {
            int temp = int.Parse(toDouble(value));
            int rest = temp % 10;
            return Math.Abs(rest);
        }

        private int getNewState(int value)
        {
            int temp = int.Parse(toDouble(value));
            int state = temp / 10;
            if (temp == -1 && state == 0)
                state = -1;
            return state;
        }

        private void getNewState(int value, int i)
        {
            int temp = int.Parse(toDouble(value));
            if(temp > 0)
            {
                this.newStates[i] = temp / 10;
                this.restStates[i] = temp % 10;
            }
            else
            {
                string s = "1";
                for(int j=0;j<temp.ToString().Length-1;j++)
                {
                    s += '0';
                }
                int tempInt = int.Parse(s);
                int result = int.Parse(toDouble(toTen(tempInt.ToString()) + toTen(temp.ToString())));
                this.restStates[i] = result % 10;
                this.newStates[i] = int.Parse(toDouble(toTen((result / 10).ToString()) + toTen((tempInt/-10).ToString())));
            }
        }

        public void outStates()
        {
            Console.WriteLine("Значение состояния: " + value, 2);
            Console.WriteLine("Новые состояния: ");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(newStates[i]);
            }
            Console.WriteLine("Остатки новых состояний: ");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(restStates[i]);
            }
        }

        public int getState()
        {
            return value;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            base.Render(spriteBatch);
            spriteBatch.DrawString(Core.basicFont, "" + num, this.Position + new Vector2(5, -5), new Color(new Vector3(124 / 255f, 185 / 255f, 255 / 255f)));
            spriteBatch.DrawString(Core.consoleFont, "" + value, this.Position + new Vector2(-Core.consoleFont.MeasureString(""+value).X / 2f+10f, 35), Color.Black);
            renderCalculates(spriteBatch);
        }

        private void renderCalculates(SpriteBatch spriteBatch)
        {
            int step = 100;
            if (num > 6)
            {
                spriteBatch.DrawString(Core.consoleFont, "q" + num + " :", new Vector2(1+950, step * (num-7)), Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + value + ")", new Vector2(1 + 950, step * (num - 7) + 15), Color.Black);
            }
            else
            {
                spriteBatch.DrawString(Core.consoleFont, "q" + num + " :", new Vector2(1, step * num), Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "(" + value + ")", new Vector2(1, step * num + 15), Color.Black);
            }
            Vector2 move = new Vector2(50,0);
            renderOne(spriteBatch, 0, 0, move);
            move.X += 50;
            renderOne(spriteBatch, 0, 1, move);
            move.X += 50;
            renderOne(spriteBatch, 1, 0, move);
            move.X += 50;
            renderOne(spriteBatch, 1, 1, move);
        }

        private void renderOne(SpriteBatch spriteBatch, int a1, int b1, Vector2 move)
        {
            int step = 100;
            if (num > 6)
            {
                move.X += 950;
                int value = toTen(this.value.ToString());
                int a = toTen(this.a.ToString());
                int b = toTen(this.b.ToString());
                int test = a * a1 + b * b1 + value;
                spriteBatch.DrawString(Core.consoleFont, "" + a1 + "*" + a, new Vector2(move.X, step * (num-7)), Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "" + b1 + "*" + b, new Vector2(move.X, step * (num-7) + 10), Color.Black);
                GameObject.DrawLine(Color.Black, new Vector2(move.X, step * (num-7) + 24), new Vector2(move.X + 40, step * (num-7) + 24), spriteBatch, 1);
                int temp = int.Parse(toDouble(test));
                float addX = Core.consoleFont.MeasureString("" + temp).X;
                float otstup = 20;
                spriteBatch.DrawString(Core.consoleFont, "" + temp, new Vector2(move.X + otstup - addX, step * (num-7) + 24), Color.Black);
                if (temp >= 0)
                {
                    addX = Core.consoleFont.MeasureString(" " + temp / 10 + "" + temp % 10).X;
                    GameObject.DrawLine(Color.Black, new Vector2(move.X + otstup - 7, step * (num-7) + 35), new Vector2(move.X + otstup - 7, step * (num-7) + 48), spriteBatch, 1);
                    GameObject.DrawLine(Color.Black, new Vector2(move.X + otstup - 17, step * (num-7) + 48), new Vector2(move.X + otstup - 7, step * (num-7) + 48), spriteBatch, 1);
                    spriteBatch.DrawString(Core.consoleFont, " " + temp / 10 + "" + temp % 10, new Vector2(move.X - addX + otstup, step * (num-7) + 34), Color.Black);
                }
                else
                {
                    string s = "1";
                    for (int j = 0; j < temp.ToString().Length - 1; j++)
                    {
                        s += '0';
                    }
                    int tempInt = int.Parse(s);
                    spriteBatch.DrawString(Core.consoleFont, "" + tempInt, new Vector2(move.X, step * (num-7) + 38), Color.Black);
                    spriteBatch.DrawString(Core.consoleFont, "" + temp, new Vector2(move.X, step * (num-7) + 48), Color.Black);
                    int result = int.Parse(toDouble(toTen(tempInt.ToString()) + toTen(temp.ToString())));
                    GameObject.DrawLine(Color.Black, new Vector2(move.X, step * (num-7) + 62), new Vector2(move.X + 40, step * (num-7) + 62), spriteBatch, 1);
                    addX = Core.consoleFont.MeasureString(s.Substring(0, s.Length - 1)).X;
                    float addX1 = Core.consoleFont.MeasureString(" " + result / 10 + "" + result % 10).X;
                    spriteBatch.DrawString(Core.consoleFont, " " + result / 10 + "" + result % 10, new Vector2(move.X + addX - addX1 + 7, step * (num-7) + 60), Color.Black);
                    GameObject.DrawLine(Color.Black, new Vector2(move.X + addX, step * (num-7) + 36), new Vector2(move.X + addX, step * (num-7) + 90), spriteBatch, 1);
                    int newStates = int.Parse(toDouble(toTen((result / 10).ToString()) + toTen((tempInt / -10).ToString())));
                    float tempAdd = addX;
                    addX = Core.consoleFont.MeasureString("" + temp).X;
                    spriteBatch.DrawString(Core.consoleFont, "" + tempInt / -10, new Vector2(move.X - addX + tempAdd, step * (num-7) + 70), Color.Black);
                    addX = Core.consoleFont.MeasureString("" + newStates).X;
                    spriteBatch.DrawString(Core.consoleFont, "" + newStates, new Vector2(move.X - addX + tempAdd, step * (num-7) + 80), Color.Black);
                }
            }
            else
            {
                int value = toTen(this.value.ToString());
                int a = toTen(this.a.ToString());
                int b = toTen(this.b.ToString());
                int test = a * a1 + b * b1 + value;
                spriteBatch.DrawString(Core.consoleFont, "" + a1 + "*" + a, new Vector2(move.X, step * num), Color.Black);
                spriteBatch.DrawString(Core.consoleFont, "" + b1 + "*" + b, new Vector2(move.X, step * num + 10), Color.Black);
                GameObject.DrawLine(Color.Black, new Vector2(move.X, step * num + 24), new Vector2(move.X + 40, step * num + 24), spriteBatch, 1);
                int temp = int.Parse(toDouble(test));
                float addX = Core.consoleFont.MeasureString("" + temp).X;
                float otstup = 20;
                spriteBatch.DrawString(Core.consoleFont, "" + temp, new Vector2(move.X + otstup - addX, step * num + 24), Color.Black);
                if (temp >= 0)
                {
                    addX = Core.consoleFont.MeasureString(" " + temp / 10 + "" + temp % 10).X;
                    GameObject.DrawLine(Color.Black, new Vector2(move.X + otstup - 7, step * num + 35), new Vector2(move.X + otstup - 7, step * num + 48), spriteBatch, 1);
                    GameObject.DrawLine(Color.Black, new Vector2(move.X + otstup - 17, step * num + 48), new Vector2(move.X + otstup - 7, step * num + 48), spriteBatch, 1);
                    spriteBatch.DrawString(Core.consoleFont, " " + temp / 10 + "" + temp % 10, new Vector2(move.X - addX + otstup, step * num + 34), Color.Black);
                }
                else
                {
                    string s = "1";
                    for (int j = 0; j < temp.ToString().Length - 1; j++)
                    {
                        s += '0';
                    }
                    int tempInt = int.Parse(s);
                    spriteBatch.DrawString(Core.consoleFont, "" + tempInt, new Vector2(move.X, step * num + 38), Color.Black);
                    spriteBatch.DrawString(Core.consoleFont, "" + temp, new Vector2(move.X, step * num + 48), Color.Black);
                    int result = int.Parse(toDouble(toTen(tempInt.ToString()) + toTen(temp.ToString())));
                    GameObject.DrawLine(Color.Black, new Vector2(move.X, step * num + 62), new Vector2(move.X + 40, step * num + 62), spriteBatch, 1);
                    addX = Core.consoleFont.MeasureString(s.Substring(0, s.Length - 1)).X;
                    float addX1 = Core.consoleFont.MeasureString(" " + result / 10 + "" + result % 10).X;
                    spriteBatch.DrawString(Core.consoleFont, " " + result / 10 + "" + result % 10, new Vector2(move.X + addX - addX1 + 7, step * num + 60), Color.Black);
                    GameObject.DrawLine(Color.Black, new Vector2(move.X + addX, step * num + 36), new Vector2(move.X + addX, step * num + 90), spriteBatch, 1);
                    int newStates = int.Parse(toDouble(toTen((result / 10).ToString()) + toTen((tempInt / -10).ToString())));
                    float tempAdd = addX;
                    addX = Core.consoleFont.MeasureString("" + temp).X;
                    spriteBatch.DrawString(Core.consoleFont, "" + tempInt / -10, new Vector2(move.X - addX + tempAdd, step * num + 70), Color.Black);
                    addX = Core.consoleFont.MeasureString("" + newStates).X;
                    spriteBatch.DrawString(Core.consoleFont, "" + newStates, new Vector2(move.X - addX + tempAdd, step * num + 80), Color.Black);
                }
            }
        }
    }
}
