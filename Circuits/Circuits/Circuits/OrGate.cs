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
    internal class OrGate : Gate
    {

        /// <summary>
        /// using superclass constructor
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        public OrGate(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
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
                paper.DrawImage(Properties.Resources.OrGateAllRed, Left, Top);
            }
            else
            {
                paper.DrawImage(Properties.Resources.OrGate, Left, Top);
            }


            // AND is simple, so we can use a circle plus a rectange.
            // An alternative would be to use a bitmap.
            //paper.FillEllipse(brush, left, top, WIDTH, HEIGHT);
            //paper.FillRectangle(brush, left, top, WIDTH / 2, HEIGHT);

            //Note: You can also use the images that have been imported into the project if you wish,
            //      using the code below.  You will need to space the pins out a bit more in the constructor.
            //      There are provided images for the other gates and selected versions of the gates as well.
        }

        /// <summary>
        /// evaluates the state of Orgate
        /// </summary>
        public override bool Evaluate()
        {
            try
            {
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                Gate gateB = pins[1].InputWire.FromPin.Owner;
                return gateA.Evaluate() || gateB.Evaluate();
            }
            catch (Exception)
            {
                MessageBox.Show("Circuit not complete");
                return false;
            }

        }


        public override Gate Clone()
        {
            OrGate copyGate = new OrGate(this.Left + CLONE_SHIFT, this.Top + CLONE_SHIFT);
            return copyGate;
        }
    }
}
