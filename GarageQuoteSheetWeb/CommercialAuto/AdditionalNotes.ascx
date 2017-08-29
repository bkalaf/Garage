<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdditionalNotes.ascx.vb" Inherits="UserControl947.AdditionalNotes" %>
<script language="javascript" type="text/javascript">
 

function DoNotCallIsAlphaNumeric(bolAllowBlank)

{ 


if (bolAllowBlank == true)

{

if (!(event.keyCode >= 65 && event.keyCode <= 90) && !(event.keyCode >= 97 && event.keyCode <= 122) && !(event.keyCode >= 48 && event.keyCode <= 59) && (event.keyCode != 32)&& (event.keyCode != 45)&& (event.keyCode != 46))

{

event.keyCode=0;

}

}

else

{

if (!(event.keyCode >= 65 && event.keyCode <= 90) && !(event.keyCode >= 97 && event.keyCode <= 122) && !(event.keyCode >= 48 && event.keyCode <= 59))

{

event.keyCode=0;

}


}

} 

</script>





							<fieldset>
                                <legend><strong>Additional Notes</strong></legend>
                                <table style="width: 680px; " border="0" cellpadding="0" cellspacing="0"
                                    class="fieldset">
                                   
                                                      
                                                
                                                <tr>
                                                    <td style="width: 360px" align="left">
                                                        <span style="color: #ff0000">&nbsp;&nbsp;</span> Additional Notes:&nbsp;<br/>&nbsp;</td>
                                                   
                                                    <td>
                                                        <asp:TextBox ID="txtmultadditionalnotes" runat="server" TextMode="MultiLine" Height="60px"
                                                            Width="300px" MaxLength="100" TabIndex="150"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                               
                                               
                                               
                                            </table>
                                        
                                        
                            </fieldset>
				
