using System.Collections.Generic;

namespace PowerBIDotNet
{
    public interface IImports
    {
        IEnumerable<Import> GetAll();
        void Import(string file);
    }
}
