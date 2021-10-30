using SplashKitSDK;
using System.Collections.Generic;

namespace monopoly
{
    static class GUIController
    {
        private static List<IDrawable> _drawables = new();

        public static void AddDrawable(IDrawable drawable)
        { if (!_drawables.Contains(drawable)) _drawables.Add(drawable); }

        public static void RemoveDrawable(IDrawable drawable)
        { if (_drawables.Contains(drawable)) _drawables.Remove(drawable); }
        
        public static void Draw()
        { for (int i = _drawables.Count - 1; i >= 0; i--) _drawables[i].Draw(); }

        public static int[] GetCoordsByTile(int loc)
        {
            int[] coords = { 0, 0 };
            if (loc >= 0 && loc < 10) { coords[0] = 920 - (58 * loc); coords[1] = 665; }
            if (loc >= 10 && loc < 20) { coords[0] = 315; coords[1] = 635 - (58 * (loc - 10)); }
            if (loc >= 20 && loc < 30) { coords[0] = 345 + (58 * (loc - 20)); coords[1] = 30; }
            if (loc >= 30 && loc < 40) { coords[0] = 950; coords[1] = 50 + (58 * (loc - 30)); }
            return coords;
        }
    }
}