using System;
using System.Collections.Generic;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// For grouping gates
    /// </summary>
    public class Compound : Gate 
    {
        /// <summary>
        /// a group of gates
        /// </summary>
        private List<Gate> _gates = new List<Gate>();

        public Compound(int x, int y)
        {
            base.MoveTo(x, y);
        }

        public List<Gate> Gates => _gates;

        public override Gate Clone()
        {
            Compound compound = new Compound(Left, Top);
            Gates.ForEach(gate => compound.AddGate(gate.Clone()));
            return compound;
        }

        public override void Draw(Graphics g)
        {
            if (Gates == null)
            {
                return;
            }
            Gates.ForEach(gate => gate.Draw(g));
        }

        public override bool Evaludate()
        {
            throw new NotImplementedException();
        }

        public void AddGate(Gate gate)
        {
            if (Gates == null)
            {
                return;
            }
            gate.ResetMovedStatus();
            Gates.Add(gate);
        }

        public override void MoveTo(int x, int y)
        {
            if (Gates == null)
            {
                return;
            }
            int dx = x - this.Left;
            int dy = y - this.Top;

            base.MoveTo(x, y);
            Gates.ForEach(gate => gate.MoveBy(dx, dy));
        }
    }
}
