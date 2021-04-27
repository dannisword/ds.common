create table RoleApps
(
 RoleID                      int                         not null,   -- 角色編碼
                                                                -- 100 000 員工基本權限 
                                                                -- 110 000 
                                                                -- 120 000
 AppID					int						    not null,	-- 應用程式編號
 IsActive               bit                         not null,   -- 啟用 
 CanApprove				bit default(0)				not null,	-- 可審核
 CanInsert				bit default(0)				not null,	-- 可新增
 CanDelete				bit default(0)				not null,	-- 可刪除
 CanUpdate				bit default(0)				not null,	-- 可修改
 CanPrint				bit default(0)				not null,	-- 可列印
 CreatedBy				int							not null,	-- 建檔人員 
 CreatedAt				datetime					not null,	-- 建檔時間 
 UpdatedBy				int							not null,	-- 異動人員 
 UpdatedAt				datetime					not null,	-- 異動時間 
 constraint RoleAppsPKey primary key(RoleID, AppID)
)

