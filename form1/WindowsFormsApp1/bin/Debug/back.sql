DECLARE @name varchar(50)
DECLARE @path varchar(255)
DECLARE @bakfile varchar(255)
set @name='@DATANAME'
set @path='@FILEPATH'
set @bakfile=@path+@name+'.BAK'
backup database @name to disk=@bakfile with name=@name
go