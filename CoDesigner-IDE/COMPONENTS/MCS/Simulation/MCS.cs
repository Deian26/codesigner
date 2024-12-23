using CoDesigner_IDE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

/// <summary>
/// Compiler for the programming language: MCL
/// </summary>
public class MCS : IIDESimulationAddonComponent
{
    #region general-fields

    #endregion

    #region singleton
    private static MCS instance = null;
    /// <summary>
    /// Returns the instance of this object to be used in the IDE
    /// </summary>
    /// <returns> The instance to be used within the IDE, for component-specific methods </returns>
    public static MCS GetInstance() //=> this name is fixed and this method must be implemented for the component to be loaded into the IDE
    {
        MCS.instance = new MCS(); //=> instantiate the singleton
        return MCS.instance;
    }

    private MCS() { } //=> this class should be a singleton
    #endregion
}

