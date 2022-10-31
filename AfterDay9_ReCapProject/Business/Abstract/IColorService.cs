using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(Expression<Func<Color,bool>> filter);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);

    }
}
