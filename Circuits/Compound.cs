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

        public override Gate Clone()
        {
            Compound compound = new Compound(Left, Top);
            _gates.ForEach(gate => compound.AddGate(gate.Clone()));
            return compound;
        }

        public override void Draw(Graphics g)
        {
            if (_gates == null)
            {
                return;
            }
            _gates.ForEach(gate => gate.Draw(g));
        }

        public override bool Evaludate()
        {
            throw new NotImplementedException();
        }

        public void AddGate(Gate gate)
        {
            if (_gates == null)
            {
                return;
            }
            gate.ResetMovedStatus();
            _gates.Add(gate);
        }

        public override void MoveTo(int x, int y)
        {
            if (_gates == null)
            {
                return;
            }
            int dx = x - this.Left;
            int dy = y - this.Top;

            base.MoveTo(x, y);
            _gates.ForEach(gate => gate.MoveBy(dx, dy));
        }

        /// <summary>
        /// Compound doesn't need a bitmap
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override Bitmap GetBitmap()
        {
            throw new NotImplementedException();
        }

        public override bool IsMouseOn(int x, int y)
        {
            foreach (Gate gate in _gates)
            {
                if (gate.IsMouseOn(x, y))
                {
                    return true;
                }
            }
            return false;
        }

        public override void BeSelected()
        {
            base.BeSelected();
            _gates.ForEach(_gate => _gate.BeSelected());
        }

        public override void BeDeselected()
        {
            base.BeDeselected();
            _gates.ForEach(_gate => _gate.BeDeselected());
        }

    }
}
