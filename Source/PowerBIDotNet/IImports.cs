using System.Collections.Generic;

namespace Infrastructure.PowerBI
{
    public interface IImports
    {
        IEnumerable<Import> GetAll();
        void Import(string file);
    }
}
