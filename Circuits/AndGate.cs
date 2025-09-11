using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs and one output.
    /// </summary>
    public class AndGate : Gate
    {
        /// <summary>
        /// Initialises the Gate.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public AndGate(int x, int y)
        {
            //Add the two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        public override Gate Clone()
        {
            return new AndGate(Left, Top);
        }

        public override void Draw(Graphics g)
        {
            //Draw each of the pins
            pins.ForEach(p => p.Draw(g));

            // Use a bitmap to draw an And gate.
            Bitmap bitmap = selected ? Properties.Resources.AndGateAllRed : Properties.Resources.AndGate;
            g.DrawImage(bitmap, Left, Top, WIDTH, HEIGHT);
        }

        public override bool Evaludate()
        {

            List<Pin> inputs = Pins.FindAll(p => p.IsInput);

            if (inputs.Any(p => p.InputWire == null || p.InputWire.FromPin == null))
            {
                MessageBox.Show("Cannot evaludate the AND gate: One or more input pins are not connected!");
                return false;
            }

            return inputs.All(p => p.InputWire.FromPin.Owner.Evaludate());
        }

        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            // change the coordinates of pins
            pins[0].X = x - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT - GAP;
            pins[2].X = x + WIDTH + GAP;
            pins[2].Y = y + HEIGHT / 2;
        }
    }
}
