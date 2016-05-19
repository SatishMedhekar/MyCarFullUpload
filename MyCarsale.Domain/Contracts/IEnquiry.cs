using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Models;


namespace MyCarsale.Domain.Contracts
{
    public interface IEnquiry
    {

        List<Enquiry> GetEnquiryReport(int InquiryID);

        void SubmitEnquiry(Enquiry CustomerInquiry);
        EnquiryCollection GetEnquiryList();



    }
}
