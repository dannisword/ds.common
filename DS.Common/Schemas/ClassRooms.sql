create table ClassRooms
(
 ClassId				bigint identity(1,1)        		not null,	-- 最新公告編號
 ClassCode  			nvarchar(18)						not null,	-- 班級
 ClassName				nvarchar(80)     					not null,	-- 
 ClassLevel				nvarchar(4000)     					not null,	-- 公告內文
 IsActive               boolean                     		not null,   -- 啟用				
 CreatedBy				int									not null,	-- 建檔人員 
 CreatedAt				datetime							not null,	-- 建檔時間 
 UpdatedBy				int									not null,	-- 異動人員 
 UpdatedAt				datetime							not null,	-- 異動時間 
 constraint ContactBooksPKey primary key(BoardId)
)