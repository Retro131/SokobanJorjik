using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Sokoban
{
    public class Level
    {
        public int TotalSteps;
        Texture2D boxTexture;
        Texture2D playerTexture;
        Texture2D targetTexture;
        Texture2D wallTexture;
        public int Id {  get; set; }
        public int BoxCount {  get; set; }
        public int TargetCount {  get; set; }
        public List<Sprite> Sprites { get; set; }
        public bool IsFinished { get; set; }
        public Level(int Id, string[,] mapInText, ContentManager contentManager) 
        {
            boxTexture = contentManager.Load<Texture2D>("Box");
            playerTexture = contentManager.Load<Texture2D>("Player");
            targetTexture = contentManager.Load<Texture2D>("Target");
            wallTexture = contentManager.Load<Texture2D>("Wall");
            this.Id = Id;
            this.BoxCount = BoxCount;
            this.TargetCount = TargetCount;
            this.Sprites = GenerateLevel(50, mapInText, boxTexture, playerTexture, targetTexture, wallTexture);
        }
        List<Sprite> GenerateLevel(int cellSize, string[,] levelGrid, Texture2D boxTexture, Texture2D playerTexture, Texture2D targetTexture, Texture2D wallTexture)
        {
            List<Sprite> levelSprites = new List<Sprite>();

            for (int y = 0; y < levelGrid.GetLength(0); y++)
            {
                for (int x = 0; x < levelGrid.GetLength(1); x++)
                {
                    string cellType = levelGrid[y, x];
                    Sprite sprite = CreateSpriteForCell(cellType, x, y, cellSize, boxTexture, playerTexture, targetTexture, wallTexture);

                    if (sprite != null)
                    {
                        levelSprites.Add(sprite);
                    }
                }
            }

            return levelSprites;
        }

        Sprite CreateSpriteForCell(string cellType, int x, int y, int cellSize, Texture2D boxTexture, Texture2D playerTexture, Texture2D targetTexture, Texture2D wallTexture)
        {
            Vector2 position = CalculatePosition(x, y, cellSize);

            switch (cellType)
            {
                case "W":
                    return new Wall(wallTexture, position, Color.White);

                case "B":
                    BoxCount++;
                    return new Box(boxTexture, position, Color.White);

                case "P":
                    return new Player(playerTexture, position, Color.White, this);

                case "T":
                    TargetCount++;
                    return new Target(targetTexture, position, Color.White);

                default:
                    // Если ячейка не соответствует известным типам, вернем null
                    return null;
            }
        }
        Vector2 CalculatePosition(int x, int y, int cellSize)
        {
            return new Vector2(x * cellSize, y * cellSize);
        }
    }
}
