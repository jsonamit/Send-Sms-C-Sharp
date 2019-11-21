<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SendSms.aspx.cs" Inherits="SendSms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-control.myclass {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-4 col-md-offset-1">
            <asp:Label runat="server" ID="lblCourses" Text="Category"></asp:Label>
        </div>
            <div class="col-md-4">
                 <asp:Label runat="server" ID="Label1" Text="Visitor and Users"></asp:Label>
            </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-1">
            <div class="form-group">
                
                <asp:DropDownList ID="ddlCategory" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
              
                    <asp:ListItem Text="----Select----" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Visitor" Value="Visitor"></asp:ListItem>
                    <asp:ListItem Text="Users" Value="Users"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
     
        <div class="col-md-4">
            <div class="form-group">

               
                <asp:DropDownCheckBoxes ID="DropDownCheckBoxes" AutoPostBack="true" Height="50px" CssClass="form-control myclass" runat="server" UseSelectAllNode="false" OnSelectedIndexChanged="DropDownCheckBoxes_SelectedIndexChanged" >
                    <Style SelectBoxWidth="200" DropDownBoxBoxWidth="180" DropDownBoxBoxHeight="150" />

                </asp:DropDownCheckBoxes>
                &nbsp;
                                 
                            <asp:ExtendedRequiredFieldValidator ID="ExtendedRequiredFieldValidator1" runat="server" ControlToValidate="DropDownCheckBoxes" ErrorMessage="Required" ForeColor="Red"></asp:ExtendedRequiredFieldValidator>
            </div>
            <asp:Label runat="server" ID="lblRoom" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <div class="row" style="margin-top: 20px;">
        <div class="col-md-6 col-md-offset-1">
            <asp:TextBox runat="server" ID="txtMessege" placeholder="Massege" CssClass="form-control" TextMode="MultiLine" Rows="10" cols="10"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 23px;">
        <div class="col-md-3 col-md-offset-1">
            <asp:Button runat="server" ID="btnSendSms" Text="Send Sms" CssClass="btn btn-block btn-primary" OnClick="btnSendSms_Click" />
        </div>
    </div>

</asp:Content>

