using Front_end.Services;

namespace Front_end.Contracts
{
    public interface IFetchDataService
    {
        Task<GetPortalPageDataVM> GetPortalPageData();
    }
}
