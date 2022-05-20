using Katmanli.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.BLL.IRepository
{
    public interface IRepository<t>
    {
        void Insert(t item);
        void Update(t item);
        void Delete(int itemId);
        List<t> GetAll();
        t Get(int itemId);
    }
}
