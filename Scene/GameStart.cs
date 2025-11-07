using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace gridplauge;

public class GameStart : IScene
{
    private GraphicsDevice _graphics;
    private SceneManager _sceneManager;
    private ContentManager _content;

    private SpriteFont _pixelfont;
    private Texture2D _rectangle;

    public GameStart(GraphicsDevice _graphics, SceneManager _sceneManager, ContentManager _content)
    {
        this._graphics = _graphics;
        this._sceneManager = _sceneManager;
        this._content = _content;

        _rectangle = new Texture2D(_graphics, 1, 1);
        _rectangle.SetData(new [] {Color.White});
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
            _sceneManager.AddScene(new Maps(_graphics, _sceneManager, _content), "maps");
            _sceneManager.ChangeScene("maps");
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        _graphics.Clear(Color.Black);

        spriteBatch.Draw(_rectangle, new Rectangle((Width / 2) - 300, (Height / 2) - 400, 600, 800), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
        spriteBatch.DrawString(_pixelfont, "You are the health expert in \nHynn Province during the Covid-19\npandemic. You are responsible for\nensuring that the people of Hynn\nProvince don't die. You can place\nanyone in quarantine, and\nimpose various sanctions on Hynn\nProvince.You are also able to close\nthe borders so that outsiders\ndon't enter and spread the\nCovid-19.\n\n\nPress E key", new Vector2((Width / 2) - 275, (Height / 2) - 375), Color.Black, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.2f);   
    }
}