using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Interfaces
{
    public interface IRemoveTodoItem
    {
        void RemoveItem(int id);
    }
}
