using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.Simple.Data.Core
{
    public interface ISimpleSettingsDatabase : ISimpleDatabase
    {
        string SettingsTableName { get; set; }

        dynamic GetSettings(string name);
        dynamic GetSettings(object id);

        int AddSettings(dynamic settings);
        bool UpdateSettings(dynamic settings);
    }
}
