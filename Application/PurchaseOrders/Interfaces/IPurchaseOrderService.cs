using Application.Common.Interfaces;
using Application.PurchaseOrders.DTOs;
using Domain.Entities;

namespace Application.PurchaseOrders.Interfaces
{
    public interface IPurchaseOrderService: IService<PurchaseOrder, CreatePurchaseOrderDto, UpdatePurchaseOrderDto>
    {

    }
}
