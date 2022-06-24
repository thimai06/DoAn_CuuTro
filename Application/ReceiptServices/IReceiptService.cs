using Common.ViewModel.ReceiptViewModel;
using Models.EF;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.ReceiptServices
{
    public interface IReceiptService
    {
        Task ReliefReceipt(ReceiptRequest receiptRequset, List<ReceiptDetailRequest> details);
        Task<List<Receipt>> ListReceipt(int id);
    }
}
