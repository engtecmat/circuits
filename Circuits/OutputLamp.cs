using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// This class will be represented the final output.
    /// </summary>
    public class OutputLamp : Gate
    {
        private bool _status = false;
        public OutputLamp(int x, int y)
        {
            //Add the output pin to the gate
            pins.Add(new Pin(this, true, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        public override Gate Clone()
        {
            return new OutputLamp(0, 0);
        }

        public override void Draw(Graphics g)
        {
            //Draw each of the pins
            pins.ForEach(p => p.Draw(g));

            // draw a Or gate using a bitmap.
            Bitmap bitmap = _status ? Properties.Resources.OutputIcon : Properties.Resources.OutputOff;
            g.DrawImage(bitmap, Left, Top, WIDTH, HEIGHT);
        }

        public override bool Evaludate()
        {
            List<Pin> inputs = Pins.FindAll(p => p.IsInput);

            if (inputs.Any(p => p.InputWire == null || p.InputWire.FromPin == null))
            {
                MessageBox.Show("Cannot evaludate the OutputLamp: One or more input pins are not connected!");
                return false;
            }

            _status = inputs.All(p => p.InputWire.FromPin.Owner.Evaludate());
            Console.WriteLine("Final output: " + _status);
            return _status;
        }

        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);
            // must move the pins too
            pins[0].X = x - GAP;
            pins[0].Y = y + HEIGHT / 2 - 5;
        }
    }
}
