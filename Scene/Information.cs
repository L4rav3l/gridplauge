using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace gridplauge;

public class Information : IScene
{
    private GraphicsDevice _graphics;
    private SceneManager _sceneManager;
    private ContentManager _content;

    private SpriteFont _pixelfont;
    private double _cooldown;

    public Information(GraphicsDevice _graphics, SceneManager _sceneManager, ContentManager _content)
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
        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        double elapsed = gameTime.ElapsedGameTime.TotalSeconds * 1000;

        if(_cooldown > 0)
        {
            _cooldown -= elapsed;
        }

        MouseState mouse = Mouse.GetState();

        Vector2 BackM = _pixelfont.MeasureString("Back");

        if(Vector2.Distance(new Vector2((Width / 10) * 9 - (BackM.X / 2) + 100, 100 - (BackM.Y / 2)), new Vector2(mouse.X, mouse.Y)) < 50 && mouse.LeftButton == ButtonState.Pressed)
        {
            _sceneManager.ChangeScene("maps");
        }

        Vector2 ToggleM = _pixelfont.MeasureString("OPEN/CLOSE DOOR");
        if(Vector2.Distance(new Vector2((Width / 2) - (ToggleM.X / 2) + 177, (Height / 4) - (ToggleM.Y / 2) + 380), new Vector2(mouse.X, mouse.Y)) < 70 && mouse.LeftButton == ButtonState.Pressed && _cooldown <= 0)
        {
            GameData.BorderClosed = !GameData.BorderClosed;
            _cooldown = 300;   
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        Vector2 BackM = _pixelfont.MeasureString("Back");
        Vector2 Back = new Vector2((Width / 10) * 9 - (BackM.X / 2) + 50, 100 - (BackM.Y / 2));

        spriteBatch.DrawString(_pixelfont, "Back", Back, Color.White);

        Vector2 DayM = _pixelfont.MeasureString($"Day {GameData.Days}");
        Vector2 Day = new Vector2((Width / 2) - (DayM.X / 2), (Height / 4) - (DayM.Y / 2));

        spriteBatch.DrawString(_pixelfont, $"Day {GameData.Days}", Day, Color.White);

        int infectednumber = 0;

        for(int i = 0; i < 36; i++)
        {
            if(GameData.CitizenData[i].Infected == true)
            {
                infectednumber++;
            }
        }

        Vector2 InfectedM = _pixelfont.MeasureString($"Infected: {infectednumber}");
        Vector2 Infected = new Vector2((Width / 2) - (InfectedM.X / 2), (Height / 4) - (InfectedM.Y / 2) + 75);

        spriteBatch.DrawString(_pixelfont, $"Infected: {infectednumber}", Infected, Color.White);

        Vector2 QuarantineM = _pixelfont.MeasureString($"Quarantine capacity: {GameData.QuarantineSize} left");
        Vector2 Quarantine = new Vector2((Width / 2) - (QuarantineM.X / 2), (Height / 4) - (QuarantineM.Y / 2) + 150);

        spriteBatch.DrawString(_pixelfont, $"Quarantine capacity: {GameData.QuarantineSize} left", Quarantine, Color.White);

        string borderText = "";

        if(GameData.BorderClosed == true)
        {
            borderText = "Border is closed";
        } else {
            borderText = "Border is open";
        }

        Vector2 BorderM = _pixelfont.MeasureString(borderText);
        Vector2 Border = new Vector2((Width / 2) - (BorderM.X / 2), (Height / 4) - (BorderM.Y / 2) + 250);

        spriteBatch.DrawString(_pixelfont, borderText, Border, Color.White);

        Vector2 ToggleM = _pixelfont.MeasureString("OPEN/CLOSE DOOR");
        Vector2 Toggle = new Vector2((Width / 2) - (ToggleM.X / 2), (Height / 4) - (ToggleM.Y / 2) + 350);

        spriteBatch.DrawString(_pixelfont, "OPEN/CLOSE DOOR", Toggle, Color.White);

        Vector2 TempM = _pixelfont.MeasureString("Average Temperature: 34-37");
        Vector2 Temp = new Vector2((Width / 2) - (TempM.X / 2), (Height / 4)- (TempM.Y / 2) + 450);

        spriteBatch.DrawString(_pixelfont, "Average Temperature: 34-36", Temp, Color.White);

        Vector2 NextDayM = _pixelfont.MeasureString("Next Day");
        Vector2 NextDay = new Vector2((Width / 2) - (NextDayM.X / 2), (Height / 4) - (NextDayM.Y / 2) + 550);

        spriteBatch.DrawString(_pixelfont, "Next Day", NextDay, Color.White);
    }
}