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

    private string[] Names = new string[100];

    public GameStart(GraphicsDevice _graphics, SceneManager _sceneManager, ContentManager _content)
    {
        this._graphics = _graphics;
        this._sceneManager = _sceneManager;
        this._content = _content;

        _rectangle = new Texture2D(_graphics, 1, 1);
        _rectangle.SetData(new [] {Color.White});

        Names[0] = "James";
        Names[1] = "Mary";
        Names[2] = "Michael";
        Names[3] = "Patricia";
        Names[4] = "John";
        Names[5] = "Jennifer";
        Names[6] = "Robert";
        Names[7] = "Linda";
        Names[8] = "David";
        Names[9] = "Elizabeth";
        Names[10] = "William";
        Names[11] = "Barbara";
        Names[12] = "Richard";
        Names[13] = "Susan";
        Names[14] = "Joseph";
        Names[15] = "Jessica";
        Names[16] = "Thomas";
        Names[17] = "Karen";
        Names[18] = "Christopher";
        Names[19] = "Sarah";
        Names[20] = "Charles";
        Names[21] = "Lisa";
        Names[22] = "Daniel";
        Names[23] = "Nancy";
        Names[24] = "Matthew";
        Names[25] = "Sandra";
        Names[26] = "Anthony";
        Names[27] = "Ashley";
        Names[28] = "Mark";
        Names[29] = "Emily";
        Names[30] = "Steven";
        Names[31] = "Kimberly";
        Names[32] = "Donald";
        Names[33] = "Betty";
        Names[34] = "Andrew";
        Names[35] = "Margaret";
        Names[36] = "Joshua";
        Names[37] = "Donna";
        Names[38] = "Paul";
        Names[39] = "Michelle";
        Names[40] = "Kenneth";
        Names[41] = "Carol";
        Names[42] = "Kevin";
        Names[43] = "Amanda";
        Names[44] = "Brian";
        Names[45] = "Melissa";
        Names[46] = "Timothy";
        Names[47] = "Deborah";
        Names[48] = "Ronald";
        Names[49] = "Stephanie";
        Names[50] = "Jason";
        Names[51] = "Rebecca";
        Names[52] = "George";
        Names[53] = "Sharon";
        Names[54] = "Edward";
        Names[55] = "Laura";
        Names[56] = "Jeffrey";
        Names[57] = "Cynthia";
        Names[58] = "Ryan";
        Names[59] = "Amy";
        Names[60] = "Jacob";
        Names[61] = "Kathleen";
        Names[62] = "Nicholas";
        Names[63] = "Angela";
        Names[64] = "Gary";
        Names[65] = "Dorothy";
        Names[66] = "Eric";
        Names[67] = "Shirley";
        Names[68] = "Jonathan";
        Names[69] = "Emma";
        Names[70] = "Stephen";
        Names[71] = "Brenda";
        Names[72] = "Larry";
        Names[73] = "Nicole";
        Names[74] = "Justin";
        Names[75] = "Pamela";
        Names[76] = "Benjamin";
        Names[77] = "Samantha";
        Names[78] = "Scott";
        Names[79] = "Anna";
        Names[80] = "Brandon";
        Names[81] = "Katherine";
        Names[82] = "Samuel";
        Names[83] = "Christine";
        Names[84] = "Gregory";
        Names[85] = "Debra";
        Names[86] = "Alexander";
        Names[87] = "Rachel";
        Names[88] = "Patrick";
        Names[89] = "Olivia";
        Names[90] = "Frank";
        Names[91] = "Carolyn";
        Names[92] = "Jack";
        Names[93] = "Maria";
        Names[94] = "Raymond";
        Names[95] = "Janet";
        Names[96] = "Dennis";
        Names[97] = "Heather";
        Names[98] = "Tyler";
        Names[99] = "Diane";

        Random rnd = new Random();

        for(int i = 0; i < GameData.CitizenData.Length; i++)
        {
            GameData.CitizenData[i] = new Citizens();

            GameData.CitizenData[i].Name = Names[rnd.Next(0, 100)];
            GameData.CitizenData[i].HouseNumber = (int)(i / 3);
            GameData.CitizenData[i].Temperature = (double)(rnd.Next(3450, 3750) / 100);
            GameData.CitizenData[i].Infected = false;
            GameData.CitizenData[i].InQuarantine = false;
        }
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
            _sceneManager.AddScene(new House(_graphics, _sceneManager, _content), "house");
            _sceneManager.AddScene(new Information(_graphics, _sceneManager, _content), "information");
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