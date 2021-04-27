create table UserRoles
(
 UserID 				int							    not null, -- 使用者編號 
 RoleID			        int				                not null, -- 角色編號
 StartAt				datetime					    not null, -- 起
 EndAt					datetime default ('2999/12/31') not null, -- 訖
 CreatedBy				int							    not null, -- 建檔人員 
 CreatedAt				datetime					    not null, -- 建檔時間 
 UpdatedBy				int							    not null, -- 異動人員 
 UpdatedAt				datetime					    not null, -- 異動時間 
 constraint UserRolesPKey primary key(UserID, RoleID, EndAt)
)
