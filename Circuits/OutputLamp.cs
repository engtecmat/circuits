using System;
using System.Drawing;

namespace Circuits
{

    public class OutputLamp : Gate
    {
        private bool _status = false;
        public OutputLamp(int x, int y)
        {
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
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
                g.DrawImage(Circuits.Properties.Resources.OutputIcon, Left, Top, WIDTH, HEIGHT);

            }
            else
            {
                g.DrawImage(Circuits.Properties.Resources.OutputIcon, Left, Top, WIDTH, HEIGHT);
            }
        }

        public override void MoveTo(int x, int y)
        {
            //Debugging message
            Console.WriteLine("pins = " + pins.Count);
            //Set the position of the gate to the values passed in
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x + WIDTH + GAP;
            pins[0].Y = y + HEIGHT / 2;
        }
    }
}
