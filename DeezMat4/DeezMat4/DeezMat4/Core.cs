using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DeezMat4
{
    public class Core : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public State[,] states = new State[4, 4];
        public List<Arrow> arrows = new List<Arrow>();
        public List<Arrow>[,] arrowsGrid = new List<Arrow>[1920, 1080];
        private int a, b, c, count;

        public static Texture2D pixel, q, s0, s1, s2, s3, s4, s5, s6, s7, s8, s9;
        public static SpriteFont basicFont, consoleFont;
        public Core(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 720;
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            q = LoadTexture("q");
            s0 = LoadTexture("s0");
            s1 = LoadTexture("s1");
            s2 = LoadTexture("s2");
            s3 = LoadTexture("s3");
            s4 = LoadTexture("s4");
            s5 = LoadTexture("s5");
            s6 = LoadTexture("s6");
            s7 = LoadTexture("s7");
            s8 = LoadTexture("s8");
            s9 = LoadTexture("s9");
            pixel = LoadTexture("pixel");
            basicFont = Content.Load<SpriteFont>("basicFont");
            consoleFont = Content.Load<SpriteFont>("consoleFont");
            addState(c);
        }
        private Texture2D LoadTexture(string s)
        {
            return Content.Load<Texture2D>("" + s);
        }
        public int[] addState(int value)
        {
            Random r = new Random();
            for (int i = 0; i < states.GetLength(0); i++)
                for (int j = 0; j < states.GetLength(1); j++)
                {
                    if (states[i, j] != null && states[i, j].getState() == value)
                    {
                        return new int[] { i, j };
                    }
                }
                        for (int i = 0; i < states.GetLength(0); i++)
                            for (int j = 0; j < states.GetLength(1); j++)
                            {
                                if (states[i, j] == null)
                                {
                                    return randomAdd(i, j, value, r);
                                }
                            }
            return null;
        }
        private int[] randomAdd(int i, int j, int value, Random r)
        {
            int x = r.Next(states.GetLength(0) - i) + i;
            int y = r.Next(states.GetLength(1) - j) + j;
            if (states[x, y] == null)
            {
                State s = new State(a, b, value, this, x, y, count);
                states[x, y] = s;
                count += 1;
                s.calculateStates();
                //s.outStates();
                return new int[] { x, y };
            }
            else
            {
                return randomAdd(i, j, value, r);
            }
        }
        public State getState(int i, int j)
        {
            return states[i, j];
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
            spriteBatch.Begin();
            string primer = "" + State.toTen(a.ToString()) + "x" + (b > 0 ? "+" : "") + State.toTen(b.ToString()) + "y" + (c > 0 ? "+" : "") + State.toTen(c.ToString());
            spriteBatch.DrawString(basicFont, primer,
                new Vector2(600 - basicFont.MeasureString(primer).X / 2, 10), Color.Black);
            for (int i = 0; i < states.GetLength(0); i++)
                for (int j = 0; j < states.GetLength(1); j++)
                    if (states[i, j] != null)
                        states[i, j].Render(spriteBatch);
            foreach (Arrow o in arrows)
                if (o != null)
                    o.Render(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
