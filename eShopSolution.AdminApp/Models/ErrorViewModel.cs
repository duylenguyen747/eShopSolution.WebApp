using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Languages;

namespace eShopSolution.AdminApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}