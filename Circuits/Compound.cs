using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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

        /// <summary>
        /// clone all the gates in the compound and itself
        /// </summary>
        /// <returns></returns>
        public override Gate Clone()
        {
            Compound compound = new Compound(Left, Top);
            _gates.ForEach(gate => compound.AddGate(gate.Clone()));
            return compound;
        }

        /// <summary>
        /// draw all the gates in the compound
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            if (_gates == null)
            {
                return;
            }

            _gates.ForEach(gate => gate.Draw(g));
        }

        /// <summary>
        /// evaludate all the gates in the compound
        /// </summary>
        /// <returns></returns>
        public override bool Evaluate()
        {
            return _gates.All(g => g.Evaluate());
        }

        public void AddGate(Gate gate)
        {
            if (_gates == null)
            {
                return;
            }
            // reset the status to make the first move correct
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

        /// <summary>
        /// check if the clicked gate int the compound
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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

        /// <summary>
        /// select all the gates in the compound
        /// </summary>
        public override void BeSelected()
        {
            base.BeSelected();
            _gates.ForEach(_gate => _gate.BeSelected());
        }

        /// <summary>
        /// deselect all the gates in the compound
        /// </summary>
        public override void BeDeselected()
        {
            base.BeDeselected();
            _gates.ForEach(_gate => _gate.BeDeselected());
        }

    }
}
