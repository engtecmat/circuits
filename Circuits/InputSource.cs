using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class represens a input which has only one output pin.
    /// </summary>
    public class InputSource : Gate
    {
        private bool _status = false;
        public InputSource(int x, int y)
        {
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        public override Gate Clone()
        {
            return new InputSource(Left, Top);
        }

        public override void Draw(Graphics g)
        {
            //Draw each of the pins
            pins.ForEach(p => p.Draw(g));

            // draw a Or gate using a bitmap.
            g.DrawImage(Properties.Resources.InputIcon, Left, Top, WIDTH, HEIGHT);
            if (_status)
            {
                g.FillRectangle(Brushes.LawnGreen, left + 6, top + 13, 12, 12);
            }
        }

        public override bool Evaludate()
        {
            return _status;
        }

        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            // must move the pins too
            pins[0].X = x + WIDTH + GAP;
            pins[0].Y = y + HEIGHT / 2 - 2;
        }

        /// <summary>
        /// toggle the status
        /// </summary>
        public void Toggle()
        {
            _status = !_status;
        }
    }
}
