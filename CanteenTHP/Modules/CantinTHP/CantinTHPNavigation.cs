using Serenity.Navigation;
using MyPages = Canteen.CantinTHP.Pages;


[assembly: NavigationMenu(4001, "CantinTHP", icon: "fa-empire")]


[assembly: NavigationMenu(int.MaxValue, "CantinTHP/Info", icon: "fa-info")]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Employee", typeof(MyPages.TbEmployeeController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Canteen", typeof(MyPages.TbEmpCanteenController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Card", typeof(MyPages.TbEmpCardController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Company", typeof(MyPages.TbEmpCompanyController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Cost Center", typeof(MyPages.TbEmpCostCenterController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Department", typeof(MyPages.TbEmpDepartmentController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Manager", typeof(MyPages.TbEmpManagerController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Shift", typeof(MyPages.TbEmpShiftController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Day Off", typeof(MyPages.TbEmpDayOffController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Info/Tb Emp Type", typeof(MyPages.TbEmpTypeController), icon: null)]


[assembly: NavigationMenu(int.MaxValue, "CantinTHP/Registration", icon: "fa-registered")]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Registration/Pre Partner Meal", typeof(MyPages.TbPrePartnerMealController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Registration/Pre Regist Meal", typeof(MyPages.TbPreRegistMealController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Registration/Emp Partner Meal", typeof(MyPages.TbEmpPartnerMealController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Registration/Emp Regist Meal", typeof(MyPages.TbEmpRegistMealController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Registration/Emp Cost Temp", typeof(MyPages.TbEmpCostTempController), icon: null)]


[assembly: NavigationMenu(int.MaxValue, "CantinTHP/Generals", icon: "fa-building")]

[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Reason for Adjust", typeof(MyPages.TbRefReason4AdjustController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Registration Type", typeof(MyPages.TbRefRegistrationTypeController), icon: null)]

[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Meal Cost", typeof(MyPages.TbMealCostController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Print Ticket", typeof(MyPages.TbPrintTicketController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Break Time", typeof(MyPages.TbRefBreakTimeController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Canteen", typeof(MyPages.TbRefCanteenController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Company", typeof(MyPages.TbRefCompanyController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Cost Center", typeof(MyPages.TbRefCostCenterController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Department", typeof(MyPages.TbRefDepartmentController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Emp Type", typeof(MyPages.TbRefEmpTypeController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Leave Type", typeof(MyPages.TbRefLeaveTypeController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Menu", typeof(MyPages.TbRefMenuController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Tb Ref Shift", typeof(MyPages.TbRefShiftController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/Generals/Zk Tbl Record", typeof(MyPages.ZkTblRecordController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "CantinTHP/V Employee Info Current", typeof(MyPages.VEmployeeInfoCurrentController), icon: null)]