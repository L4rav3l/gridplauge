using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using TiledSharp;

namespace gridplauge;

public class Maps : IScene
{
    private GraphicsDevice _graphics;
    private SceneManager _sceneManager;
    private ContentManager _content;
    
    private Texture2D _tileset;
    private TmxMap map;

    private Camera2D camera;

    public Maps(GraphicsDevice _graphics, SceneManager _sceneManager, ContentManager _content)
    {
        this._graphics = _graphics;
        this._sceneManager = _sceneManager;
        this._content = _content;
    }

    public void LoadContent()
    {
        map = new TmxMap("Content/tilemap.tmx");
        camera = new Camera2D(_graphics.Viewport);
        camera.Position = camera.WorldToScreen(new Vector2(489, 914));

        _tileset = _content.Load<Texture2D>("texture");
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();

        if(state.IsKeyDown(Keys.W) && camera.Position.Y >= 380)
        {
            camera.Position.Y-=5;
        } else if(state.IsKeyDown(Keys.S) && camera.Position.Y <= 1360)
        {
            camera.Position.Y+=5;
        }

        if(state.IsKeyDown(Keys.A) && camera.Position.X >= 44)
        {
            camera.Position.X-=5;
        } else if(state.IsKeyDown(Keys.D) && camera.Position.X <= 950)
        {
            camera.Position.X+=5;
        }

        MouseState mouse = Mouse.GetState();

        Vector2 mousepos = new Vector2(mouse.X, mouse.Y);


        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(640, 832))) < 140)
        {
            Console.WriteLine("Ház1");
        }
        
        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(960, 704))) < 140)
        {
            Console.WriteLine("Ház2");
        }

        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(1344, 768))) < 140)
        {
            Console.WriteLine("Ház3");
        }

        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(768, 1216))) < 140)
        {
            Console.WriteLine("Ház4");
        }

        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(1600, 1280))) < 140)
        {
            Console.WriteLine("Ház5");
        }
        
        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(1920, 1152))) < 140)
        {
            Console.WriteLine("Ház6");
        }

        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(448, 1600))) < 140)
        {
            Console.WriteLine("Ház7");
        }

        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(1088, 1536))) < 140)
        {
            Console.WriteLine("Ház8");
        }

        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(2304, 1472))) < 140)
        {
            Console.WriteLine("Ház9");
        }
        
        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(768, 1920))) < 140)
        {
            Console.WriteLine("Ház10");
        }

        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(1536, 1792))) < 140)
        {
            Console.WriteLine("Ház11");
        }

        if(state.IsKeyDown(Keys.E) && Vector2.Distance(mousepos, camera.WorldToScreen(new Vector2(2304, 1920))) < 140)
        {
            Console.WriteLine("Ház12");
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int mapWidth = map.Width;
        int mapHeight = map.Height;

        int Width = _graphics.Viewport.Width;
        int Height = _graphics.Viewport.Height;

        _graphics.Clear(Color.Black);

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                int i = y * mapWidth + x;
                if (i >= map.Layers[0].Tiles.Count) continue;

                var tile = map.Layers[0].Tiles[i];
                if (tile.Gid == 0) continue;

                int tilesPerRow = _tileset.Width / map.TileWidth;
                int tileIndex = tile.Gid - 1;

                int tileIndexX = tileIndex % tilesPerRow;
                int tileIndexY = tileIndex / tilesPerRow;

                Rectangle source = new Rectangle(
                    tileIndexX * map.TileWidth,
                    tileIndexY * map.TileHeight,
                    map.TileWidth,
                    map.TileHeight
                );

                Vector2 worldPosition = new Vector2(x * map.TileWidth, y * map.TileHeight);
                Vector2 screenPosition = camera.WorldToScreen(worldPosition);

                spriteBatch.Draw(_tileset, screenPosition, source, Color.White);
            }
        }
    }
}