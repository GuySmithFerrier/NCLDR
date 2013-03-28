namespace NCldr
{
    using System;

    /// <summary>
    /// NCldrLoader loads/saves the raw NCLDR data from an NCldr data file
    /// </summary>
    /// <remarks>Set the NCldrLoader.NCldrDataPath property before calling NCldrLoader.Load</remarks>
    [Obsolete("NCldrLoader is deprecated. Use NCldrBinaryFileDataSource instead.")]
    public class NCldrLoader : NCldrBinaryFileDataSource
    {
    }
}
