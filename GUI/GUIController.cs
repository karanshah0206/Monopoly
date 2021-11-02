using System.Collections.Generic;

namespace monopoly
{
    class GUIController
    {
        private static GUIController _guiController;
        private List<IDrawable> _drawables;

        private GUIController()
        { _drawables = new(); }

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
            {
                if (x <= 392) return Board.GetTile(20);
                else if (x >= 912) return Board.GetTile(30);
                else
                {
                    x -= 392; x = System.Math.Floor(x / 58); x += 21;
                    return Board.GetTile((int)x);
                }
            }
            else if (y >= 612)
            {
                if (x <= 392) return Board.GetTile(10);
                else if (x >= 912) return Board.GetTile(0);
                else
                {
                    x -= 392; x = System.Math.Floor(x / 58); x = 9 - x;
                    return Board.GetTile((int)x);
                }
            }
            else if (x >= 912)
            {
                y -= 88; y = System.Math.Floor(y / 58); y += 31;
                return Board.GetTile((int)y);
            }
            else if (x <= 392)
            {
                y -= 88; y = System.Math.Floor(y / 58); y = 9 - y; y += 10;
                return Board.GetTile((int)y);
            }
            return null;
        }
    }
}