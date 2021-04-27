CREATE TABLE AppStores
(
 AppID				int	identity(1,1)				not null, -- 
 AppCode            int                             not null, -- APP 編碼
                                                              -- 100 000 基本設定
 AppName            nvarchar(80)                    not null, -- APP 名稱
 ParentCode         int                             not null, -- 最上層 APP
 AppColor           nvarchar(30)                    not null, -- APP 顏色
 AppIcon            nvarchar(30)                    not null, -- APP 圖示
 AppUrl             nvarchar(255)                   not null, -- APP 網址
 IsActive			bit								not null, -- 資料狀態
 CreatedAt			datetime default(GETDATE())     not null, -- 建立時間
 CreatedBy			int								not null, -- 建立人員
 UpdatedAt			datetime default(GETDATE())     not null, -- 系統異動時間
 UpdatedBy			int 							not null, -- 系統異動人員 
 constraint AppStores_PK primary key(AppID)
)
create index AppStores_IX1 on AppStores(AppCode, IsActive, ParentCode); 