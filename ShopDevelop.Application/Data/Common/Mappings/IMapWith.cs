using AutoMapper;

namespace ShopDevelop.Application.Data.Common.Mappings;

public interface IMapWith<T>
{
    /// <summary>
    /// It is used to create a dynamic mapping.
    /// </summary>
    /// <param name="profile"></param>
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}