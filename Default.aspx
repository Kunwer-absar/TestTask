<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"
    Theme="Default" %>

<%@ Register Assembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="System.Web.UI.HtmlControls" TagPrefix="cc2" %>
<%@ Register Assembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="System.Web.UI" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v7.3" Namespace="DevExpress.Web.ASPxDataView"
    TagPrefix="dxdv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v7.3" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v7.3" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v7.3" Namespace="DevExpress.Web.ASPxTabControl"
    TagPrefix="dxtc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank</title>

    <script language="javascript" type="text/javascript">

        String.prototype.Trim = function () { return this.replace(/^\s+|\s+$/g, ''); }

        function ValidateFields() {
            var retValue = true;

            var ctrl2 = document.getElementById("pcBank_txtAccountNo");
            var valid2 = document.getElementById("pcBank_lblValidAccountNo");

            var txtValue2 = ctrl2.value;
            if (txtValue2.Trim() == "") {
                valid2.style.visibility = "visible";
                retValue = false;
            }
            else {
                valid2.style.visibility = "hidden";
            }

            return retValue;

        }

        function AllowOnlyNumeric() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;

            // Verify if the key entered was a numeric character (0-9)
            if ((key > 47 && key < 58))
                // If it was, then allow the entry to continue
                return;
            else
                // If it was not, then dispose the key and continue with entry
                window.event.returnValue = null;
        }

        function ValidatePageNumber() {
            var retValue = true;

            var ctrl = document.getElementById("pcBank_txtGotoPage");
            var valid = document.getElementById("pcBank_lblValidGotoPage");

            var txtValue = ctrl.value;
            if (txtValue.Trim() == "") {
                valid.style.visibility = "visible";
                retValue = false;
            }
            else {
                valid.style.visibility = "hidden";
            }

            return retValue;
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tbl" cellpadding="2" cellspacing="2" width="100%">
                <tr class="tblrow">
                    <td colspan="3" class="head1" style="height: 23px">
                        TestTask</td>
                </tr>
                <tr class="tblrow">
                    <td colspan="3">
                        <asp:Label ID="lblMsg" runat="server" CssClass="label"></asp:Label></td>
                </tr>
                </table>
            <table class="tbl" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                <td class="head4small" colspan="3">
                    Customer Details
                </td>
                    
                </tr>
                <tr>
                    <td class="heading">
                        Customer Name
                    </td>
                    <td>
                        <dxe:ASPxTextBox ID="txtcustomerName" runat="server">

                        </dxe:ASPxTextBox>
                         <asp:RequiredFieldValidator ID="rfvCustomername" runat="server" ControlToValidate="txtcustomerName"
                          CssClass="error" Display="Dynamic" ErrorMessage="Please Enter Customer Name" ValidationGroup="vgCustomer">
                        </asp:RequiredFieldValidator>  
                    </td>
                </tr>
                <tr>
                    <td class="heading">
                        Customer Address
                    </td>
                    <td>
                        <dxe:ASPxTextBox ID="txtcustomeraddress" runat="server">

                        </dxe:ASPxTextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcustomeraddress"
                          CssClass="error" Display="Dynamic" ErrorMessage="Please Enter Customer Address" ValidationGroup="vgCustomer"> 
                        </asp:RequiredFieldValidator>  
                    </td>

                </tr>
                <tr>
                    <dxe:ASPxButton ID="btnSaveCustomer" runat="server" Text="Save Customer" style="max-height:14px" align="center" causesValidation="true" ValidationGroup="vgCustomer" >
                         
                       </dxe:ASPxButton>
                </tr>
                </table>
              <table class="tbl" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                <td class="head4small" colspan="3">
                    Add Customer Orders
                </td>
                    
                </tr>
                <tr>
                    <td class="heading">
                        Customer
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCustomerName" runat="server">

                        </asp:DropDownList>
                           
                    </td>
                </tr>
                <tr>
                    <td class="heading">
                        Order Discription
                    </td>
                    <td>
                        <dxe:ASPxTextBox ID="OrderDiscription" runat="server">

                        </dxe:ASPxTextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="OrderDiscription" ValidationGroup="vgOrder"
                          CssClass="error" Display="Dynamic" ErrorMessage="Please Enter Order Discription">
                        </asp:RequiredFieldValidator>  
                    </td>
                </tr>
                   <tr>
                    <td class="heading">
                        Order Amount
                    </td>
                    <td>
                        <dxe:ASPxTextBox ID="txtAmount" runat="server" >

                        </dxe:ASPxTextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="txtAmount" ValidationGroup="vgOrder"
                          CssClass="error" Display="Dynamic" ErrorMessage="Please Enter Order Discription">
                        </asp:RequiredFieldValidator>  
                        <asp:RegularExpressionValidator  ID="revOrderAmount" runat="server" ControlToValidate="txtAmount" ValidationGroup="vgOrder"
                        ValidationExpression="[0-9]*"
                           CssClass="error" Display="Dynamic"   ErrorMessage="Invalid input. Please input numbers">
                        </asp:RegularExpressionValidator >
                    </td>
                </tr>
                  <tr>
                      
                           <dxe:ASPxButton ID="btnsave" runat="server" Text="Save Order" style="max-height:14px" align="center" causesValidation="true" ValidationGroup="vgOrder" >
                         
                       </dxe:ASPxButton>
                      
                  </tr>
                </table>

            <table class="tbl" cellpadding="2" cellspacing="2" width="100%">
                <tr>

                </tr>
                <tr class="tblrow">
                    <td class="head4small" colspan="3">
                       
                                        <asp:GridView ID="gvList" runat="server" Width="940px"  HorizontalAlign="Center"
    AutoGenerateColumns="false"   AllowPaging="True" CssClass="table table-hover table-striped">
                                            <Columns>
                                                 
                    <asp:BoundField DataField ="CustomerName" HeaderText ="Customer Name" />    
                    <asp:BoundField DataField ="CustomerAddress"  HeaderText ="Customer Address" />
                    <asp:BoundField DataField ="OrderNo"  HeaderText ="Order Number" />
                                                 <asp:BoundField DataField ="OrderDate" DataFormatString = "{0:dd/MM/yyyy}"  HeaderText ="Order Date" />
                    <asp:BoundField DataField ="OrderDiscription" HeaderText ="Order Description" />
                    <asp:BoundField DataField ="OrderAmount" DataFormatString="{0:C2}" HeaderText ="Order Amount" />


                                                    
                                            </Columns>
                                        
                                     </asp:GridView>
                   
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
