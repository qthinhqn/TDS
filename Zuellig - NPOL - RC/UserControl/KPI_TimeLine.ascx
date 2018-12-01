<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KPI_TimeLine.ascx.cs" Inherits="NPOL.UserControl.KPI_TimeLine" %>

<link href='https://fonts.googleapis.com/css?family=Titillium+Web:400,200,300,600,700' rel='stylesheet' type='text/css'>
<link href="css/timeline.css" rel="stylesheet">
<%--<button id="toggleButton">Toggle</button>--%>

<ul class="timeline" id="timeline">
  <li class="li complete" ID ="liStart" runat="server">
    <div class="timestamp">
       <span class="author">
           <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_Timeline,lb1_Detail %>"></asp:Label>
       </span>
      <span class="date">
          <asp:Label ID="lbDateStart" runat="server" Text=""></asp:Label>
      </span>
    </div>
    <div class="status">
      <h4> 
          <asp:Label ID="Label3" runat="server" Text="<%$Resources:KPI_Timeline,lb1_title %>"></asp:Label>
      </h4>
    </div>
  </li>
  <li class="li complete" ID ="liReview_First" runat="server">
    <div class="timestamp">
      <span class="author">
          <asp:Label ID="Label2" runat="server" Text="<%$Resources:KPI_Timeline,lbReview_First %>"></asp:Label>
      </span>
      <span class="date">
          <asp:Label ID="lbDateReview_First" runat="server" Text=""></asp:Label>
      </span>
    </div>
    <div class="status">
      <h4> 
          <asp:Label ID="Label8" runat="server" Text="<%$Resources:KPI_Timeline,lbReviewFirst_title %>"></asp:Label>
      </h4>
    </div>
  </li>
  <li class="li complete" ID ="liReview" runat="server">
    <div class="timestamp">
      <span class="author">
          <asp:Label ID="Label4" runat="server" Text="<%$Resources:KPI_Timeline,lb2_Detail %>"></asp:Label>
      </span>
      <span class="date">
          <asp:Label ID="lbDateReview" runat="server" Text=""></asp:Label>
      </span>
    </div>
    <div class="status">
      <h4> 
          <asp:Label ID="Label6" runat="server" Text="<%$Resources:KPI_Timeline,lb2_title %>"></asp:Label>
      </h4>
    </div>
  </li>
  <li class="li complete" ID ="liApproval" runat="server">
    <div class="timestamp">
      <span class="author">
          <asp:Label ID="Label7" runat="server" Text="<%$Resources:KPI_Timeline,lb3_Detail %>"></asp:Label>
      </span>
      <span class="date">
          <asp:Label ID="lbDateApproval" runat="server" Text=""></asp:Label>
      </span>
    </div>
    <div class="status">
      <h4> 
          <asp:Label ID="Label9" runat="server" Text="<%$Resources:KPI_Timeline,lb3_title %>"></asp:Label>
      </h4>
    </div>
  </li>
  <li class="li" ID ="liEnd" runat="server" style="display:none">
    <div class="timestamp">
      <span class="author">
          <asp:Label ID="Label12" runat="server" Text="<%$Resources:KPI_Timeline,lb4_Detail %>"></asp:Label>
      </span>
      <span class="date">
          <asp:Label ID="lbDateEnd" runat="server" Text=""></asp:Label>
      </span>
    </div>
    <div class="status">
      <h4> 
          <asp:Label ID="Label10" runat="server" Text="<%$Resources:KPI_Timeline,lb4_title %>"></asp:Label>
      </h4>
    </div>
  </li>
 </ul>      

