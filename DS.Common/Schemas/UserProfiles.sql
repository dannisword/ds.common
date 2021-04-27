create table UserProfiles
(
 UserId			    int	identity(1,1)				    not null,   -- 識別號
 UserCode           nvarchar(20)                        not null,   
 UserName           nvarchar(30)                        not null,
 UesrPassword       nvarchar(80)                        not null,
 Category			nvarchar(08)					    not null,	-- 員工、眷屬
 Email              nvarchar(80)                        null,
 Token              nvarchar(255)                       null,
 LastLogin          datetime                            null,
 PublicationAt		datetime    default ('2999/12/31')	not null,   -- 上載日期
 Status             smallint                            not null,   -- 狀態	0:新建 10:審核 20:發佈 90:取消	
 IsActive			bit								    not null,   -- 啟用 	
 CreateAt			int 							    not null,   -- 建立人員 
 CreateTime			datetime default (GETDATE()) 	    not null,   -- 建立時間
 SystemUser			int 							    not null,   -- 系統異動人員 
 SystemTime			datetime default (GETDATE()) 	    not null,   -- 系統異動時間
 constraint UserProfiles_PK primary key(UserId)
)
create index UserProfiles_IX1 on UserProfiles(UserCode, IsActive); 


/*
1.帳號同步到雲端
2.何時取消帳號
*/