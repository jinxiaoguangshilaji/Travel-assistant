declare @dumpfile varchar(255)  
declare @msg varchar(70)  
   select @dumpfile = '@FILEPATH@DATANAME.BAK'  
   select @msg=convert(char(26),getdate(),9)  
   print @msg  
   
restore DATABASE @DATANAME from disk=@dumpfile  
if (@@ERROR <> 0 )  
begin  
   select @msg=convert(char(26),getdate(),9)+'-----��ԭ����ʧ�ܻ�����쳣'  
   print @msg  
 end  
else  
begin  
   select @msg=convert(char(26),getdate(),9)+'-----���ݿ⻹ԭ���'  
   print @msg  
end  