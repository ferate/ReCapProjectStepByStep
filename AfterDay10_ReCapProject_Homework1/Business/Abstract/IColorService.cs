using Core.Utilities;
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
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(Expression<Func<Color,bool>> filter);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);

    }
}
