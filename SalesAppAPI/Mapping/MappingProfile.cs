using System.Collections.Generic;
using AutoMapper;
using SalesAppAPI.DTOs;
using SalesAppAPI.Models;

namespace TourApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDTO, Account>();
            CreateMap<Account, AccountDTO>();

            CreateMap<CatalogDTO, Catalog>();
            CreateMap<Catalog, CatalogDTO>();

            CreateMap<ComboDTO, Combo>();
            CreateMap<Combo, ComboDTO>();

            CreateMap<ComboDetailsDTO, ComboDetails>();
            CreateMap<ComboDetails, ComboDetailsDTO>();

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<DeliveryNoteDTO, DeliveryNote>();
            CreateMap<DeliveryNote, DeliveryNoteDTO>();

            CreateMap<InvoiceDTO, Invoice>();
            CreateMap<Invoice, InvoiceDTO>();

            CreateMap<InvoiceDetailsDTO, InvoiceDetails>();
            CreateMap<InvoiceDetails, InvoiceDetailsDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO>();

            CreateMap<StaffDTO, Staff>();
            CreateMap<Staff, StaffDTO>();

            CreateMap<StorageDTO, Storage>();
            CreateMap<Storage, StorageDTO>();
        }
    }
}