using SplashKitSDK;

namespace monopoly
{
    interface IDrawable
    {
        public Bitmap Image { get; }
        public void Draw();
    }
}