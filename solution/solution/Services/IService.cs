using solution.Models;
using solution.ResponseModels;

namespace solution.Services;

public interface IService
{
    public Task<AccountGetResponseModel> GetAccount(int id);
    public Task AddProductApplyCategories(AddProductRequestModel request);
}