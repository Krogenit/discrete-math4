using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeezMat4
{
    public class GameObject
    {
        public Vector2 Position;
        public Vector2 Origin;
        public Rectangle Rect;
        public Texture2D Text;
        public float Size = 1;
        public float Rotation = 0;
        public Vector4 color = new Vector4(1, 1, 1, 1);
        public float layer = 0F;
        public SpriteEffects effects = SpriteEffects.None;
        public GameObject(Texture2D text, Vector2 pos)
        {
            Position = pos;
            Text = text;
            Origin = new Vector2(Text.Width / 2, Text.Height / 2);
            Rect = new Rectangle((int)Position.X - (int)(Text.Width / 2 * Size), (int)Position.Y - (int)(Text.Height / 2 * Size), (int)(Text.Width * Size), (int)(Text.Height * Size));
        }
        public GameObject(Vector2 pos)
        {
            Position = pos;
        }
        public void Create(Texture2D text)
        {
            Text = text;
            Origin = new Vector2(Text.Width / 2, Text.Height / 2);
            Rect = new Rectangle((int)Position.X - (int)(Text.Width / 2 * Size), (int)Position.Y - (int)(Text.Height / 2 * Size), (int)(Text.Width * Size), (int)(Text.Height * Size));
        }
        public virtual void UpdateColor()
        {
            //if (Core.world.stars.Count > 0)
            //{
            //    float del = 2f;
            //    float baseColor = 0.6f;
            //    color = new Vector4(baseColor + Core.world.stars[0].color.X / del, baseColor + Core.world.stars[0].color.Y / del, baseColor + Core.world.stars[0].color.Z / del, 1);
            //}
        }
        public virtual void Update()
        {
            Rect = new Rectangle((int)Position.X - (int)(Text.Width / 2 * Size), (int)Position.Y - (int)(Text.Height / 2 * Size), (int)(Text.Width * Size), (int)(Text.Height * Size));
        }
        public virtual void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Text, Position, null, new Color(color), Rotation, Origin, Size, effects, layer);
        }
        public static void DrawRectangle(Color color, Vector2 position1, Vector2 position2, SpriteBatch spriteBatch, int linesize)
        {
            Vector2 pos1 = position1;
            Vector2 pos2 = new Vector2(position2.X, position1.Y);
            double distance = Vector2.Distance(pos1, pos2);
            float angle = -(float)Math.Atan2(pos1.X - pos2.X, pos1.Y - pos2.Y) - (float)Math.PI / 2f;

            spriteBatch.Draw(Core.pixel, pos1, new Rectangle(0, 0, (int)distance, linesize), color, angle, new Vector2(0f, 2 / 2f), 1f, SpriteEffects.None, 0);

            pos1 = new Vector2(position2.X, position1.Y);
            pos2 = new Vector2(position2.X, position2.Y);
            distance = Vector2.Distance(pos1, pos2);
            angle = -(float)Math.Atan2(pos1.X - pos2.X, pos1.Y - pos2.Y) - (float)Math.PI / 2f;

            spriteBatch.Draw(Core.pixel, pos1, new Rectangle(0, 0, (int)distance, linesize), color, angle, new Vector2(0f, 2 / 2f), 1f, SpriteEffects.None, 0);

            pos1 = new Vector2(position2.X, position2.Y);
            pos2 = new Vector2(position1.X, position2.Y);
            distance = Vector2.Distance(pos1, pos2);
            angle = -(float)Math.Atan2(pos1.X - pos2.X, pos1.Y - pos2.Y) - (float)Math.PI / 2f;

            spriteBatch.Draw(Core.pixel, pos1, new Rectangle(0, 0, (int)distance, linesize), color, angle, new Vector2(0f, 2 / 2f), 1f, SpriteEffects.None, 0);

            pos1 = new Vector2(position1.X, position2.Y);
            pos2 = new Vector2(position1.X, position1.Y);
            distance = Vector2.Distance(pos1, pos2);
            angle = -(float)Math.Atan2(pos1.X - pos2.X, pos1.Y - pos2.Y) - (float)Math.PI / 2f;

            spriteBatch.Draw(Core.pixel, pos1, new Rectangle(0, 0, (int)distance, linesize), color, angle, new Vector2(0f, 2 / 2f), 1f, SpriteEffects.None, 0);
        }
        public static void DrawLine(Color color, Vector2 position1, Vector2 position2, SpriteBatch spriteBatch, int linesize)
        {
            double distance = Math.Sqrt(((position2.X - position1.X) * (position2.X - position1.X)) + ((position2.Y - position1.Y) * (position2.Y - position1.Y)));
            float angle = -(float)Math.Atan2(position1.X - position2.X, position1.Y - position2.Y) - (float)Math.PI / 2f;

            spriteBatch.Draw(Core.pixel, position1, new Rectangle(0, 0, (int)distance, linesize), color, angle, new Vector2(0f, 2 / 2f), 1f, SpriteEffects.None, 0);
        }
    }
}
