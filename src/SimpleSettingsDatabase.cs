using GPS.Simple.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace GPS.Simple.Data
{
    public class SimpleSettingsDatabase : SimpleDatabase, ISimpleSettingsDatabase
    {
        private string _settingsTableName = "settings";

        public string SettingsTableName
        {
            get { return _settingsTableName; }
            set { _settingsTableName = value; }
        }

        private string _columnNameAlias = "Name";

        public string ColumnNameAlias
        {
            get { return _columnNameAlias; }
            set { _columnNameAlias = value; }
        }

        private string _columnValueAlias = "Value";

        public string ColumnValueAlias
        {
            get { return _columnValueAlias; }
            set { _columnValueAlias = value; }
        }


        public SimpleSettingsDatabase(string connectionString)
            : base(connectionString)
        {
            
        }        
         
        public int AddSettings(dynamic settings)
        {
            var result = this.RunQuery(db => db[this.SettingsTableName].Insert(settings));

            if (result != null)
                return result.Id;
            else
                return 0;
        }

        public dynamic GetSettings(string name)
        {
            dynamic x = this.RunQuery(db => db[this.SettingsTableName].Find(db[this.SettingsTableName][this.ColumnNameAlias] == name));

            return x;
        }

        public dynamic GetSettings(object id)
        {
            dynamic x = this.RunQuery(db => db[this.SettingsTableName].Find(db[this.SettingsTableName].Id == id));

            return x;
        }

        public bool UpdateSettings(dynamic settings)
        {
            dynamic s = this.RunQuery(db => db[this.SettingsTableName].Find(db[this.SettingsTableName].Id == settings.Id));

            settings.Id = s.Id;

            this.RunQuery(db => db[this.SettingsTableName].Update(settings));

            return true;
        }
    }
}
