DECLARE @name varchar(50)
DECLARE @path varchar(255)
DECLARE @bakfile varchar(255)
set @name='trafficservice'
set @path='E:\sql��ĩ\sql��ĩ1.1.�ڶ���\sql��ĩ\form1\WindowsFormsApp1\bin\Debug\'
set @bakfile=@path+@name+'.BAK'
backup database @name to disk=@bakfile with name=@name
go