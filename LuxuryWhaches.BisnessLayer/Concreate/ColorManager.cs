using LuxuryWhaches.BisnessLayer.Abstract;
using LuxuryWhaches.DataAcsessLayer.Abstract;
using LuxuryWhaches.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.BisnessLayer.Concreate
{
    public class ColorManager:IColorServices
    {
        IColorDAl _color;

        public ColorManager(IColorDAl color)
        {
            _color = color;
        }

        public void TDelete(ProductColor t)
        {
            _color.Delete(t);
        }

        public List<ProductColor> TGetAll()
        {
            return _color.GetAll(); 
        }

        public ProductColor TGetByID(int id)
        {
            return _color.GetByID(id);
        }

        public void TInsert(ProductColor t)
        {
            _color.Insert(t);
        }

        public List<ProductColor> TListForFilter(Expression<Func<ProductColor, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ProductColor t)
        {
            _color.Update(t);
        }
    }
}
