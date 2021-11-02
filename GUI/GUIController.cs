using SplashKitSDK;
using System.Collections.Generic;

namespace monopoly
{
    public class GUIController
    {
        private static GUIController _guiController;
        private List<IDrawable> _drawables;
        private SoundEffect _alertSound, _stepSound, _playerLost;

        private GUIController()
        {
            _drawables = new();
            _alertSound = new("alert", "alert.mp3");
            _stepSound = new("step", "step.mp3");
            _playerLost = new("lost", "lost.mp3");
        }

        public static GUIController GetInstance()
        {
            if (_guiController == null)
                _guiController = new GUIController();
            return _guiController;
        }

        public void AddDrawable(IDrawable drawable)
        { if (!_drawables.Contains(drawable)) _drawables.Add(drawable); }

        public void RemoveDrawable(IDrawable drawable)
        { if (_drawables.Contains(drawable)) _drawables.Remove(drawable); }
        
        public void Draw()
        { for (int i = _drawables.Count - 1; i >= 0; i--) _drawables[i].Draw(); }

        public int[] GetCoordsByTile(int loc)
        {
            int[] coords = { 0, 0 };
            if (loc >= 0 && loc < 10) { coords[0] = 920 - (58 * loc); coords[1] = 665; }
            if (loc >= 10 && loc < 20) { coords[0] = 315; coords[1] = 635 - (58 * (loc - 10)); }
            if (loc >= 20 && loc < 30) { coords[0] = 345 + (58 * (loc - 20)); coords[1] = 30; }
            if (loc >= 30 && loc < 40) { coords[0] = 950; coords[1] = 50 + (58 * (loc - 30)); }
            return coords;
        }

        public Tile GetTileByClick(double x, double y)
        {
            if (y <= 88)
                if (x <= 392) return Board.GetTile(20);
                else if (x >= 912) return Board.GetTile(30);
                else return Board.GetTile((int)(System.Math.Floor((x - 392) / 58) + 21));
            else if (y >= 612)
                if (x <= 392) return Board.GetTile(10);
                else if (x >= 912) return Board.GetTile(0);
                else return Board.GetTile((int)(9 - System.Math.Floor((x - 392) / 58)));
            else if (x >= 912) return Board.GetTile((int)(System.Math.Floor((y - 88) / 58) + 31));
            else if (x <= 392 && x >= 300) return Board.GetTile((int)(19 - System.Math.Floor((y - 88) / 58)));
            return null;
        }

        public Color GetPlayerColor(string name)
        {
            if (name.Contains('1')) return Color.Red;
            else if (name.Contains('2')) return Color.Blue;
            else if (name.Contains('3')) return Color.Green;
            else if (name.Contains('4')) return Color.Yellow;
            else if (name.Contains('5')) return Color.DarkGray;
            else if (name.Contains('6')) return Color.White;
            else if (name.Contains('7')) return Color.Orange;
            else return Color.Brown;
        }

        public void DrawHouse(int x, int y, int loc, int houseCount)
        {
            if (loc > 0 && loc < 10) SplashKit.FillRectangle(Color.BrightGreen, x + (11 * houseCount), y - 74, 10, 15);
            else if (loc > 10 && loc < 20) SplashKit.FillRectangle(Color.BrightGreen, x + 73, y + (11 * houseCount), 15, 10);
            else if (loc > 20 && loc < 30) SplashKit.FillRectangle(Color.BrightGreen, x - (11 * houseCount), y + 68, 10, 15);
            else SplashKit.FillRectangle(Color.BrightGreen, x - 73, y - (11 * houseCount), 15, 10);
        }

        public void DrawHotel(int x, int y, int loc)
        {
            if (loc > 0 && loc < 10) SplashKit.FillRectangle(Color.LightCoral, x + 45, y - 74, 10, 15);
            else if (loc > 10 && loc < 20) SplashKit.FillRectangle(Color.LightCoral, x + 73, y + 45, 15, 10);
            else if (loc > 20 && loc < 30) SplashKit.FillRectangle(Color.LightCoral, x - 44, y + 68, 10, 15);
            else SplashKit.FillRectangle(Color.LightCoral, x - 73, y - 45, 15, 10);
        }

        public void PlaySound(string soundEffect)
        {
            switch(soundEffect)
            {
                case "lost": _playerLost.Play(); break;
                case "alert": _alertSound.Play(); break;
                case "step": _stepSound.Play(); break;
            }
        }
    }
}