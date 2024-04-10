using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.Domain.Enums
{
    public enum Status
    {
        New = 1,
        Apply,
        Applied, 
        Hold,
        SiteVisit,
        SentToApprove,
        Renegotiation,
        Approved,
        Rejected,
        Withdrawn,
        WithdrawnFromCompany,
        ReturnedForAdditionalCollateral,
        Canceled,
        SendToBoard,
        GeneratedApplication,
        GeneratedAgreement,
        CreditBureauCheck
    }
}
