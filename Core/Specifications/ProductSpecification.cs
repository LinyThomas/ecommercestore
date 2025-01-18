using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecparams specparams) : base(x =>
    (string.IsNullOrEmpty(specparams.Search) || x.Name.ToLower().Contains(specparams.Search))&& 
     (specparams.Brands.Count == 0 || specparams.Brands.Contains(x.Brand)) &&
        (specparams.Types.Count == 0 || specparams.Types.Contains(x.Type))
    )
    {
        ApplyPaging((specparams.PageSize * (specparams.PageIndex - 1)), specparams.PageSize);
        switch (specparams.Sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(x => x.Price);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;
        }
    }
}
