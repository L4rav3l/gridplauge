using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

namespace gridplauge;

public class EasterEgg : IScene
{
    private GraphicsDevice _graphics;
    private SceneManager _sceneManager;
    private ContentManager _content;

    private Vector2 _position;
    private Vector2[] _covidpositon = new Vector2[5];

    private Texture2D _slides;
    private Texture2D _covid19;
    private SpriteFont _pixelfont;

    private Random rnd;

    private int _score = 0;
    
    public EasterEgg(GraphicsDevice _graphics, SceneManager _sceneManager, ContentManager _content)
    {
        this._graphics = _graphics;
        this._sceneManager = _sceneManager;
        this._content = _content;

        _position = new Vector2(0, (_graphics.Viewport.Height * 3 / 4f));

        rnd = new Random();

        for(int i = 0; i < 5; i++)
        {
            _covidpositon[i].X = rnd.Next(100, _graphics.Viewport.Width - 100);
            _covidpositon[i].Y = rnd.Next(50, 250);
        }
    }

    public void LoadContent()
    {
        _slides = _content.Load<Texture2D>("slides");
        _covid19 = _content.Load<Texture2D>("covid19");
        _pixelfont = _content.Load<SpriteFont>("pixelfont");
    }

    public void Update(GameTime gameTime)
    {
        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        KeyboardState state = Keyboard.GetState();
        
        if(state.IsKeyDown(Keys.A))
        {
            _position.X-=5;
        }

        if(state.IsKeyDown(Keys.D))
        {
            _position.X+=5;
        }

        for(int i = 0; i < 5; i++)
        {
            _covidpositon[i].Y++;
        }

        for(int i = 0; i < 5; i++)
        {
            if(Vector2.Distance(_covidpositon[i], new Vector2(_position.X + 32, _position.Y)) < 48)
            {
                _covidpositon[i].X = rnd.Next(100, _graphics.Viewport.Width - 100);
                _covidpositon[i].Y = rnd.Next(64, 164);
                _score++;
            } else if(_covidpositon[i].Y >= _graphics.Viewport.Height)
            {
               _covidpositon[i].X = rnd.Next(100, _graphics.Viewport.Width - 100);
               _covidpositon[i].Y = rnd.Next(64, 164); 
            }
        }

        if(state.IsKeyDown(Keys.Escape))
        {
            _sceneManager.ChangeScene("menu");
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _graphics.Clear(Color.Black);

        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        for(int i = 0; i < 5; i++)
        {
            spriteBatch.Draw(_covid19, _covidpositon[i], null, Color.White);
        }

        spriteBatch.Draw(_slides, _position, null, Color.White);

        Vector2 ScoreM = _pixelfont.MeasureString(_score.ToString());
        Vector2 Score = new Vector2((Width / 2) - (ScoreM.X / 2), (Height / 4) - (ScoreM.Y / 2));

        spriteBatch.DrawString(_pixelfont, _score.ToString(), Score, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.2f);
    }
}