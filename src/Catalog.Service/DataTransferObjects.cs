using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Service.DataTransferObjects
{
    public record ItemDataTransfer(Guid Id, string Name, string Description, bool Available, decimal Price, DateTime AddingDate);

    public record CreateItemDataTransfer([Required] string Name, [MaxLength(100)] string Description, bool Available, [Range(0, 20)] decimal Price);

    public record UpdateItemDataTransfer([Required] string Name, [MaxLength(100)] string Description, bool Available, [Range(0, 20)] decimal Price);


}