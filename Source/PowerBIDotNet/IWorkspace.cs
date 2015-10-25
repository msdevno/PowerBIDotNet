// https://msdn.microsoft.com/en-us/library/mt243840.aspx

using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public interface IWorkspace
    {
        IImports Imports { get; }

        IGroups Groups { get; }

        IRows Rows { get; }

        IDatasets Datasets { get;  }

        ITables Tables { get; }
    }
}
