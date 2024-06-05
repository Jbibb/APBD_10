using System.Collections;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using solution.Contexts;
using solution.Exceptions;
using solution.Models;
using solution.ResponseModels;

namespace solution.Services;

public class Service(DatabaseContext databaseContext) : IService
{
    public async Task<AccountGetResponseModel> GetAccount(int id)
    {
        var result = await databaseContext.Accounts
            .Where(a => a.AccountId == id).Select(a => new AccountGetResponseModel
            {
                firstName = a.AccountFirstName,
                lastName = a.AccountLastName,
                email = a.AccountEmail,
                phone = a.AccountPhone,
                role = a.Role.RoleName,
                cart = a.ShoppingCarts.Select(sc => new CartElementResponseModel
                {
                    productId = sc.ProductId,
                    productName = sc.Product.ProductName,
                    amount = sc.ShoppingCartAmount
                })
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Account with id = {id} does not exist");
        }

        return result;


    }

    public async Task AddProductApplyCategories(AddProductRequestModel request)
    {
        var missingCategoryIds = new List<int>();
        foreach (var requestProductCategoryId in request.productCategories)
        {
            if (! await databaseContext.Categories.AnyAsync(c => c.CategoryId == requestProductCategoryId))
            {
                missingCategoryIds.Add(requestProductCategoryId);
            }
        }

        if (missingCategoryIds.Count > 0)
        {
            var errors = new Dictionary<string, string[]>();
            var errorString = new StringBuilder("Category(ies) with id(s) = ");
            for (int i = 0; i < missingCategoryIds.Count - 1; i++)
                errorString.Append(missingCategoryIds[i]).Append(", ");
            errorString.Append(missingCategoryIds[^1]).Append(" does(do) not exist");
            
            errors.Add("productCategories", new []{errorString.ToString()});
            throw new CategoryValidationException(errors);
        }
        
        var newProduct = new Product
        {
            ProductName = request.productName,
            ProductWeight = request.productWeight,
            ProductWidth = request.productWidth,
            ProductHeight = request.productHeight,
            ProductDepth = request.productDepth,
            Categories = databaseContext.Categories.Where(c => request.productCategories.Contains(c.CategoryId)).ToList()
        };
        await databaseContext.Products.AddAsync(newProduct);
        await databaseContext.SaveChangesAsync();
    }
}

    