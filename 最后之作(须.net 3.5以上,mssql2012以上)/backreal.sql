DECLARE @name varchar(50)
DECLARE @path varchar(255)
DECLARE @bakfile varchar(255)
set @name='trafficservice1'
set @path='I:\��ҵ\sql���ݿ�\����ҵ\��ʮС��sql��ĩ\sql��ĩ\���֮��(��.net 3.5����,mssql2012����)\'
set @bakfile=@path+@name+'.BAK'
backup database @name to disk=@bakfile with name=@name
go