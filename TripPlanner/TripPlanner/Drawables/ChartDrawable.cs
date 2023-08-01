
namespace TripPlanner.Drawables
{
    public class ChartDrawable : BaseDrawable, IDrawable
    {
        public int mAngle;
        public override void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Color.FromArgb("#2B6777");
            canvas.StrokeSize = 24;
            canvas.DrawArc(13, 13, 180, 180, mAngle, 90, false, false);

            canvas.StrokeColor = Color.FromArgb("#C8D8E4");
            canvas.DrawArc(13, 13, 180, 180, mAngle, 90, true, false);
        }
    }
}
