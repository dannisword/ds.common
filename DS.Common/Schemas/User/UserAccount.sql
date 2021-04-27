create table UserAccounts
(
 UserID 			    int	identity(1,1)			    not null, -- 使用者編號 
 ShortName              nvarchar(30)                    not null, --
 FullName               nvarchar(80)                    not null, --
 Classification         smallint                        not null, -- 類別
 Email                  nvarchar(30)                    not null, --
 PasswordHash           nvarchar(20)                    not null, --
 Privacy                bit                             not null, -- 隱私權                 
 StartAt				datetime					    not null, -- 起
 EndAt					datetime default ('2999/12/31') not null, -- 訖
 Status                 smallint                        not null, -- 10 : 新增
 IsActive               bit                             not null, --
 CreatedBy				int							    not null, -- 建檔人員 
 CreatedAt				datetime					    not null, -- 建檔時間 
 UpdatedBy				int							    not null, -- 異動人員 
 UpdatedAt				datetime					    not null, -- 異動時間 
 constraint UserAccountsPKey primary key(UserID)
)
create unique index UserAccountsKey1 on UserAccounts(Email);