using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Models.BaseActions
{
    public class SuccessMassage
    {
        public static string Deleted(string entity, int id) => $"{entity} with id={id} deleted.";
        public static string Created(string entity, int id) => $"{entity} with id ={id} created";
        public static string Edited(string entity, int id) => $"{entity} with id ={id} edited";
        public static string GetById(string entity, int id) => $"{entity} with id={id} retrieved.";
        public static string GetAll(string entity) => $"All {entity} retrieved.";
    }
}
