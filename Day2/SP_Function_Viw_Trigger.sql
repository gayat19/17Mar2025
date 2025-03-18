--Select all products
select * from Products
 

--select products that are priced more than 20/unit
SELECT * FROM Products Where unitPrice > 20;
 
--select the products which have a as second letter
select * from Products
where ProductName like '_a%'

--print the count of the products that are discontinued
select count(*) as discontinued_count from Products where Discontinued = 1

--print the number of products in each category
SELECT CategoryID, COUNT(*) AS ProductCount 
FROM Products 
GROUP BY CategoryID;

-- print the count of products for each supplier only if the product is 
--not discontinued
SELECT SupplierID, COUNT(*) AS ProductCount
FROM Products
WHERE Discontinued = 0 
GROUP BY SupplierID;
 


--print the number of products in each category where the price/unit is <40
--and the category has  more than 3 products
Select CategoryID, Count(*) as Category_Count  
from products  where Unitprice<40  
group by CategoryID 
Having Count(*)>3;
 

--print the products which are priced more than the average price
--of all the products from category 2
SELECT * FROM Products
WHERE UnitPrice > 
(SELECT AVG(UnitPrice) FROM Products WHERE CategoryID = 2);

--print the category name and the product name for every product
select c.CategoryName , p.ProductName 
from products p 
join Categories c 
on p.CategoryID = c.CategoryID


select * from Customers
--print the company name, product name for orders place by
-- customers from Mexico
SELECT c.CompanyName, p.ProductName
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od On od.OrderID = o.OrderID
JOIN Products p ON od.ProductID = p.ProductID
WHERE c.Country = 'Mexico';
--print the supplier name and the number of products he supplies
select CompanyName, count(ProductId) Number_Of_Products
from Suppliers s JOIN Products p
ON s.SupplierID = p.SupplierID
group by CompanyName



create procedure proc_FirstExample
as
begin
   print 'Hello World!!!'
end

execute proc_FirstExample

drop procedure proc_FirstExample

create procedure proc_FirstExample(@username nvarchar(20))
as
begin
   print 'Hello '+@username
end

execute proc_FirstExample 'Ramu'

select * from Categories
create proc proc_GetAllProductsFromCategory(@CName varchar(100))
as
begin
   declare @cid int
   set @cid = (select CategoryID from Categories where CategoryName = @CName)
   if(@cid>0)
   begin
      select * from Products where CategoryID = @cid
   end
   else
     print 'No products for the given category '+@Cname
end

proc_GetAllProductsFromCategory 'Beveraes'

--create a new database dbEmployeeManagement
--create a new table Employees -Id,Name, Age, DepartmentId
--create a new table Department -Id, Name, HOD
--create a new tabel Salary - Id, Basic, HRA, DA, Allownace
--create a new table EmployeeSalary - Id, EmploeeId, Date, SalaryID, Dedection, netpay


create database dbEmployeeManagement;

USE dbEmployeeManagement; 
create table Department(

		DeptID int PRIMARY KEY IDENTITY(1,1),

		DeptName varchar(20),

		HoD int

	);

	create table EmployeesData(

		EmpID int PRIMARY KEY IDENTITY(1,1),

		EmpName varchar(20),

		Age int,

		DeptID int,

		FOREIGN KEY (DeptID) REFERENCES Department(DeptID)

	);

	create table Salary(

		SalaryID int PRIMARY KEY IDENTITY(1,1),

		Basic decimal(10,2),

		HRA decimal(10,2),

		DA decimal(10,2),

		Allowance decimal(10,2)

	);

	create table EmployeeSalary(

		EmpSalaryID int PRIMARY KEY IDENTITY(1,1),

		EmpID int,

		[Date] date,

		SalaryID int,

		Deduction decimal(10,2),

		NetPay decimal(10,2),

		FOREIGN KEY (EmpID) REFERENCES EmployeesData(EmpID),

		FOREIGN KEY (SalaryID) REFERENCES Salary(SalaryID)

	);
 
Alter table Department
add constraint fk_HOD foreign key(HoD) references EmployeesData(EmpId)

sp_help  Department
--create procedure for inserting in to department Table
create proc proc_insertDepartment(@dname varchar(100),
@dhod int)
as
begin
   if(@dhod<=0)
      insert into Department(DeptName) values(@dname)
	else
	  insert into Department(DeptName,Hod) values(@dname,@dhod)
