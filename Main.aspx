<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="admin_Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="col-sm-12">
        <div class="panel">
            <div class="panel-content">
                <div id="DivView">
                    <table id="responsive-table" class="data-table table table-striped table-hover responsive nowrap" cellspacing="0" width="100%">
                        <thead>

                            <tr>
                                <th>Name</th>
                                <th>Mobile</th>
                                <th>Email</th>
                               <%-- <th>Courses</th>--%>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpUsers" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("name") %></td>

                                        <td><%#Eval("mobile") %></td>
                                        <td><%#Eval("email") %></td>

                                       <%-- <td><%#Eval("Courses") %></td>--%>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

