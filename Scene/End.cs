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
        KeyboardState state = Keyboard.GetState();


        if(state.IsKeyDown(Keys.E))
        {
            _sceneManager.ChangeScene("menu");
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _graphics.Clear(Color.Black);

        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        if(GameData.GoodEnding == true)
        {
            string text = "You successfully prevented the spread of COVID-19.\nBecause of this, you received the most expensive mansion in the province.\nPress E key";
            Vector2 textSize = _pixelfont.MeasureString(text);
            Vector2 position = new Vector2((Width - textSize.X * 0.75f) / 2, (Height - textSize.Y * 0.75f) / 2);

            spriteBatch.DrawString(_pixelfont, text, position, Color.White, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.2f);

        } else {
            string text = "Most of the citizens were infected with COVID-19. So, you failed. Try again.\nPress E key";
            Vector2 textSize = _pixelfont.MeasureString(text);
            Vector2 position = new Vector2((Width - textSize.X * 0.75f) / 2, (Height - textSize.Y * 0.75f) / 2);

            spriteBatch.DrawString(_pixelfont, text, position, Color.White, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.2f);
        }
    }
}