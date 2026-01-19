using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}
