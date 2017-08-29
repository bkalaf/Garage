Imports System.Configuration

Namespace SIUINS.Utils
    '26-FEB-2004, PAL, don't like having to type this every time. Put in constants class so no typing mistakes
    Public Class Consts
        Public Const LOGIN_ID As String = "ProducerID"
        Public Const LOGIN_FIRST As String = "ProducerFirstName"
        Public Const LOGIN_LAST As String = "ProducerLastName"
        Public Const LOGIN_MID As String = "ProducerMI"
        Public Const LOGIN_PHONE As String = "ProducerPhone"
        Public Const LOGIN_EMAIL As String = "ProducerEmail"
        Public Const LOGIN_TYPE As String = "ProducerTypeID"
        Public Const LOGIN_DESC As String = "ProducerTypeDescr"
        Public Const LOGIN_DEPT As String = "ProducerDept"

        Public Const CustID As String = "CustID"
        Public Const ID As String = "AgencyID"
        Public Const NAME As String = "AgencyName"
        Public Const ADDR1 As String = "AgencyAddr1"
        Public Const ADDR2 As String = "AgencyAddr2"
        Public Const CITY As String = "AgencyCity"
        Public Const STATE As String = "AgencyState"
        Public Const ZIP As String = "AgencyZip"
        Public Const CTRY As String = "AgencyCountry"
        Public Const PHONE As String = "AgencyPhone"
        Public Const FAX As String = "AgencyFax"

        Public Const SIGPAD As String = "SignaturePad"
        Public Const CUST_BIZ As String = "CustomerBusiness"
        Public Const DRAFT As String = "DraftAgent"
        Public Const DRAFT_TYPE As String = "DraftType"
        Public Const ACCU_AUTO As String = "AccuAutoFilename"

        Public Const REF_CASH As String = "RefCash"
        Public Const REF_CASH_TYPE As String = "RefCashType"

        Public Const WAIT_TIMER As String = "WaitTimer"
        Public Const WAIT_FOUND As String = "WaitFound"

        Public Const PA_BIZ_ENABLED As String = "PABusinessEnabled"

        Public Const MAIL_SERVER As String = "mail.siuins.com"

        'for the Customer Business array indices.
        Public Enum BizType
            PersonalAuto = 0
            PersonalProperty = 1
            PropertyCasualty = 2
            Brokerage = 3
            CommercialAuto = 4
            Marine = 5
        End Enum

    End Class

End Namespace