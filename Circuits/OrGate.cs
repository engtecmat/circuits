using Circuits.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// This class repsentes Or Gate, it has two input pins and one output pin.
    /// </summary>
    public class OrGate : Gate
    {
        public OrGate(int x, int y)
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
            return new OrGate(Left, Top);
        }

        public override bool Evaludate()
        {
            List<Pin> inputs = Pins.FindAll(p => p.IsInput);

            if (inputs.Any(p => p.InputWire == null || p.InputWire.FromPin == null))
            {
                MessageBox.Show("Cannot evaludate the Or gate: One or more input pins are not connected!");
                return false;
            }

            // the result will true if any of the inputs is true.
            return inputs.Any(p => p.InputWire.FromPin.Owner.Evaludate());
        }

        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            // must move the pins too
            pins[0].X = x - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT - GAP;
            pins[2].X = x + WIDTH + GAP;
            pins[2].Y = y + HEIGHT / 2 - 1;
        }

        protected override Bitmap GetBitmap()
        {
            return Selected ? Resources.OrGateAllRed : Resources.OrGate;
        }
    }

}
