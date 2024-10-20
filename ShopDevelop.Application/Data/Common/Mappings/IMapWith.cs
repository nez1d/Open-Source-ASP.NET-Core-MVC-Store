using AutoMapper;

namespace ShopDevelop.Application.Data.Common.Mappings
{
    internal interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
