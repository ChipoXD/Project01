using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01.Ui
{
    internal class UiManager
    {
        private List<BaseUi> components = new List<BaseUi>();

        public void AddComponent(BaseUi component)
        {
            components.Add(component);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in components.Where(component => component.IsVisible))
            {
                component.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in components.Where(component => component.IsVisible))
            {
                component.Draw(spriteBatch);
            }
        }
    }
}
