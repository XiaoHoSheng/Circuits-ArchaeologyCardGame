using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Circuits
{
    internal class OutputLamp : Gate
    {
        protected bool _lit = false;
        /// <summary>
        /// using new constructer (As only 1 pin)
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        public OutputLamp(int x, int y) : base(x, y)
        {
            //clears the pins from base constructer
            pins.Clear();
            //Add the output pin to the gate
            pins.Add(new Pin(this, true, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }



        /// <summary>
        /// Moves the InputSource to the position specified.
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public override void MoveTo(int x, int y)
        {
            //Debugging message
            Console.WriteLine("pins = " + pins.Count);
            //Set the position of the gate to the values passed in
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x;
            pins[0].Y = y + HEIGHT;

        }

        /// <summary>
        /// Draws the input in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);
            //Check if the gate has been selected
            if (selected)
            {
                //using resources to draw
                if (_lit)
                {
                    paper.DrawImage(Properties.Resources.OutputRed, Left, Top);
                }
                else
                {
                    paper.DrawImage(Properties.Resources.OutputOffRed, Left, Top);
                }
            }
            else
            {
                if (_lit)
                {
                    paper.DrawImage(Properties.Resources.Output, Left, Top);
                }
                else
                {
                    paper.DrawImage(Properties.Resources.OutputOff, Left, Top);
                }



                // AND is simple, so we can use a circle plus a rectange.
                // An alternative would be to use a bitmap.
                //paper.FillEllipse(brush, left, top, WIDTH, HEIGHT);
                //paper.FillRectangle(brush, left, top, WIDTH / 2, HEIGHT);

                //Note: You can also use the images that have been imported into the project if you wish,
                //      using the code below.  You will need to space the pins out a bit more in the constructor.
                //      There are provided images for the other gates and selected versions of the gates as well.
            }
        }

        public override bool Evaluate()
        {
            try
            {
                ///evaluates input
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                //if is high voltage, lit
                if (gateA.Evaluate())
                {
                    _lit = true;
                }
                else
                {
                    _lit = false;
                }
                return gateA.Evaluate();
            }
            catch (Exception)
            {
                MessageBox.Show("Circuit not complete");
                return false;
            }

        }
        public override Gate Clone()
        {
            OutputLamp copyGate = new OutputLamp(this.Left + CLONE_SHIFT, this.Top + CLONE_SHIFT);
            return copyGate;
        }
    }
}
