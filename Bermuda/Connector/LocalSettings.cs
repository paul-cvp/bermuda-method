using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Connector
{
    public class LocalSettings
    {
        public static void ResetKey(string key)
        {
            Properties.Settings.Default[key] = null;
        }
        public static void SaveToLocalSettings(string key, object value)
        {
            if (value != null && key != null)
            {
                if (value is string)
                {
                    Properties.Settings.Default[key] = (string)value;
                }
                else if (value is DataSet)
                {
                    Properties.Settings.Default[key] = (DataSet)value;
                }
                else
                {
                    Properties.Settings.Default[key] = JsonConvert.SerializeObject(value);
                }
                Properties.Settings.Default.Save();
            }
        }
        public static string GetDataFromLocalSettings(string key)
        {
            try
            {
                return (string) Properties.Settings.Default[key];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static T GetDataFromLocalSettings<T>(string key)
        {
            try
            {
                if (typeof(T)==typeof(DataSet))
                {
                    return (T)Properties.Settings.Default[key];
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>((string)Properties.Settings.Default[key]);
                }
            } catch (Exception e)
            {
                return default(T);
            }
        }
    }
}
