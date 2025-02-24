/*using AutoMapper;
using System.Reflection;

namespace ShopDevelop.Application.Data.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingFromAssembly(assembly);
    /// <summary>
    /// This method allows you to find and call the Mapping method on types that
    /// implement the IMapWith interface and apply mappings using Automapper.
    /// </summary>
    /// <param name="assembly"></param>
    private void ApplyMappingFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}*/