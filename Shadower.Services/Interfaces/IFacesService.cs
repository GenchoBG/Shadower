using System;
using System.Collections.Generic;
using System.Text;
using Shadower.Data.Models;

namespace Shadower.Services.Interfaces
{
    public interface IFacesService
    {
        List<Face> GetFound();
    }
}
