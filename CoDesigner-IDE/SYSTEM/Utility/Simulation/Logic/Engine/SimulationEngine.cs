using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Manages the interactions between the elements within a single simulation instance.
    /// </summary>
    public class SimulationEngine
    {
        public int simulationIndex { get; }  = -1;
        // concrete simulation elements
        public List<ConcreteElement> ConcreteElements = new List<ConcreteElement>();

        /// <summary>
        /// Create a new simulation engine
        /// </summary>
        /// <param name="simulationIndex"> The index of the containing simulation </param>
        public SimulationEngine(int simulationIndex) 
        { 
            this.simulationIndex = simulationIndex;
        }
    }
}
