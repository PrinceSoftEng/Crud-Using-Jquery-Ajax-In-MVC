Alter Procedure tblEmployee_sp_CRUDtblEmployee
	@EmpId Int,
	@EmpName Varchar(50),
	@Age int,
	@State Varchar(50),
	@Country varchar(50),
	@Action Varchar(20)
AS
BEGIN	
    If @Action='Insert'
	BEGIN
		Insert Into tblEmployee(EmpName,Age,State,Country) Values(@EmpName,@Age,@State,@Country)
	END
	ELSE If @Action='Update'
	BEGIN
		Update tblEmployee set EmpName=@EmpName,Age=@Age,State=@State,Country=@Country where EmpId=@EmpId
	END	
END

