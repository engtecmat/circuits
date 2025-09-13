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

        /// <summary>
        /// the status will be changed after clicking
        /// </summary>
        /// <returns></returns>
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

        protected override Bitmap GetBitmap()
        {
            if (Selected)
            {
                return _status ? Properties.Resources.InputOnRed : Properties.Resources.InputOffRed;
            }
            return _status ? Properties.Resources.InputOn : Properties.Resources.InputOff;
        }
    }
}
