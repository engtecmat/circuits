using System.Collections.Generic;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class defines the properties and methods that every gate will have
    /// </summary>
    public abstract class Gate
    {
        /// <summary>
        /// the color after the gate is selected
        /// </summary>
        protected Brush selectedBrush = Brushes.Red;

        /// <summary>
        /// A gate's default color
        /// </summary>
        protected Brush normalBrush = Brushes.LightGray;


        // left is the left-hand edge of the main part of the gate.
        // So the input pins are further left than left.
        protected int left;

        // top is the top of the whole gate
        protected int top;

        // width and height of the main part of the gate
        protected const int WIDTH = 40;
        protected const int HEIGHT = 40;

        // length of the connector legs sticking out left and right
        protected const int GAP = 10;

        //Has the gate been selected
        protected bool selected = false;

        /// <summary>
        /// storages the status in a group
        /// </summary>
        private bool moved = false;

        /// <summary>
        /// This is the list of all the pins of this gate.
        /// e.g., an AND gate always has two input pins (0 and 1) and one output pin (number 2).
        /// </summary>
        protected List<Pin> pins = new List<Pin>();

        /// <summary>
        /// Gets the list of pins for the gate.
        /// </summary>
        public List<Pin> Pins
        {
            get { return pins; }
        }

        /// <summary>
        /// Gets and sets whether the gate is selected or not.
        /// </summary>
        public virtual bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// Gets the left hand edge of the gate.
        /// </summary>
        public int Left
        {
            get { return left; }
        }

        /// <summary>
        /// Gets the top edge of the gate.
        /// </summary>
        public int Top
        {
            get { return top; }
        }

        /// <summary>
        /// Moves the gate to the position specified.
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public virtual void MoveTo(int x, int y)
        {
            //Set the position of the gate to the values passed in
            left = x;
            top = y;
        }

        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + WIDTH
                && top <= y && y < top + HEIGHT)
                return true;
            else
                return false;
        }

        /// <summary>
        /// evaluate the gate's output
        /// </summary>
        /// <returns></returns>
        public abstract bool Evaludate();

        /// <summary>
        /// Duplicate a gate
        /// </summary>
        /// <returns></returns>
        public abstract Gate Clone();

        /// <summary>
        /// reset status to false, which makes sure the gate's next move in a group correct.
        /// </summary>
        public void ResetMovedStatus()
        {
            moved = false;
        }
        /// <summary>
        /// Moves the gate by a relative amount.
        /// </summary>
        /// <param name="dx">The change in x</param>
        /// <param name="dy">The change in y</param>
        public virtual void MoveBy(int dx, int dy)
        {
            if ((dx > 0 || dy > 0) && !moved)
            {
                moved = true;
                MoveTo(this.left, this.top);
                return;
            }
            MoveTo(this.left + dx, this.top + dy);
        }

        /// <summary>
        /// determine the brush by the gate's selected status
        /// </summary>
        /// <returns></returns>
        protected Brush GetBrush()
        {
            //Check if the gate has been selected
            return Selected ? selectedBrush : normalBrush;
        }
    }
}
