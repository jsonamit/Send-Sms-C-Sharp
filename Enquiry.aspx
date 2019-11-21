<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Enquiry.aspx.cs" Inherits="Enquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <asp:Panel runat="server" ID="PanelEntry">
       <div class="row">
           <div class="col-md-2 pull-right" >
            <asp:Button runat="server" ID="btnViewEnquiry" Text="View Enquiry" CssClass="btn btn-block btn-success" OnClick="btnViewEnquiry_Click" />
        </div>
       </div>
    <div class="row">
        <div class="col-md-3 col-md-offset-1">
            <div class="form-group">
                <asp:Label runat="server" ID="lblName" Text="Name"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtName" placeholder="Name"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <asp:Label runat="server" ID="lblMobile" Text="Mobile"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtmobile" placeholder="Mobile"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <asp:Label runat="server" ID="lblEmail" Text="Email"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="Email"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row" style="margin-top:20px;">
        <div class="col-md-3 col-md-offset-1">

            <div class="form-group">
                <asp:Label runat="server" ID="lblCourses" Text="Courses"></asp:Label>
              <%--  <asp:TextBox runat="server" CssClass="form-control" ID="txtCourses" placeholder="Courses"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlCourses" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Select Courses" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Rajasthan Judicial Services" Value="Rajasthan Judicial Services"></asp:ListItem>
                        <asp:ListItem Text="Higher Judicial Services" Value="Higher Judicial Services"></asp:ListItem>
                        <asp:ListItem Text="Assistant Public Prosecuter" Value="Assistant Public Prosecuter"></asp:ListItem>
                        <asp:ListItem Text="Junier Law Officer" Value="Junier Law Officer"></asp:ListItem>
                        <asp:ListItem Text="Legal Officer" Value="Legal Officer"></asp:ListItem>
                    </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-3" style="margin-top: 23px;">
            <asp:Button runat="server" ID="btnEnquirySubmit" Text="Submit" CssClass="btn btn-block btn-primary" OnClick="btnEnquirySubmit_Click" />
        </div>
         
    </div>
     </asp:Panel>

     <asp:Panel runat="server" ID="PanelViewEnquiry" >
        <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                    <table class="table table-striped table-advance table-hover">
                        <tbody>
                            <tr>
                                <th  style="text-align:center"><i></i>Name</th>
                                <th  style="text-align:center"><i></i>Mobile</th>                             
                                <th  style="text-align:center"><i></i>Courses</th>  
                                 <th style="text-align:center"><i></i>Action</th>                               
                            </tr>
                            <asp:Repeater ID="RpViewEnquiry" runat="server" OnItemCommand="RpViewEnquiry_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 25%;text-align:center"><%#Eval("name") %></td>
                                        <td style="width: 25%;text-align:center"><%#Eval("mobile") %></td>                                      
                                        <td style="width: 25%;text-align:center"><%#Eval("courses") %></td>                                     
                                           <td style="width: 25%;text-align:center">
                                            <div class="btn-group">
                                                <asp:LinkButton class="btn btn-success" runat="server"  ID="btnAddmission" CommandArgument='<%#Eval("id") %>' CommandName="addmission"><i class="icon_check_alt2">Admission</i></asp:LinkButton>
                                               <%-- <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="delete" class="btn btn-danger"><i class="icon_close_alt2"></i></asp:LinkButton>--%>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </section>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

