using LuxuryWhaches.DataAcsessLayer.Abstract;
using LuxuryWhaches.DataAcsessLayer.Repository;
using LuxuryWhaches.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.DataAcsessLayer.EFRepository
{
    public class EFColorDal : GenericRepository<ProductColor>, IColorDAl
    {
    }
}
