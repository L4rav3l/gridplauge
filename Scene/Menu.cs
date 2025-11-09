using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace gridplauge;

public class Menu : IScene
{
    private GraphicsDevice _graphics;
    private SceneManager _sceneManager;
    private ContentManager _content;

    private SpriteFont _pixelfont;

    private int _Selected;
    private double _KeyCooldown;
    private double _BlinkCooldown;

    private bool _Blink = false;

    public Menu(GraphicsDevice _graphics, SceneManager _sceneManager, ContentManager _content)
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
        double elapsed = gameTime.ElapsedGameTime.TotalSeconds * 1000;

        if(_KeyCooldown >= 0)
        {
            _KeyCooldown -= elapsed;
        }

        if(_BlinkCooldown >= 0)
        {
            _BlinkCooldown -= elapsed;
        } else {
            _Blink = !_Blink;
            _BlinkCooldown = 500;
        }

        KeyboardState state = Keyboard.GetState();

        if((state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Down)) && _KeyCooldown <= 0)
        {
            if(_Selected == 0)
            {
                _Selected = 1;
            } else {
                _Selected = 0;
            }

            _KeyCooldown = 500;
        }

        if(state.IsKeyDown(Keys.Enter))
        {
            if(_Selected == 0)
            {
                _sceneManager.AddScene(new GameStart(_graphics, _sceneManager, _content), "gamestart");
                _sceneManager.ChangeScene("gamestart");
            } else {
                GameData.Quit = true;
            }
        }

        if(state.IsKeyDown(Keys.E))
        {
            _sceneManager.ChangeScene("easteregg");
        }
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        string playText = "";
        string quitText = "";

        if(_Selected == 0)
        {
            if(_Blink == false)
            {
                playText = "> Play <";
            } else {
                playText = "Play";
            }
                quitText = "Quit";
        } else {
            playText = "Play";
            if(_Blink == false)
            {
                quitText = "> Quit <";
            } else {
                quitText = "Quit";
            }
        }

        Vector2 TitleM = _pixelfont.MeasureString("Grid Plauge");
        Vector2 TitlePos = new Vector2((Width / 2) - (TitleM.X / 2), (Height / 4) - (TitleM.Y / 2));

        spriteBatch.DrawString(_pixelfont, "Grid Plauge", TitlePos, Color.White);

        Vector2 PlayM = _pixelfont.MeasureString(playText) * 0.75f;
        Vector2 PlayPos = new Vector2((Width / 2) - (PlayM.X / 2), (Height / 4) - (PlayM.Y / 2) + 100);

        spriteBatch.DrawString(_pixelfont, playText, PlayPos, Color.White, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.1f);

        Vector2 QuitM = _pixelfont.MeasureString(quitText) * 0.75f;
        Vector2 QuitPos = new Vector2((Width / 2) - (QuitM.X / 2), (Height / 4) - (QuitM.Y / 2) + 150);

        spriteBatch.DrawString(_pixelfont, quitText, QuitPos, Color.White, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.1f);
    }
}