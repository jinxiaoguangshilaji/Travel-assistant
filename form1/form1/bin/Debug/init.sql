/*
创建数据库
*/
create database @DATABASENAME
on 
(
name='@DATABASENAME',
filename='@RUNDIRECTORY@DATABASENAME.mdf',
size=5MB,
maxsize=150MB,
filegrowth=20%
);
GO

/*
创建表
*/
use @DATABASENAME;
GO
create table dij_temp
(
	id varchar(8) not null,
	end_point nvarchar(8) not null,
	end_time datetime not null,
	cost money not null,
	traffic_count int not null,
	flag int not null  /*1 最快 ,2 最便宜,3 直达,8 bus,16 train,32 hstrain,64 plane*/
);

create table dij_ans
(
	id varchar(8) not null,
	end_point nvarchar(8) not null,
	end_time datetime not null,
	cost money not null,
	traffic_count int not null,
	flag int not null
);

create table user_info
(
   user_nick nvarchar(20) not null,
   user_id varchar(20) PRIMARY KEY,
   user_pswd varchar(16) not null,
   user_money float not null,
   user_phone char(11) not null,
   user_textnum int,  
   user_text text,
   user_power int not null /*1 是否未被封禁,2 是否允许订票,4 是否为管理员账户*/
);
alter table user_info add constraint butong unique(user_phone);
alter table user_info add constraint CK_tel_Format check (user_phone like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');

create table order_cache
(
	user_id varchar(20) not null,
	traffic_id varchar(8) not null,
	traffic_start_time datetime not null,
	traffic_cost  money not null
);

create table order_info
(
	order_id varchar(20) not null,
	traffic_id varchar(8) not null,
	traffic_start_time datetime not null,
	traffic_seat int not null,
	traffic_cost money not null,
	order_valid int default 1 /*1未领取,2已领取,3过期,4退票,5其他原因作废;*/
);

create table order_form
(
	order_id varchar(20) primary key,
	order_cost money not null,
	user_id varchar(20) not null,
	order_time datetime not null,
);

Create Table traffic_train
(traffic_id varchar(8) not null,
 traffic_start_point nvarchar(8) not null,
 traffic_start_time datetime not null,
 traffic_end_point nvarchar(8) not null,
 traffic_end_time datetime not null,
 traffic_seat_number int not null,
 traffic_seat_count int not null,
 traffic_cost money not null
);
Create Table traffic_hstrain
(traffic_id varchar(8) not null,
 traffic_start_point nvarchar(8) not null,
 traffic_start_time datetime not null,
 traffic_end_point nvarchar(8) not null,
 traffic_end_time datetime not null,
 traffic_seat_number int not null,
 traffic_seat_count int not null,
 traffic_cost money not null
);
Create Table traffic_plane
(traffic_id varchar(8) not null,
 traffic_start_point nvarchar(8) not null,
 traffic_start_time datetime not null,
 traffic_end_point nvarchar(8) not null,
 traffic_end_time datetime not null,
 traffic_seat_number int not null,
 traffic_seat_count int not null,
 traffic_cost money not null
);
Create Table traffic_bus
(traffic_id varchar(8) not null,
 traffic_start_point nvarchar(8) not null,
 traffic_start_time datetime not null,
 traffic_end_point nvarchar(8) not null,
 traffic_end_time datetime not null,
 traffic_seat_number int not null,
 traffic_seat_count int not null,
 traffic_cost money not null
);
GO

/*
创建视图
*/
Create view traffic_all as
select 
traffic_id as id,
traffic_start_point as start_point,
traffic_start_time as start_time,
traffic_end_point as end_point,
traffic_end_time as end_time,
traffic_cost as cost,
traffic_seat_number-traffic_seat_count as seat 
from 
(
select * from traffic_bus 
union 
select * from traffic_train 
union 
select * from traffic_hstrain 
union 
select * from traffic_plane
)ls
where traffic_seat_count<traffic_seat_number;
GO

/*
创建索引
*/
create clustered index order_index
on order_info(order_id);
GO

/*
创建存储过程
*/
create procedure dij
@first_point nvarchar(8),
@first_time datetime,
@final_point nvarchar(8),
@flag int
as
begin
declare @id varchar(8);
declare @start_point nvarchar(8);
declare @start_time datetime;
declare @cost money;
declare @count int;
delete from dij_temp;
delete from dij_ans;
insert into dij_temp values('start',@first_point,@first_time,0,0,@flag);


while (select count(*) from dij_temp)>0
begin

if (@flag&2)!=0
begin
 select top 1 @id=id,@start_point=end_point,@start_time=end_time,@cost=cost,@count=traffic_count from dij_temp order by cost,end_time;
 delete from dij_temp where end_time=@start_time and id=@id;
 delete from dij_ans where end_point=@start_point and cost>@cost and datediff(mi,@start_time,end_time)>0;
 if (select count(*) from dij_ans where end_point=@start_point and cost<@cost and datediff(mi,end_time,@start_time)>0)=0
 begin
  insert into dij_ans values(@id,@start_point,@start_time,@cost,@count,@flag);
  print 'insert to ans';
  print @id;
  print @start_point;
  print @start_time;
  print @cost;
  print @count;
 end
 else
  continue;
end

else if (@flag&4)!=0
begin
 select top 1 @id=id,@start_point=end_point,@start_time=end_time,@cost=cost,@count=traffic_count from dij_temp order by traffic_count,end_time;
 delete from dij_temp where end_time=@start_time and id=@id;
 delete from dij_ans where end_point=@start_point and traffic_count>@count and datediff(mi,@start_time,end_time)>0;
 if (select count(*) from dij_ans where end_point=@start_point and traffic_count<@count and datediff(mi,end_time,@start_time)>0)=0
 begin
  insert into dij_ans values(@id,@start_point,@start_time,@cost,@count,@flag);
 end
 else
  continue;
end

else
begin
 select top 1 @id=id,@start_point=end_point,@start_time=end_time,@cost=cost,@count=traffic_count from dij_temp order by end_time;
 delete from dij_temp where end_time=@start_time and id=@id;
 delete from dij_ans where end_point=@start_point and datediff(mi,@start_time,end_time)>0;
 if (select count(*) from dij_ans where end_point=@start_point and datediff(mi,end_time,@start_time)>0)=0
 begin
  insert into dij_ans values(@id,@start_point,@start_time,@cost,@count,@flag);
 end
 else
  continue;
end

if(@flag&8)!=0
begin
insert into dij_temp select id,end_point,end_time,@cost+cost,@count,@flag from traffic_all where start_point=@start_point and datediff(mi,@start_time,start_time)>=5 and id=@id and id in (select distinct traffic_id from traffic_bus);
insert into dij_temp select id,end_point,end_time,@cost+cost,@count+1,@flag from traffic_all where start_point=@start_point and datediff(mi,@start_time,start_time)>=5 and id!=@id and id in (select distinct traffic_id from traffic_bus);

end
if(@flag&16)!=0
begin
insert into dij_temp select id,end_point,end_time,@cost+cost,@count,@flag from traffic_all where start_point=@start_point and datediff(mi,@start_time,start_time)>=5 and id=@id and id in (select distinct traffic_id from traffic_train);
insert into dij_temp select id,end_point,end_time,@cost+cost,@count+1,@flag from traffic_all where start_point=@start_point and datediff(mi,@start_time,start_time)>=5 and id!=@id and id in (select distinct traffic_id from traffic_train);

end
if(@flag&32)!=0
begin
insert into dij_temp select id,end_point,end_time,@cost+cost,@count,@flag from traffic_all where start_point=@start_point and datediff(mi,@start_time,start_time)>=5 and id=@id and id in (select distinct traffic_id from traffic_hstrain);
insert into dij_temp select id,end_point,end_time,@cost+cost,@count+1,@flag from traffic_all where start_point=@start_point and datediff(mi,@start_time,start_time)>=5 and id!=@id and id in (select distinct traffic_id from traffic_hstrain);

end
if(@flag&64)!=0
begin
insert into dij_temp select id,end_point,end_time,@cost+cost,@count+1,@flag from traffic_all where start_point=@start_point and datediff(mi,@start_time,start_time)>=5 and id in (select distinct traffic_id from traffic_plane);

end
end


if (select count(*) from dij_ans where end_point=@final_point)=0
 return 0;
if (@flag&2)!=0
begin
 select top 1 @id=id,@start_time=end_time,@cost=cost from dij_ans where end_point=@final_point order by cost,end_time;
 while @id!='start'
 begin
  insert into dij_temp select * from dij_ans where id=@id and end_time=@start_time;
  select top 1 @id=id,@start_time=end_time,@cost=cost from dij_ans where end_point=(select start_point from traffic_all where id=@id and end_time=@start_time) and cost=@cost-(select cost from traffic_all where id=@id and end_time=@start_time) order by end_time;
 end
end

else if (@flag&4)!=0
begin
 select top 1 @id=id,@start_time=end_time,@count=traffic_count from dij_ans where end_point=@final_point order by traffic_count,end_time;
 while @id!='start'
 begin
  insert into dij_temp select * from dij_ans where id=@id and end_time=@start_time;
  select top 1 @id=id,@start_time=end_time,@count=traffic_count from dij_ans where end_point=(select start_point from traffic_all where id=@id and end_time=@start_time) and ((traffic_count=@count-1 and (id!=@id or id in(select id from traffic_plane)))or(traffic_count=@count and (id=@id and id not in(select id from traffic_plane)))) order by end_time;
 end
end

else
begin
 select top 1 @id=id,@start_time=end_time from dij_ans where end_point=@final_point order by end_time;
 while @id!='start'
 begin
  insert into dij_temp select * from dij_ans where id=@id and end_time=@start_time;
  select top 1 @id=id,@start_time=end_time from dij_ans where end_point=(select start_point from traffic_all where id=@id and end_time=@start_time) and datediff(mi,end_time,(select start_time from traffic_all where id=@id and end_time=@start_time))>0 order by end_time;
 end
end

delete from dij_ans;
insert into dij_ans select * from dij_temp;
end

GO

/*
创建触发器
*/

	/*订票数据更新_余票更新_all_update*/
create trigger all_update
on traffic_all
instead of update
as 
begin
update traffic_bus set traffic_seat_count=traffic_seat_number-(select seat from inserted) where traffic_id=(select id from inserted) and traffic_start_time=(select start_time from inserted);
update traffic_train set traffic_seat_count=traffic_seat_number-(select seat from inserted) where traffic_id=(select id from inserted) and traffic_start_time=(select start_time from inserted);
update traffic_hstrain set traffic_seat_count=traffic_seat_number-(select seat from inserted) where traffic_id=(select id from inserted) and traffic_start_time=(select start_time from inserted);
update traffic_plane set traffic_seat_count=traffic_seat_number-(select seat from inserted) where traffic_id=(select id from inserted) and traffic_start_time=(select start_time from inserted);
end
GO

	/*订票数据更新_订单生成_cache_inserted*/
create trigger cache_inserted
on order_cache
after insert
as 
begin
	while (select count(*) from order_cache)>0
	begin
		if (select seat from traffic_all where id=(select top 1 traffic_id from order_cache order by traffic_id,traffic_start_time) and start_time=(select top 1 traffic_start_time from order_cache order by traffic_id,traffic_start_time))>0
		begin
			update traffic_all set seat=seat-1 where id=(select top 1 traffic_id from order_cache order by traffic_id,traffic_start_time) and start_time=(select top 1 traffic_start_time from order_cache order by traffic_id,traffic_start_time);
			insert into order_info select top 1 (select count(*) from order_form),traffic_id,traffic_start_time,(select seat from traffic_all where id=(select top 1 traffic_id from order_cache order by traffic_id,traffic_start_time) and start_time=(select top 1 traffic_start_time from order_cache order by traffic_id,traffic_start_time)),traffic_cost,1 from order_cache order by traffic_id,traffic_start_time;
			
			delete top(1) from order_cache where traffic_id=(select top 1 traffic_id from order_cache order by traffic_id,traffic_start_time) and traffic_start_time=(select top 1 traffic_start_time from order_cache order by traffic_id,traffic_start_time);
		end
		else
			rollback;
	end
	insert into order_form select top 1 (select count(*) from order_form)+1,(select sum(traffic_cost)from inserted),user_id,GETDATE() from inserted;
	update user_info set user_money=user_money-(select sum(traffic_cost) from inserted) where user_id=(select top 1 user_id from inserted);
end
GO

	/*md5加密_账户注册_user_insert*/
create trigger user_insert
on user_info
instead of insert
as 
begin
insert into user_info select user_nick,user_id,substring(sys.fn_sqlvarbasetostr(HashBytes('MD5',user_pswd)),11,16),user_money,user_phone,user_textnum,user_text,user_power from inserted;
end
GO

	/*md5加密_账户修改_user_update*/
create trigger user_update
on user_info
after update
as 
begin
if update (user_pswd)
update user_info set user_pswd=substring(sys.fn_sqlvarbasetostr(HashBytes('MD5',user_pswd)),11,16) where user_id in (select user_id from inserted);
end
GO

/*插入数据*/
insert into traffic_plane values
('113','L比尔吉沃特','2017/2/3 16:00:00','L弗雷尔卓德','2017/2/3 17:30:00',100,20,50),
('114','L弗雷尔卓德','2017/2/3 16:00:00','L比尔吉沃特','2017/2/3 17:30:00',100,20,50);
insert into traffic_train values 
('111','L比尔吉沃特','2017/2/3 15:50:00','L德玛西亚','2017/2/3 16:00:00',100,20,100),
('111','L德玛西亚','2017/2/3 16:15:00','L弗雷尔卓德','2017/2/3 17:00:00',100,20,100),
('111','L弗雷尔卓德','2017/2/3 17:45:30','L恕瑞玛','2017/2/3 19:00:00',100,20,100),
('111','L恕瑞玛','2017/2/3 19:15:30','L无畏先锋','2017/2/3 20:00:00',100,20,100);
insert into traffic_bus values 
('117','L德玛西亚','2017/2/3 17:50:30','L无畏先锋','2017/2/3 21:00:00',50,20,50);
insert into traffic_hstrain values 
('115','L弗雷尔卓德','2017/2/3 17:45:00','L无畏先锋','2017/2/3 19:00:00',100,20,6000);
insert into user_info values('程磊','2017001','000000','170','13826051438','0','','5');
insert into user_info values('金小光','2017002','000000','170','13826051423','0','','5');
insert into user_info values('胡伟涛','2017003','000000','170','13826051434','0','','5');
insert into user_info values('test','test','test','170','13826051422','0','','1');
insert into user_info values('feng','feng','feng','170','13826051441','0','','0');
insert into user_info values('putong','putong','putong','170','13826051433','0','','3');

insert into traffic_plane values
('pB4X4X','北京','2018-1-3 22:22:0','乌鲁木齐','2018-1-3 23:11:0',100,1,616),
('pB4X4X','乌鲁木齐','2018-1-3 23:19:0','昆明','2018-1-4 0:15:0',100,1,532),
('pB4X4X','昆明','2018-1-4 0:20:0','石家庄','2018-1-4 1:34:0',100,1,73),
('pB4X4X','石家庄','2018-1-4 1:42:0','西宁','2018-1-4 2:40:0',100,1,253),
('pB4X4X','西宁','2018-1-4 2:49:0','合肥','2018-1-4 3:6:0',100,1,110),
('pB4X4X','合肥','2018-1-4 3:13:0','合肥','2018-1-4 3:57:0',100,1,477),
('pB4X4X','合肥','2018-1-4 4:6:0','昆明','2018-1-4 4:27:0',100,1,260),
('pB4X4X','昆明','2018-1-4 4:35:0','武汉','2018-1-4 5:38:0',100,1,432),
('pB4X4X','武汉','2018-1-4 5:46:0','合肥','2018-1-4 6:8:0',100,1,228),
('pB4X4X','合肥','2018-1-4 6:17:0','呼和浩特','2018-1-4 7:31:0',100,1,61),
('pB4X4X','呼和浩特','2018-1-4 7:39:0','拉萨','2018-1-4 7:58:0',100,1,282);
insert into traffic_plane values
('pH8DWR','香港','2018-1-4 8:6:0','郑州','2018-1-4 8:43:0',100,1,520),
('pH8DWR','郑州','2018-1-4 8:50:0','乌鲁木齐','2018-1-4 9:41:0',100,1,315),
('pH8DWR','乌鲁木齐','2018-1-4 9:49:0','上海','2018-1-4 10:41:0',100,1,483),
('pH8DWR','上海','2018-1-4 10:49:0','长沙','2018-1-4 11:13:0',100,1,614),
('pH8DWR','长沙','2018-1-4 11:21:0','长沙','2018-1-4 12:17:0',100,1,299),
('pH8DWR','长沙','2018-1-4 12:22:0','太原','2018-1-4 12:54:0',100,1,570);
insert into traffic_plane values
('p5HSI3','太原','2018-1-4 13:0:0','西安','2018-1-4 13:50:0',100,1,52),
('p5HSI3','西安','2018-1-4 13:58:0','杭州','2018-1-4 14:43:0',100,1,420),
('p5HSI3','杭州','2018-1-4 14:49:0','沈阳','2018-1-4 15:6:0',100,1,631),
('p5HSI3','沈阳','2018-1-4 15:11:0','天津','2018-1-4 16:20:0',100,1,329),
('p5HSI3','天津','2018-1-4 16:29:0','上海','2018-1-4 17:26:0',100,1,589),
('p5HSI3','上海','2018-1-4 17:34:0','武汉','2018-1-4 18:15:0',100,1,533),
('p5HSI3','武汉','2018-1-4 18:20:0','长沙','2018-1-4 18:46:0',100,1,420),
('p5HSI3','长沙','2018-1-4 18:52:0','广州','2018-1-4 19:38:0',100,1,112),
('p5HSI3','广州','2018-1-4 19:46:0','西宁','2018-1-4 20:38:0',100,1,623),
('p5HSI3','西宁','2018-1-4 20:45:0','郑州','2018-1-4 21:21:0',100,1,59),
('p5HSI3','郑州','2018-1-4 21:27:0','银川','2018-1-4 22:17:0',100,1,636);
insert into traffic_plane values
('p0BA46','西安','2018-1-4 22:23:0','兰州','2018-1-4 23:12:0',100,1,108),
('p0BA46','兰州','2018-1-4 23:20:0','哈尔滨','2018-1-4 23:36:0',100,1,238),
('p0BA46','哈尔滨','2018-1-4 23:43:0','呼和浩特','2018-1-5 0:29:0',100,1,310),
('p0BA46','呼和浩特','2018-1-5 0:37:0','西宁','2018-1-5 1:25:0',100,1,100),
('p0BA46','西宁','2018-1-5 1:31:0','福州','2018-1-5 1:46:0',100,1,200),
('p0BA46','福州','2018-1-5 1:51:0','成都','2018-1-5 2:55:0',100,1,348),
('p0BA46','成都','2018-1-5 3:2:0','拉萨','2018-1-5 3:33:0',100,1,642),
('p0BA46','拉萨','2018-1-5 3:42:0','西安','2018-1-5 4:4:0',100,1,264);
insert into traffic_plane values
('pP6ASY','乌鲁木齐','2018-1-5 4:11:0','长沙','2018-1-5 4:47:0',100,1,420),
('pP6ASY','长沙','2018-1-5 4:56:0','重庆','2018-1-5 5:38:0',100,1,633),
('pP6ASY','重庆','2018-1-5 5:47:0','西安','2018-1-5 6:2:0',100,1,393),
('pP6ASY','西安','2018-1-5 6:8:0','南昌','2018-1-5 6:58:0',100,1,208);
insert into traffic_train values
('t3BH3U','济南','2018-1-3 22:23:0','武汉','2018-1-3 22:43:0',100,1,637),
('t3BH3U','武汉','2018-1-3 22:51:0','昆明','2018-1-4 0:0:0',100,1,151);
insert into traffic_train values
('tY4KSH','石家庄','2018-1-4 0:7:0','沈阳','2018-1-4 0:59:0',100,1,613),
('tY4KSH','沈阳','2018-1-4 1:8:0','杭州','2018-1-4 1:59:0',100,1,73),
('tY4KSH','杭州','2018-1-4 2:5:0','济南','2018-1-4 3:6:0',100,1,609),
('tY4KSH','济南','2018-1-4 3:11:0','长沙','2018-1-4 3:43:0',100,1,267),
('tY4KSH','长沙','2018-1-4 3:50:0','长沙','2018-1-4 4:30:0',100,1,283),
('tY4KSH','长沙','2018-1-4 4:35:0','济南','2018-1-4 4:51:0',100,1,464),
('tY4KSH','济南','2018-1-4 4:58:0','乌鲁木齐','2018-1-4 6:6:0',100,1,391);
insert into traffic_train values
('tHCZJ6','哈尔滨','2018-1-4 6:14:0','郑州','2018-1-4 6:56:0',100,1,141),
('tHCZJ6','郑州','2018-1-4 7:4:0','石家庄','2018-1-4 7:27:0',100,1,368),
('tHCZJ6','石家庄','2018-1-4 7:36:0','长春','2018-1-4 8:15:0',100,1,228),
('tHCZJ6','长春','2018-1-4 8:23:0','沈阳','2018-1-4 8:57:0',100,1,395),
('tHCZJ6','沈阳','2018-1-4 9:6:0','重庆','2018-1-4 10:2:0',100,1,538),
('tHCZJ6','重庆','2018-1-4 10:10:0','台北','2018-1-4 10:33:0',100,1,574);
insert into traffic_train values
('tZ4259','乌鲁木齐','2018-1-4 10:42:0','石家庄','2018-1-4 11:31:0',100,1,146),
('tZ4259','石家庄','2018-1-4 11:39:0','南宁','2018-1-4 12:3:0',100,1,95),
('tZ4259','南宁','2018-1-4 12:8:0','石家庄','2018-1-4 12:39:0',100,1,364);
insert into traffic_train values
('tH7Y26','西宁','2018-1-4 12:44:0','长沙','2018-1-4 13:0:0',100,1,261),
('tH7Y26','长沙','2018-1-4 13:6:0','西宁','2018-1-4 14:11:0',100,1,257),
('tH7Y26','西宁','2018-1-4 14:20:0','澳门','2018-1-4 15:2:0',100,1,308),
('tH7Y26','澳门','2018-1-4 15:11:0','银川','2018-1-4 16:19:0',100,1,458),
('tH7Y26','银川','2018-1-4 16:24:0','武汉','2018-1-4 17:11:0',100,1,279),
('tH7Y26','武汉','2018-1-4 17:18:0','重庆','2018-1-4 17:35:0',100,1,346),
('tH7Y26','重庆','2018-1-4 17:43:0','长春','2018-1-4 18:5:0',100,1,222),
('tH7Y26','长春','2018-1-4 18:14:0','杭州','2018-1-4 19:17:0',100,1,465);
insert into traffic_train values
('t1N7OZ','兰州','2018-1-4 19:24:0','沈阳','2018-1-4 20:20:0',100,1,109),
('t1N7OZ','沈阳','2018-1-4 20:27:0','长春','2018-1-4 21:23:0',100,1,509),
('t1N7OZ','长春','2018-1-4 21:30:0','海口','2018-1-4 22:11:0',100,1,372),
('t1N7OZ','海口','2018-1-4 22:18:0','沈阳','2018-1-4 23:13:0',100,1,564),
('t1N7OZ','沈阳','2018-1-4 23:22:0','海口','2018-1-5 0:4:0',100,1,165),
('t1N7OZ','海口','2018-1-5 0:13:0','哈尔滨','2018-1-5 1:18:0',100,1,243),
('t1N7OZ','哈尔滨','2018-1-5 1:25:0','昆明','2018-1-5 2:34:0',100,1,377),
('t1N7OZ','昆明','2018-1-5 2:42:0','海口','2018-1-5 3:47:0',100,1,555);
insert into traffic_hstrain values
('hZ8KK8','兰州','2018-1-3 22:23:0','天津','2018-1-3 23:0:0',100,1,421),
('hZ8KK8','天津','2018-1-3 23:8:0','兰州','2018-1-3 23:55:0',100,1,222),
('hZ8KK8','兰州','2018-1-4 0:0:0','成都','2018-1-4 0:26:0',100,1,134),
('hZ8KK8','成都','2018-1-4 0:34:0','西宁','2018-1-4 1:44:0',100,1,392),
('hZ8KK8','西宁','2018-1-4 1:51:0','西宁','2018-1-4 3:4:0',100,1,99),
('hZ8KK8','西宁','2018-1-4 3:13:0','长沙','2018-1-4 3:50:0',100,1,324),
('hZ8KK8','长沙','2018-1-4 3:55:0','石家庄','2018-1-4 4:38:0',100,1,461),
('hZ8KK8','石家庄','2018-1-4 4:47:0','南昌','2018-1-4 5:5:0',100,1,205);
insert into traffic_hstrain values
('hL1XY6','长沙','2018-1-4 5:14:0','郑州','2018-1-4 6:15:0',100,1,136),
('hL1XY6','郑州','2018-1-4 6:24:0','郑州','2018-1-4 7:23:0',100,1,304),
('hL1XY6','郑州','2018-1-4 7:31:0','南宁','2018-1-4 8:32:0',100,1,89),
('hL1XY6','南宁','2018-1-4 8:39:0','南京','2018-1-4 8:58:0',100,1,120),
('hL1XY6','南京','2018-1-4 9:5:0','杭州','2018-1-4 9:21:0',100,1,69),
('hL1XY6','杭州','2018-1-4 9:26:0','太原','2018-1-4 9:57:0',100,1,637);
insert into traffic_hstrain values
('hMCYZZ','贵阳','2018-1-4 10:6:0','兰州','2018-1-4 11:13:0',100,1,434),
('hMCYZZ','兰州','2018-1-4 11:18:0','银川','2018-1-4 11:42:0',100,1,473),
('hMCYZZ','银川','2018-1-4 11:47:0','澳门','2018-1-4 12:37:0',100,1,127),
('hMCYZZ','澳门','2018-1-4 12:45:0','海口','2018-1-4 13:42:0',100,1,592),
('hMCYZZ','海口','2018-1-4 13:51:0','澳门','2018-1-4 15:4:0',100,1,299);
insert into traffic_hstrain values
('h9IM4W','澳门','2018-1-4 15:10:0','哈尔滨','2018-1-4 16:8:0',100,1,62),
('h9IM4W','哈尔滨','2018-1-4 16:16:0','郑州','2018-1-4 16:44:0',100,1,493),
('h9IM4W','郑州','2018-1-4 16:52:0','银川','2018-1-4 17:27:0',100,1,361),
('h9IM4W','银川','2018-1-4 17:33:0','福州','2018-1-4 18:29:0',100,1,261),
('h9IM4W','福州','2018-1-4 18:38:0','郑州','2018-1-4 19:26:0',100,1,117),
('h9IM4W','郑州','2018-1-4 19:35:0','成都','2018-1-4 19:59:0',100,1,139),
('h9IM4W','成都','2018-1-4 20:5:0','南京','2018-1-4 21:4:0',100,1,236),
('h9IM4W','南京','2018-1-4 21:13:0','天津','2018-1-4 21:36:0',100,1,505),
('h9IM4W','天津','2018-1-4 21:41:0','太原','2018-1-4 21:59:0',100,1,597),
('h9IM4W','太原','2018-1-4 22:6:0','长沙','2018-1-4 22:23:0',100,1,281),
('h9IM4W','长沙','2018-1-4 22:29:0','兰州','2018-1-4 23:41:0',100,1,590);
insert into traffic_hstrain values
('hR1H14','广州','2018-1-4 23:47:0','福州','2018-1-5 0:19:0',100,1,413),
('hR1H14','福州','2018-1-5 0:24:0','杭州','2018-1-5 1:17:0',100,1,234),
('hR1H14','杭州','2018-1-5 1:25:0','贵阳','2018-1-5 2:16:0',100,1,503),
('hR1H14','贵阳','2018-1-5 2:25:0','乌鲁木齐','2018-1-5 3:6:0',100,1,204),
('hR1H14','乌鲁木齐','2018-1-5 3:14:0','重庆','2018-1-5 3:31:0',100,1,595),
('hR1H14','重庆','2018-1-5 3:36:0','贵阳','2018-1-5 3:56:0',100,1,256),
('hR1H14','贵阳','2018-1-5 4:1:0','南昌','2018-1-5 5:10:0',100,1,242),
('hR1H14','南昌','2018-1-5 5:15:0','兰州','2018-1-5 5:33:0',100,1,632),
('hR1H14','兰州','2018-1-5 5:41:0','银川','2018-1-5 6:3:0',100,1,479);
insert into traffic_hstrain values
('hINE5T','香港','2018-1-5 6:8:0','南昌','2018-1-5 7:11:0',100,1,101),
('hINE5T','南昌','2018-1-5 7:16:0','香港','2018-1-5 8:16:0',100,1,243),
('hINE5T','香港','2018-1-5 8:25:0','长春','2018-1-5 8:58:0',100,1,505),
('hINE5T','长春','2018-1-5 9:3:0','福州','2018-1-5 10:12:0',100,1,221),
('hINE5T','福州','2018-1-5 10:20:0','天津','2018-1-5 11:2:0',100,1,285),
('hINE5T','天津','2018-1-5 11:7:0','台北','2018-1-5 12:8:0',100,1,336),
('hINE5T','台北','2018-1-5 12:17:0','拉萨','2018-1-5 12:54:0',100,1,533),
('hINE5T','拉萨','2018-1-5 13:1:0','澳门','2018-1-5 13:32:0',100,1,231),
('hINE5T','澳门','2018-1-5 13:40:0','福州','2018-1-5 14:14:0',100,1,488),
('hINE5T','福州','2018-1-5 14:23:0','成都','2018-1-5 15:13:0',100,1,626),
('hINE5T','成都','2018-1-5 15:18:0','香港','2018-1-5 16:21:0',100,1,161);
insert into traffic_hstrain values
('h89KHD','福州','2018-1-5 16:29:0','杭州','2018-1-5 16:58:0',100,1,619),
('h89KHD','杭州','2018-1-5 17:7:0','成都','2018-1-5 18:12:0',100,1,447),
('h89KHD','成都','2018-1-5 18:20:0','武汉','2018-1-5 18:57:0',100,1,488);
insert into traffic_bus values
('b25M9M','沈阳','2018-1-3 22:22:0','沈阳','2018-1-3 23:16:0',100,1,572),
('b25M9M','沈阳','2018-1-3 23:21:0','石家庄','2018-1-3 23:47:0',100,1,525),
('b25M9M','石家庄','2018-1-3 23:56:0','银川','2018-1-4 0:18:0',100,1,566),
('b25M9M','银川','2018-1-4 0:27:0','南京','2018-1-4 1:27:0',100,1,270);
insert into traffic_bus values
('bHELE9','乌鲁木齐','2018-1-4 1:34:0','拉萨','2018-1-4 2:23:0',100,1,362),
('bHELE9','拉萨','2018-1-4 2:31:0','南昌','2018-1-4 3:19:0',100,1,412),
('bHELE9','南昌','2018-1-4 3:25:0','澳门','2018-1-4 3:54:0',100,1,307),
('bHELE9','澳门','2018-1-4 4:0:0','海口','2018-1-4 4:53:0',100,1,400),
('bHELE9','海口','2018-1-4 5:0:0','北京','2018-1-4 5:39:0',100,1,219),
('bHELE9','北京','2018-1-4 5:45:0','海口','2018-1-4 6:0:0',100,1,533),
('bHELE9','海口','2018-1-4 6:9:0','南宁','2018-1-4 6:50:0',100,1,123),
('bHELE9','南宁','2018-1-4 6:59:0','太原','2018-1-4 7:19:0',100,1,341),
('bHELE9','太原','2018-1-4 7:28:0','南京','2018-1-4 8:34:0',100,1,613),
('bHELE9','南京','2018-1-4 8:39:0','呼和浩特','2018-1-4 9:37:0',100,1,422);
insert into traffic_bus values
('b2WN47','西宁','2018-1-4 9:46:0','乌鲁木齐','2018-1-4 10:4:0',100,1,600),
('b2WN47','乌鲁木齐','2018-1-4 10:13:0','上海','2018-1-4 10:35:0',100,1,604),
('b2WN47','上海','2018-1-4 10:44:0','成都','2018-1-4 11:6:0',100,1,437),
('b2WN47','成都','2018-1-4 11:15:0','台北','2018-1-4 11:41:0',100,1,308),
('b2WN47','台北','2018-1-4 11:47:0','贵阳','2018-1-4 12:31:0',100,1,179);
insert into traffic_bus values
('b6YENH','兰州','2018-1-4 12:38:0','郑州','2018-1-4 12:56:0',100,1,525),
('b6YENH','郑州','2018-1-4 13:4:0','呼和浩特','2018-1-4 13:26:0',100,1,250);
insert into traffic_bus values
('b3LLIX','西安','2018-1-4 13:32:0','香港','2018-1-4 14:27:0',100,1,338),
('b3LLIX','香港','2018-1-4 14:36:0','南昌','2018-1-4 14:59:0',100,1,215),
('b3LLIX','南昌','2018-1-4 15:8:0','重庆','2018-1-4 16:21:0',100,1,629),
('b3LLIX','重庆','2018-1-4 16:30:0','石家庄','2018-1-4 17:31:0',100,1,537);
insert into traffic_bus values
('bJ5R3A','石家庄','2018-1-4 17:37:0','西安','2018-1-4 18:41:0',100,1,470),
('bJ5R3A','西安','2018-1-4 18:50:0','福州','2018-1-4 19:23:0',100,1,328),
('bJ5R3A','福州','2018-1-4 19:30:0','北京','2018-1-4 20:19:0',100,1,642),
('bJ5R3A','北京','2018-1-4 20:24:0','银川','2018-1-4 20:52:0',100,1,462),
('bJ5R3A','银川','2018-1-4 21:0:0','台北','2018-1-4 21:54:0',100,1,397),
('bJ5R3A','台北','2018-1-4 22:1:0','呼和浩特','2018-1-4 22:34:0',100,1,469),
('bJ5R3A','呼和浩特','2018-1-4 22:41:0','济南','2018-1-4 23:30:0',100,1,232);
insert into traffic_bus values
('bOOUM9','长春','2018-1-4 23:36:0','澳门','2018-1-4 23:57:0',100,1,151),
('bOOUM9','澳门','2018-1-5 0:6:0','兰州','2018-1-5 0:52:0',100,1,281),
('bOOUM9','兰州','2018-1-5 0:58:0','郑州','2018-1-5 2:0:0',100,1,266),
('bOOUM9','郑州','2018-1-5 2:9:0','西安','2018-1-5 2:37:0',100,1,260),
('bOOUM9','西安','2018-1-5 2:46:0','北京','2018-1-5 3:49:0',100,1,366),
('bOOUM9','北京','2018-1-5 3:55:0','哈尔滨','2018-1-5 4:20:0',100,1,610);
insert into traffic_bus values
('b1VA3N','长沙','2018-1-5 4:27:0','济南','2018-1-5 5:40:0',100,1,620),
('b1VA3N','济南','2018-1-5 5:46:0','南京','2018-1-5 6:48:0',100,1,190),
('b1VA3N','南京','2018-1-5 6:54:0','上海','2018-1-5 7:51:0',100,1,484),
('b1VA3N','上海','2018-1-5 7:57:0','西安','2018-1-5 8:21:0',100,1,154),
('b1VA3N','西安','2018-1-5 8:28:0','银川','2018-1-5 9:10:0',100,1,433),
('b1VA3N','银川','2018-1-5 9:15:0','香港','2018-1-5 10:9:0',100,1,553),
('b1VA3N','香港','2018-1-5 10:18:0','澳门','2018-1-5 10:53:0',100,1,179);
