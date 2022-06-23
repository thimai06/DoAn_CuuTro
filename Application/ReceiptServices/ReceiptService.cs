using Common.ViewModel.ReceiptViewModel;

using Models.BaseRepository;
using Models.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ReceiptServices
{
    public class ReceiptService : IReceiptService
    {
        private readonly IRepository _repository;

        public ReceiptService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ReliefReceipt(ReceiptRequest receiptRequset, List<ReceiptDetailRequest> details)
        {
            var receipt = new Receipt()
            {
                ID_relieft = receiptRequset.RelieftId,
                Date = DateTime.Now,
                Nguoitang = receiptRequset.Name,
                Details_receipt = new List<Details_receipt>()
            };
           
            if(details != null && details.Any())
            {
                foreach (var request in details)
                {
                    if(receipt.Details_receipt.Any(x => x.ID_product == request.ProductId))
                    {
                        var detail = receipt.Details_receipt.First(x => x.ID_product == request.ProductId);
                        detail.Quantity += request.Quantities;
                    }
                    else
                    {
                        var detail = new Details_receipt()
                        {
                            ID_receipt = receipt.ID_receipt,
                            ID_product = request.ProductId,
                            Quantity = request.Quantities,
                        };
                        receipt.Details_receipt.Add(detail);
                    }
                }
            }
            _repository.Add(receipt);
            await _repository.SaveChangesAsync();
        }
    }
}
