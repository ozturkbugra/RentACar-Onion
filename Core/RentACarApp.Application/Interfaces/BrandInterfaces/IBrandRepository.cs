using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Interfaces.BrandInterfaces
{
    public interface IBrandRepository
    {
        string MaxCarByBrand();
        int BrandCount();
    }
}
