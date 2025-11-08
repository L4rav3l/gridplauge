using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace gridplauge;

public class House : IScene
{
    private GraphicsDevice _graphics;
    private ContentManager _content;
    private SceneManager _sceneManager;

    private SpriteFont _pixelfont;

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

        if(Vector2.Distance(new Vector2(100, 100), new Vector2(mouse.X, mouse.Y)) < 50)
        {
            _sceneManager.ChangeScene("maps");
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        Vector2 BackM = _pixelfont.MeasureString("Back");
        Vector2 Back = new Vector2(100 - (BackM.X / 2), 100 - (BackM.Y / 2));

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
            if(GameData.CitizenData[i].HouseNumber == GameData.House.Value)
            {
                Vector2 ResidentDataM = _pixelfont.MeasureString($"Name: {GameData.CitizenData[i].Name}, Temperature: {GameData.CitizenData[i].Temperature.ToString()} Quarantine: {GameData.CitizenData[i].InQuarantine.ToString()}");
                Vector2 ResidentData = new Vector2((Width / 2) - (ResidentDataM.X / 2), (Height / 4) - (ResidentDataM.Y / 2) + 150 + (50 * number));

                spriteBatch.DrawString(_pixelfont, $"Name: {GameData.CitizenData[i].Name}, Temperature: {GameData.CitizenData[i].Temperature.ToString()} Quarantine: {GameData.CitizenData[i].InQuarantine.ToString()}", ResidentData, Color.White);

                number++;
            }
        }
    }
}