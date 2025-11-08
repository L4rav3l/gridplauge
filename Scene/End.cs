using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace gridplauge;

public class End : IScene
{
    private GraphicsDevice _graphics;
    private SceneManager _sceneManager;
    private ContentManager _content;

    private SpriteFont _pixelfont;

    public End(GraphicsDevice _graphics, SceneManager _sceneManager, ContentManager _content)
    {
        this._graphics = _graphics;
        this._sceneManager = _sceneManager;
        this._content = _content;
    }

    public void LoadContent()
    {
        _pixelfont = _content.Load<SpriteFont>("pixelfont");
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _graphics.Clear(Color.Black);

        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        if(GameData.GoodEnding == true)
        {
            Vector2 EndingM = _pixelfont.MeasureString("You successfully prevented the spread of COVID-19. Because of this, you received the most expensive mansion in the province.");
            Vector2 Ending = new Vector2((Width / 2) - (EndingM.X / 2), (Height / 2) - (EndingM.Y / 2));

            spriteBatch.DrawString(_pixelfont, "You successfully prevented the spread of COVID-19. Because of this, you received the most expensive mansion in the province.", Ending, Color.White);
        } else {
            
        }
    }
}