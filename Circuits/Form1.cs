using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Circuits
{

    /*
        Question 1: Is it a better idea to fully document the Gate class or the AndGate subclass? Can you inherit comments?
        Answer: 
            Yes, it is a better idea to fully document the Gate class. AndGate only needs to add new documentation for members that are unique to it
            Yes, comments can indeed be inherited.

        Question 2: What is the advantage of making a method abstract in the superclass rather than just writing a virtual method with no code in the body of the method? Is there any disadvantage to an abstract method?
        Answer:
            An abstract method forces a non-abstract subclass to provide its own implementation. This gurantees that the funtionality is definied.
            A virtual method with an empty body is optional to override, which could lead subclasses that do not function correctly if the developer forgets to implement it.
            The main disadvantage of an abstract method is that it forces the class containing it to also be declared abstract, meaning you cannnot create an instance of that class.
        
        Question 3: If a class has an abstract method in it, does the class have to be abstract?
        Answer: Yes, any class has one or more abstract methods must be declared as an abstract class.
        
        
        Question 4: What would happen in you program if one of the gates added to your Compound Gate is another Compound Gate? Is your design robust enough to cope with this situation?
        Answer: The current design is robust enough to handle nested compound gates. The MoveTo and `Draw` methods in the Compound class iterate through their internal gates and call the corresponding methods. This recursive delegation works naturally with nested compound gates.
     */

    /// <summary>
    /// The main GUI for the COMPX102 digital circuits editor.
    /// This has a toolbar, containing buttons called buttonAnd, buttonOr, etc.
    /// The contents of the circuit are drawn directly onto the form.
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The (x,y) mouse position of the last MouseDown event.
        /// </summary>
        protected int startX, startY;

        /// <summary>
        /// If this is non-null, we are inserting a wire by
        /// dragging the mouse from startPin to some output Pin.
        /// </summary>
        protected Pin startPin = null;

        /// <summary>
        /// The (x,y) position of the current gate, just before we started dragging it.
        /// </summary>
        protected int currentX, currentY;

        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        protected List<Gate> gates = new List<Gate>();

        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        protected List<Wire> wiresList = new List<Wire>();

        /// <summary>
        /// The currently selected gate, or null if no gate is selected.
        /// </summary>
        protected Gate current = null;

        /// <summary>
        /// The new gate that is about to be inserted into the circuit
        /// </summary>
        protected Gate newGate = null;

        /// <summary>
        /// for grouping gates
        /// </summary>
        private Compound newCompound = null;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Finds the pin that is close to (x,y), or returns
        /// null if there are no pins close to the position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The pin that has been selected</returns>
        public Pin findPin(int x, int y)
        {
            foreach (Gate g in gates)
            {
                foreach (Pin p in g.Pins)
                {
                    if (p.isMouseOn(x, y))
                        return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Handles all events when the mouse is moving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                Console.WriteLine("wire from " + startPin + " to " + e.X + "," + e.Y);
                currentX = e.X;
                currentY = e.Y;
            }
            else if (startX >= 0 && startY >= 0 && current != null)
            {
                Console.WriteLine("mouse move to " + e.X + "," + e.Y);
                current.MoveTo(currentX + (e.X - startX), currentY + (e.Y - startY));
            }
            else if (newGate != null)
            {
                currentX = e.X;
                currentY = e.Y;
            }

            // trigger redrawn
            this.Invalidate();
        }

        /// <summary>
        /// Handles all events when the mouse button is released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);
                if (endPin != null)
                {
                    Console.WriteLine("Trying to connect " + startPin + " to " + endPin);
                    Pin input, output;
                    if (startPin.IsOutput)
                    {
                        input = endPin;
                        output = startPin;
                    }
                    else
                    {
                        input = startPin;
                        output = endPin;
                    }
                    if (input.IsInput && output.IsOutput)
                    {
                        if (input.InputWire == null)
                        {
                            Wire newWire = new Wire(output, input);
                            input.InputWire = newWire;
                            wiresList.Add(newWire);
                        }
                        else
                        {
                            MessageBox.Show("That input is already used.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: you must connect an output pin to an input pin.");
                    }
                }
                startPin = null;
                this.Invalidate();
            }
            // We have finished moving/dragging
            startX = -1;
            startY = -1;
            currentX = 0;
            currentY = 0;
        }

        /// <summary>
        /// This will create a new And gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAnd_Click(object sender, EventArgs e)
        {
            newGate = new AndGate(0, 0);
        }

        /// <summary>
        /// Redraws all the graphics for the current circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Draw all of the gates
            foreach (Gate g in gates)
            {
                g.Draw(e.Graphics);
            }
            //Draw all of the wires
            foreach (Wire w in wiresList)
            {
                w.Draw(e.Graphics);
            }

            if (startPin != null)
            {
                e.Graphics.DrawLine(Pens.White,
                    startPin.X, startPin.Y,
                    currentX, currentY);
            }
            if (newGate != null)
            {
                // show the gate that we are dragging into the circuit
                newGate.MoveTo(currentX, currentY);
                newGate.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// This will create a new Or gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonOr_Click(object sender, EventArgs e)
        {
            newGate = new OrGate(0, 0);
        }

        /// <summary>
        /// This will create a new Not gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonNot_Click(object sender, EventArgs e)
        {
            newGate = new NotGate(0, 0);
        }

        /// <summary>
        /// This will create a new IntputSource.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonInputSource_Click(object sender, EventArgs e)
        {
            newGate = new InputSource(0, 0);
        }

        /// <summary>
        /// This will create a new OutputLamp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonOutputLamp_Click(object sender, EventArgs e)
        {
            newGate = new OutputLamp(0, 0);
        }

        /// <summary>
        /// This will evaluate the circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonEvaluation_Click(object sender, EventArgs e)
        {
            // evaluate all the Outputlamps
            gates.FindAll(g => g is OutputLamp).ForEach(g => g.Evaluate());
            this.Invalidate();
        }

        /// <summary>
        /// This will copy the current gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            if (current == null)
            {
                return;
            }

            newGate = current.Clone();
        }

        /// <summary>
        /// This will start a compound mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonStartGroup_Click(object sender, EventArgs e)
        {
            newCompound = new Compound(0, 0);
        }

        /// <summary>
        /// Handles events while the mouse button is pressed down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (current == null)
            {
                // try to start adding a wire
                startPin = findPin(e.X, e.Y);
                return;
            }

            if (current.IsMouseOn(e.X, e.Y))
            {
                // start dragging the current object around
                startX = e.X;
                startY = e.Y;
                currentX = current.Left;
                currentY = current.Top;
            }
        }

        /// <summary>
        /// This will end the compound mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonEndGroup_Click(object sender, EventArgs e)
        {
            if (newCompound == null)
            {
                return;
            }

            newGate = newCompound;
            newCompound = null;

            this.Invalidate();
        }

        /// <summary>
        /// Handles all events when a mouse is clicked in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            // 1. Iterate the list to see if any gate has been clicked.
            Gate clickedGate = null;
            foreach (Gate g in gates)
            {
                if (g.IsMouseOn(e.X, e.Y))
                {
                    clickedGate = g;
                    break;
                }
            }

            // 2. If the newGate is not null which means a new gate has been clicked.
            if (newGate != null)
            {
                newGate.MoveTo(e.X, e.Y);
                gates.Add(newGate);
                newGate = null;
            }

            // 3. If newCompound is not null, which means it is creating a group of gates
            if (newCompound != null && clickedGate != null)
            {
                newCompound.AddGate(clickedGate);
                clickedGate.BeSelected();
                current = newCompound;
            }
            else if (clickedGate != null)
            {
                // 4. If a gate has been clicked and the gate is a InputSource, the toggle its status.
                if (clickedGate != null && clickedGate is InputSource)
                {
                    ((InputSource)clickedGate).Toggle();
                }

                // 5. If another gate is clicked, deselect the current one.
                if (current != null)
                {
                    //Unselect the selected gate
                    current.BeDeselected();
                }
                // 6. set teh current gate to the clicked gate.
                current = clickedGate;
                current.BeSelected();
            }
            else
            {
                // 7. If no gate is being clicked, then set the current one to null and  deselect all the gates.
                current = null;
                gates.ForEach(g => g.BeDeselected());
            }

            this.Invalidate();
        }
    }
}
