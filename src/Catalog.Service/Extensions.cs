using Catalog.Service.DataTransferObjects;
using Catalog.Service.Entities;

namespace Catalog.Service
{
    public static class Extensions
    {
        public static ItemDataTransfer AsDataTransfer(this Item item)
        {
            return new ItemDataTransfer(item.Id, item.Name, item.Description, item.Available, item.Price, item.AddingDate);
        }
    }
}