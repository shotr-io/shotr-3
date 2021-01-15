using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shotr.Core.Custom;
using ShotrUploaderPlugin;

namespace Shotr.Core.Services
{
    public class PluginService
    {
        public static void Initialize(ServiceCollection services)
        {
            //Initialize stuffs.
            Console.WriteLine("Loading types from local assembly...");

            //Load all modules from current module.
            try
            {
                foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    try
                    {
                        if (typeof(IImageUploader).IsAssignableFrom(type) && type != typeof(IImageUploader) && type != typeof(UploaderBridge))
                        {
                            //Load the module.
                            Console.WriteLine($"Loaded type plugin {type}.");
                            services.AddTransient(typeof(IImageUploader), type);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch (ReflectionTypeLoadException e)
            {
                foreach (var exceptions in e.LoaderExceptions)
                {
                    if (exceptions is { })
                    {
                        Console.WriteLine(exceptions.ToString());
                    }
                }
            }
        }
    }
}

