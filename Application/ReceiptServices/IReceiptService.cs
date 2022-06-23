using Common.ViewModel.ReceiptViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.ReceiptServices
{
    public interface IReceiptService
    {
        Task ReliefReceipt(ReceiptRequest receiptRequset, List<ReceiptDetailRequest> details);
    }
}
