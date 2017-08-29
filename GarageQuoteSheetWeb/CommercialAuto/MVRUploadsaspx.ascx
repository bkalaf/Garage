<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MVRUploadsaspx.ascx.vb"
    Inherits="MVRUploadsaspx" %>
<script type="text/javascript">
    function CheckFile(Cntrl) {
        debugger;
        var file = document.getElementById(Cntrl.id);
        var len = file.value.length;
        var ext = file.value;
        if (ext.substr(len - 3, len) != "pdf") {
            alert("Please select a pdf file ");
            Clear(Cntrl);
        }
    }

    function Clear(Cntrl) {
        //Reference the FileUpload and get its Id and Name.
        var fileUpload = document.getElementById(Cntrl.id);
        var id = fileUpload.id;
        var name = fileUpload.name;

        //Create a new FileUpload element.
        var newFileUpload = document.createElement("INPUT");
        newFileUpload.type = "FILE";

        //Append it next to the original FileUpload.
        fileUpload.parentNode.insertBefore(newFileUpload, fileUpload.nextSibling);

        //Remove the original FileUpload.
        fileUpload.parentNode.removeChild(fileUpload);

        //Set the Id and Name to the new FileUpload.
        newFileUpload.id = id;
        newFileUpload.name = name;
        return false;
    }


    $('INPUT[type="file"]').change(function (e) {
        var ext = $(this).val().split('.').pop().toLowerCase(); //this.value.match(/\.(.+)$/)[1];
        switch (ext) {
            case 'pdf':
            case 'doc':
            case 'docx':
                // $('#uploadButton').attr('disabled', false);
                break;
            default:
                alert('Please upload only pdf,doc and docx files.');
                //this.value = '';
                e.preventDefault();
                var fu = $(this);
                fu.replaceWith(fu.val('').clone(true));
                //this.replaceWith(this.value('').clone(true));
        }
    });

</script>
<asp:UpdatePanel ID="UpdMVRUploads" runat="server">
    <ContentTemplate>
        <fieldset>
            <legend><strong>MVR Uploads</strong></legend>
            <table style="width: 680px; height: 50px;" border="0" cellpadding="0" cellspacing="0"
                class="fieldset">
                <tr>
                    <td colspan="2" width="100%">
                        <table width="100%">
                            <tr>
                                <td style="text-align: left;">
                                    <b>If this is a “For Hire Trucking” quote request, please upload MVRs below.</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:Label ID="lblFile1" runat="server"></asp:Label>
                                                <asp:FileUpload ID="upl1" runat="server" />
                                                <asp:RegularExpressionValidator ID="revupload1" Display="Dynamic" runat="server"
                                                    ErrorMessage="Only PDF files are allowed!" ValidationGroup="Upload" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                    ControlToValidate="upl1" CssClass="text-red" Text="*"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:Label ID="lblFile2" runat="server"></asp:Label>
                                                <asp:FileUpload ID="upl2" runat="server" />
                                                <asp:RegularExpressionValidator ID="revupload2" Display="Dynamic" runat="server"
                                                    ErrorMessage="Only PDF files are allowed!" ValidationGroup="Upload" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                    ControlToValidate="upl2" CssClass="text-red" Text="*"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:Label ID="lblFile3" runat="server"></asp:Label>
                                                <asp:FileUpload ID="upl3" runat="server" />
                                                <asp:RegularExpressionValidator ID="revupload3" runat="server" Display="Dynamic"
                                                    ErrorMessage="Only PDF files are allowed!" ValidationGroup="Upload" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                    ControlToValidate="upl3" CssClass="text-red" Text="*"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:Label ID="lblFile4" runat="server"></asp:Label>
                                                <asp:FileUpload ID="upl4" runat="server" />
                                                <asp:RegularExpressionValidator ID="revupload4" runat="server" Display="Dynamic"
                                                    ErrorMessage="Only PDF files are allowed!" ValidationGroup="Upload" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                    ControlToValidate="upl4" CssClass="text-red" Text="*"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:Label ID="lblFile5" runat="server"></asp:Label>
                                                <asp:FileUpload ID="upl5" runat="server" />
                                                <asp:RegularExpressionValidator ID="revupload5" runat="server" Display="Dynamic"
                                                    ErrorMessage="Only PDF files are allowed!" Text="*" ValidationGroup="Upload"
                                                    ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                                                    ControlToValidate="upl5" CssClass="text-red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:ValidationSummary ID="valsumuploads" runat="server" ValidationGroup="Upload"
                                        ShowMessageBox="true" ShowSummary="true" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
    </ContentTemplate>
</asp:UpdatePanel>
