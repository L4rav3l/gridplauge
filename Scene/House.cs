using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

namespace gridplauge;

public class House : IScene
{
    private GraphicsDevice _graphics;
    private ContentManager _content;
    private SceneManager _sceneManager;

    private SpriteFont _pixelfont;
    
    private int _selected = 0;
    private double _clickCooldown;

    public House(GraphicsDevice _graphics, SceneManager _sceneManager, ContentManager _content)
    {
        this._graphics = _graphics;
        this._content = _content;
        this._sceneManager = _sceneManager;
    }

    public void LoadContent()
    {
        _pixelfont = _content.Load<SpriteFont>("pixelfont");
    }

    public void Update(GameTime gameTime)
    {
        MouseState mouse = Mouse.GetState();

        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        Vector2 BackM = _pixelfont.MeasureString("Back");

        double elapsed = gameTime.ElapsedGameTime.TotalSeconds * 1000;

        if(GameData.Entered == true)
        {
            GameData.Entered = false;
            _clickCooldown = 500;
        }

        if(_clickCooldown >= 0)
        {
            _clickCooldown -= elapsed;
        }

        if(Vector2.Distance(new Vector2((Width / 10) * 9 - (BackM.X / 2) + 100, 100 - (BackM.Y / 2)), new Vector2(mouse.X, mouse.Y)) < 50 && mouse.LeftButton == ButtonState.Pressed && _clickCooldown <= 0)
        {
            _sceneManager.ChangeScene("maps");
        }

        if(Vector2.Distance(new Vector2(Width / 2 - 50, Height / 4 + 400), new Vector2(mouse.X, mouse.Y)) < 50 && mouse.LeftButton == ButtonState.Pressed && _selected >= 1 && _clickCooldown <= 0)
        {
            _selected--;
            _clickCooldown = 150;
        }

        if(Vector2.Distance(new Vector2(Width / 2 + 50, Height / 4 + 400), new Vector2(mouse.X, mouse.Y)) < 50 && mouse.LeftButton == ButtonState.Pressed && _selected < 2 && _clickCooldown <= 0)
        {
            _selected++;
            _clickCooldown = 150;
        }

        Vector2 QuarantineM = _pixelfont.MeasureString("Quarantine");
        Vector2 Quarantine = new Vector2((Width / 2), (Height / 4) + (QuarantineM.Y / 2) + 500 + 25);

        if(Vector2.Distance(Quarantine, new Vector2(mouse.X, mouse.Y)) <= 100 && mouse.LeftButton == ButtonState.Pressed && _clickCooldown <= 0)
        {
            _clickCooldown = 400;

            if(GameData.QuarantineSize > 0 && GameData.CitizenData[(GameData.House.Value * 3) - 3 + _selected].InQuarantine == false)
            {
                GameData.CitizenData[(GameData.House.Value * 3) - 3 + _selected].InQuarantine = true;
                GameData.QuarantineSize--;
            }
        }

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        Vector2 BackM = _pixelfont.MeasureString("Back");
        Vector2 Back = new Vector2((Width / 10) * 9 - (BackM.X / 2) + 50, 100 - (BackM.Y / 2));

        spriteBatch.DrawString(_pixelfont, "Back", Back, Color.White);

        Vector2 HouseM = _pixelfont.MeasureString($"House #{GameData.House.Value}");
        Vector2 House = new Vector2((Width / 2) - (HouseM.X / 2), (Height / 4) - (HouseM.Y / 2));

        spriteBatch.DrawString(_pixelfont, $"House #{GameData.House.Value}", House, Color.White);

        Vector2 ResidentM = _pixelfont.MeasureString("Resident:");
        Vector2 Resident = new Vector2((Width / 2) - (ResidentM.X / 2), (Height / 4) - (ResidentM.Y / 2) + 100);

        spriteBatch.DrawString(_pixelfont, "Resident:", Resident, Color.White);

        int number = 1;

        for(int i = 0; i < 36; i++)
        {
            if(GameData.CitizenData[i].HouseNumber == GameData.House.Value - 1)
            {
                Vector2 ResidentDataM = _pixelfont.MeasureString($"Name: {GameData.CitizenData[i].Name}, Temperature: {GameData.CitizenData[i].Temperature.ToString()} Quarantine: {GameData.CitizenData[i].InQuarantine.ToString()}");
                Vector2 ResidentData = new Vector2((Width / 2) - (ResidentDataM.X / 2), (Height / 4) - (ResidentDataM.Y / 2) + 150 + (50 * number));

                spriteBatch.DrawString(_pixelfont, $"Name: {GameData.CitizenData[i].Name}, Temperature: {GameData.CitizenData[i].Temperature.ToString()} Quarantine: {GameData.CitizenData[i].InQuarantine.ToString()}", ResidentData, Color.White);

                number++;
            }
        }

        spriteBatch.DrawString(_pixelfont, "<- ->", new Vector2(Width / 2 - 50, Height / 4 + 400), Color.White);

        Vector2 NameM = _pixelfont.MeasureString(GameData.CitizenData[(GameData.House.Value / 3) + _selected].Name);
        Vector2 Name = new Vector2((Width / 2) - (NameM.X / 2), (Height / 4) + (NameM.Y / 2) + 500);

        spriteBatch.DrawString(_pixelfont, GameData.CitizenData[(GameData.House.Value * 3) - 3 + _selected].Name, Name, Color.White);

        Vector2 QuarantineM = _pixelfont.MeasureString("Quarantine");
        Vector2 Quarantine = new Vector2((Width / 2) - (QuarantineM.X / 2), (Height / 4) - (QuarantineM.Y / 2) + 500);

        spriteBatch.DrawString(_pixelfont, "Quarantine", Quarantine, Color.White);
    }
}