using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Circuits
{


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
            return new NotGate(0, 0);
        }

        public override void Draw(Graphics g)
        {
            Brush brush;
            //Check if the gate has been selected
            Console.WriteLine(selected);
            if (selected)
            {
                brush = selectedBrush;
            }
            else
            {
                brush = normalBrush;
            }
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(g);

            // draw a Or gate using a bitmap.

            if (selected)
            {
                g.DrawImage(Circuits.Properties.Resources.NotGateAllRed, Left, Top, WIDTH, HEIGHT);

            }
            else
            {
                g.DrawImage(Circuits.Properties.Resources.NotGate, Left, Top, WIDTH, HEIGHT);
            }
        }

        public override bool Evaludate()
        {
            List<Pin> inputs = Pins.FindAll(p => p.IsInput);

            if (inputs.Any(p => p.InputWire == null || p.InputWire.FromPin == null))
            {
                MessageBox.Show("Cannot evaludate the Not gate: One or more input pins are not connected!");
                return false;
            }

            return inputs.All(p => p.InputWire.FromPin.Owner.Evaludate());
        }

        public override void MoveTo(int x, int y)
        {
            //Debugging message
            Console.WriteLine("pins = " + pins.Count);
            //Set the position of the gate to the values passed in
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x + WIDTH + GAP;
            pins[1].Y = y + HEIGHT / 2;
        }
    }
}
