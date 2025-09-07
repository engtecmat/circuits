using System;
using System.Collections.Generic;
using System.Drawing;

namespace Circuits
{
    public class Compound : Gate
    {
        /// <summary>
        /// a group of gates
        /// </summary>
        private List<Gate> _gates;

        public Compound()
        {
            _gates = new List<Gate>();
        }

        public List<Gate> Gates => _gates;

        public override Gate Clone()
        {
            throw new NotImplementedException();
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
            Gates.Add(gate);
        }

        public override void MoveTo(int x, int y)
        {
            if (Gates == null)
            {
                return;
            }
            Gates.ForEach(gate => gate.MoveTo(0, 0));
        }
    }
}
