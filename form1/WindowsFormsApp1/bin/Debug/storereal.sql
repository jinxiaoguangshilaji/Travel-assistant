declare @dumpfile varchar(255)  
declare @msg varchar(70)  
   select @dumpfile = 'E:\sql期末\sql期末1.1.第二次\sql期末\form1\WindowsFormsApp1\bin\Debug\trafficservice.BAK'  
   select @msg=convert(char(26),getdate(),9)  
   print @msg  
   
restore DATABASE trafficservice from disk=@dumpfile  
if (@@ERROR <> 0 )  
begin  
   select @msg=convert(char(26),getdate(),9)+'-----还原数据失败或出现异常'  
   print @msg  
 end  
else  
begin  
   select @msg=convert(char(26),getdate(),9)+'-----数据库还原完毕'  
   print @msg  
end  