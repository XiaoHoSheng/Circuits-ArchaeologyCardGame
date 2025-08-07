using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Circuits
{
    public class Compound : Gate
    {
        //list of gates in compound
        public List<Gate> gates = new List<Gate>();
        public List<Point> pointlist = new List<Point>();
        public Compound(int x, int y) : base(x, y)
        {
            pins.Clear();
        }

        /// <summary>
        /// adds gate and saves coordinates
        /// </summary>
        /// <param name="gate"></param>
        public void AddGate(Gate gate)
        {
            
            gates.Add(gate);
            pointlist.Add(new Point(gate.left - gates[0].left, gate.top - gates[0].top));
            
        }

        /// <summary>
        /// draws every gate in compound gate
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
           foreach (Gate gate in gates)
            {
                if (selected)
                {
                    gate.Selected = true;
                    gate.Draw(paper);
                }
                else
                {
                    gate.Selected = false;
                    gate.Draw(paper);
                }
                
            }

        }

        /// <summary>
        /// Evaluates
        /// </summary>
        public override bool Evaluate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// clones a compound gate
        /// </summary>
        /// <returns></returns>
        public override Gate Clone()
        {
            //copies gate through list, adds to new gate
            Compound copyGate = new Compound(this.Left + CLONE_SHIFT, this.Top + CLONE_SHIFT);
            for (int i = 0; i < gates.Count; i++)
            {
                copyGate.AddGate(gates[i].Clone());
            }
            return copyGate;

        }

        /// <summary>
        /// moves the compound gate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MoveTo(int x, int y)
        {
            for (int a = 0; a < gates.Count; a++)
            {
                //change the position
                try
                {
                    gates[a].MoveTo(x + pointlist[a].X + 650, y + pointlist[a].Y + 350);
                }
                catch
                {
                }
                
            }
        }

        /// <summary>
        /// Checks if any gate in the compound has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public override bool IsMouseOn(int x, int y)
        {
            foreach (Gate g in gates)
            {
                if (g.IsMouseOn(x, y))
                {
                    return true;
                }
                    
            }
            return false;
        }
    }
}
