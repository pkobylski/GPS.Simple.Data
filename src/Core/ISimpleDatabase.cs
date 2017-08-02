using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.Simple.Data.Core
{
    public interface ISimpleDatabase
    {
        dynamic RunQuery(Func<dynamic, dynamic> dbQuery);
    }
}
