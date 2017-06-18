using labppo1.Pluginworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace labppo1
{
    class PluginLoader
    {
        private List<IPlugin> plugins;

        public List<IPlugin> loadPlugins(string path)
        {
            plugins = new List<IPlugin>();
            try
            {
                string[] allfiles = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
                foreach (string file in allfiles)
                {
                string pt = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                Assembly assembly = Assembly.LoadFile(pt + "\\" + file);
                    Type[] alltypes = assembly.GetExportedTypes();
                    foreach (Type type in alltypes)
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type))
                            plugins.Add((IPlugin)Activator.CreateInstance(type));
                    }
                }
            }
            catch { }
            return plugins;
        }

        public List<IPlugin> loadPlugin(string path)
        {
            try
            {
                plugins = new List<IPlugin>();
                Assembly assembly = Assembly.LoadFile(path);
                Type[] alltypes = assembly.GetExportedTypes();
                foreach (Type type in alltypes)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                        plugins.Add((IPlugin)Activator.CreateInstance(type));
                }
            }
            catch { }

            return plugins;
        }

        public PluginLoader()
        {
        }
    }

}
