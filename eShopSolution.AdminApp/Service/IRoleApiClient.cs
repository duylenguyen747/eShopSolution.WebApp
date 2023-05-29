using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Roles;

namespace eShopSolution.AdminApp.Service
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
    }
}