end
proc_insertDepartment 'HR',0

select * from Department



--create a procedure for inserting data in to employee table
create proc proc_InsertEmployee(@ename varchar(50), @eage int, @did int)
as
begin
   insert into EmployeesData(EmpName,Age,DeptID) values(@ename,@eage,@did)
end

--alter the above sp to check for valid department Id
alter proc proc_InsertEmployee(@ename varchar(50), @eage int, @did int)
as
begin
   declare @count int
   set @count = (select count(*) from department where DeptID = @did)
   if(@count>0)
		insert into EmployeesData(EmpName,Age,DeptID) values(@ename,@eage,@did)
   else 
      print 'Invalid department id'
end
proc_InsertEmployee 'Somu',24,3

alter proc proc_InsertEmployee(@ename varchar(50), @eage int, @did int)
as
begin
   declare @count int
   set @count = (select count(*) from department where DeptID = @did)
   Begin try
   if(@count>0)
		insert into EmployeesData(EmpName,Age,DeptID) values(@ename,@eage,@did)
   else 
      RAISERROR ('No such departmet Id',16,1)
   end try
   begin catch
		select ERROR_MESSAGE()
   end catch
end

alter proc proc_InsertEmployee(@ename varchar(50), @eage int, @did int)
as
begin
   declare @count int
   set @count = (select count(*) from department where DeptID = @did)
   begin transaction
      insert into EmployeesData(EmpName,Age,DeptID) values(@ename,@eage,@did)
	  insert into EmployeeSalary(EmpID,[Date] ,SalaryID ,Deduction ,NetPay)
	  values(@@IDENTITY,SYSDATETIME(),1,0,(select(basic+HRA+DA+Allowance) from Salary where salaryID=1))
	  if(@count<=0)
	     rollback
   commit
end

proc_InsertEmployee 'Jimu',29,1

select * from EmployeesData
select * from EmployeeSalary

alter view vw_GetProductDetails
as
SELECT c.CompanyName, p.ProductName, c.Country country
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od On od.OrderID = o.OrderID
JOIN Products p ON od.ProductID = p.ProductID

select CompanyName,ProductName from vw_GetProductDetails
WHERE Country = 'Mexico';

create function fn_SelectProductData(@country varchar(20))
returns Table
as
return (SELECT c.CompanyName, p.ProductName, c.Country country
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od On od.OrderID = o.OrderID
JOIN Products p ON od.ProductID = p.ProductID where c.country = @country)

select * from dbo.fn_SelectProductData('Mexico')

--create a view that will get the productname and the categoryname. 
CREATE VIEW vw_selectProductCategoryName
AS
	SELECT P.ProductName, C.CategoryName
	FROM Products AS P
	INNER JOIN Categories AS C
	ON P.CategoryID = C.CategoryID;
 
SELECT * FROM vw_selectProductCategoryName
--CReate a function that will get the productname and the categoryname of all products that
--are below teh price range of the parameter

CREATE FUNCTION fn_GetProductsByPrice(@price INT)
RETURNS TABLE
AS
	RETURN (SELECT P.ProductName, C.CategoryName
		FROM Products AS P
		INNER JOIN Categories AS C
		ON P.CategoryID = C.CategoryID WHERE P.UnitPrice < @price
	);
 
SELECT * FROM dbo.fn_GetProductsByPrice(20);

create table EmployeeProject
(Empid int,
Projectid int,
assignedDate date,
releasedate date)

create table project
(projectId int,
projectname varchar(50),
projectstatus varchar(20))

select * from project
select * from EmployeeProject

insert into EmployeeProject values(3,102,SYSDATETIME(),null)


alter trigger trg_Sample
on EmployeeProject
for insert
as
begin
  declare @id int
  set @id = (select Empid from inserted)
  print 'employee inserted '+convert(varchar(5),@id)
end


create trigger trg_UpdateEmployeeOnProjectClose
on project
after update
as
begin
  declare @status varchar(20)
  set @status = (select projectstatus from inserted)
  if(lower(@status) = 'closed')
  begin
	  declare @id int
	  set @id = (select projectId from inserted)
	  update EmployeeProject set releasedate=SYSDATETIME() where Projectid=@id
  end
end

update project set projectstatus = 'closed' where projectId =102