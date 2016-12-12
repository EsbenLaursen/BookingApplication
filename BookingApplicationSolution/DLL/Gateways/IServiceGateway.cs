using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Gateways
{
    public interface IServiceGateway<T>
    {
        //Create
        T Create(T t);

        //Read
        T Read(int id);
        List<T> Read();

        //Update
        T Update(T t);

        //Delete
        bool Delete(int id);
    }
}
