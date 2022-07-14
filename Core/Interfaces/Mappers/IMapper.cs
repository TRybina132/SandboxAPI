using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Mappers
{
    public interface IMapper<TEntity, TViewModel>
    {
        TEntity Map(TViewModel viewModel);
        TViewModel Map(TEntity viewModel);
    }
}
