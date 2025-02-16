using ModularMonolith.Core.Interfaces;
using System.Reflection;

namespace ModularMonolith.Core;

public static class ModuleLoader
{
    public static IEnumerable<Module> LoadModules(string pluginsFolderPath)
    {
        var modules = new List<Module>();

        if (!Directory.Exists(pluginsFolderPath))
            throw new DirectoryNotFoundException($"Plugin folder not found: {pluginsFolderPath}");


        var dllFiles = Directory.GetFiles(pluginsFolderPath, "*.dll", SearchOption.TopDirectoryOnly);
        foreach (var dll in dllFiles)
        {
            try
            {
                var assembly = Assembly.LoadFrom(dll);
                var moduleTypes = assembly.GetTypes()
                    .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsAbstract && t.IsClass);

                foreach (var type in moduleTypes)
                {
                    if (Activator.CreateInstance(type) is Module module)
                        modules.Add(module);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading modules from {dll}: {ex.Message}");
            }
        }
        return modules;
    }
}