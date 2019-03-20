DECLARE @name varchar(50)
DECLARE @path varchar(255)
DECLARE @bakfile varchar(255)
set @name='trafficservice1'
set @path='I:\作业\sql数据库\大作业\第十小组sql期末\sql期末\最后之作(须.net 3.5以上,mssql2012以上)\'
set @bakfile=@path+@name+'.BAK'
backup database @name to disk=@bakfile with name=@name
go