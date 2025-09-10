using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Circuits
{

    /// <summary>
    /// This is Not gate, it includes one input pin and one ouput pin
    /// </summary>
    public class NotGate : Gate
    {

        public NotGate(int x, int y)
        {
            //Add the input pin to the gate
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        public override Gate Clone()
        {
            return new NotGate(Left, Top);
        }

        public override void Draw(Graphics g)
        {
            //Draw each of the pins
            pins.ForEach(p => p.Draw(g));

            // draw a Or gate using a bitmap.
            Bitmap bitmap = selected ? Properties.Resources.NotGateAllRed : Properties.Resources.NotGate;
            g.DrawImage(bitmap, Left, Top, WIDTH, HEIGHT);
        }

        public override bool Evaludate()
        {
            List<Pin> inputs = Pins.FindAll(p => p.IsInput);

            if (inputs.Any(p => p.InputWire == null || p.InputWire.FromPin == null))
            {
                MessageBox.Show("Cannot evaludate the Not gate: One or more input pins are not connected!");
                return false;
            }

            return inputs.All(p => !p.InputWire.FromPin.Owner.Evaludate());
        }

        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);
            // must move the pins too
            pins[0].X = x - GAP;
            pins[0].Y = y + HEIGHT / 2 - 2;
            pins[1].X = x + WIDTH + GAP;
            pins[1].Y = y + HEIGHT / 2 - 2;
        }
    }
}
