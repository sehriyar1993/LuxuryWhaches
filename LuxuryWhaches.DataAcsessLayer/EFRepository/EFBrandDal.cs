using LuxuryWhaches.DataAcsessLayer.Abstract;
using LuxuryWhaches.DataAcsessLayer.Repository;
using LuxuryWhaches.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.DataAcsessLayer.EFRepository
{
	public class EFBrandDal:GenericRepository<Brand>, IBrandDal
	{
	}
}
