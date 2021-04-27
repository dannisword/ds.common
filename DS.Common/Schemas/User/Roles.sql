create table Roles
(
 RoleID					int identity(1,1)   		not null,	-- 角色編號
 RoleCode               int				            not null,	-- 角色編碼
                                                                -- 100 000 最高權限 
                                                                -- 110 000 
                                                                -- 120 000
 RoleName				nvarchar(32)				not null,	-- 角色名稱
 GroupCode				smallint					not null,	-- 分組代碼
 IsActive               bit                         not null,   -- 
 CreatedBy				int							not null,	-- 建檔人員 
 CreatedAt				datetime					not null,	-- 建檔時間 
 UpdatedBy				int							not null,	-- 異動人員 
 UpdatedAt				datetime					not null,	-- 異動時間 

 constraint RolesPKey primary key(RoleID)
)
create index Roles_IX1 on Roles(RoleCode, GroupCode); 