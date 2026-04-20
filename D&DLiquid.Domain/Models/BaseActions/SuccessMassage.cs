using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Models.BaseActions
{
    public class SuccessMassage
    {
        public static string Deleted(string entity, int id) => $"{entity} with id={id} deleted.";
    }
}
