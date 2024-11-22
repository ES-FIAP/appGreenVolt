using AutoMapper;
using greenVolt.Models; // Modelo do app
using greenVolt.Dominio; // Modelo da API

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Empresa, Company>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.id_empresa))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.nome_empresa))
            .ForMember(dest => dest.TaxId, opt => opt.MapFrom(src => src.cnpj))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.descricao))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.categoria))
            .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.contato))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.criado_em))
            .ForMember(dest => dest.EnergySourceType, opt => opt.MapFrom(src => src.tipo_origem_energia))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.valor));

        CreateMap<Company, Empresa>()
            .ForMember(dest => dest.id_empresa, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dest => dest.nome_empresa, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.cnpj, opt => opt.MapFrom(src => src.TaxId))
            .ForMember(dest => dest.descricao, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.categoria, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.contato, opt => opt.MapFrom(src => src.Contact))
            .ForMember(dest => dest.criado_em, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.tipo_origem_energia, opt => opt.MapFrom(src => src.EnergySourceType))
            .ForMember(dest => dest.valor, opt => opt.MapFrom(src => src.Price));
    }
}
