<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bus_type_registration.aspx.cs" Inherits="busrental.admin.bus_type_registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middlecontent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="bustype">
<asp:GridView ID="dgvbustype" DataKeyNames="BusTypeNo,BusTypeName" runat="server" AutoGenerateColumns="false"
            CssClass="Gridview" HeaderStyle-BackColor="#61A6F8" ShowFooter="true" HeaderStyle-Font-Bold="true"
            HeaderStyle-ForeColor="White" OnRowCancelingEdit="dgvbustype_RowCancelingEdit"
            OnRowDeleting="dgvbustype_RowDeleting" OnRowEditing="dgvbustype_RowEditing" OnRowUpdating="dgvbustype_RowUpdating"
            OnRowCommand="dgvbustype_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="i/update.png"
                            ToolTip="Update" Height="20px" Width="20px" />
                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/admin/i/cancel.png"
                            ToolTip="Cancel" Height="20px" Width="20px" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="i/edit.png"
                            ToolTip="Edit" Height="20px" Width="20px" />
                        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                            ImageUrl="i/delete.png" ToolTip="Delete" Height="20px" Width="20px" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="i/new.png"
                            CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new User" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BusTypeName">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtbustypename" runat="server" Text='<%#Eval("BusTypeName") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblbustypename" runat="server" Text='<%#Eval("BusTypeName") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtftrbustypename" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvbustypename" runat="server" ControlToValidate="txtftrbustypename"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Seat">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtseat" runat="server" Text='<%#Eval("Seat") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblseat" runat="server" Text='<%#Eval("Seat") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtftrseat" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvseat" runat="server" ControlToValidate="txtftrseat"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Color">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtcolor" runat="server" Text='<%#Eval("Color") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcolor" runat="server" Text='<%#Eval("Color") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtftrcolor" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvcolor" runat="server" ControlToValidate="txtftrcolor"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</div> 
</asp:Content>
