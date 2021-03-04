using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public static class Extensions
    {
        public static void MikahDraw(this SpriteBatch sprite, Texture2D tex, Rectangle hitBox, Color tint, float rotation)
        {
            //sprite.Draw(tex, hitBox, tint);
            Vector2 origin = new Vector2(.5f, .5f);
            // Console.WriteLine(origin);
            sprite.Draw(tex, hitBox, null, tint, rotation, origin, SpriteEffects.None, 1.0f);

            //sprite.Draw(tex, new Vector2(400, 400), null, Color.White, rotation, new Vector2(0.5f, 0.5f), Vector2.One * 25, SpriteEffects.None, 0f);
        }
    }
}
