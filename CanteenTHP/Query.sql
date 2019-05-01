ALTER VIEW v_EmployeeInfoCurrent
AS
WITH
   cte1 AS (
   SELECT C.EmpID, C.CompanyKey, Rc.CompanyName
   FROM tbEmp_Company C
	INNER JOIN (
		SELECT EmpID
			,DateChange = MAX(DateChange)
		FROM tbEmp_Company
		GROUP BY EmpID
		) AS CM ON C.EmpID = CM.EmpID
		AND C.DateChange = CM.DateChange
	LEFT JOIN tbRef_Company Rc ON Rc.CompanyKey = C.CompanyKey
   ),
   cte2 AS (
   SELECT D.EmpID, D.DepKey, Rd.DepName
   FROM tbEmp_Department D
	INNER JOIN (
		SELECT EmpID
			,DateChange = MAX(DateChange)
		FROM tbEmp_Department
		GROUP BY EmpID
		) AS DM ON D.EmpID = DM.EmpID
		AND D.DateChange = DM.DateChange
	LEFT JOIN tbRef_Department Rd ON Rd.DepKey = D.DepKey
   ),
   cte3 AS (
   SELECT M.EmpID, M.IsManager
   FROM tbEmp_Manager M
	INNER JOIN (
		SELECT EmpID
			,DateChange = MAX(DateChange)
		FROM tbEmp_Manager
		GROUP BY EmpID
		) AS MM ON M.EmpID = MM.EmpID
		AND M.DateChange = MM.DateChange
   ),
   cte4 AS (
   SELECT T.EmpID, T.CanTeenID, Rt.CanteenName
   FROM tbEmp_Canteen T
	LEFT JOIN (
		SELECT EmpID
			,DateChange = MAX(DateChange)
		FROM tbEmp_Canteen
		GROUP BY EmpID
		) AS TM ON T.EmpID = TM.EmpID
		AND T.DateChange = TM.DateChange
	LEFT JOIN tbRef_Canteen Rt ON Rt.CanteenID = T.CanteenID
   ),
   cte5 AS (
   SELECT CC.EmpID, CC.CostCenter
   FROM tbEmp_CostCenter CC
	LEFT JOIN (
		SELECT EmpID
			,DateChange = MAX(DateChange)
		FROM tbEmp_CostCenter
		GROUP BY EmpID
		) AS CCM ON CC.EmpID = CCM.EmpID
		AND CC.DateChange = CCM.DateChange
   )
SELECT E.*
	,C.CompanyKey
	,C.CompanyName
	,D.DepKey
	,D.DepName
	,M.IsManager
	,T.CanteenID
	,T.CanteenName
	,CC.CostCenter
FROM tbEmployee E
-- Company
LEFT JOIN cte1 C ON E.EmployeeID = C.EmpID
-- Department
LEFT JOIN cte2 D ON E.EmployeeID = D.EmpID
-- Manager
LEFT JOIN cte3 M ON E.EmployeeID = M.EmpID
-- Canteen
LEFT JOIN cte4 T ON E.EmployeeID = T.EmpID
-- CostCenter
LEFT JOIN cte5 CC ON E.EmployeeID = CC.EmpID

GO