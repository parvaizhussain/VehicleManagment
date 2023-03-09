using Application.Features.AccessRights.Commands.CreateAccessRights;
using Application.Features.AccessRights.Commands.UpdateAccessRights;
using Application.Features.AccessRights.Queries.GetAccessRightsByID;
using Application.Features.AccessRights.Queries.GetAccessRightsList;
using Application.Features.Airport.Command.Create;
using Application.Features.Airport.Command.Update;
using Application.Features.Airport.Querys.GetByID;
using Application.Features.Airport.Querys.GetByList;
using Application.Features.Booking.Command.Create;
using Application.Features.Booking.Command.Update;
using Application.Features.Booking.Querys.GetByID;
using Application.Features.Booking.Querys.GetByList;
using Application.Features.Branch.Commands.CreateBranch;
using Application.Features.Branch.Commands.UpdateBranch;
using Application.Features.Branch.Queries.GetBranchByID;
using Application.Features.Branch.Queries.GetBranchList;
using Application.Features.City.Commands.CreateCity;
using Application.Features.City.Commands.UpdateCity;
using Application.Features.City.Queries.GetCityByID;
using Application.Features.City.Queries.GetCityList;
using Application.Features.Department.Commands.CreateDepartment;
using Application.Features.Department.Commands.UpdateDepartment;
using Application.Features.Department.Queries.GetDepartmentByID;
using Application.Features.Department.Queries.GetDepartmentList;
using Application.Features.Driver.Command.Create;
using Application.Features.Driver.Command.Update;
using Application.Features.Driver.Querys.GetByID;
using Application.Features.Driver.Querys.GetByList;
using Application.Features.FuelCard.Command.Create;
using Application.Features.FuelCard.Command.Delete;
using Application.Features.FuelCard.Command.Update;
using Application.Features.FuelCard.Querys.GetByID;
using Application.Features.FuelCard.Querys.GetByList;
using Application.Features.Group.Commands.CreateGroup;
using Application.Features.Group.Commands.UpdateGroup;
using Application.Features.Group.Queries.GetGroupByID;
using Application.Features.Group.Queries.GetGroupList;
using Application.Features.MaintainaceHistory.Command.Create;
using Application.Features.MaintainaceHistory.Command.Update;
using Application.Features.MaintainaceHistory.Querys.GetByID;
using Application.Features.MaintainaceHistory.Querys.GetByList;
using Application.Features.Network.Commands.CreateNetwork;
using Application.Features.Network.Commands.UpdateNetwork;
using Application.Features.Network.Queries.GetNetworkByID;
using Application.Features.Network.Queries.GetNetworkByRegionCode;
using Application.Features.Network.Queries.GetNetworkList;
using Application.Features.Receipt.Command.Create;
using Application.Features.Receipt.Command.Update;
using Application.Features.Receipt.Querys.GetByID;
using Application.Features.Receipt.Querys.GetByList;
using Application.Features.Region.Commands.CreateRegion;
using Application.Features.Region.Commands.UpdateRegion;
using Application.Features.Region.Queries.GetRegionByID;
using Application.Features.Region.Queries.GetRegionList;
using Application.Features.ServiceCenter.Command.Create;
using Application.Features.ServiceCenter.Command.Update;
using Application.Features.ServiceCenter.Querys.GetByID;
using Application.Features.ServiceCenter.Querys.GetByList;
using Application.Features.Session.Commands.CreateSession;
using Application.Features.Session.Commands.UpdateSession;
using Application.Features.Session.Queries.GetSessionByID;
using Application.Features.Session.Queries.GetSessionByName;
using Application.Features.Session.Queries.GetSessionList;
//using Application.Features.Vehicle.Command.CreateCommand;
//using Application.Features.Vehicle.Command.CreateVehicle;
//using Application.Features.Vehicle.Command.UpdateVehicle;
using Application.Features.VehicleBrands.Command.Create;
using Application.Features.VehicleBrands.Command.Update;
using Application.Features.VehicleBrands.Querys.GetByID;
using Application.Features.VehicleBrands.Querys.GetByList;
using Application.Features.VehicleCompany.Command.Create;
using Application.Features.VehicleCompany.Command.Update;
using Application.Features.VehicleCompany.Querys.GetByID;
using Application.Features.VehicleCompany.Querys.GetByList;
using Application.Features.VehicleDetails.Command.Create;
using Application.Features.VehicleDetails.Command.Update;
using Application.Features.VehicleDetails.Querys.GetByID;
using Application.Features.VehicleDetails.Querys.GetByList;
using Application.Features.VehicleRequest.Command.Create;
using Application.Features.VehicleRequest.Command.Update;
using Application.Features.VehicleRequest.Querys.GetByID;
using Application.Features.VehicleRequest.Querys.GetByList;
using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
//using Domain.Entities;


namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Region, CreateRegionDto>().ReverseMap();
            CreateMap<Region, GetRegionVM>().ReverseMap();
            CreateMap<Region, GetRegionListVM>().ReverseMap();
            CreateMap<Region, CreateRegionCommand>().ReverseMap();
            CreateMap<Region, UpdateRegionCommand>().ReverseMap();

            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            CreateMap<Branch, GetBranchVM>().ReverseMap();
            CreateMap<Branch, GetBranchListVM>().ReverseMap();
            CreateMap<Branch, CreateBranchCommand>().ReverseMap();
            CreateMap<Branch, UpdateBranchCommand>().ReverseMap();

            CreateMap<City, CreateCityDto>().ReverseMap();
            CreateMap<City, GetCityVM>().ReverseMap();
            CreateMap<City, GetCityListVM>().ReverseMap();
            CreateMap<City, CreateCityCommand>().ReverseMap();
            CreateMap<City, UpdateCityCommand>().ReverseMap();

            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, GetDepartmentVM>().ReverseMap();
            CreateMap<Department, GetDepartmentListVM>().ReverseMap();
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();

            CreateMap<Group, CreateGroupDto>().ReverseMap();
            CreateMap<Group, GetGroupVM>().ReverseMap();
            CreateMap<Group, GetGroupListVM>().ReverseMap();
            CreateMap<Group, CreateGroupCommand>().ReverseMap();
            CreateMap<Group, UpdateGroupCommand>().ReverseMap();

            CreateMap<Network, CreateNetworkDto>().ReverseMap();
            CreateMap<Network, GetNetworkVM>().ReverseMap();
            CreateMap<Network, GetNetworkListVM>().ReverseMap();
            CreateMap<Network, CreateNetworkCommand>().ReverseMap();
            CreateMap<Network, UpdateNetworkCommand>().ReverseMap();
            CreateMap<Network, GetNetworkByRegionCodeVM>().ReverseMap();

            CreateMap<Session, CreateSessionCommand>().ReverseMap();
            CreateMap<Session, CreateSessionDto>().ReverseMap();
            CreateMap<Session, GetSessionByNameVM>().ReverseMap();
            CreateMap<Session, GetSessionVM>().ReverseMap();
            CreateMap<Session, UpdateSessionCommand>().ReverseMap();
            CreateMap<Session, GetSessionListVM>().ReverseMap();

            //CreateMap<VehicleSpecification, CreateVehicleCommand>().ReverseMap();
            //CreateMap<VehicleSpecification, CreateVehicleDto>().ReverseMap();

            CreateMap<VehicleCompany, Create_VehicleCompany_Commands>().ReverseMap();
            CreateMap<VehicleCompany, Create_VehicleCompany_Dto>().ReverseMap();
            CreateMap<VehicleCompany, Get_VehicleCompany_VM>().ReverseMap();
            CreateMap<VehicleCompany, Get_VehicleCompany_ListVM>().ReverseMap();
            CreateMap<VehicleCompany, Update_VehicleCompany_Commads>().ReverseMap();

            CreateMap<VehicleBrands, Create_VehicleBrands_Commands>().ReverseMap();
            CreateMap<VehicleBrands, Create_VehicleBrands_Dto>().ReverseMap();
            CreateMap<VehicleBrands, Get_VehicleBrands_VM>().ReverseMap();
            CreateMap<VehicleBrands, Get_VehicleBrands_ListVM>().ReverseMap();
            CreateMap<VehicleBrands, Update_VehicleBrands_Commads>().ReverseMap();

            CreateMap<Set_VehicleDetails, Create_VehicleDetails_Commands>().ReverseMap();
            CreateMap<Set_VehicleDetails, Create_VehicleDetails_Dto>().ReverseMap();
            CreateMap<Set_VehicleDetails, Get_VehicleDetails_VM>().ReverseMap();
            CreateMap<Set_VehicleDetails, Get_VehicleDetails_ListVM>().ReverseMap();
            CreateMap<Set_VehicleDetails, Update_VehicleDetails_Commads>().ReverseMap();


            CreateMap<ServiceCenter, Create_ServiceCenter_Commands>().ReverseMap();
            CreateMap<ServiceCenter, Create_ServiceCenter_Dto>().ReverseMap();
            CreateMap<ServiceCenter, Get_ServiceCenter_VM>().ReverseMap();
            CreateMap<ServiceCenter, Get_ServiceCenter_ListVM>().ReverseMap();
            CreateMap<ServiceCenter, Update_ServiceCenter_Commads>().ReverseMap();

            CreateMap<MaintainaceHistory, Create_MaintainaceHistory_Commands>().ReverseMap();
            CreateMap<MaintainaceHistory, Create_MaintainaceHistory_Dto>().ReverseMap();
            CreateMap<MaintainaceHistory, Get_MaintainaceHistory_VM>().ReverseMap();
            CreateMap<MaintainaceHistory, Get_MaintainaceHistory_ListVM>().ReverseMap();
            CreateMap<MaintainaceHistory, Update_MaintainaceHistory_Commads>().ReverseMap();

            CreateMap<AccessRights, CreateAccessRightsDto>().ReverseMap();
            CreateMap<AccessRights, GetAccessRightsVM>().ReverseMap();
            CreateMap<AccessRights, GetAccessRightsListVM>().ReverseMap();
            CreateMap<AccessRights, CreateAccessRightsCommand>().ReverseMap();
            CreateMap<AccessRights, UpdateAccessRightsCommand>().ReverseMap();

            CreateMap<VehicleRequest, Create_VehicleRequest_Commands>().ReverseMap();
            CreateMap<VehicleRequest, Create_VehicleRequest_Dto>().ReverseMap();
            CreateMap<VehicleRequest, Get_VehicleRequest_VM>().ReverseMap();
            CreateMap<VehicleRequest, Get_VehicleRequest_ListVM>().ReverseMap();
            CreateMap<VehicleRequest, Update_VehicleRequest_Commads>().ReverseMap();


			CreateMap<Driver, Create_Driver_Commands>().ReverseMap();
			CreateMap<Driver, Create_Driver_Dto>().ReverseMap();
			CreateMap<Driver, Get_Driver_VM>().ReverseMap();
			CreateMap<Driver, Get_Driver_ListVM>().ReverseMap();
			CreateMap<Driver, Update_Driver_Commads>().ReverseMap();



            CreateMap<Airport, Create_Airport_Commands>().ReverseMap();
            CreateMap<Airport, Create_Airport_Dto>().ReverseMap();
            CreateMap<Airport, Get_Airport_VM>().ReverseMap();
            CreateMap<Airport, Get_Airport_ListVM>().ReverseMap();
            CreateMap<Airport, Update_Airport_Commads>().ReverseMap();

            CreateMap<FuelCard, Create_FuelCard_Commands>().ReverseMap();
            CreateMap<FuelCard, Create_FuelCard_Dto>().ReverseMap();
            CreateMap<FuelCard, Get_FuelCard_VM>().ReverseMap();
            CreateMap<FuelCard, Get_FuelCard_ListVM>().ReverseMap();
            CreateMap<FuelCard, Update_FuelCard_Commands>().ReverseMap();
            CreateMap<FuelCard, Delete_FuelCard_Commands>().ReverseMap();


            CreateMap<BookingMaster, Create_booking_Commands>().ReverseMap();
            CreateMap<BookingMaster, Create_booking_Dto>().ReverseMap();
            CreateMap<BookingMaster, Get_booking_VM>().ReverseMap();
            CreateMap<BookingMaster, Get_booking_ListVM>().ReverseMap();
            CreateMap<BookingMaster, Update_booking_Commads>().ReverseMap();


            CreateMap<Receipt, Create_Receipt_Commands>().ReverseMap();
            CreateMap<Receipt, Create_Receipt_Dto>().ReverseMap();
            CreateMap<Receipt, Get_Receipt_VM>().ReverseMap();
            CreateMap<Receipt, Get_Receipt_ListVM>().ReverseMap();
            CreateMap<Receipt, Update_Receipt_Commads>().ReverseMap();
        }


    }
}
