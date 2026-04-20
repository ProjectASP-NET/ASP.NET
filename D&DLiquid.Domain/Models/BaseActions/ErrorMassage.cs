using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Models.BaseActions
{
    public class ErrorMassage
    {
        public static string NotFound(string entity, int id) => $"{entity} with id={id} not found.";
    }
}
