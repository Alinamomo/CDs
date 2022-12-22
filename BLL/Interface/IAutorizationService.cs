using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IAutorizationService
    {
        bool TryEnter(string login, string password);
        int GetCuttentAdmin();
    }
}
